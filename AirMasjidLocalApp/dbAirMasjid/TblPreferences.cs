using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblPreferences
    {
        public string Serial { get; set; }
        public string AutoScreen { get; set; }
        public string TahajjudAzan { get; set; }
        public int? EstablishId { get; set; }
        public int? Events { get; set; }
        public int? ViewMode { get; set; }
        public string Patch { get; set; }

        public virtual TblEstablishment Establish { get; set; }
        public virtual TblSerialRegistration SerialNavigation { get; set; }
    }
}
