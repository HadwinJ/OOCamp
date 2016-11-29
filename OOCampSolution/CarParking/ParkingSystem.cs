using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingSystem
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NextAvailableNumber { get; set; }
        public Dictionary<int, Car> ParkingSpace { get; set; }

        public ParkingSystem(int capacity)
        {
            Capacity = capacity;
            ParkingSpace = new Dictionary<int, Car>();
            NextAvailableNumber = 10000;
        }

        public int Park(Car myCar)
        {
            if (ParkingSpace.Count == Capacity)
                return 0;
            var ticketId = NextAvailableNumber++;
            ParkingSpace.Add(ticketId, myCar);
            return ticketId;
        }

        public Car Pick(int parkingId)
        {
            var myCar = ParkingSpace[parkingId];
            ParkingSpace.Remove(parkingId);
            return myCar;
        }
    }
}
