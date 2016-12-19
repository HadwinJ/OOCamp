using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingSystem
    {
        const int defaultCapacity = 10;
        public int AvailableNumber { get; private set; }

        private int _nextAvailableNumber;
        private Dictionary<int, Car> _parkingSpace;

        public ParkingSystem()
        {
            AvailableNumber = defaultCapacity;
            _parkingSpace = new Dictionary<int, Car>();
            _nextAvailableNumber = 10000;
        }

        public ParkingSystem(int capacity)
        {
            // Guid g = Guid.NewGuid();
            // Console.WriteLine(g);

            AvailableNumber = capacity;
            _parkingSpace = new Dictionary<int, Car>();
            _nextAvailableNumber = 10000;
        }

        public int Park(Car myCar)
        {
            if (0 == AvailableNumber)
                return 0;
            var ticketId = _nextAvailableNumber++;
            AvailableNumber--;
            _parkingSpace.Add(ticketId, myCar);
            return ticketId;
        }

        public Car Pick(int parkingId)
        {
            if (_parkingSpace.ContainsKey(parkingId))
            {
                var myCar = _parkingSpace[parkingId];
                _parkingSpace.Remove(parkingId);
                AvailableNumber++;
                return myCar;
            }
            return null;

        }
    }
}
