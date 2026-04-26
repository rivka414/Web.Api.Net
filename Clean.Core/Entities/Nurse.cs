namespace Clean.Core.Entities
{
    public class Nurse
    {
        public int Id { get; set; }           // מזהה ייחודי
        public string FirstName { get; set; } // שם פרטי
        public string LastName { get; set; }  // שם משפחה
        public string Role { get; set; }      // תפקיד: מלצר / מנהל / טבח (אם תרצי)
        public string Status { get; set; }    // סטטוס: פעילה / בחל״ת / לא זמינה
        public List<Appointment>? Appointments { get; set; }
    }
}
