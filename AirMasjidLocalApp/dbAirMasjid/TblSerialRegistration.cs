using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblSerialRegistration
    {
        public string Serial { get; set; }
        public string Hostname { get; set; }
        public string Owner { get; set; }
        public int? Ownerid { get; set; }

        public virtual Tblnameaddress OwnerNavigation { get; set; }
        public virtual TblPreferences TblPreferences { get; set; }
        public virtual TblRegistrations TblRegistrations { get; set; }
    }
}
