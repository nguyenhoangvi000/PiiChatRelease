using System;
using System.Collections.Generic;
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

    }
}
