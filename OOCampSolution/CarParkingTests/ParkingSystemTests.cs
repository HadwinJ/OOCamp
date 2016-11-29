using Xunit;
using CarParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Tests
{
    public class ParkingSystemTests
    {
        [Fact()]
        public void ParkingSystemTest()
        {
            Assert.True(true, "This test needs an implementation");
        }

        

        [Fact()]
        public void ParkingAndPickingBack()
        {
            var myCar = new Car();
            var myParkingSystem = new ParkingSystem(10);

            var parkingId = myParkingSystem.Park(myCar);
            var myReceiving = myParkingSystem.Pick(parkingId);

            Assert.Equal<Car>(myCar, myReceiving);
        }

        [Fact()]
        public void ShowAvailableSpace()
        {
            // given
            var myParkingSystem = new ParkingSystem(10);
            var myCar = new Car();

            // when
            var parkingId = myParkingSystem.Park(myCar);

            // then
            Assert.Equal(9, myParkingSystem.AvailableNumber);
        }
    }
}