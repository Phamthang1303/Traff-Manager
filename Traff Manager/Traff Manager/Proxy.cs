using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Traff_Manager
{
    internal class Proxy
    {
        public string? ipAddress { get; set; }
        public int? port { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }

        public Proxy(string? ipPortUssernamePassword = null) {
            if (!string.IsNullOrEmpty(ipPortUssernamePassword))
            {
                string[] arr = ipPortUssernamePassword.Split(':');
                if (arr.Length == 2)
                {
                    ipAddress = arr[0];
                    password = arr[1];
                }
                else if (arr.Length == 4)
                {
                    ipAddress = arr[0];
                    password = arr[1];
                    username = arr[2];
                    password = arr[3];
                }
            }
        }
    }

    internal class SettingsTraff
    {
        public bool? Accepting { get; set; }
        public bool? StartWithWindows { get; set; }
        public string? Token { get; set; }

        public bool isEmpty()
        {
            return !Accepting.HasValue && !StartWithWindows.HasValue && string.IsNullOrEmpty(Token);
        }
    }
}
