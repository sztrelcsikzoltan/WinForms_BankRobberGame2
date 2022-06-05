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
    public partial class StartForm : Form
    {
        int progressbar_counter = 0;
        int progressbar_counter0 = 0;
        int progressbar_counter1 = 0;
        string SQL_errorMessage = "";
        bool databaseExists = false;

        public StartForm()
        {
            InitializeComponent();
            
            label_status0.Visible = false;
            label_status1.Visible = false;
            progressBar1.Visible = false;
            SQL_errorMessage = DatabaseConnectionCheck();
            progressTimer.Start();
            DatabaseSet();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            GameForm gamePage = new GameForm();
            gamePage.Show();
        }

        private void HelpForm_Click(object sender, EventArgs e)
        {
            HelpForm helpPage = new HelpForm();
            helpPage.Show();
        }

        private void SettingsForm_Click(object sender, EventArgs e)
        {
            SettingsForm settingsPage = new SettingsForm();
            settingsPage.Show();
        }

        private void DatabaseForm_Click(object sender, EventArgs e)
        {
            DatabaseForm databasePage = new DatabaseForm();
            databasePage.Show();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (progressbar_counter == 20) // after 1 second
            {
                label_title.Visible = true;
            }
            if (progressbar_counter == 40) // after 2 seconds
            {
                label_status0.Visible = true;
            }
            if (progressbar_counter == 60) // after 3 seconds
            {
                progressBar1.Visible = true;
            }
            if (progressbar_counter > 60)
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value++;
                }
                else
                {
                    progressBar1.Visible = false;
                    // if there is a database connection
                    if (SQL_errorMessage == "")
                    {

                        label_status1.Visible = true;
                        progressBar1.Visible = false;
                        EnableButtons();
                    }
                    else
                    {

                        if (label_noConnection.Visible == false)
                        {
                            label_noConnection.Visible = true;
                            button_errorMessageDetails.Visible = true;
                            button_connectToDatabase.Visible = true;
                            label_status1.Visible = false;
                        }

                        if (SQL_errorMessage.Contains("Unable to connect to any of the specified MySQL hosts.") && label_status0.Visible == true)
                        {
                            label_status0.Visible = false;
                            MessageBox.Show("Connection to the MySQL database failed! \nPlease make sure that the database server is available and that the connection data on the Settings page are correct.", caption: "Error message");
                        }
                        EnableButtons();
                    }
                }
            }
            progressbar_counter++;
        }

        private void EnableButtons()
        {
            if (progressbar_counter0 == 0)
            {
                progressbar_counter0 = progressbar_counter;
                progressbar_counter1 = progressbar_counter;
            }
            if (progressbar_counter1 - progressbar_counter0 == 20)
            {
                button_help.Enabled = true;
            }
            if (progressbar_counter1 - progressbar_counter0 == 40)
            {
                button_startGame.Enabled = true;
            }
            if (progressbar_counter1 - progressbar_counter0 == 60)
            {
                button_settings.Enabled = true;
            }
            if (progressbar_counter1 - progressbar_counter0 == 80)
            {
                button_database.Enabled = true;
            }
            if (progressbar_counter1 - progressbar_counter0 == 100)
            {
                label_status0.Visible = false;
                label_status1.Visible = false;
                progressTimer.Stop();
                progressbar_counter0 = 0;

                // checking for settings.csv, is not present copying it into the ApplicationData folder
                SettingsFileCheck();
            }
            progressbar_counter1++;
        }
        
        private void SettingsFileCheck()
        {
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Bank Robber Game";
            string settingsFilename = targetPath + "\\settings.csv";
            bool fileExists = File.Exists(settingsFilename);
            if (fileExists == false)
            {
                string sourcePath = Environment.CurrentDirectory;
                string settingsFilename0 = sourcePath + "\\settings.csv";
                // If the directory already exists, this method does not create a new directory.
                System.IO.Directory.CreateDirectory(targetPath);
                try
                {
                    System.IO.File.Copy(settingsFilename0, settingsFilename, true);
                }
                catch (Exception)
                {

                    label_status0.Visible = false;
                    label_status1.Text = "Installation error!";
                    label_status1.Visible = true;
                    label_status1.BackColor = Color.Red;
                    button_settings.Enabled = false;
                    button_startGame.Enabled = false;
                    MessageBox.Show("The installation was inappropriate,because the file containing the settings (settings.csv) is not available in the user's \\AppData\\Roaming\\Bank Robber Game\\ folder. This is required for the program to work properly. Please try to reinstall the program.", caption: "Error message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
        
        private string DatabaseConnectionCheck()
        {
            string SQL_errorMessage = "";

            //  ShowDatabases();
            string connectionString = $"datasource=localhost;port=3306;username=root;password=;"; // no database is selected
            string query_database = "SHOW DATABASES;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query_database, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {

                    List<string> Databases = new List<string>();
                    int row_index = 0;
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0) };
                        Databases.Add(row[0]);
                        if (row[0] == "bankrobber") databaseExists = true;
                        row_index++;
                    }
                    int num_databases = Databases.Count; // number of databases
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                SQL_errorMessage = ex.ToString();
            }
            return SQL_errorMessage;
        }

        private void DatabaseCreate()
        {
            if (databaseExists == false) // if there is no such database, we create it
            {
                string database_name = "bankrobber";
                string connectionString = $"datasource=localhost;port=3306;username=root;password=;";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string query = $"CREATE DATABASE `{database_name}` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                try
                {
                    databaseConnection.Open();
                    commandDatabase.Prepare();
                    commandDatabase.ExecuteNonQuery();
                    databaseConnection.Close();
                    // MessageBox.Show(text: $"The new database '{database_name}' was created.", caption: "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: ex.ToString(), caption: "Error message");
                }
                databaseConnection.Close();
            }
            else
            {
                // MessageBox.Show(text: "The database already exists.");
            }

        }

        private void TableCreate()
        {
            /*
            if (tableExists) // if the table exists AND the field names and count do not match (id, neme, score, date), then we delete it
            {
                databaseConnection = new MySqlConnection(connectionString);
                string query_delete = $"DROP TABLE `bankrobber`.`{table_name}`;";
                commandDatabase = new MySqlCommand(query_delete, databaseConnection);
                try
                {
                    databaseConnection.Open();
                    commandDatabase.Prepare();
                    commandDatabase.ExecuteNonQuery();
                    databaseConnection.Close();
                    MessageBox.Show(text: $"The table 'results' was deleted.", caption: "Message");
                }
                catch (Exception ex)
                {
                    // richTextBox1.Text = "Error: There is a big trouble.";
                    MessageBox.Show(ex.ToString(), caption: "Error message");
                }
            }
            */
            if (TableCheck() == false)// if table not present, we create it
            {

                // create table section
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bankrobber;";
                string query = "CREATE TABLE `results` (`id` int auto_increment PRIMARY KEY, `name` varchar(30), `score`int, `outcome` varchar(11), `datum` datetime)";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                try
                {
                    databaseConnection.Open();
                    commandDatabase.Prepare();
                    commandDatabase.ExecuteNonQuery();
                    databaseConnection.Close();
                    // MessageBox.Show(text: "The new table 'results' was created.", caption: "Message");
                    // string datum = DateTime.Now.ToString();
                    SaveResultIntoTable("Zoly", 46, "YOU WON!", "21.08.05 11:22:11");
                    SaveResultIntoTable("Zoly", 11, "You lost!", "21.08.05 11:11:11");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), caption: "Error message");
                }
            }
        }

        private bool TableCheck() // whether the table 'results' exists
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
                if (!reader.HasRows) // if there is no result, then there is no such table and we create it
                {
                    databaseConnection.Close();
                }
                else
                {
                    tableExists = true;
                    // MessageBox.Show("The table 'results' already exists!");
                }
                // executed even if such table exits)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), caption: "Error message");
            }
            return tableExists;
        }

        private void SaveResultIntoTable(string name, int score, string outcome, string datum)
        {
            string query_insert = $"INSERT INTO `results` VALUES (0, '{name}', {score}, '{outcome}', '{datum}');"; // if the auto_increment value is zero, then it automatically uses the next available value!
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
                MessageBox.Show(ex.ToString(), caption: "Error message");
            }
        }

        private void Button_errorMessageDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SQL_errorMessage, caption: "Error message details:");
        }

        private void Button_connectToDatabase_Click(object sender, EventArgs e)
        {
            label_status0.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            button_connectToDatabase.Visible = false;
            label_noConnection.Visible = false;
            button_errorMessageDetails.Visible = false;
            SQL_errorMessage = DatabaseConnectionCheck();
            progressTimer.Start();
            DatabaseSet();
        }

        private void DatabaseSet()
        {
            // SQL_errorMessage = DatabaseConnectionCheck();
            if (SQL_errorMessage == "") // if there is database connection
            {
                DatabaseCreate();
                TableCreate();
            }
        }

    }
}
