using System;
using System.Collections.Generic;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class TblCameraLookup
    {
        public int CameraelementId { get; set; }
        public int? CamerasId { get; set; }
        public string RstpCamera { get; set; }
        public string RstpCameraTarget { get; set; }
        public string Cdn { get; set; }
        public int? Active { get; set; }
        public int? Cameradelay { get; set; }
        public string Script { get; set; }
        public string Description { get; set; }

        public virtual TblCameras Cameras { get; set; }
    }
}
