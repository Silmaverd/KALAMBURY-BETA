using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace KalamburySerwer
{
    class GameRoom
    {
        /* GameRoom specific values  */
        public string NAME { set; get; }
        public int ID { set; get; }
        public int PLAYER_COUNT { set; get; }
        public string STATUS { set; get; }
        public int ADMIN_ID { set; get; }
        public string CATCHWORD { set; get; }

        /* Instances */
        private List<GameClient> _clients;              // Lista klientów nalerzących do tego pokoju
        private ClientManager _manager;                 // Instancja Client Managera

        /* Timer */
        private Thread _catchphraseTimerThread;         // WĄTEK wysyłający update timera pokoju
        public int timeForAnswer;                       // Ilość czasu na odpowiedź 
        private int counter;                            // Licznik czasu
        System.Timers.Timer gameTimer;                  // Timer

        public GameRoom(ClientManager manager)
        {
            this.STATUS = "OCZEKUJE";
            this.CATCHWORD = String.Empty;
            _clients = new List<GameClient>();
            _manager = manager;

            /* Ustawienia Taimera */
            gameTimer = new System.Timers.Timer();
            gameTimer.Elapsed += new ElapsedEventHandler(timerTheradOneTick);
            gameTimer.Interval = 1000;
        }

        public void resetTimer()
        {
            gameTimer.Stop();
            this._catchphraseTimerThread.Abort();
            this.counter = this.timeForAnswer;                
            foreach (GameClient client in _clients)
            {
                client.SendMessage("TIMER_UPDATE:" + counter + ";");
            }
        }

        public void startTimer()
        {
            this.counter = this.timeForAnswer;
            this._catchphraseTimerThread = new Thread(timerThread);
            this._catchphraseTimerThread.Start();
        }

        public void timerThread()
        {
            this.gameTimer.Start();
        }

        private void timerTheradOneTick(object source, ElapsedEventArgs e)
        {

            if (this.PLAYER_COUNT.Equals(0)) _catchphraseTimerThread.Abort();
            foreach (GameClient client in _clients)
            {
                client.SendMessage("TIMER_UPDATE:" + counter + ";");
            }
            this.counter--;
            if (this.counter.Equals(0))
            {
                resetTimer();
                this._manager.PassphraseNotFound(ADMIN_ID);
            }
        }

        public void addClient(GameClient client)
        {
            this._clients.Add(client);
        }

        public void removeClient(GameClient client)
        {
            this._clients.Remove(client);
        }
    }
}
