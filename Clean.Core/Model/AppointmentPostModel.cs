namespace Web_api_queuies.Model
{
    public class AppointmentPostModel
    {
        public int BabyId { get; set; }      // מזהה התינוק
        public int NurseId { get; set; }     // מזהה האחות המטפלת
        public DateTime Date { get; set; }   // תאריך ושעת התור
        public string Status { get; set; }   // סטטוס: חדש / מאושר / בוטל / הושלם
        public string Notes { get; set; }    // הערות נוספות (לא חובה)
    }
}
