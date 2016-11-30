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
        public void ShowInitialAvailableSpace()
        {
            // given
            var myParkingSystem = new ParkingSystem(10);

            // when

            // then
            Assert.Equal(10, myParkingSystem.AvailableNumber);
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

        [Fact()]
        public void Parking_ReturnZero_WhenZeroAvailable()
        {
            // given
            var myParkingSystem = new ParkingSystem(2);
            var myCar1 = new Car();
            var myCar2 = new Car();
            var myCar3 = new Car();

            // when
            var parkingId1 = myParkingSystem.Park(myCar1);
            var parkingId2 = myParkingSystem.Park(myCar2);
            var parkingId3 = myParkingSystem.Park(myCar3);

            // then
            Assert.Equal(10000, parkingId1);
            Assert.Equal(10001, parkingId2);
            Assert.Equal(0, parkingId3);
        }

        [Fact()]
        public void Pick_ReturnNull_WhenInvalidNumber()
        {
            // given
            var myParkingSystem = new ParkingSystem(10);
            var myCar1 = new Car();
            var myCar2 = new Car();
            var myCar3 = new Car();

            // when
            var parkingId1 = myParkingSystem.Park(myCar1);
            var parkingId2 = myParkingSystem.Park(myCar2);
            var parkingId3 = myParkingSystem.Park(myCar3);
            var myCar = myParkingSystem.Pick(11000);

            // then
            Assert.Equal(null, myCar);
        }

        [Fact()]
        public void Pick_ReturnNull_WhenNoCar()
        {
            // given
            var myParkingSystem = new ParkingSystem(10);

            // when
            var myCar = myParkingSystem.Pick(11000);

            // then
            Assert.Equal(null, myCar);
        }
    }
}