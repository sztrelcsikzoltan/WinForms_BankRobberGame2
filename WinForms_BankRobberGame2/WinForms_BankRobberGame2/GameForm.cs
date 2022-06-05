using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_BankRobberGame2
{
    public partial class GameForm : Form
    {
        // new Player class instance
        Player playerClass = new Player(8, 0);
        // new GardVer class instance
        GuardVer guardVerClass = new GuardVer(5, 5);
        // new GardHor class instances
        GuardHor guardHor1Class = new GuardHor(5);
        GuardHor guardHor2Class = new GuardHor(5);

        List<Coin> CoinList = new List<Coin>();
        List<Coin> CoinList1 = new List<Coin>();
        // List<GuardHor> GuardHorList = new List<GuardHor>();
        bool goup, godown, goleft, goright, isGameOver;
        int timer_counter = 0;

        // public int redGhostSpeed, yellowGhostSpeed;
        readonly string name = "";
        

        public GameForm()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            // adding coin pictureboxes to the CoinList
            for (int i = 5; i <= 50; i++)
            {
                string name = $"pictureBox{i}";
                Control[] temp_arr = this.Controls.Find(name, true);
                var field = temp_arr[0] as PictureBox;
                CoinList.Add(new Coin(field));
            }
            // hide static pictureboxes: done in Reset function
            


            /// int[] coord = { 1, 2 };
            // List<int[]> PictureBoxXY = new List<int[]> { coord, coord };
            List<int> PictureBoxList1X = new List<int> { 201, 266, 324, 391, 201, 266, 324, 391 };
            List<int> PictureBoxList1Y = new List<int> {  12,  12,  12,  12, 134, 134, 134, 134 };
            List<int> PictureBoxList2X = new List<int> { 490, 539, 582, 490, 539, 582 };
            List<int> PictureBoxList2Y = new List<int> { 12, 12, 12, 66, 66, 66 };
            List<int> PictureBoxList3X = new List<int> { 116, 165, 208, 249, 298, 341, 382, 425, 468 };
            List<int> PictureBoxList3Y = new List<int> { 270, 270, 270, 270, 270, 270, 270, 270, 270 };
            List<int> PictureBoxList4X = new List<int> {  72, 121, 164,  72, 121, 164,  72, 121, 164 };
            List<int> PictureBoxList4Y = new List<int> { 415, 415, 415, 469, 469, 469, 524, 524, 524 };
            List<int> PictureBoxList5X = new List<int> { 278, 343, 404, 468, 278, 343, 404, 468 };
            List<int> PictureBoxList5Y = new List<int> { 402, 402, 402, 402, 524, 524, 524, 524 };
            List<int> PictureBoxList6X = new List<int> { 555, 604, 647, 555, 604, 647 };
            List<int> PictureBoxList6Y = new List<int> { 445, 445, 445, 499, 499, 499 };

            // add pictureboxes dinamically
            for (int i = 0; i < 9; i++)
            {
                string pictureboxName = $"picturebox{i}";
                int locationX = PictureBoxList3X[i];
                int locationY = PictureBoxList3Y[i];
                PictureBox picturebox = CreatePictureBox(pictureboxName, locationX, locationY);
                CoinList1.Add(new Coin(picturebox));

                pictureboxName = $"picturebox{i}";
                locationX = PictureBoxList4X[i];
                locationY = PictureBoxList4Y[i];
                picturebox = CreatePictureBox(pictureboxName, locationX, locationY);
                CoinList1.Add(new Coin(picturebox));

                if (i < 8)
                {
                    pictureboxName = $"picturebox{i}";
                    locationX = PictureBoxList1X[i];
                    locationY = PictureBoxList1Y[i];
                    picturebox = CreatePictureBox(pictureboxName, locationX, locationY);
                    CoinList1.Add(new Coin(picturebox));
                    if (i < 4)
                    {
                        picturebox.Image = Properties.Resources.coin_1;
                    }

                    locationX = PictureBoxList5X[i];
                    locationY = PictureBoxList5Y[i];
                    picturebox = CreatePictureBox(pictureboxName, locationX, locationY);
                    CoinList1.Add(new Coin(picturebox));
                    if (i > 3)
                    {
                        picturebox.Image = Properties.Resources.coin_1;
                    }
                }

                if (i < 6)
                {
                    pictureboxName = $"picturebox{i}";
                    locationX = PictureBoxList2X[i];
                    locationY = PictureBoxList2Y[i];
                    picturebox = CreatePictureBox(pictureboxName, locationX, locationY);
                    CoinList1.Add(new Coin(picturebox));

                    locationX = PictureBoxList6X[i];
                    locationY = PictureBoxList6Y[i];
                    picturebox = CreatePictureBox(pictureboxName, locationX, locationY);
                    CoinList1.Add(new Coin(picturebox));
                }
            }


            // field0.Visible = false;
            // field0.Visible = true;


            // reading file into list of classes
            List<Settings> SettingsList = new List<Settings>();
            // It is not possible to write into the installation directora (program folder), thus the settings file is placed into the ApplicationData folder, it is possible to set it in the Installer program
            // string settingsFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Bank Robber Game\\settings.csv");
            string settingsFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Bank Robber Game\\settings.csv";
            
            StreamReader sr = new StreamReader(settingsFilename);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Settings settings = new Settings(sor[0], sor[1]);
                SettingsList.Add(settings);
            }
            sr.Close();
            name = SettingsList[0].setting_value;
            playerClass.speed = Convert.ToInt32(SettingsList[1].setting_value);
            // playerSpeed = Convert.ToInt32(SettingsList[1].setting_value);
            guardHor1Class.speed = Convert.ToInt32(SettingsList[2].setting_value);
            guardHor1Class.speed = Convert.ToInt32(SettingsList[2].setting_value);
            // redGhostSpeed = Convert.ToInt32(SettingsList[2].setting_value);
            // yellowGhostSpeed = Convert.ToInt32(SettingsList[2].setting_value);
            guardVerClass.speedX = Convert.ToInt32(SettingsList[2].setting_value);
            guardVerClass.speedY = Convert.ToInt32(SettingsList[2].setting_value);
            // pinkGhostX = Convert.ToInt32(SettingsList[2].setting_value);
            // pinkGhostY = Convert.ToInt32(SettingsList[2].setting_value);
            //this.BackColor = Color.FromArgb(Convert.ToInt32(SettingsList[3].setting_value));
            this.BackColor = ColorTranslator.FromHtml(SettingsList[3].setting_value);
            pictureBox1.BackColor = ColorTranslator.FromHtml(SettingsList[4].setting_value);
            pictureBox2.BackColor = ColorTranslator.FromHtml(SettingsList[4].setting_value);
            pictureBox3.BackColor = ColorTranslator.FromHtml(SettingsList[4].setting_value);
            pictureBox4.BackColor = ColorTranslator.FromHtml(SettingsList[4].setting_value);
            /*
            // display test
            for (int i = 0; i < SettingsList.Count; i++)
            {
                // Console.WriteLine(SettingsList[i]);
                MessageBox.Show(SettingsList[i].setting_name + " " + SettingsList[i].setting_value);
            }
            */
            string message = "Please enter your name:";
            if (SettingsList[0].setting_value == "Name") // if no name was entered yet
            {
                do
                {
                    name = Interaction.InputBox(Prompt: $"{message}", Title: "Message", DefaultResponse: "Name");
                    message = "Please enter a valid name!";
                } while (name == "Name" || name == "" || (name.Contains(" ") && name.Replace(" ", "").Length == 0) );

                string rows = null;
                foreach (Settings setting in SettingsList)
                {
                    if (setting.setting_name == "name")
                    {
                       rows += setting.setting_name + ";" + name + "\n";
                    }
                    else if (setting.setting_name == "speed robber")
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                    else if (setting.setting_name == "speed guard")
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                    else if (setting.setting_name == "background color")
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                    else if (setting.setting_name == "wall color")
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                }
                StreamWriter sw = new StreamWriter(settingsFilename, append: false, Encoding.UTF8);
                sw.Write(rows);
                sw.Close();
            }

            ResetGame();
        }
        private PictureBox CreatePictureBox(string name, int locationX, int locationY)
        {
            string pictureBoxName = name;
            var pictureBox0 = new PictureBox();
            pictureBox0.Image = Properties.Resources.spinning_coin_gif_5;
            pictureBox0.Location = new Point(locationX, locationY);
            // pictureBox0.Margin = new System.Windows.Forms.Padding(4);
            pictureBox0.Size = new Size(33, 31);
            pictureBox0.SizeMode = PictureBoxSizeMode.StretchImage;
            // pictureBox0.TabIndex = 10;
            // pictureBox0.TabStop = false;
            pictureBox0.Tag = "coin";
            pictureBox0.Name = name;
            Controls.Add(pictureBox0);

            // Control[] arr = this.Controls.Find(name, true);
            // var pb = arr[0] as PictureBox;
            // return pb;
            return pictureBox0;
        }

        private void gamePage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        
        private void gamePage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                ResetGame();
                // BeginInvoke(new MethodInvoker(resetGame));
            }

        }

        private void MainGameTimer(object sender, EventArgs e)
        {

            if (timer_counter == 0) txtScore.Text = $" Hello, {name}! Good luck to the game! Score: " + playerClass.score;

            if(goleft == true)
            {
                player.Left -= playerClass.speed;
                // player.Left -= playerSpeed;
                player.Image = Properties.Resources.left1;
            }
            if (goright == true)
            {
                player.Left += playerClass.speed;
                // player.Left += playerSpeed;
                player.Image = Properties.Resources.right1;
            }
            if (godown == true)
            {
                player.Top += playerClass.speed;
                //player.Top += playerSpeed;
                player.Image = Properties.Resources.down1;
            }
            if (goup == true)
            {
                player.Top -= playerClass.speed;
                // player.Top -= playerSpeed;
                player.Image = Properties.Resources.up1;
            }

            if (player.Left < -14)
            {
                player.Left = 670;
            }
            if (player.Left > 670)
            {
                player.Left = -14;
            }

            if(player.Top < -14)
            {
                player.Top = 550;
            }
            if(player.Top > 550)
            {
                player.Top = -14;
            }

            // intersection of bank robber with coin
            foreach (var coin in CoinList1)
            {
                if (coin.picturebox.Visible == true)
                {
                    if (player.Bounds.IntersectsWith(coin.picturebox.Bounds))
                    {
                        playerClass.score += 1;
                        txtScore.Text = $" Hello, {name}! Good luck to the game! Score: " + playerClass.score;
                        coin.picturebox.Visible = false;
                    }
                }
            }

            foreach (Control x in this.Controls) 
            {
                if(x is PictureBox)
                {
                    /*
                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (bankrobber.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                    */
                    
                    if((string)x.Tag == "wall")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You lost!");
                        }


                        if(guardVer.Bounds.IntersectsWith(x.Bounds))
                        {
                            // instead of <= 0 speedY is used to avoid "breaking" into the wall on intersection
                            if (x.Bounds.Y + x.Bounds.Height - guardVer.Bounds.Y <= guardVerClass.speedY || guardVer.Bounds.Y + guardVer.Bounds.Height - x.Bounds.Y <= -guardVerClass.speedY)
                            {
                                guardVerClass.speedY = -guardVerClass.speedY;
                                // pinkGhostY = -pinkGhostY;
                            }
                            else
                            {
                                guardVerClass.speedX = -guardVerClass.speedX;
                                // pinkGhostX = -pinkGhostX;
                            }
                        }
                    }


                    if((string)x.Tag == "ghost")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You lost!");
                        }

                    }
                }
            }


            // moving guards
            guardHor1.Left += guardHor1Class.speed;
            // redGhost.Left += redGhostSpeed;

            if (guardHor1.Bounds.IntersectsWith(pictureBox1.Bounds) || guardHor1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                guardHor1Class.speed = -guardHor1Class.speed;
                // redGhostSpeed = -redGhostSpeed;
            }

            guardHor2.Left -= guardHor2Class.speed;
            // yellowGhost.Left -= yellowGhostSpeed;

            if (guardHor2.Bounds.IntersectsWith(pictureBox3.Bounds) || guardHor2.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                guardHor2Class.speed = -guardHor2Class.speed;
                // yellowGhostSpeed = -yellowGhostSpeed;
            }

            guardVer.Left -= guardVerClass.speedX;
            guardVer.Top -= guardVerClass.speedY;
            // pinkGhost.Left -= pinkGhostX;
            // pinkGhost.Top -= pinkGhostY;


            if(guardVer.Top < 0 || guardVer.Top >= 600 - guardVer.Bounds.Height - 36)
            {
                guardVerClass.speedY = -guardVerClass.speedY;
                // pinkGhostY = -pinkGhostY;
            }

            if(guardVer.Left < 0 || guardVer.Left >= 600 + guardVer.Bounds.Width)
            {
                guardVerClass.speedX = -guardVerClass.speedX;
                // pinkGhostX = -pinkGhostX;
            }




            if (playerClass.score == 46)
            {
                GameOver("YOU WON!");
            }

            timer_counter++;
        }

        private void ResetGame()
        {

            txtScore.Text = "Score: 0";
            playerClass.score = 0;
            timer_counter = 0;

            /*
            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;
            */
            isGameOver = false;

            player.Left = 31;
            player.Top = 46;

            guardHor1.Left = 208;
            guardHor1.Top = 55;

            guardHor2.Left = 448;
            guardHor2.Top = 445;

            guardVer.Left = 525;
            guardVer.Top = 235;

            foreach (var coin in CoinList1)
            {
                coin.picturebox.Visible = true;
            }

            foreach (var coin in CoinList)
            {
                coin.picturebox.Visible = false;
                // coin.picturebox.Visible = true;
            }
            
            /*
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                   x.Visible = true;
                }
            }
            */
            
            // if there is is delay due to database access and it does not detect the keyisup event, then we set it here
            goup = false;
            godown = false;
            goleft = false;
            goright = false;
            player.Image = Properties.Resources.right1;

            gameTimer.Start();
        }

        private void GameOver(string message)
        {

            isGameOver = true;

            gameTimer.Stop();

            // txtScore.Text = "Score: " + score + Environment.NewLine + message;
            string info = message == "You lost!" ? " (Press enter to restart the game.)" : $" Congrats, {name}! (Press ener to start a new game.)";
            txtScore.Text = "Score: " + playerClass.score + "  " + message + info;

            SaveResultIntoTable(name, playerClass.score, message, DateTime.Now.ToString());

        }

        private void SaveResultIntoTable(string name, int score, string outcome, string date)
        {

            if (TableCheck()) // if there is any column in the table
            {
                string query_insert = $"INSERT INTO `results` VALUES (NULL, '{name}', {score}, '{outcome}', '{date}');"; // if auto increment is NULL vagy 0, it will automatically save the subsequent value!
                string connectionString = $"datasource=localhost;port=3306;username=root;password=;database=bankrobber;";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query_insert, databaseConnection);
                try
                {
                    databaseConnection.Open();
                    commandDatabase.Prepare();
                    commandDatabase.ExecuteNonQuery();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // richTextBox1.Text = "Hiba: Nagy baj van.";
                    MessageBox.Show(ex.ToString(), caption: "Error message");
                }
            }
            else
            {
                MessageBox.Show("Database access error, the score could not be saved!");
            }
        }

        private bool TableCheck() // whether the 'results' table exists
        {
            bool tableExists = false;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bankrobber;";
            // check if table exists:
            string query = "SHOW TABLES LIKE 'results';";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (!reader.HasRows) // if the table does not exist
                {
                    databaseConnection.Close();
                }
                else
                {
                    tableExists = true;
                    // MessageBox.Show("The table 'results' already exists!");
                }
                // executed even if such table already exists)
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.ToString(), caption: "Error message");
            }
            return tableExists;
        }
        /*
        class settings
        {
            public string setting_name;
            public string setting_value;

            public settings(string setting_name, string setting_value)
            {
                this.setting_name = setting_name;
                this.setting_value = setting_value;
            }
        }
        */
    }
}
