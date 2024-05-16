using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Animation;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuiTestClient
{
    class SetUpMessageInputs
    {
        public static Dictionary<string, TextBox> currentTextBoxes = new Dictionary<string, TextBox>();
        public static Dictionary<string, ComboBox> currentComboBoxes = new Dictionary<string, ComboBox>();

        public static void ClearDictionaries()
        {
            currentTextBoxes.Clear();
            currentComboBoxes.Clear();
        }

        public static Grid SetUpHelloServer()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("HELLO_SERVER");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 1, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "HELLO_SERVER", true);
            
            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpConnectGame()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("CONNECT_GAME");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 4, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "CONNECT_GAME", true);
            AddTextBoxToGrid(inputGrid, 1, "Name (string):", "", false);
            AddComboBoxToGrid(inputGrid, 2, "Rolle (Role):", new List<string> { "PLAYER", "AI", "SPECTATOR"});
            AddTextBoxToGrid(inputGrid, 3, "LobbyID (Guid):", "", false);

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpReconnect()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("RECONNECT");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 4, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "RECONNECT", true);
            AddTextBoxToGrid(inputGrid, 1, "LobbyID (Guid):", "", false);
            AddTextBoxToGrid(inputGrid, 2, "PlayerID (Guid):", "", false);
            AddTextBoxToGrid(inputGrid, 3, "ReconnectToken (Guid):", "", false);


            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpCharacterChosen()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("CHARACTER_CHOSEN");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 2, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "CHARACTER_CHOSEN", true);
            AddComboBoxToGrid(inputGrid, 1, "Character (Character):", new List<string> { "MARIUS", "LUIS", "JONNI", "BROWSER", "PENNI", "DARIA", "WARIUS", "WALUIS", "BU_HU", "TULPLENA", "BIRGIT", "DON_THE_KING" });

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpRecruitRequest()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("RECRUIT_REQUEST");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 5, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "RECRUIT_REQUEST", true);
            AddTextBoxToGrid(inputGrid, 1, "TerritoryID (int):", "", false);
            AddTextBoxToGrid(inputGrid, 2, "Toasts (int):", "", false);
            AddTextBoxToGrid(inputGrid, 3, "Dumbas (int):", "", false);
            AddTextBoxToGrid(inputGrid, 4, "Koobras (int):", "", false);

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpMovementRequest()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("MOVEMENT_REQUEST");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 6, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "MOVEMENT_REQUEST", true);
            AddTextBoxToGrid(inputGrid, 1, "FromID (int):", "", false);
            AddTextBoxToGrid(inputGrid, 2, "ToID (int):", "", false);
            AddTextBoxToGrid(inputGrid, 3, "Toasts (int):", "", false);
            AddTextBoxToGrid(inputGrid, 4, "Dumbas (int):", "", false);
            AddTextBoxToGrid(inputGrid, 5, "Koobras (int):", "", false);

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpFightRequest()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("FIGHT_REQUEST");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 3, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "FIGHT_REQUEST", true);
            AddTextBoxToGrid(inputGrid, 1, "TerritoryID (int):", "", false);
            AddTextBoxToGrid(inputGrid, 2, "DefenderID (Guid):", "", false);

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpEndRequest()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("END_REQUEST");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 2, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "END_REQUEST", true);
            AddComboBoxToGrid(inputGrid, 1, "Phase (Phase):", new List<string> { "RECRUIT", "MOVEMENT", "FIGHT" });
            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpTextMessage()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("TEXT_MESSAGE");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 2, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "TEXT_MESSAGE", true);
            AddTextBoxToGrid(inputGrid, 1, "Message (string):", "", false);

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }

      
        public static Grid SetUpPauseRequest()
        {
            ClearDictionaries();

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("PAUSE_REQUEST");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 2, 2);

            AddTextBoxToGrid(inputGrid, 0, "Nachrichtentyp:", "PAUSE_REQUEST", true);
            AddComboBoxToGrid(inputGrid, 1, "Pause (bool):", new List<string> {"true", "false"});

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);

            return newGrid;
        }


        public static Grid SetUpInvalidMessage()
        {
            ClearDictionaries();

            string invalid = @"{ 
    'messageType': 'MOIN_MEISTER' 
}";

            Grid newGrid = new Grid();
            SetUpGrid(newGrid, 2, 0);

            // Titel
            TextBlock title = SetUpTitle("Invalid Message");
            newGrid.Children.Add(title);
            Grid.SetRow(title, 0);

            // Grid for inputs
            Grid inputGrid = new Grid();
            inputGrid.HorizontalAlignment = HorizontalAlignment.Center;
            SetUpGrid(inputGrid, 1, 2);

            var textBlock = new TextBlock
            {
                Text = "Nachrichteninhalt:",
                FontSize = 15,
                TextWrapping = TextWrapping.Wrap,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.Black,
                Margin = new Thickness(10, 10, 20, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top, 
            };

            // Erstelle TextBox
            var textBox = new TextBox
            {
                Text = invalid,
                IsReadOnly = false,
                AcceptsReturn = true,
                Width = 300,
            };

            inputGrid.Children.Add(textBlock);
            Grid.SetRow(textBlock, 0);
            Grid.SetColumn(textBlock, 0);

            inputGrid.Children.Add(textBox);
            Grid.SetRow(textBox, 0);
            Grid.SetColumn(textBox, 1);

            currentTextBoxes.Add("Nachrichteninhalt:", textBox);

            newGrid.Children.Add(inputGrid);
            Grid.SetRow(inputGrid, 1);


            return newGrid;
        }




        private static void SetUpGrid(Grid grid, int rows, int columns)
        {
            for(int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            for (int i = 0; i < columns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
        }


        private static TextBlock SetUpTitle(string title)
        {
            TextBlock titleTextBlock = new TextBlock();
            titleTextBlock.Text = title;
            titleTextBlock.FontSize = 25;
            titleTextBlock.FontWeight = FontWeights.Bold;
            titleTextBlock.Foreground = Brushes.Black;
            titleTextBlock.Margin = new Thickness(10, 10, 10, 20);
            titleTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            titleTextBlock.VerticalAlignment = VerticalAlignment.Center;

            return titleTextBlock;
        }


        private static void AddTextBoxToGrid(Grid grid, int row, string label, string defaultText, bool readOnly)
        {
            var textBlock = new TextBlock
            {
                Text = label,
                FontSize = 15,
                TextWrapping = TextWrapping.Wrap,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.Black,
                Margin = new Thickness(10, 10, 20, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 200,
                Height = 20
            };

            // Erstelle TextBox
            var textBox = new TextBox
            {
                Text = defaultText,
                Height = 20,
                Width = 200,
                IsReadOnly = readOnly
            };

            grid.Children.Add(textBlock);
            Grid.SetRow(textBlock, row);
            Grid.SetColumn(textBlock, 0);

            grid.Children.Add(textBox);
            Grid.SetRow(textBox, row);
            Grid.SetColumn(textBox, 1);

            currentTextBoxes.Add(label, textBox);
        }


        private static void AddComboBoxToGrid(Grid grid, int row, string label, List<string> options)
        {
            var textBlock = new TextBlock
            {
                Text = label,
                FontSize = 15,
                TextWrapping = TextWrapping.Wrap,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.Black,
                Margin = new Thickness(10, 10, 20, 0),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            ComboBox comboBox = new ComboBox()
            {
                FontSize = 13,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.Black,
                Margin = new Thickness(20, 5, 20, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 200,
                Height = 25
            };
            
            foreach(string option in options)
            {
                comboBox.Items.Add(option);
            }

            grid.Children.Add(textBlock);
            Grid.SetRow(textBlock, row);
            Grid.SetColumn(textBlock, 0);

            grid.Children.Add(comboBox);
            Grid.SetRow(comboBox, row);
            Grid.SetColumn(comboBox, 1);

            currentComboBoxes.Add(label, comboBox);
        }

    }
}
