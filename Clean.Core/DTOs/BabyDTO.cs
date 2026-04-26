using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.DTOs
{
    public class BabyDTO
    {
        public int Id { get; set; }           // מזהה ייחודי
        public string FirstName { get; set; } // שם פרטי
        public string LastName { get; set; }  // שם משפחה
        public DateTime DateOfBirth { get; set; } // תאריך לידה
        public string Status { get; set; }
    }
}
