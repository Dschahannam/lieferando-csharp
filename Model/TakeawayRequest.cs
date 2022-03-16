using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Lieferando.Model
{
    public abstract class TakeawayRequest
    {
        public abstract string Name { get; }
        public abstract string Endpoint { get; }
    }
}
