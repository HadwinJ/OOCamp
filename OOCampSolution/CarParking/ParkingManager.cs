using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingManager
    {
        private List<ParkingBoy> _parkingBoyList = new List<ParkingBoy>();

        public int AvailableNumber
        {
            get { return _parkingBoyList.Sum(pb => pb.AvailableNumber); }
        }

        public void AddParkingBoy(ParkingBoy myParkingBoy)
        {
            _parkingBoyList.Add(myParkingBoy);
        }

        public Tuple<string, int> Park(Car myCar)
        {
            var parkingBoy = _parkingBoyList.OrderByDescending(p => p.AvailableNumber).FirstOrDefault();
            return parkingBoy?.Park(myCar);
        }

        public Car Pick(Tuple<string, int> parkingId)
        {
            var parkingBoy = _parkingBoyList.Where(p => p.ParkingStations.Any(ps => ps.Name == parkingId.Item1)).FirstOrDefault();
            return parkingBoy.Pick(parkingId);
        }
    }
}
