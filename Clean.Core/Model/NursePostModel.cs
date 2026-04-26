namespace Web_api_queuies.Model
{
    public class NursePostModel
    {
        public string FirstName { get; set; } // שם פרטי
        public string LastName { get; set; }  // שם משפחה
        public string Role { get; set; }      // תפקיד: מלצר / מנהל / טבח (אם תרצי)
        public string Status { get; set; }
    }
}
