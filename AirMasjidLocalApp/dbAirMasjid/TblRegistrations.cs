using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblRegistrations
    {
        public string Serial { get; set; }
        public DateTime Logintime { get; set; }
        public string LocalIp { get; set; }
        public string Vpnip { get; set; }
        public string ExternalIp { get; set; }
        public string PublicIp { get; set; }
        public string WifiQuality { get; set; }
        public string Cloudserver { get; set; }
        public string Virtualhub { get; set; }
        public string Vpnserver { get; set; }

        public virtual TblSerialRegistration SerialNavigation { get; set; }
    }
}
