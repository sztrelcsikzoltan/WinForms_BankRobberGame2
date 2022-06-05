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
    public partial class DatabaseForm : Form
    {
        string query = "";
        readonly string database_name = "bankrobber";
        string table_name = "results";
        int row_index = 0;
        List<string> Fields = new List<string> { "id", "name", "score", "outcome", "date" }; // list of column names
        // readonly int num_columns = 5; // id, name, score, outcome, date 
        string primary_value = "";
        int PK_row_index = 0;
        string PK_field_name = "id";
        bool edit_mode = false;
        bool deleteRow_activated = false;

        public DatabaseForm()
        {
            InitializeComponent();
            query = $"SELECT * FROM `{database_name}`.`{table_name}` ORDER BY `score` DESC;";
            ShowValues();
            button_allResults.Enabled = false;
        }

        private void ShowValues()
        {
            dataGridView_values.Columns.Clear();
            button_deleteRow.ForeColor = Color.Black;
            dataGridView_values.AllowUserToAddRows = false; // hide last empty row
            dataGridView_values.DefaultCellStyle.SelectionBackColor = Color.White; // remove blue selection highlight
            dataGridView_values.DefaultCellStyle.SelectionForeColor = Color.Navy;
            dataGridView_values.AllowUserToResizeRows = false;
            dataGridView_values.AllowUserToResizeColumns = false;
            deleteRow_activated = false;
            if (!edit_mode) // if not edit mode, read view
            { 
                dataGridView_values.ReadOnly = true;
                dataGridView_values.RowHeadersVisible = false; // hide first empty control column
            }
            
            if (!edit_mode) label_message.Text = query;
            edit_mode = false;

            if (TableCheck()) // whether there is a table in the database
            {
                string connectionString = $"datasource=localhost;port=3306;username=root;password=;database=bankrobber;Convert Zero Datetime=True;"; // this last entry is required for eventual zero-value dates!
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                MySqlDataReader reader;
                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    // naming columns
                    int column_index = 0;
                    foreach (var field in Fields)
                    {
                        dataGridView_values.Columns.Add(new DataGridViewColumn() { HeaderText = field, CellTemplate = new DataGridViewTextBoxCell() });
                        dataGridView_values.Columns[column_index].Width = 152;
                        column_index++;
                    }
                    dataGridView_values.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11.00F, FontStyle.Bold);
                    dataGridView_values.DefaultCellStyle.Font = new Font("Arial", 10.00F, FontStyle.Regular);
                    dataGridView_values.Columns[0].Visible = false; // hide id column

                    row_index = 0;
                    if (reader.HasRows)
                    {
                        int num_columns = Fields.Count;
                        string[] row = new string[num_columns];
                        while (reader.Read())
                        {
                            // creating row array based on number of table columns
                            string value = "";
                            for (int i = 0; i < num_columns; i++)
                            {
                                // string test = reader.GetString(i);
                                value = reader.GetValue(i).ToString(); // GetString(i) generates error when the Date is "0000-00-00" !
                                row[i] = !reader.IsDBNull(i) ? value : "";
                                if (value.Contains(" 00:00:00")) row[i] = value.Replace(" 00:00:00", "");  // remove long date format
                                if (value == "01.01.01 00:00:00") row[i] = "00-00-00"; // in case of date "0000-00-00" the .NET display is incorrect

                            }
                            dataGridView_values.Rows.Insert(row_index, row);
                            row_index++;
                        }
                        // dataGridView_values.Sort(dataGridView_values.Columns[2], ListSortDirection.Descending);

                        // check number of rows in table
                        if (primary_value == "")
                        {
                            // dataGridView_values.CurrentCell = dataGridView_values.Rows[0].Cells[0]; // needed?
                        }
                        else // if primary_value is not empty
                        {
                            int i = 0;
                            while (i < dataGridView_values.RowCount - 1)
                            {
                                if (dataGridView_values.Rows[i].Cells[0].Value != null && dataGridView_values.Rows[i].Cells[0].Value.ToString().ToLower() == primary_value.ToString().ToLower())
                                {
                                    break;
                                }
                                i++;
                            }
                            dataGridView_values.CurrentCell = dataGridView_values.Rows[i].Cells[0]; // needed?
                        }
                        button_deleteRow.Enabled = true;
                    }
                    else
                    {
                        // Console.WriteLine("No rows found.");
                    }
                    if (row_index <= 1) button_deleteRow.Enabled = false; // if there is no row or only 1, then the delete botton is disabled
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    label_message.Text = ex.ToString();
                }
                // executed even there is no row in the table (only empty columns with header)
                // setting ClientSize if bigger than the width of columns
                // dataGridView_values.AutoResizeColumns(); // setting column width to the minimum
                int total_width = dataGridView_values.RowHeadersWidth*0 + 0;
                for (int i = 0+1; i < dataGridView_values.ColumnCount; i++) // 0+1, mert az id oszlop el van rejtve
                {
                    total_width += dataGridView_values.Columns[i].Width + 1; // 2 pixels due to the 2 borders?
                }
                if (total_width < 731)
                {
                    dataGridView_values.ClientSize = new Size(total_width, 230);
                }
                else
                {
                    dataGridView_values.ClientSize = new Size(731, 230);
                }

            }
            else
            {
                button_allResults.Enabled = false;
                button_ownResults.Enabled = false;
                button_winningResults.Enabled = false;
                button_deleteRow.Enabled = false;
                MessageBox.Show("The MySQL database is not accessible!");
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
                if (!reader.HasRows) // if there is no result, three is no such table and we create it
                {
                    databaseConnection.Close();
                }
                else
                {
                    tableExists = true;
                    // MessageBox.Show("The table 'results' already exists!");
                }
                // executed even if such table exists)
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.ToString(), caption: "Error message");
            }
            return tableExists;
        }


        private void button_deleteRow_Click(object sender, EventArgs e)
        {

            if (!deleteRow_activated) // pressing button for the 2nd time
            {
                edit_mode = true;
                deleteRow_activated = true;
                button_deleteRow.ForeColor = Color.Red;
                dataGridView_values.AllowUserToAddRows = false; // hide last empty row
                dataGridView_values.DefaultCellStyle.SelectionBackColor = Color.Blue; // restore blue selection highlight
                dataGridView_values.DefaultCellStyle.SelectionForeColor = Color.White;
                dataGridView_values.ClearSelection();
                dataGridView_values.CurrentCell = dataGridView_values.Rows[dataGridView_values.FirstDisplayedScrollingRowIndex+1].Cells[1]; // select cell to the right as the current cell, othewise it will not be blow in case of using the edit_button ??
                dataGridView_values.Rows[dataGridView_values.FirstDisplayedScrollingRowIndex+1].Selected = true; // select first VISIBLE row

                button_ownResults.Enabled = true;
                button_allResults.Enabled = true;
                button_winningResults.Enabled = true;
            }
            else
            {
                string connectionString = $"datasource=localhost;port=3306;username=root;password=;database={database_name};";
                int selectedRows_count = dataGridView_values.SelectedRows.Count;
                if (selectedRows_count > 0)
                {
                    // confirm delete
                    string question = selectedRows_count == 1 ? "Ar you sure to delete the selected row?" : "Are you sure to delete the selected rows?";
                    var result_MessageBox = MessageBox.Show(question, "Question:",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (result_MessageBox == DialogResult.Yes)
                    {
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        label_message.Text = ""; // delete multiline content
                        bool id1_delete = false;
                        for (int i = 0; i < dataGridView_values.SelectedRows.Count; i++)
                        {
                            string field_value = dataGridView_values.SelectedRows[i].Cells[PK_row_index].Value.ToString(); // this is the value of the actual PK field
                            if (field_value != "1") // ig id != 1 (1st default line cannot be deleted)
                            {
                                string query_delete = $"DELETE FROM `{database_name}`.`{table_name}` WHERE `{table_name}`.`{PK_field_name}` = '{field_value}';";
                                label_message.Text += query_delete + "\n";

                                MySqlCommand commandDatabase = new MySqlCommand(query_delete, databaseConnection);
                                try
                                {
                                    databaseConnection.Open();
                                    commandDatabase.Prepare();
                                    commandDatabase.ExecuteNonQuery();
                                    databaseConnection.Close();
                                }
                                catch (Exception ex)
                                {
                                    label_message.Text = ex.ToString();
                                }
                                dataGridView_values.DefaultCellStyle.SelectionBackColor = Color.White; // remove blue selection highlight
                                dataGridView_values.DefaultCellStyle.SelectionForeColor = Color.Navy;
                            }
                            else
                            {
                                id1_delete = true;
                            }
                        }
                        ShowValues();
                        if (id1_delete == true)
                        {
                            MessageBox.Show("The first default row cannot be deleted", caption: "Message");
                        }
                    }
                }
                else // pressing button for the 2nd time
                {
                    MessageBox.Show("The entire row(s) has/have to be selected! \n (Click once on any cell of the row(s) to be selected. To select multiple rows hold down the Ctrl button during selection.) ", "Delete");
                }
            }
        }

        private void dataGridView_values_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // when selecting row in case of deleteRow_activated (the header e.RowIndex -1, thus nothing happens when clicking it!)
            if (deleteRow_activated && e.RowIndex > -1 && dataGridView_values.Rows[e.RowIndex].Selected == false)
            {
                dataGridView_values.Rows[e.RowIndex].Selected = true;
            }
        }

        private void button_allResults_Click(object sender, EventArgs e)
        {
            query = $"SELECT * FROM `{database_name}`.`{table_name}` ORDER BY `score` DESC;";
            if (button_deleteRow.ForeColor == Color.Red) edit_mode = false;
            ShowValues();
            button_allResults.Enabled = false;
            button_ownResults.Enabled = true;
            button_winningResults.Enabled = true;
            if (row_index > 1)  button_deleteRow.Enabled = true;
        }

        private void button_ownResults_Click(object sender, EventArgs e)
        {
            // reading name from file
            string settingsFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Bank Robber Game\\settings.csv";

            StreamReader sr = new StreamReader(settingsFilename);
            string[] row = sr.ReadLine().Split(';');
            string name = row[1];
            sr.Close();

            query = $"SELECT * FROM `{database_name}`.`{table_name}` WHERE `name` ='{name}' ORDER BY `score` DESC;";
            if (button_deleteRow.ForeColor == Color.Red) edit_mode = false;
            ShowValues();
            button_ownResults.Enabled = false;
            button_allResults.Enabled = true;
            button_winningResults.Enabled = true;
            if (row_index > 1)  button_deleteRow.Enabled = true;
        }

        private void button_winningResults_Click(object sender, EventArgs e)
        {
            // query = $"SELECT `id`, `name`, MAX(`score`), `outcome`, `date` FROM `{database_name}`.`{table_name}` WHERE `outcome` = 'YOU WON!' GROUP BY `name`;";
            query = $"SELECT * FROM `{database_name}`.`{table_name}` WHERE `outcome` = 'YOU WON!';";
            if (button_deleteRow.ForeColor == Color.Red) edit_mode = false;
            ShowValues();
            button_winningResults.Enabled = false;
            button_ownResults.Enabled = true;
            button_allResults.Enabled = true;
            if (row_index > 1) button_deleteRow.Enabled = true;
        }

    }
}
