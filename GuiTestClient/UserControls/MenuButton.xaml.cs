using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GuiTestClient;

namespace GuiTestClient.UserControls
{
    /// <summary>
    /// Interaktionslogik für MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public static List<MenuButton> AllMenuButtons = new List<MenuButton>();
        public MenuButton()
        {
            InitializeComponent();
            btn.Click += Button_Click;
            AllMenuButtons.Add(this);
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }

        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MenuButton));


        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(MenuButton));


        public MahApps.Metro.IconPacks.PackIconMaterialKind Icon
        {
            get { return (MahApps.Metro.IconPacks.PackIconMaterialKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(MahApps.Metro.IconPacks.PackIconMaterialKind), typeof(MenuButton));

        // Event-Handler for mouse click

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Title)
            {
                case "Hello Server":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.HELLO_SERVER);
                    break;
                case "Connect Game":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.CONNECT_GAME);
                    break;
                case "Reconnect":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.RECONNECT);
                    break;
                case "Character Chosen":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.CHARACTER_CHOSEN);
                    break;
                case "Recruit Request":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.RECRUIT_REQUEST);
                    break;
                case "Movement Request":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.MOVEMENT_REQUEST);
                    break;
                case "Fight Request":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.FIGHT_REQUEST);
                    break;
                case "End Request":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.END_REQUEST);
                    break;
                case "Text Message":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.TEXT_MESSAGE);
                    break;
                case "Pause Request":
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.PAUSE_REQUEST);
                    break;
                default:
                    MainWindow.instance.Handle_MessageTypeClick(MessageType.INVALID_MESSAGE);
                    break;
            }
        }
    }
}
