using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblEstablishment
    {
        public TblEstablishment()
        {
            TblPreferences = new HashSet<TblPreferences>();
        }

        public int EstablishId { get; set; }
        public int? CamerasId { get; set; }
        public int? StreamId { get; set; }
        public int? EventsId { get; set; }
        public string TweetId { get; set; }
        public string Description { get; set; }

        public virtual TblCameras Cameras { get; set; }
        public virtual TblEvents Events { get; set; }
        public virtual TblStreamLookup Stream { get; set; }
        public virtual ICollection<TblPreferences> TblPreferences { get; set; }
    }
}
