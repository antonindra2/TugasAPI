using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Base
{
    public class BaseAddress
    {
        public string Url()
        {
            var url = "http://localhost:57439/api/";
            return url;
        }
    }
}