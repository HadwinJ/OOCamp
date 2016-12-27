using Xunit;
using CarParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Tests
{
    public class ParkingBoyTests
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
            var myParkingBoy = new ParkingBoy();

            var parkingId = myParkingBoy.Park(myCar);
            var myReceiving = myParkingBoy.Pick(parkingId);

            Assert.Equal<Car>(myCar, myReceiving);
        }

        [Fact()]
        public void ShowInitialAvailableSpace()
        {
            // given
            var myParkingBoy = new ParkingBoy();

            // when

            // then
            Assert.Equal(20, myParkingBoy.AvailableNumber);
        }

        [Fact()]
        public void ShowAvailableSpace()
        {
            // given
            var myParkingBoy = new ParkingBoy();
            var myCar = new Car();

            // when
            var parkingId = myParkingBoy.Park(myCar);

            // then
            Assert.Equal(19, myParkingBoy.AvailableNumber);
        }

        [Fact()]
        public void Parking_ReturnNull_WhenZeroAvailable()
        {

            // given
            var myParkingBoy = new ParkingBoy(parkingSystems: new List<ParkingStation> { new ParkingStation("testParking", 10) });
            var myCar1 = new Car();
            var myCar2 = new Car();
            var myCar3 = new Car();
            var myCar4 = new Car();
            var myCar5 = new Car();
            var myCar6 = new Car();
            var myCar7 = new Car();
            var myCar8 = new Car();
            var myCar9 = new Car();
            var myCar10 = new Car();
            var myCar11 = new Car();

            // when
            var parkingId1 = myParkingBoy.Park(myCar1);
            var parkingId2 = myParkingBoy.Park(myCar2);
            var parkingId3 = myParkingBoy.Park(myCar3);
            var parkingId4 = myParkingBoy.Park(myCar4);
            var parkingId5 = myParkingBoy.Park(myCar5);
            var parkingId6 = myParkingBoy.Park(myCar6);
            var parkingId7 = myParkingBoy.Park(myCar7);
            var parkingId8 = myParkingBoy.Park(myCar8);
            var parkingId9 = myParkingBoy.Park(myCar9);
            var parkingId10 = myParkingBoy.Park(myCar10);
            var parkingId11 = myParkingBoy.Park(myCar11);


            // then
            Assert.Equal(new Tuple<string, int>("testParking", 10000), parkingId1);
            Assert.Equal(new Tuple<string, int>("testParking", 10001), parkingId2);
            Assert.Equal(new Tuple<string, int>("testParking", 10002), parkingId3);
            Assert.Equal(new Tuple<string, int>("testParking", 10003), parkingId4);
            Assert.Equal(new Tuple<string, int>("testParking", 10004), parkingId5);
            Assert.Equal(new Tuple<string, int>("testParking", 10005), parkingId6);
            Assert.Equal(new Tuple<string, int>("testParking", 10006), parkingId7);
            Assert.Equal(new Tuple<string, int>("testParking", 10007), parkingId8);
            Assert.Equal(new Tuple<string, int>("testParking", 10008), parkingId9);
            Assert.Equal(new Tuple<string, int>("testParking", 10009), parkingId10);
            Assert.Equal(null, parkingId11);
        }

        [Fact()]
        public void Parking_UseSecondParkingSystem_WhenFirstZeroAvailable()
        {
            // given
            var myParkingBoy = new ParkingBoy(parkingSystems: new List<ParkingStation> { new ParkingStation("park01", 6), new ParkingStation("park02", 6) });
            var myCar1 = new Car();
            var myCar2 = new Car();
            var myCar3 = new Car();
            var myCar4 = new Car();
            var myCar5 = new Car();
            var myCar6 = new Car();
            var myCar7 = new Car();
            var myCar8 = new Car();
            var myCar9 = new Car();
            var myCar10 = new Car();
            var myCar11 = new Car();

            // when
            var parkingId1 = myParkingBoy.Park(myCar1);
            var parkingId2 = myParkingBoy.Park(myCar2);
            var parkingId3 = myParkingBoy.Park(myCar3);
            var parkingId4 = myParkingBoy.Park(myCar4);
            var parkingId5 = myParkingBoy.Park(myCar5);
            var parkingId6 = myParkingBoy.Park(myCar6);
            var parkingId7 = myParkingBoy.Park(myCar7);
            var parkingId8 = myParkingBoy.Park(myCar8);
            var parkingId9 = myParkingBoy.Park(myCar9);
            var parkingId10 = myParkingBoy.Park(myCar10);
            var parkingId11 = myParkingBoy.Park(myCar11);


            // then
            Assert.Equal(new Tuple<string, int>("park01", 10000), parkingId1);
            Assert.Equal(new Tuple<string, int>("park01", 10001), parkingId2);
            Assert.Equal(new Tuple<string, int>("park01", 10002), parkingId3);
            Assert.Equal(new Tuple<string, int>("park01", 10003), parkingId4);
            Assert.Equal(new Tuple<string, int>("park01", 10004), parkingId5);
            Assert.Equal(new Tuple<string, int>("park01", 10005), parkingId6);
            Assert.Equal(new Tuple<string, int>("park02", 10000), parkingId7);
            Assert.Equal(new Tuple<string, int>("park02", 10001), parkingId8);
            Assert.Equal(new Tuple<string, int>("park02", 10002), parkingId9);
            Assert.Equal(new Tuple<string, int>("park02", 10003), parkingId10);
            Assert.Equal(new Tuple<string, int>("park02", 10004), parkingId11);
        }

        [Fact()]
        public void Pick_ReturnNull_WhenInvalidNumber()
        {
            // given
            var myParkingBoy = new ParkingBoy();
            var myCar1 = new Car();
            var myCar2 = new Car();
            var myCar3 = new Car();

            // when
            var parkingId1 = myParkingBoy.Park(myCar1);
            var parkingId2 = myParkingBoy.Park(myCar2);
            var parkingId3 = myParkingBoy.Park(myCar3);
            var myCar = myParkingBoy.Pick(new Tuple<string, int>("Invalid", 11000));

            // then
            Assert.Equal(null, myCar);
        }

        [Fact()]
        public void Pick_ReturnNull_WhenNoCar()
        {
            // given
            var myParkingBoy = new ParkingBoy();

            // when
            var myCar = myParkingBoy.Pick(new Tuple<string, int>("park", 11000));

            // then
            Assert.Equal(null, myCar);
        }

    }
}