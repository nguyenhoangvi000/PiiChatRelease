using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PiiChat.Models
{
    public class MessageContent
    {
        public string content { set; get; }
        public string time { set; get; }
        public string sourceImage { set; get; }
        public string alignment { set; get; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public MessageContent()
        {

        }

        public MessageContent(string v1, string v2, string v3, string v4)
        {
            this.content = v1;
            this.time = v2;
            this.sourceImage = v3;
            this.alignment = v4;
        }

        public void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
