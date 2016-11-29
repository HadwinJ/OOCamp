﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingSystem
    {
        public int AvailableNumber { get; set; }

        private int _nextAvailableNumber;
        private Dictionary<int, Car> _parkingSpace;

        public ParkingSystem(int capacity)
        {
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
            var myCar = _parkingSpace[parkingId];
            _parkingSpace.Remove(parkingId);
            AvailableNumber++;
            return myCar;
        }
    }
}
