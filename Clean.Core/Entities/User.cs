using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } // בעולם אמיתי נשמור Hash, כרגע נשמור טקסט פשוט
        public string Email { get; set; }
        public string Role { get; set; } = "User"; // ברירת מחדל
    }
}
