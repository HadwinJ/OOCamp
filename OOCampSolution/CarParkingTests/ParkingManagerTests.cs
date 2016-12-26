using Xunit;
using CarParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Tests
{
    public class ParkingManagerTests
    {
        [Fact()]
        public void ParkingBoyTest()
        {
            var parkingBoy = new ParkingBoy();
            Assert.True(true);
        }

        [Fact()]
        public void ParkingAndPickingBack()
        {
            var myCar = new Car();
            var myParkingBoy = new ParkingBoy(new List<ParkingStation> {
                new ParkingStation("Station1"),
                new ParkingStation("Station2")
            });
            var myParkingManager = new ParkingManager();

            myParkingManager.AddParkingBoy(myParkingBoy);
            var parkingId = myParkingManager.Park(myCar);

            var myReceiving = myParkingManager.Pick(parkingId);

            Assert.Equal<Car>(myCar, myReceiving);
        }

        [Fact()]
        public void ShowInitialAvailableSpace()
        {
            // given
            var myParkingBoy = new ParkingBoy(new List<ParkingStation> {
                new ParkingStation("Station1"),
                new ParkingStation("Station2")
            });
            var myParkingManager = new ParkingManager();
            myParkingManager.AddParkingBoy(myParkingBoy);

            // when

            // then
            Assert.Equal(20, myParkingManager.AvailableNumber);
        }

        [Fact()]
        public void ShowAvailableSpace()
        {
            // given
            var myCar = new Car();
            var myParkingBoy = new ParkingBoy(new List<ParkingStation> {
                new ParkingStation("Station1"),
                new ParkingStation("Station2")
            });
            var myParkingManager = new ParkingManager();
            myParkingManager.AddParkingBoy(myParkingBoy);

            // when
            var parkingId = myParkingBoy.Park(myCar);

            // then
            Assert.Equal(19, myParkingManager.AvailableNumber);
        }
        
        

    }
}