using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblUsers
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
