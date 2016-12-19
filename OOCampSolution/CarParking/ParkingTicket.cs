using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingTicket
    {
        public string ParkingStationName { get; set; }
        public int ParkingId { get; set; }
        public ParkingTicket(string parkingStationName, int parkingId)
        {
            ParkingStationName = parkingStationName;
            ParkingId = parkingId;
        }
    }
}
