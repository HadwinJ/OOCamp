using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class FuncParkingBase
    {

        public List<ParkingStation> ParkingStations { get; set; }
        public int AvailableNumber
        {
            get { return ParkingStations.Sum(p => p.AvailableNumber); }
        }


        public FuncParkingBase(List<ParkingStation> parkingSystems = null,
            Func<List<ParkingStation>, ParkingStation> findParkingStationFunc = null)
        {
            ParkingStations = (null != parkingSystems) ? parkingSystems :
                new List<ParkingStation>() {
                new ParkingStation("Park01"),
                new ParkingStation("Park02")};

            FindParkingStationFunc = (null != findParkingStationFunc) ? findParkingStationFunc :
                ps => ps.FirstOrDefault(p => p.AvailableNumber > 0);
        }

        public Car Pick(Tuple<string, int> parkingTicket)
        {
            return (parkingTicket != null) ? ParkingStations.FirstOrDefault(p => p.Name == parkingTicket.Item1)?.Pick(parkingTicket) : null;
        }


        public Func<List<ParkingStation>, ParkingStation> FindParkingStationFunc { get; }

        public Tuple<string, int> Park(Car myCar)
        {
            var parkingId = FindParkingStationFunc(ParkingStations)?.Park(myCar);
            return parkingId;
        }


    }
}
