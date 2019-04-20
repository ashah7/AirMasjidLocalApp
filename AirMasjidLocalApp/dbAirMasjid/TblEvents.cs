using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblEvents
    {
        public TblEvents()
        {
            TblEstablishment = new HashSet<TblEstablishment>();
            TblEventlookup = new HashSet<TblEventlookup>();
        }

        public int EventsId { get; set; }
        public int? EstablishId { get; set; }
        public string Starttime { get; set; }
        public string Duration { get; set; }
        public int Active { get; set; }
        public string Eventdesc { get; set; }

        public virtual ICollection<TblEstablishment> TblEstablishment { get; set; }
        public virtual ICollection<TblEventlookup> TblEventlookup { get; set; }
    }
}
