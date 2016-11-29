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
        public ICollection<Tuple<int, Car>> ParkingSpace { get; set; }

        public ParkingSystem(int capacity)
        {
            Capacity = capacity;
            ParkingSpace = new List<Tuple<int, Car>>();
            NextAvailableNumber = 10000;
        }
    }
}
