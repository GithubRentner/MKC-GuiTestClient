using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GuiTestClient
{
    class ReadOutInputs
    {
        public static string ReadOutMessage(MessageType type) {

            string message = "";
            
            switch (type)
            {
                case MessageType.HELLO_SERVER:
                    message = ReadOutHelloServer();
                    break;
                case MessageType.CONNECT_GAME:
                    message = ReadOutConnectGame();
                    break;
                case MessageType.RECONNECT:
                    message = ReadOutReconnect();
                    break;
                case MessageType.CHARACTER_CHOSEN:
                    message = ReadOutCharacterChosen();
                    break;
                case MessageType.RECRUIT_REQUEST:
                    message = ReadOutRecruitRequest();
                    break;
                case MessageType.MOVEMENT_REQUEST:
                    message = ReadOutMovementRequest();
                    break;
                case MessageType.FIGHT_REQUEST:
                    message = ReadOutFightRequest();
                    break;
                case MessageType.END_REQUEST:
                    message = ReadOutEndRequest();
                    break;
                case MessageType.TEXT_MESSAGE:
                    message = ReadOutTextMessage();
                    break;
                case MessageType.PAUSE_REQUEST:
                    message = ReadOutPauseRequest();
                    break;
                case MessageType.INVALID_MESSAGE:
                    message = ReadOutInvalidMessage();
                    break;
            }

            return message;
        }

        private static string ReadOutInvalidMessage()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;

            return textBoxes["Nachrichteninhalt:"].Text;
        }


        private static string ReadOutPauseRequest()
        {
            Dictionary<string, ComboBox> comboBoxes = SetUpMessageInputs.currentComboBoxes;

            bool pause;
            try
            {
                pause = bool.Parse(comboBoxes["Pause (bool):"].Text);
            } catch(FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert fürpause an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für pause einen Wert an!");
                return "";
            }

            return Messages.CreatePauseRequest(pause);
        }


        private static string ReadOutTextMessage()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;

            string message = textBoxes["Message (string):"].Text;

            return Messages.CreateTextMessage(message);
        }


        private static string ReadOutEndRequest()
        {
            Dictionary<string, ComboBox> comboBoxes = SetUpMessageInputs.currentComboBoxes;

            Phase phase;
            try
            {
                phase = (Phase)Enum.Parse(typeof(Phase), comboBoxes["Phase (Phase):"].Text);
            }
            catch (ArgumentException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Phase an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Phase einen Wert an!");
                return "";
            }

            return Messages.CreateEndRequest(phase);
        }


        private static string ReadOutFightRequest()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;

            int territoryId;
            try
            {
                territoryId = int.Parse(textBoxes["TerritoryID (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für TerritoryID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für TerritoryID einen Wert an!");
                return "";
            }

            Guid defenderId;
            try
            {
                defenderId = Guid.Parse(textBoxes["DefenderID (Guid):"].Text);
            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe eine validen Guid für DefenderID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für DefenderID einen Wert an!");
                return "";
            }

            return Messages.CreateFightRequest(territoryId, defenderId);
        }


        private static string ReadOutMovementRequest()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;

            int fromId;
            try
            {
                fromId = int.Parse(textBoxes["FromID (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für FromID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für FromID einen Wert an!");
                return "";
            }

            int toId;
            try
            {
                toId = int.Parse(textBoxes["ToID (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für ToID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für ToID einen Wert an!");
                return "";
            }

            int toasts;
            try
            {
                toasts = int.Parse(textBoxes["Toasts (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Toasts an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Toasts einen Wert an!");
                return "";
            }

            int dumbas;
            try
            {
                dumbas = int.Parse(textBoxes["Dumbas (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Dumbas an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Dumbas einen Wert an!");
                return "";
            }

            int koobras;
            try
            {
                koobras = int.Parse(textBoxes["Koobras (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Koobras an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Koobras einen Wert an!");
                return "";
            }

            return Messages.CreateMovementRequest(fromId, toId, toasts, dumbas, koobras);
        }


        private static string ReadOutRecruitRequest()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;

            int territoryID;
            try
            {
                territoryID = int.Parse(textBoxes["TerritoryID (int):"].Text);
                
            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für TerritoryID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für TerritoryID einen Wert an!");
                return "";
            }

            int toasts;
            try
            {
                toasts = int.Parse(textBoxes["Toasts (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Toasts an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Toasts einen Wert an!");
                return "";
            }

            int dumbas;
            try
            {
                dumbas = int.Parse(textBoxes["Dumbas (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Dumbas an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Dumbas einen Wert an!");
                return "";
            }

            int koobras;
            try
            {
                koobras = int.Parse(textBoxes["Koobras (int):"].Text);

            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Koobras an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Koobras einen Wert an!");
                return "";
            }

            return Messages.CreateRecruitRequest(territoryID, toasts, dumbas, koobras);
        }


        private static string ReadOutCharacterChosen()
        {
            Dictionary<string, ComboBox> comboBoxes = SetUpMessageInputs.currentComboBoxes;

            Character character;
            try
            {
                character = (Character)Enum.Parse(typeof(Character), comboBoxes["Character (Character):"].Text);
            }
            catch (ArgumentException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Character an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Character einen Wert an!");
                return "";
            }

            return Messages.CreateCharacterChosen(character);
        }


        private static string ReadOutReconnect()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;

            Guid lobbyId;
            try
            {
                lobbyId = Guid.Parse(textBoxes["LobbyID (Guid):"].Text);
            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe eine validen Guid für LobbyID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für LobbyID einen Wert an!");
                return "";
            }

            Guid playerId;
            try
            {
                playerId = Guid.Parse(textBoxes["PlayerID (Guid):"].Text);
            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe eine validen Guid für PlayerID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für PlayerID einen Wert an!");
                return "";
            }

            Guid reconnectToken;
            try
            {
                reconnectToken = Guid.Parse(textBoxes["ReconnectToken (Guid):"].Text);
            }
            catch (FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe eine validen Guid für ReconnectToken an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für ReconnectToken einen Wert an!");
                return "";
            }

            return Messages.CreateReconnect(lobbyId, playerId, reconnectToken);


        }


        private static string ReadOutConnectGame()
        {
            Dictionary<string, TextBox> textBoxes = SetUpMessageInputs.currentTextBoxes;
            Dictionary<string, ComboBox> comboBoxes = SetUpMessageInputs.currentComboBoxes;

            string name = textBoxes["Name (string):"].Text;

            Role role;
            try
            {
                role = (Role)Enum.Parse(typeof(Role), comboBoxes["Rolle (Role):"].Text);
            } catch(ArgumentException e)
            {
                MainWindow.instance.ShowError("Bitte gebe einen validen Wert für Rolle an!");
                return "";
            } catch(Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für Rolle einen Wert an!");
                return "";
            }

            Guid lobbyId;
            try
            {
                lobbyId = Guid.Parse(textBoxes["LobbyID (Guid):"].Text);
            } catch(FormatException e)
            {
                MainWindow.instance.ShowError("Bitte gebe eine validen Guid für LobbyID an!");
                return "";
            }
            catch (Exception e)
            {
                MainWindow.instance.ShowError("Bitte gebe für LobbyID einen Wert an!");
                return "";
            }

            return Messages.CreateConnectGame(name, role, lobbyId);
        }


        private static string ReadOutHelloServer()
        {
            // Nothing to read out 
            return Messages.CreateHelloServer();
        }
    }
}
