using GuiTestClient.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GuiTestClient.SetUpMessageInputs;
using Icon = MahApps.Metro.IconPacks.PackIconMaterial;

namespace GuiTestClient
{

    public enum Sender
    {
        SERVER,
        CLIENT
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly SolidColorBrush ClientColor = new SolidColorBrush(Color.FromRgb(78, 149, 217));
        private static readonly SolidColorBrush ServerColor = new SolidColorBrush(Color.FromRgb(166, 202, 236));
        
        public static MainWindow instance;
        private MessageType currentType = MessageType.HELLO_SERVER;


        public MainWindow()
        {
            InitializeComponent();
            instance = this;

            InitialDialog();

            Handle_MessageTypeClick(MessageType.HELLO_SERVER);

            TestClient.IncomingMessageEvent += HandleIncomingMessage;
            TestClient.ConnectionStatusChanged += HandleConnectionStatus;

            TestClient.EstablishConnection();
        }


        private void InitialDialog()
        {
            var dialog = new HostPortDialog();
            if (dialog.ShowDialog() != true)
            {
                // Beende die Anwendung, wenn der Dialog abgebrochen wurde
                Application.Current.Shutdown();
            }
            return;
        }


        private void AddMessage(string messageType, Sender sender, int index)
        {
            if(sender == Sender.SERVER)
            {
                Border message = CreateMessage(messageType, HorizontalAlignment.Left, ServerColor, index);
                message.MouseLeftButtonDown += MessageClicked;
                MessageStackPanel.Children.Add(message);
            }
            else
            {
                Border message = CreateMessage(messageType, HorizontalAlignment.Right, ClientColor, index);
                message.MouseLeftButtonDown += MessageClicked;
                MessageStackPanel.Children.Add(message);
            }

            // Scroll to bottom if current position is bottom
            if (MessageScrollViewer.VerticalOffset == MessageScrollViewer.ScrollableHeight)
            {
                MessageScrollViewer.ScrollToBottom();
            }
        }

        private Border CreateMessage(string messageType, HorizontalAlignment align, SolidColorBrush color, int index)
        {

            Border border = new Border
            {
                Width = 300,
                Margin = new Thickness(10, 10, 10, 10),
                HorizontalAlignment = align,
                CornerRadius = new CornerRadius(10),
                Background = color,
                Padding = new Thickness(5),
                Tag = index // Index der Nachricht
            };

            var textBlock = new TextBlock
            {
                Text = messageType,
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            border.Child = textBlock;

            return border;
        }

        private void MessageClicked(object sender, MouseButtonEventArgs e)
        {
            // Nachricht wurde geklickt
            Border clickedBorder = (Border)sender;
            int messageIndex = (int)clickedBorder.Tag-1;

            string message = TestClient.GetMessageFromList(messageIndex);

            JsonViewer newWindow = new JsonViewer(message);
   
            newWindow.Show();
            newWindow.Activate();
        }


        private void CopyToClipboard(object sender, MouseButtonEventArgs e)
        {
            StackPanel stackPanel = ((StackPanel)((Border)sender).Child);
            string textToCopy = (string)((TextBlock)stackPanel.Children[1]).Text;

            Thread clipboardThread = new Thread(() =>
            {
                try
                {
                    // Aktionen, um Text zur Zwischenablage hinzuzufügen
                    Clipboard.SetText(textToCopy);
                    MessageBox.Show($"Text in die Zwischenablage kopiert.");
                }
                catch (Exception ex)
                {
                    // Fehlerbehandlung, falls das Kopieren fehlschlägt
                    MessageBox.Show($"Fehler beim Kopieren in die Zwischenablage");
                }
            });

            // Starte den Thread
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.Start();

        }



        // -------------------------------------------------------------------------------------------

        public void Handle_MessageTypeClick(MessageType type)
        {
            Grid grid = new Grid();
            currentType = type;

            switch (type)
            {
                case MessageType.HELLO_SERVER:
                    grid = SetUpHelloServer();
                    ActivateChild("Hello Server");
                    break;
                case MessageType.CONNECT_GAME:
                    grid = SetUpConnectGame();
                    ActivateChild("Connect Game");
                    break;
                case MessageType.RECONNECT:
                    grid = SetUpReconnect();
                    ActivateChild("Reconnect");
                    break;
                case MessageType.CHARACTER_CHOSEN:
                    grid = SetUpCharacterChosen();
                    ActivateChild("Character Chosen");
                    break;
                case MessageType.RECRUIT_REQUEST:
                    grid = SetUpRecruitRequest();
                    ActivateChild("Recruit Request");
                    break;
                case MessageType.MOVEMENT_REQUEST:
                    grid = SetUpMovementRequest();
                    ActivateChild("Movement Request");
                    break;
                case MessageType.FIGHT_REQUEST:
                    grid = SetUpFightRequest();
                    ActivateChild("Fight Request");
                    break;
                case MessageType.END_REQUEST:
                    grid = SetUpEndRequest();
                    ActivateChild("End Request");
                    break;
                case MessageType.TEXT_MESSAGE:
                    grid = SetUpTextMessage();
                    ActivateChild("Text Message");
                    break;
                case MessageType.PAUSE_REQUEST:
                    grid = SetUpPauseRequest();
                    ActivateChild("Pause Request");
                    break;
                case MessageType.INVALID_MESSAGE:
                    grid = SetUpInvalidMessage();
                    ActivateChild("Invalid Message");
                    break;
            }

            MessageInput_Border.Child = grid;
        }


        public void ActivateChild(string title)
        {
            StackPanel messageMenu = MessageMenu;

            foreach (var item in MessageMenu.Children)
            {
                if (item is MenuButton menuButton)
                {
                    if (menuButton.Title == title)
                    {
                        menuButton.IsActive = true;
                    }
                    else
                    {
                        menuButton.IsActive = false;
                    }
                }
            }

        }

        public void Send_Clicked(object sender, RoutedEventArgs e)
        {            
            string message = ReadOutInputs.ReadOutMessage(currentType);

            if(currentType == MessageType.CONNECT_GAME) {
                dynamic obj = JsonConvert.DeserializeObject(message);
                lobbyID.Text = obj.lobbyID.ToString();
            }

            if(message != "")
            {
                TestClient.SendMessage(message);

                int messageCount = TestClient.GetMessageCount();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    AddMessage(currentType.ToString(), Sender.CLIENT, messageCount);
                });    
            }
            
        }


        public void HandleIncomingMessage(object sender, string message)
        {
            dynamic obj = JsonConvert.DeserializeObject(message);
            string type = obj.messageType.ToString();

            if(type == "CONNECTED")
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    playerID.Text = obj.playerID.ToString();
                    reconnectToken.Text = obj.reconnectToken.ToString();
                });
            }

            int messageCount = TestClient.GetMessageCount();
            Application.Current.Dispatcher.Invoke(() =>
            {
                AddMessage(type, Sender.SERVER, messageCount);
            });
        }

        public void HandleConnectionStatus(object sender, bool newStatus)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if(newStatus)
                {
                    status.Text = "verbunden";
                    status.Foreground = Brushes.LightGreen;
                }
                else
                {
                    status.Text = "getrennt";
                    status.Foreground = Brushes.Red;
                }
                
            });
        }


        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }
        



        // -------------------------------------------------------------------------------------------


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1250;
                    this.Height = 830;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                  
                    IsMaximized = true;
                }
            }
        }


        // -------------------------------------------------------------------------------------------


        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Connect_Click(object sender, MouseButtonEventArgs e)
        {
            if (!TestClient.IsConnected)
            {
                TestClient.EstablishConnection();
            }
            else
            {
                MessageBox.Show("Du bist bereits verbunden!");
            }
        }

        private void Disconnect_Click(object sender, MouseButtonEventArgs e)
        {
            if (TestClient.IsConnected)
            {
                TestClient.CloseConnection();
            }
            else
            {
                MessageBox.Show("Du bist bereits disconnectet!");
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = Brushes.White;
                if (border.Child is Icon icon)
                {
                    icon.Foreground = Brushes.Black;
                }
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#215F9A"));
                if (border.Child is Icon icon)
                {
                    icon.Foreground = Brushes.White;
                }
            }
        }


        private void Send_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6b52ea"));
                if (border.Child is TextBlock block)
                {
                    block.Foreground = Brushes.White;
                }
            }
        }

        private void Send_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#215F9A"));
                if (border.Child is TextBlock block)
                {
                    block.Foreground = Brushes.White;
                }
            }
        }

    }
}