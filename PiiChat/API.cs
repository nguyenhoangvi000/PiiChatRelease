using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiiChat.Models;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PiiChat
{
    public class API
    {
        HttpClient client = null;
        private static API _api;

        protected API()
        {
            client = new HttpClient();
        }

        public static API getInstance()
        {
            if (_api == null)
            {
                _api = new API();
            }
            return _api;
        }

        public async Task<UserInfo> getUser()//UserInfo user
        {
            HttpResponseMessage response = await client.GetAsync(Config.ServerUri + "api/users");
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                JObject obj = JObject.Parse(result);
                bool value = obj.Value<bool>("success");
                if (value)
                {
                    var userJSON = obj.Value<JObject>("user");
                    return new UserInfo()
                    {
                        id = userJSON.Value<string>("id"),
                        username = userJSON.Value<string>("username"),
                        displayname = userJSON.Value<string>("displayname"),
                        exp = userJSON.Value<long>("exp"),
                        iat = userJSON.Value<long>("iat"),
                    };
                }
                return null;
            }
        }
    }
}
