using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolexStore.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string Email { get; set; }
    }
}