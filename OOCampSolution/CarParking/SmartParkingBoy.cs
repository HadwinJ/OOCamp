using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class SmartParkingBoy : ParkingBoy
    {

        public SmartParkingBoy() : base()
        { }

        public SmartParkingBoy(List<ParkingStation> _parkingSystems) : base(_parkingSystems)
        { }


        public override Tuple<string, int> Park(Car myCar)
        {

            var parkingId = ParkingStations.OrderByDescending(p=>p.AvailableNumber).FirstOrDefault().Park(myCar);

            return parkingId;
        }


    }
}
