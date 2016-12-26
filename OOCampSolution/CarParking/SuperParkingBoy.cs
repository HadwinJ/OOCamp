using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class SuperParkingBoy : ParkingBoy
    {

        public SuperParkingBoy() : base()
        { }

        public SuperParkingBoy(List<ParkingStation> _parkingSystems) : base(_parkingSystems)
        { }

        public override Tuple<string, int> Park(Car myCar)
        {
            var parkingId = ParkingStations.OrderByDescending(p => (float)p.AvailableNumber / (float)p.TotalCapacity).FirstOrDefault().Park(myCar);

            return parkingId;
        }


    }
}
