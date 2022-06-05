using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_BankRobberGame2
{
    class Settings
    {
        public string setting_name;
        public string setting_value;

        public Settings(string setting_name, string setting_value)
        {
            this.setting_name = setting_name;
            this.setting_value = setting_value;
        }
    }
}
