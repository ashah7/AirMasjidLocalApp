using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblCameras
    {
        public TblCameras()
        {
            TblCameraLookup = new HashSet<TblCameraLookup>();
            TblEstablishment = new HashSet<TblEstablishment>();
        }

        public int CamerasId { get; set; }
        public int? EstablishId { get; set; }

        public virtual ICollection<TblCameraLookup> TblCameraLookup { get; set; }
        public virtual ICollection<TblEstablishment> TblEstablishment { get; set; }
    }
}
