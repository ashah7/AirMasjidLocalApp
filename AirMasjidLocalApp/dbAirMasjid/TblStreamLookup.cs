using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblStreamLookup
    {
        public TblStreamLookup()
        {
            TblEstablishment = new HashSet<TblEstablishment>();
        }

        public int StreamId { get; set; }
        public string StreamUrl { get; set; }
        public string Transmitter { get; set; }
        public int? Transmitterport { get; set; }
        public int? Micstatus { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblEstablishment> TblEstablishment { get; set; }
    }
}
