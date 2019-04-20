using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblEventlookup
    {
        public int EventselementId { get; set; }
        public int? EventsId { get; set; }
        public string Broadcastday { get; set; }
        public string Eventurl { get; set; }
        public int? Active { get; set; }
        public int? AutoScreen { get; set; }

        public virtual TblEvents Events { get; set; }
    }
}
