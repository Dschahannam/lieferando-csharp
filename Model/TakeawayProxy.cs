using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Lieferando.Model
{
    public class TakeawayProxy
    {
        public TakeawayProxy(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public string Host { get; }
        public int Port { get; }
    }
}
