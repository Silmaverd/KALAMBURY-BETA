using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburyKlient
{
    public partial class GameWindow : Form
    {
        private GameServer gameServer;
        private List<Coordinate> coordinatesToSend;
        private bool mousePressed = false;
        private bool roomAdmin = false;
        private string chosenCOLOR = "BLACK";

        public GameWindow(string userName, string roomName)
        {
            InitializeComponent();
            this.userName.Text = userName;
            this.roomName.Text = roomName;
            this.catchwordGetBtn.Visible = false;
            this.clearBtn.Visible = false;
            this.chosenBLACK.Visible = false;
            this.chosenRED.Visible = false;
            this.chosenBLUE.Visible = false;
            this.chosenGREEN.Visible = false;
            this.chosenYELLOW.Visible = false;
            this.chosenColorVisualizer.Visible = false;
            this.drawingDesk.Image = new Bitmap(this.drawingDesk.Width, this.drawingDesk.Height);
            this.coordinatesToSend = new List<Coordinate>();
        }

        private string GetSendCoordinatesCommand()
        {
            StringBuilder coordinatesCommand = new StringBuilder("COORDINATE:"+this.chosenCOLOR+":");
            int MaxCoords = 100;
            int CoordsToSend = 0;
            for(int i = 0; i < coordinatesToSend.Count; i+=3) {
                Coordinate coordinate = coordinatesToSend.ElementAt(i);
                if (i > 0)
                {
                    coordinatesToSend.ElementAt(i - 1).toRemove = true;
                    coordinatesToSend.ElementAt(i - 2).toRemove = true;
                }
                coordinate.toRemove = true;
                coordinatesCommand.Append(Convert.ToString(coordinate.X) + "," + Convert.ToString(coordinate.Y) + ":");
                CoordsToSend++;
                if (CoordsToSend.Equals(MaxCoords))
                    break;
            }
            for(int i = 0; i < this.coordinatesToSend.Count; i++)
            {
                if (coordinatesToSend.ElementAt(i).toRemove)
                {
                    coordinatesToSend.Remove(coordinatesToSend.ElementAt(i));
                    i--;
                }
            }

            return coordinatesCommand.ToString();
        }

        private void ClearCoordinatesFromTheList()
        {
            this.coordinatesToSend.Clear();
        }

        public void ClearDrawingDesk()
        {
            this.drawingDesk.Refresh();
        }

        private void SendCoordinates()
        {
            string COMMAND = String.Empty;
            while (this.coordinatesToSend.Count > 0)
            {
                COMMAND = this.GetSendCoordinatesCommand();
                this.gameServer.SendMessage(COMMAND);
            }
        }

        public void SetServer(GameServer gameServer)
        {
            this.gameServer = gameServer;
        }

        private void ExitGameRoom()
        {
            this.gameServer.SendMessage("ROOM_EXIT");
            this.Hide();
        }

        public void UpdateGameRoomUsers(string [] gameRoomUsers)
        {
            this.ClearPlayers();
            for(int i = 1; i < gameRoomUsers.Length; i++)
            {
                this.AddPlayerUsername(gameRoomUsers[i]);
            }
        }

        public void UpdateChatRoom(string message)
        {
            if (this.chatRoom.InvokeRequired)
            {
                this.chatRoom.Invoke(new Action<string>(this.UpdateChatRoom), message);
            }
            else
            {
                this.chatRoom.Items.Add(ConvertToDisplayableMessage(message));
                int visibleItems = this.chatRoom.ClientSize.Height / this.chatRoom.ItemHeight;
                this.chatRoom.TopIndex = Math.Max(this.chatRoom.Items.Count - visibleItems + 1, 0);
            }
        }

        public void AddPlayerUsername(string username)
        {
            if (this.playersInTheRoom.InvokeRequired)
            {
                this.playersInTheRoom.Invoke(new Action<string>(AddPlayerUsername), username);
            }
            else this.playersInTheRoom.Items.Add(username);
        }

        public void ClearPlayers()
        {
            if (this.playersInTheRoom.InvokeRequired)
            {
                this.playersInTheRoom.Invoke(new Action(ClearPlayers));
            }
            else this.playersInTheRoom.Items.Clear();
        }

        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ExitGameRoom();
        }

        private void chatSendMessageBtn_Click(object sender, EventArgs e)
        {
            string message = this.chatMessage.Text;
            if (message != String.Empty)
            {
                this.chatMessage.Clear();
                string safeMessage = this.ConvertToSafeMessageFormat(message);
                this.gameServer.SendMessage("CHAT_MESSAGE:" + safeMessage);
            } 
        }

        private string ConvertToSafeMessageFormat(string toConvert)
        {
            string convertedMessage = toConvert.Replace(":", "<colon>");
            convertedMessage = convertedMessage.Replace(";", "<semicolon>");
            return convertedMessage;
        }

        private string ConvertToDisplayableMessage(string toConvert)
        {
            string convertedMessage = toConvert.Replace("<colon>", ":");
            convertedMessage = convertedMessage.Replace("<semicolon>", ";");
            return convertedMessage;
        }

        public void BeRoomAdmin()
        {
            if (this.catchwordGetBtn.InvokeRequired)
                this.catchwordGetBtn.Invoke(new Action(BeRoomAdmin));
            else
            {
                this.ClearDesk();
                this.roomAdmin = true;
                this.chosenBLACK.Visible = true;
                this.chosenRED.Visible = true;
                this.chosenBLUE.Visible = true;
                this.chosenGREEN.Visible = true;
                this.chosenYELLOW.Visible = true;
                this.chosenColorVisualizer.Visible = true;
                this.clearBtn.Visible = true;
                this.catchwordGetBtn.Visible = true;
                this.drawingDesk.Enabled = true;
            }
        }

        public void BeNormalUser()
        {
            if (this.catchwordGetBtn.InvokeRequired)
                this.catchwordGetBtn.Invoke(new Action(BeNormalUser));
            else
            {
                this.ClearDesk();
                this.roomAdmin = false;
                this.chosenBLACK.Visible = false;
                this.chosenRED.Visible = false;
                this.chosenBLUE.Visible = false;
                this.chosenGREEN.Visible = false;
                this.chosenYELLOW.Visible = false;
                this.chosenColorVisualizer.Visible = false;
                this.clearBtn.Visible = false;    
                this.catchwordGetBtn.Visible = false;
                this.drawingDesk.Enabled = false;
            }
        }

        private void chatMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                string message = this.chatMessage.Text;
                if (message != String.Empty)
                {
                    this.chatMessage.Clear();
                    string safeMessage = this.ConvertToSafeMessageFormat(message);
                    this.gameServer.SendMessage("CHAT_MESSAGE:" + safeMessage);
                }
            }
        }

        public void SetCatchWord(string catchWord)
        {
            if (this.catchwordField.InvokeRequired)
            {
                this.catchwordField.Invoke(new Action<string>(this.SetCatchWord), catchWord);
            }
            else this.catchwordField.Text = catchWord;
        }

        public void ClearCatchWord()
        {
            if (this.catchwordField.InvokeRequired)
            {
                this.catchwordField.Invoke(new Action(this.ClearCatchWord));
            }
            else this.catchwordField.Text = "";
        }

        private void catchwordGetBtn_Click(object sender, EventArgs e)
        {
            this.gameServer.SendMessage("GET_CATCHWORD");
            this.catchwordGetBtn.Visible = false;
        }

        private void drawingDesk_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !this.roomAdmin)
                return;
            if (!mousePressed)
                this.mousePressed = true;
        }
        private void drawingDesk_MouseUp(object sender, MouseEventArgs e)
        {
            this.mousePressed = false;
            this.SendCoordinates();
        }

        private void drawingDesk_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mousePressed) {
                Coordinate newCoord = new Coordinate();
                newCoord.X = e.X;
                newCoord.Y = e.Y;
                this.coordinatesToSend.Add(newCoord);
            }
        }

        private void catchwordFoundBtn_Click(object sender, EventArgs e)
        {

        }

        public void ClearDesk()
        {
            if (this.drawingDesk.InvokeRequired)
            {
                this.drawingDesk.Invoke(new Action(this.ClearDesk));
            }else
            {
                using (Graphics myGraphics = Graphics.FromImage(this.drawingDesk.Image))
                {
                    myGraphics.Clear(Color.LightYellow);
                    this.drawingDesk.Refresh();
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.gameServer.SendMessage("DESK_CLEAR");
        }

        public void DrawCoordinates(string [] coordinates, string COLOR)
        {
            for(int i = 1; i < coordinates.Length; i++)
            {
                string newCoords = coordinates[i];
                string oldCoords = coordinates[i - 1];
                this.DrawLine(oldCoords, newCoords, COLOR);
            }
        }

        private void DrawLine(string first, string second,string COLOR)
        {
            if (this.drawingDesk.InvokeRequired)
            {
                this.drawingDesk.Invoke(new Action<string, string,string>(this.DrawLine), first, second,COLOR);
            }
            else
            {
                if (first.Equals(String.Empty) || second.Equals(String.Empty))
                    return;
                using (Graphics myGraphics = Graphics.FromImage(this.drawingDesk.Image))
                {
                    try
                    {
                        string[] FirstCoords =  first.Split(',');
                        string[] SecondCoords = second.Split(',');
                        int First_X =  Convert.ToInt32(FirstCoords[0]);
                        int First_Y =  Convert.ToInt32(FirstCoords[1]);
                        int Second_X = Convert.ToInt32(SecondCoords[0]);
                        int Second_y = Convert.ToInt32(SecondCoords[1]);

                        Pen myPen = this.GetChosenPen(COLOR);
                        myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        myGraphics.DrawLine(myPen, First_X, First_Y,Second_X,Second_y);
                        this.drawingDesk.Refresh();
                    }
                    catch (Exception exception)
                    {
                        //BLAD KOMENDY ;(
                    }
                }
            }
        }

        private Pen GetChosenPen(string COLOR)
        {
            if (COLOR.Equals("BLACK"))
            {
                return new Pen(new SolidBrush(Color.Black), 1);
            }
            if (COLOR.Equals("RED"))
            {
                return new Pen(new SolidBrush(Color.Red), 1);
            }
            if (COLOR.Equals("BLUE"))
            {
                return new Pen(new SolidBrush(Color.Blue), 1);
            }
            if (COLOR.Equals("GREEN"))
            {
                return new Pen(new SolidBrush(Color.Green), 1);
            }
            if (COLOR.Equals("YELLOW"))
            {
                return new Pen(new SolidBrush(Color.Yellow), 1);
            }
            return new Pen(new SolidBrush(Color.Black),1);
        }

        private void RefreshDrawingDesk()
        {
            if (this.drawingDesk.InvokeRequired)
            {
                this.drawingDesk.Invoke(new Action(this.RefreshDrawingDesk));
            }
            else this.drawingDesk.Refresh();
        }

        private void DrawCoordinate(string coordinates)
        {
            if (this.drawingDesk.InvokeRequired)
            {
                this.drawingDesk.Invoke(new Action<string>(this.DrawCoordinate), coordinates);
            }
            else
            {
                using (Graphics myGraphics = Graphics.FromImage(this.drawingDesk.Image))
                {
                    if (coordinates.Equals(String.Empty))
                        return;
                    try
                    {
                        string[] coords = coordinates.Split(',');
                        Pen myPen = new Pen(new SolidBrush(Color.Black));
                        int X = Convert.ToInt32(coords[0]);
                        int Y = Convert.ToInt32(coords[1]);
                        myGraphics.DrawEllipse(myPen, X, Y, 3, 3);
                    }catch(Exception exception)
                    {
                        //BLAD KOMENDY ;(
                    }
                }
            }
        }

        private void chosenBLACK_Click(object sender, EventArgs e)
        {
            this.chosenColorVisualizer.BackColor = Color.Black;
            this.chosenCOLOR = "BLACK";
        }

        private void chosenRED_Click(object sender, EventArgs e)
        {
            this.chosenColorVisualizer.BackColor = Color.Red;
            this.chosenCOLOR = "RED";
        }

        private void chosenBLUE_Click(object sender, EventArgs e)
        {
            this.chosenColorVisualizer.BackColor = Color.Blue;
            this.chosenCOLOR = "BLUE";
        }

        private void chosenGREEN_Click(object sender, EventArgs e)
        {
            this.chosenColorVisualizer.BackColor = Color.Green;
            this.chosenCOLOR = "GREEN";
        }

        private void chosenYELLOW_Click(object sender, EventArgs e)
        {
            this.chosenColorVisualizer.BackColor = Color.Yellow;
            this.chosenCOLOR = "YELLOW";
        }
    }
}
