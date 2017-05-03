using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalamburySerwer
{
    class GameRoom
    {
        public string NAME { set; get; }
        public int ID { set; get; }
        public int PLAYER_COUNT { set; get; }
        public string STATUS { set; get; }
        public int ADMIN_ID { set; get; }
        public string CATCHWORD { set; get; }

        public GameRoom()
        {
            this.STATUS = "OCZEKUJE";
            this.CATCHWORD = String.Empty;
        }
    }
}
