using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiiChat.Models;

namespace PiiChat.Models
{
    public class Header
    {
        public string HeaderTitle { get; set; }

        public Header()
        {
            HeaderTitle = string.Empty;
        }

        public static ObservableCollection<UserInfo> GetTexts()
        {
            ObservableCollection<UserInfo> myListContact = new ObservableCollection<UserInfo>();
            myListContact.Add(new UserInfo("ABC"));
            myListContact.Add(new UserInfo("AEF"));
            myListContact.Add(new UserInfo("GHI"));
            myListContact.Add(new UserInfo("JKL"));
            myListContact.Add(new UserInfo("MNO"));
            myListContact.Add(new UserInfo("PQR"));
            myListContact.Add(new UserInfo("STU"));
            return myListContact;
        }

        public static ObservableCollection<GroupInfoList> GetItemsGrouped()
        {
            ObservableCollection<GroupInfoList> groups = new ObservableCollection<GroupInfoList>();

            var query = from item in GetTexts()
                        group item by item.Username[0] into g
                        orderby g.Key
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupInfoList info = new GroupInfoList();

                info.Key = g.GroupName;

                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }
            return groups;
        }
    }
}
