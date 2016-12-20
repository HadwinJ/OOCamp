using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class SmartParkingBoy : ParkingBoy
    {
        //const int maxNumberOfParkingSystem = 3;
        //public int NumberOfParkingSystem { get; private set; }

        //public List<ParkingStation> ParkingStations { get; set; }
        //public int AvailableNumber
        //{
        //    get { return ParkingStations.Sum(p => p.AvailableNumber); }
        //}

        public SmartParkingBoy() : base()
        { }
        //public SmartParkingBoy()
        //{
        //    ParkingStations = new List<ParkingStation>();
        //    ParkingStations.Add(new ParkingStation("Park01"));
        //    ParkingStations.Add(new ParkingStation("Park02"));

        //    NumberOfParkingSystem = ParkingStations.Count;

        //}

        public SmartParkingBoy(List<ParkingStation> _parkingSystems) : base(_parkingSystems)
        { }
        //public SmartParkingBoy(List<ParkingStation> _parkingSystems)
        //{
        //    ParkingStations = _parkingSystems;
        //    NumberOfParkingSystem = _parkingSystems.Count;
        //}

        //public Car Pick(Tuple<string, int> parkingTicket)
        //{
        //    return (parkingTicket != null) ? ParkingStations.FirstOrDefault(p => p.Name == parkingTicket.Item1)?.Pick(parkingTicket) : null;
        //}

        public override Tuple<string, int> Park(Car myCar)
        {
            //var maxAvailableNumber = ParkingStations.Max(p => p.AvailableNumber);
            //if (maxAvailableNumber > 0)
            //{
            //    var parkingId = ParkingStations.FirstOrDefault(p => p.AvailableNumber == maxAvailableNumber).Park(myCar);
            //    return parkingId;
            //}

            var parkingId = ParkingStations.OrderByDescending(p=>p.AvailableNumber).FirstOrDefault().Park(myCar);

            return parkingId;
        }


    }
}
