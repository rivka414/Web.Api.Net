using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }          // מזהה ייחודי
        public int BabyId { get; set; }      // מזהה התינוק
        public int NurseId { get; set; }     // מזהה האחות המטפלת
        public DateTime Date { get; set; }   // תאריך ושעת התור
        public string Status { get; set; }   // סטטוס: חדש / מאושר / בוטל / הושלם
        public string Notes { get; set; }    // הערות נוספות (לא חובה)
    }
}
