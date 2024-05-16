using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiTestClient
{
    class Messages
    {

        public static string CreateHelloServer()
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "HELLO_SERVER";

            // Convert JObject to string
            return jsonObject.ToString();
        }

        public static string CreateConnectGame(string name, Role role, Guid lobbyId)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "CONNECT_GAME";
            jsonObject["name"] = name;
            jsonObject["role"] = role.ToString();
            jsonObject["lobbyID"] = lobbyId.ToString();

            // Convert JObject to string
            return jsonObject.ToString();
        }


        public static string CreateReconnect(Guid lobbyId, Guid playerId, Guid reconnectToken)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "RECONNECT";
            jsonObject["lobbyID"] = lobbyId.ToString();
            jsonObject["playerID"] = playerId.ToString();
            jsonObject["reconnectToken"] = reconnectToken.ToString();

            // Convert JObject to string
            return jsonObject.ToString();
        }

        public static string CreateCharacterChosen(Character character)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "CHARACTER_CHOSEN";
            jsonObject["character"] = character.ToString();

            // Convert JObject to string
            return jsonObject.ToString();
        }



        public static string CreateRecruitRequest(int territoryId, int toasts, int dumbas, int koobras)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "RECRUIT_REQUEST";
            jsonObject["territoryID"] = territoryId;
            jsonObject["units"] = JObject.FromObject(new Dictionary<UnitType, int>
        {
            { UnitType.TOASTS, toasts },
            { UnitType.DUMBAS, dumbas },
            { UnitType.KOOBRAS, koobras }
        });

            // Convert JObject to string
            return jsonObject.ToString();
        }


        public static string CreateMovementRequest(int fromId, int toId, int toasts, int dumbas, int koobras)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "MOVEMENT_REQUEST";
            jsonObject["fromID"] = fromId;
            jsonObject["toID"] = toId;
            jsonObject["units"] = JObject.FromObject(new Dictionary<UnitType, int>
        {
            { UnitType.TOASTS, toasts },
            { UnitType.DUMBAS, dumbas },
            { UnitType.KOOBRAS, koobras }
        });

            // Convert JObject to string
            return jsonObject.ToString();
        }


        public static string CreateFightRequest(int territoryId, Guid defenderId)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "FIGHT_REQUEST";
            jsonObject["territoryID"] = territoryId;
            jsonObject["defenderID"] = defenderId;

            // Convert JObject to string
            return jsonObject.ToString();
        }


        public static string CreateEndRequest(Phase phase)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "END_REQUEST";
            jsonObject["phase"] = phase.ToString();

            // Convert JObject to string
            return jsonObject.ToString();
        }



        public static string CreateTextMessage(string text)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "TEXT_MESSAGE";
            jsonObject["message"] = text;

            // Convert JObject to string
            return jsonObject.ToString();
        }



        public static string CreatePauseRequest(bool pause)
        {
            // Create new JsonObject
            JObject jsonObject = new JObject();

            // Add Values
            jsonObject["messageType"] = "PAUSE_REQUEST";
            jsonObject["pause"] = pause;

            // Convert JObject to string
            return jsonObject.ToString();
        }
    }
}
