using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace WinForms_BankRobberGame2
{
    public partial class SettingsForm : Form
    {
        // Color backgroundColor;
        // Color wallColor;
        readonly List<Settings> SettingsList = new List<Settings>();
        readonly string settingsFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Bank Robber Game\\settings.csv";


        public SettingsForm()
        {
            InitializeComponent();

            // reading file into class list
            StreamReader sr = new StreamReader(settingsFilename);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Settings setting = new Settings(sor[0], sor[1]);
                SettingsList.Add(setting);
            }
            sr.Close();
            toolStripTextBox_name.Text = SettingsList[0].setting_value;
            toolStripTextBox_speedRobber.Text = SettingsList[1].setting_value;
            toolStripTextBox_speedGuard.Text = SettingsList[2].setting_value;
            colorDialog1.Color =   ColorTranslator.FromHtml(SettingsList[3].setting_value);
            // backgroundColor = ColorTranslator.FromHtml(SettingsList[3].setting_value);
            colorDialog2.Color =ColorTranslator.FromHtml(SettingsList[4].setting_value);
            // wallColor = ColorTranslator.FromHtml(SettingsList[4].setting_value);

            label_name.Text = SettingsList[0].setting_value;
            label_speed.Text = $"robber: {SettingsList[1].setting_value}\nguard:  {SettingsList[2].setting_value}";
            label_colors.Text = $"background: {SettingsList[3].setting_value}\nwall:                {SettingsList[4].setting_value}";



            /*
            toolStripComboBox_sebesseg.Items[0] = "IGEN";
            toolStripComboBox_sebesseg.SelectedItem = toolStripComboBox_sebesseg.Items[0];
            */
        }


           // Menu/Settings/Background color
        private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            // backgroundColor = colorDialog1.Color;
        }

        private void WallColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            // wallColor = colorDialog2.Color;
        }

        private void settingsPage_Load(object sender, EventArgs e)
        {

        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            bool change = false;
            string rows = null;
            foreach (Settings setting in SettingsList)
            {
                if (setting.setting_name == "name")
                {
                    string new_name = toolStripTextBox_name.Text;
                    if (new_name != setting.setting_value) // if there was a change
                    {
                        
                        if (new_name != "Name" && new_name != "" && (new_name.Contains(" ") == false || new_name.Replace(" ", "").Length != 0))
                        {
                            rows += setting.setting_name + ";" + new_name + "\n";
                            change = true;
                        }
                        else
                        {
                            MessageBox.Show($"The new name ('{new_name}') entered is invalid, please select a another name!", caption: "Error message",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                }

                if (setting.setting_name == "speed robber")
                {

                    string new_speed = toolStripTextBox_speedRobber.Text;
                    if (new_speed != setting.setting_value) // if there was a change
                    {
                        if (int.TryParse(new_speed, out int value) && value > 0 && value <= 20)
                        {
                            rows += setting.setting_name + ";" + value + "\n";
                            change = true;
                        }
                        else
                        {
                            MessageBox.Show($"The new speed ('{new_speed}') of the robber is invalid, please select another value!\n(The speed is an integer between 1-20.)", caption: "Error message",
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                }
                if (setting.setting_name == "speed guard")
                {
                    string new_speed = toolStripTextBox_speedGuard.Text;
                    if (new_speed != setting.setting_value) // if there was a change
                    {
                        if (int.TryParse(new_speed, out int value) && value > 0 && value <= 20)
                        {
                            rows += setting.setting_name + ";" + value + "\n";
                            change = true;
                        }
                        else
                        {
                            MessageBox.Show($"The new speed ('{new_speed}') of the guard is invalid, please select another value!\n(The speed is an integer between 1-20.)", caption: "Error message",
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                }
                if (setting.setting_name == "background color")
                {
                    if (ColorTranslator.ToHtml(colorDialog1.Color) != setting.setting_value) // if there was a change
                    {
                        rows += setting.setting_name + ";" + ColorTranslator.ToHtml(colorDialog1.Color) + "\n";
                        change = true;
                    }
                    else
                    {
                        if (ColorTranslator.ToHtml(colorDialog1.Color) == ColorTranslator.ToHtml(colorDialog2.Color))
                        {
                            MessageBox.Show("The wall color cannot match the background color!", caption: "Error message",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                }
                if (setting.setting_name == "wall color")
                {
                    if (ColorTranslator.ToHtml(colorDialog2.Color) != setting.setting_value) // if there was as change
                    {
                        if (ColorTranslator.ToHtml(colorDialog2.Color) == ColorTranslator.ToHtml(colorDialog1.Color))
                        {
                            MessageBox.Show("The background color cannot match the wall color!",caption: "Error message",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        rows += setting.setting_name + ";" + ColorTranslator.ToHtml(colorDialog2.Color) + "\n";
                        change = true;
                    }
                    else
                    {
                        rows += setting.setting_name + ";" + setting.setting_value + "\n";
                    }
                }
            }
            if (change)
            {

                label_name.Text = toolStripTextBox_name.Text;
                label_speed.Text = $"robber: {toolStripTextBox_speedRobber.Text}\nguard:  {toolStripTextBox_speedGuard.Text}";
                label_colors.Text = $"background: {ColorTranslator.ToHtml(colorDialog1.Color)}\nwall:               {ColorTranslator.ToHtml(colorDialog2.Color)}";
                StreamWriter sw = new StreamWriter(settingsFilename, append: false, Encoding.UTF8);
                sw.Write(rows);
                sw.Close();
                MessageBox.Show("OK", caption:"Message",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The values did not change.", caption:"Message",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
        }

    }
}
