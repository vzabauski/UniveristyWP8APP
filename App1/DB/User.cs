using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.DB
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public long Role { get; set; }
    }
}
