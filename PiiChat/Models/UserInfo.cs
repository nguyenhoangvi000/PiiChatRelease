using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiiChat.Models
{
    public class UserInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayname { get; set; }
        public long iat { get; set; }
        public long exp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public UserInfo(string name)
        {
            this.Username = name;
        }

        public UserInfo()
        {
        }

        public UserInfo(string id, string username, string displayname, long iat, long exp)
        {
            this.id = id;
            this.username = username;
            this.displayname = displayname;
            this.iat = iat;
            this.exp = exp;
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged("Username");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
