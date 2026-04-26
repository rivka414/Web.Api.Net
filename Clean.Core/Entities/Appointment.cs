namespace Clean.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }          // מזהה ייחודי
        public int BabyId { get; set; }      // מזהה התינוק
        public int NurseId { get; set; }     // מזהה האחות המטפלת
        public DateTime Date { get; set; }   // תאריך ושעת התור
        public string Status { get; set; }   // סטטוס: חדש / מאושר / בוטל / הושלם
        public string Notes { get; set; }    // הערות נוספות (לא חובה)

        // קשר לתינוק
        public Baby? Baby { get; set; }   // Navigation Property

        // קשר לאחות
        public Nurse? Nurse { get; set; } // Navigation Property
    }
}
