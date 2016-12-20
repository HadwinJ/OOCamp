using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingStation
    {
        const int defaultCapacity = 10;

        public string Name { get; set; }

        public int TotalCapacity { get; private set; }
        public int AvailableNumber { get; private set; }

        private int _nextAvailableNumber;
        private Dictionary<int, Car> _parkingSpace;

        public ParkingStation(string name)
        {
            AvailableNumber = defaultCapacity;
            TotalCapacity = defaultCapacity;
            _parkingSpace = new Dictionary<int, Car>();
            _nextAvailableNumber = 10000;
            Name = name;
        }

        public ParkingStation(string name, int capacity)
        {
            // Guid g = Guid.NewGuid();
            // Console.WriteLine(g);
            if (capacity <= 0) throw new ArgumentOutOfRangeException("capacity");

            AvailableNumber = capacity;
            TotalCapacity = capacity;
            _parkingSpace = new Dictionary<int, Car>();
            _nextAvailableNumber = 10000;
            Name = name;
        }

        public Tuple<string, int> Park(Car myCar)
        {
            if (0 == AvailableNumber)
                return null;
            var ticketId = _nextAvailableNumber++;
            AvailableNumber--;
            _parkingSpace.Add(ticketId, myCar);
            return new Tuple<string,int>(Name, ticketId);
        }

        public Car Pick(Tuple<string, int> parkingTicket)
        {
            if (parkingTicket.Item1 == Name)
            {
                if (_parkingSpace.ContainsKey(parkingTicket.Item2))
                {
                    var myCar = _parkingSpace[parkingTicket.Item2];
                    _parkingSpace.Remove(parkingTicket.Item2);
                    AvailableNumber++;
                    return myCar;
                }
            }
            
            return null;

        }
    }
}
