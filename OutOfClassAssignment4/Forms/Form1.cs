using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutOfClassAssignment4
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        int PlayerWin = 0;
        int ComputerWin = 0;
        int TieCount = 0;
        int counter = 0;

        int TicTacToeSize = 0;
        int BoxSize = 0;

        public Form1()
        {
            InitializeComponent();
            CreateGame();
            this.Size = new Size(800,420);
            this.Size = new Size(this.Width,(this.Width/2)+20);
        }

        Panel TicTacToeShow;
        public void CreateGame()    //Creates the board
        {
            Button[,] Set = new Button[3,3];        //Multi-dimension array
            TicTacToeSize = (this.Width / 2) - 50;
            BoxSize = TicTacToeSize / 3;
            TicTacToeShow = new Panel();
            TicTacToeShow.Size = new Size(TicTacToeSize,TicTacToeSize);
            TicTacToeShow.BackColor = Color.FromArgb(20,20,20);
            TicTacToeShow.Location = new Point(10,10);
            TicTacToeShow.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(TicTacToeShow);

            Console.WriteLine(TicTacToeSize);
            for (int i = 0; i < Set.GetLength(0); i++)
            {
                for (int x = 0; x < Set.GetLength(1); x++)
                {
                    Set[i, x] = new Button();
                    Set[i, x].Size = new Size(BoxSize, BoxSize);
                    Set[i, x].Location = new Point(i * BoxSize, x * BoxSize);
                    Set[i, x].Text = "";
                    Set[i, x].Name = i + "," + x;
                    Set[i, x].ForeColor = Color.FromArgb(190,190,190);
                    Set[i,x].Font = new Font("Arial", (BoxSize/5), FontStyle.Regular);
                    Set[i, x].Click += UserPress;

                    TicTacToeShow.Controls.Add(Set[i,x]);                    
                }
            }
        }

        public void GameGame(String Checking)
        {
            Console.WriteLine(Checking);
            String[] Status = Regex.Split(Checking,",");
            if (Status[0] == "tie")
            {
                Console.WriteLine("Game Tie");
                counter = 0;
                TieCount++;
                for (int i = 0; i < TicTacToeShow.Controls.Count; i++)
                {
                    TicTacToeShow.Controls[i].Text = "";
                }
            }else if (Status[0] == "win")
            {
                Console.WriteLine("Games won!");
                counter = 0;
                Console.WriteLine(Status[1]);
                if (Status[1] == "X")
                {
                    PlayerWin++;
                }
                else
                {
                    ComputerWin++;
                }
                for (int i = 0; i < TicTacToeShow.Controls.Count; i++)
                {
                    TicTacToeShow.Controls[i].Text = "";
                }
            }
            this.PlayerCounter.Location = new Point((this.TicTacToeShow.Location.X+this.TicTacToeShow.Width)+10,this.Height/2);
            this.ComputerCounter.Location = new Point(this.PlayerCounter.Location.X,(this.PlayerCounter.Location.Y+this.PlayerCounter.Height)+10);
            this.TieCounter.Location = new Point(this.ComputerCounter.Location.X, (this.ComputerCounter.Location.Y + this.ComputerCounter.Height) + 10);

            this.PlayerCounter.Text = "Player Wins: "+PlayerWin;
            this.ComputerCounter.Text = "Computer Wins: "+ComputerWin;
            this.TieCounter.Text = "Ties: " + TieCount;
        }

        public void ComputerTurn()
        {
            while (true)
            {               
                String getPossible = "";
                for (int i = 0; i < TicTacToeShow.Controls.Count; i++)
                {
                    if (TicTacToeShow.Controls[i].Text == "")
                    {
                        getPossible += i + "//";
                    }
                }
                String[] Possible = Regex.Split(getPossible, "//");
                String mm = Possible[random.Next(0, Possible.Length)];
                try
                {
                    int move = Convert.ToInt32(mm);
                    TicTacToeShow.Controls[move].Text = "O";
                    GameGame(WinnerCheck());
                    break;
                }
                catch
                {

                }
            }
        }


        /*
         * Button Layout
         *  _____ _____ _____
         * |     |     |     |
         * |  0  |  3  |  6  |
         * |_____|_____|_____|
         * |     |     |     |
         * |  1  |  4  |  7  |
         * |_____|_____|_____|
         * |     |     |     |
         * |  2  |  5  |  8  |
         * |_____|_____|_____|
         */
        public String WinnerCheck()
        {
            var Check = TicTacToeShow.Controls; //Shortcuts
            string toreturn = "no";
            if (counter + 1 >= 9)
            {
                toreturn = "tie";
            }
            else
            {
                //Check first to second, this implies first and second are the same, then if second is same as third, first equals third
                //Check Vertical
                counter++;
                if ((Check[0].Text == Check[1].Text) && (Check[1].Text == Check[2].Text) && (Check[0].Text!=""))       //First column
                {
                    //Console.WriteLine("First Column");
                    toreturn = "win," + Check[0].Text;
                }
                else if ((Check[3].Text == Check[4].Text) && (Check[4].Text == Check[5].Text) && (Check[3].Text != ""))  //Second Column
                {
                    //Console.WriteLine("Second Column");
                    toreturn = "win," + Check[3].Text;
                }
                else if ((Check[6].Text == Check[7].Text) && (Check[6].Text == Check[8].Text) && (Check[6].Text != ""))  //Third Column
                {
                    //Console.WriteLine("Third Column");
                    toreturn = "win," + Check[6].Text;
                }

                //Check Horizontal
                else if ((Check[0].Text == Check[3].Text) && (Check[3].Text == Check[6].Text) && (Check[0].Text != ""))
                {
                    //Console.WriteLine("First Row");
                    toreturn = "win," + Check[0].Text;
                }
                else if ((Check[1].Text == Check[4].Text) && (Check[4].Text == Check[7].Text) && (Check[4].Text != ""))
                {
                    //Console.WriteLine("Second Row");
                    toreturn = "win," + Check[1].Text;
                }
                else if ((Check[2].Text == Check[5].Text) && (Check[5].Text == Check[8].Text) && (Check[2].Text != ""))
                {
                    //Console.WriteLine("Third Row");
                    toreturn = "win," + Check[2].Text;
                }

                //Check Diagonal
                else if ((Check[0].Text == Check[4].Text) && (Check[4].Text == Check[8].Text) && (Check[0].Text != ""))
                {
                    //Console.WriteLine("TopLeft BottomRight");
                    toreturn = "win," + Check[0].Text;
                }
                else if ((Check[2].Text == Check[4].Text) && (Check[4].Text == Check[6].Text) && (Check[2].Text != ""))
                {
                    //Console.WriteLine("BottomLeft TopRight");
                    toreturn = "win," + Check[2].Text;
                }

                //If none is right, no one wins
            }
            return toreturn;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(this.Width, (this.Width / 2) + 20);
            TicTacToeSize = (this.Width / 2) - 50;
            BoxSize = TicTacToeSize / 3;
            this.TicTacToeShow.Size = new Size(TicTacToeSize, TicTacToeSize);
            this.PlayerCounter.Location = new Point((this.TicTacToeShow.Location.X + this.TicTacToeShow.Width) + 10, this.Height / 2);
            this.ComputerCounter.Location = new Point(this.PlayerCounter.Location.X, (this.PlayerCounter.Location.Y + this.PlayerCounter.Height) + 10);
            this.TieCounter.Location = new Point(this.ComputerCounter.Location.X, (this.ComputerCounter.Location.Y + this.ComputerCounter.Height) + 10);

            var Set = this.TicTacToeShow.Controls;
            Console.WriteLine(Set.Count);
            for (int i = 0; i < Set.Count; i++)
            {
                String[] xy = Regex.Split(Set[i].Name,",");
                Set[i].Size = new Size(BoxSize, BoxSize);
                Set[i].Location = new Point(Convert.ToInt32(xy[0]) * BoxSize, Convert.ToInt32(xy[1]) * BoxSize);
                Set[i].ForeColor = Color.FromArgb(190, 190, 190);
                Set[i].Font = new Font("Arial", (BoxSize / 5), FontStyle.Regular);
            }
        }

        private void UserPress(object sender, EventArgs e)
        {
            Button suspect = (Button)sender;
            if (suspect.Text=="")
            {
                suspect.Text = "X";
                GameGame(WinnerCheck());
                ComputerTurn();
            }
        }
    }
}
