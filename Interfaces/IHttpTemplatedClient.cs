using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferando.Interfaces
{
    public interface IHttpTemplatedClient
    {
        Dictionary<string, string> GetStandardParameters();
    }
}
