using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiTestClient
{
    public enum MessageType
    {
        HELLO_SERVER,
        CONNECT_GAME,
        RECONNECT,
        CHARACTER_CHOSEN,
        RECRUIT_REQUEST,
        MOVEMENT_REQUEST,
        FIGHT_REQUEST,
        END_REQUEST,
        TEXT_MESSAGE,
        PAUSE_REQUEST,
        INVALID_MESSAGE
    }
}
