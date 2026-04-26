namespace Clean.Core.Entities
{
    public class Baby
    {
        public int Id { get; set; }           // מזהה ייחודי
        public string FirstName { get; set; } // שם פרטי
        public string LastName { get; set; }  // שם משפחה
        public DateTime DateOfBirth { get; set; } // תאריך לידה
        public string Status { get; set; }    // סטטוס: פעיל / לא פעיל / הועבר תחנה
        public List<Appointment>? Appointments { get; set; }
    }
}
