using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class SuperParkingBoy : ParkingBoy
    {

        public SuperParkingBoy(String name = "DefaultSuperParkingBoy", List<ParkingStation> parkingSystems = null) : base(name, parkingSystems)
        { }

        public override Tuple<string, int> Park(Car myCar)
        {
            var parkingId = ParkingStations.OrderByDescending(p => (float)p.AvailableNumber / (float)p.TotalCapacity).FirstOrDefault().Park(myCar);

            return parkingId;
        }


    }
}
