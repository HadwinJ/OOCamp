using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingManager : ParkingBoy
    {

        protected List<ParkingBoy> _parkingBoyList = new List<ParkingBoy>();
        public ParkingManager(String name = "DefaultParkingManager", List<ParkingStation> parkingSystems = null) : base(name, parkingSystems)
        { }


        public override int AvailableNumber
        {
            get { return _parkingBoyList.Sum(pb => pb.AvailableNumber) + ParkingStations.Sum(p => p.AvailableNumber); }
        }

        public void AddParkingBoy(ParkingBoy myParkingBoy)
        {
            _parkingBoyList.Add(myParkingBoy);
        }

        public override Tuple<string, int> Park(Car myCar)
        {
            var parkingBoy = _parkingBoyList.Where(p => p.AvailableNumber > 0).OrderByDescending(p => p.AvailableNumber).FirstOrDefault();
            if (parkingBoy != null)
            {
                return parkingBoy.Park(myCar);
            }
            return base.Park(myCar);
        }

        public override Car Pick(Tuple<string, int> parkingId)
        {
            var parkingBoy = _parkingBoyList.Where(p => p.ParkingStations.Any(ps => ps.Name == parkingId.Item1)).FirstOrDefault();
            if (parkingBoy != null)
            {
                return parkingBoy.Pick(parkingId);
            }
            return base.Pick(parkingId);
        }

        public Tuple<string, int> Park(Car myCar, ParkingBoy myParkingBoy)
        {
            return myParkingBoy?.Park(myCar);
        }
    }
}
