using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingBoy
    {
        public string Name { get; }
        public List<ParkingStation> ParkingStations { get; set; }
        public virtual int AvailableNumber
        {
            get { return ParkingStations.Sum(p => p.AvailableNumber); }
        }


        public ParkingBoy(String name = "DefaultParkingBoy", List<ParkingStation> parkingSystems = null)
        {
            Name = name;
            ParkingStations = (parkingSystems != null) ? parkingSystems :
                    new List<ParkingStation>() {
                        new ParkingStation("Park01"),
                        new ParkingStation("Park02")};
        }

        public virtual Car Pick(Tuple<string, int> parkingTicket)
        {
            return (parkingTicket != null) ? ParkingStations.FirstOrDefault(p => p.Name == parkingTicket.Item1)?.Pick(parkingTicket) : null;
        }

        public virtual Tuple<string, int> Park(Car myCar)
        {
            var parkingId = ParkingStations.FirstOrDefault(p => p.AvailableNumber > 0)?.Park(myCar);
            return parkingId;
        }


    }
}
