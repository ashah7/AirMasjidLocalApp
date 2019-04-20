using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class Tblnameaddress
    {
        public Tblnameaddress()
        {
            TblSerialRegistration = new HashSet<TblSerialRegistration>();
        }

        public int Ownerid { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<TblSerialRegistration> TblSerialRegistration { get; set; }
    }
}
