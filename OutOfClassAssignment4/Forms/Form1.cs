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
        /*
         * 
         * Hey! this is my tic tac toe take.
         * It probably could have been better but oh well
         * 
         * Methods in here
         *      Make the game
         *      Check game status
         *      check if anyone won and spits out a gamestatus
         *      computer's turn
         *      player's click listener           
         * 
         */
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
            this.Size = new Size(800,420);                      //force the window to be this size
            this.Size = new Size(this.Width,(this.Width/2)+20); //adjust it
        }

        Panel TicTacToeShow;            //panel that holds all the buttons
        public void CreateGame()    //Creates the board
        {
            Button[,] Set = new Button[3,3];        //Multi-dimension array for the buttons
            TicTacToeSize = (this.Width / 2) - 50;          //measure the size 
            BoxSize = TicTacToeSize / 3;                    //make box sizes
            TicTacToeShow = new Panel();                    //establish the panel, this is where the program will look for buttons
            TicTacToeShow.Size = new Size(TicTacToeSize,TicTacToeSize);     //size of the panel based on the measurements
            TicTacToeShow.BackColor = Color.FromArgb(20,20,20);             
            TicTacToeShow.Location = new Point(10,10);                      //place a new location
            TicTacToeShow.BorderStyle = BorderStyle.FixedSingle;            //add a border
            this.Controls.Add(TicTacToeShow);                               //add the panel to the main form

            Console.WriteLine(TicTacToeSize);
            for (int x = 0; x < Set.GetLength(0); x++)                      //creating the buttons, first loop (x coordinate)
            {
                for (int y = 0; y < Set.GetLength(1); y++)                      //second loop (y coordinate in axis form)
                {
                    Set[x, y] = new Button();                       
                    Set[x, y].Size = new Size(BoxSize, BoxSize);
                    Set[x, y].Location = new Point(x * BoxSize, y * BoxSize);       //position it based on the x+y coordinates
                    Set[x, y].Text = "";                                            //blank text because the program looks for blanks
                    Set[x, y].Name = x + "," + y;                                   //create a name, might need it might not
                    Set[x, y].ForeColor = Color.FromArgb(190,190,190);              
                    Set[x,y].Font = new Font("Arial", (BoxSize/5), FontStyle.Regular);
                    Set[x, y].Click += UserPress;                                   //click listener

                    TicTacToeShow.Controls.Add(Set[x,y]);                           //add it to the panel we made earlier
                }
            }
        }

        public void GameGame(String Checking)       //checks game conditions
        {
            Console.WriteLine(Checking);
            String[] Status = Regex.Split(Checking,",");        //split the string, check the first element and second element
            if (Status[0] == "tie")                     //if game finishes
            {
                Console.WriteLine("Game Tie");              //clear the game
                counter = 0;
                TieCount++;
                for (int i = 0; i < TicTacToeShow.Controls.Count; i++)          //loop through the established panel earlier and clears all the text
                {
                    TicTacToeShow.Controls[i].Text = "";
                }
            }else if (Status[0] == "win")                       //checks game condition
            {
                Console.WriteLine("Games won!");
                counter = 0;
                Console.WriteLine(Status[1]);           //the string is checking the second element
                if (Status[1] == "X")           //player is X
                {
                    PlayerWin++;
                }
                else
                {
                    ComputerWin++;              //only other option is y, so computer wins otherwise
                }
                for (int i = 0; i < TicTacToeShow.Controls.Count; i++)      //loop everything again and clear the text
                {
                    TicTacToeShow.Controls[i].Text = "";
                }
            }

            //check if we need to resize, just ignore this. It was a side thing I wanted to practice on
            this.PlayerCounter.Location = new Point((this.TicTacToeShow.Location.X+this.TicTacToeShow.Width)+10,this.Height/2);
            this.ComputerCounter.Location = new Point(this.PlayerCounter.Location.X,(this.PlayerCounter.Location.Y+this.PlayerCounter.Height)+10);
            this.TieCounter.Location = new Point(this.ComputerCounter.Location.X, (this.ComputerCounter.Location.Y + this.ComputerCounter.Height) + 10);

            this.PlayerCounter.Text = "Player Wins: "+PlayerWin;
            this.ComputerCounter.Text = "Computer Wins: "+ComputerWin;
            this.TieCounter.Text = "Ties: " + TieCount;
        }

        public void ComputerTurn()          //establish computer's turn
        {
            while (true)            //loop over and over again until it breaks
            {               
                String getPossible = "";        //in hind sight, I probably could have gotten away with just using a list<string> but oh well. list<string> could potentially make this so much easier
                for (int i = 0; i < TicTacToeShow.Controls.Count; i++)      //grab the possible slots we can use
                {
                    if (TicTacToeShow.Controls[i].Text == "")       
                    {
                        getPossible += i + "//";
                    }
                }
                String[] Possible = Regex.Split(getPossible, "//");         //could have just been a list<string>
                String mm = Possible[random.Next(0, Possible.Length)];      //random through the possibilitites
                try
                {
                    int move = Convert.ToInt32(mm);         //if it success then cool
                    TicTacToeShow.Controls[move].Text = "O";
                    GameGame(WinnerCheck());        //check if computer wins
                    break;                          //break out of the loop
                }
                catch
                {
                    //if it is not then loop again. 
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
        public String WinnerCheck()     //checks if anyone wins
        {
            var Check = TicTacToeShow.Controls; //Shortcuts
            string toreturn = "no";
            if (counter + 1 >= 9)       //run out of spaces then it's a tie
            {
                toreturn = "tie";
            }
            else
            {
                //yeah I don't know how to make this "smarter" just brute forced it
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
