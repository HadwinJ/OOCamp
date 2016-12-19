using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingBoy
    {
        const int maxNumberOfParkingSystem = 10;
        public int NumberOfParkingSystem { get; set; }

        public ParkingSystem[] ParkingSystems { get; set; }
        public int AvailableNumber
        {
            get { return ParkingSystems.Sum(p=>p.AvailableNumber); }
        }
        
        public ParkingBoy()
        {
            ParkingSystems = new ParkingSystem[maxNumberOfParkingSystem];
            NumberOfParkingSystem = maxNumberOfParkingSystem;

            for (int i = 0; i < maxNumberOfParkingSystem; i++)
            {
                ParkingSystems[i] = new ParkingSystem();
            }
        }

        public Car Pick(Tuple<int, int> parkingId)
        {
            return ParkingSystems[parkingId.Item1].Pick(parkingId.Item2);
        }

        public Tuple<int, int> Park(Car myCar)
        {
            for (int i = 0; i < NumberOfParkingSystem; i++)
            {

                if (ParkingSystems[i].AvailableNumber > 0)
                {
                    var parkingId = ParkingSystems[i].Park(myCar);
                    return new Tuple<int, int>(i, parkingId);
                }

            }
            return null;
        }

        public ParkingBoy(int numberOfParkingSystem)
        {
            ParkingSystems = new ParkingSystem[numberOfParkingSystem];
            NumberOfParkingSystem = numberOfParkingSystem;

            for (int i = 0; i < numberOfParkingSystem; i++)
            {
                ParkingSystems[i] = new ParkingSystem();
            }
        }
    }
}
