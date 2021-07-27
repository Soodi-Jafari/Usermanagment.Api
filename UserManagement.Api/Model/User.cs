using System;

namespace UserManagement.Api
{
    public class User
    {
        public int id { get; set; }
        public DateTime geburtsdatum { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
    }
}
