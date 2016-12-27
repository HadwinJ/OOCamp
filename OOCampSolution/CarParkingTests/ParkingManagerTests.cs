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
        public void Test_OK()
        {
            var parkingManager = new ParkingManager();
            Assert.True(true);
        }

        [Fact()]
        public void ParkingAndPickingBack()
        {
            var car1 = new Car();

            var myParkingBoy = new ParkingBoy(parkingSystems: new List<ParkingStation> {
                new ParkingStation("Station3"),
                new ParkingStation("Station4")
            });
            var myParkingManager = new ParkingManager();

            myParkingManager.AddParkingBoy(myParkingBoy);
            var parkingId = myParkingManager.Park(car1);

            var myReceiving = myParkingManager.Pick(parkingId);

            Assert.Equal<Car>(car1, myReceiving);
            Assert.Equal(new Tuple<string, int>("Station3", 10000), parkingId);
        }

        [Fact()]
        public void ArrangeParkingBoy_ParkingAndPickingBack()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();


            var myParkingBoy = new ParkingBoy(parkingSystems : new List <ParkingStation> {
                new ParkingStation("Station3", 3),
                new ParkingStation("Station4", 2)
            });

            var smartParkingBoy = new SmartParkingBoy(parkingSystems : new List <ParkingStation> {
                new ParkingStation("Station5", 3),
                new ParkingStation("Station6", 5)
            });

            var myParkingManager = new ParkingManager();

            myParkingManager.AddParkingBoy(myParkingBoy);
            myParkingManager.AddParkingBoy(smartParkingBoy);

            // Act
            var parkingId1 = myParkingManager.Park(car1, myParkingBoy);
            var parkingId2 = myParkingManager.Park(car2, smartParkingBoy);

            var pickbackCar1 = myParkingManager.Pick(parkingId1);
            var pickbackCar2 = myParkingManager.Pick(parkingId2);

            // Assert
            Assert.Equal<Car>(car1, pickbackCar1);
            Assert.Equal(new Tuple<string, int>("Station3", 10000), parkingId1);

            Assert.Equal<Car>(car2, pickbackCar2);
            Assert.Equal(new Tuple<string, int>("Station6", 10000), parkingId2);
        }

        [Fact()]
        public void ShowInitialAvailableSpace()
        {
            // given
            var myParkingBoy = new ParkingBoy(parkingSystems: new List <ParkingStation> {
                new ParkingStation("Station3"),
                new ParkingStation("Station4")
            });
            var myParkingManager = new ParkingManager();
            myParkingManager.AddParkingBoy(myParkingBoy);

            // when

            // then
            Assert.Equal(40, myParkingManager.AvailableNumber);
        }

        [Fact()]
        public void ShowAvailableSpace()
        {
            // given
            var myCar = new Car();
            var myParkingBoy = new ParkingBoy(parkingSystems: new List <ParkingStation> {
                new ParkingStation("Station3"),
                new ParkingStation("Station4")
            });
            var myParkingManager = new ParkingManager();
            myParkingManager.AddParkingBoy(myParkingBoy);

            // when
            var parkingId = myParkingBoy.Park(myCar);

            // then
            Assert.Equal(39, myParkingManager.AvailableNumber);
        }

        [Fact()]
        public void ParkingBoy_MultipleAndPickingBackMultiple()
        {
            // Arrange
            var myCar1 = new Car();
            var myCar2 = new Car();
            var myCar3 = new Car();
            var myCar4 = new Car();
            var myCar5 = new Car();
            var myCar6 = new Car();
            var myCar7 = new Car();
            var myCar8 = new Car();
            var myCar9 = new Car();

            var myParkingBoy = new ParkingBoy(parkingSystems: new List <ParkingStation> {
                new ParkingStation("Station3", 3),
                new ParkingStation("Station4", 5)
            });
            var myParkingManager = new ParkingManager();

            myParkingManager.AddParkingBoy(myParkingBoy);

            // Act
            var parkingId1 = myParkingManager.Park(myCar1);
            var parkingId2 = myParkingManager.Park(myCar2);
            var parkingId3 = myParkingManager.Park(myCar3);
            var parkingId4 = myParkingManager.Park(myCar4);
            var parkingId5 = myParkingManager.Park(myCar5);
            var parkingId6 = myParkingManager.Park(myCar6);
            var parkingId7 = myParkingManager.Park(myCar7);
            var parkingId8 = myParkingManager.Park(myCar8);
            var parkingId9 = myParkingManager.Park(myCar9);

            var myReceiving1 = myParkingManager.Pick(parkingId1);
            var myReceiving2 = myParkingManager.Pick(parkingId2);
            var myReceiving3 = myParkingManager.Pick(parkingId3);
            var myReceiving4 = myParkingManager.Pick(parkingId4);
            var myReceiving5 = myParkingManager.Pick(parkingId5);
            var myReceiving6 = myParkingManager.Pick(parkingId6);
            var myReceiving7 = myParkingManager.Pick(parkingId7);
            var myReceiving8 = myParkingManager.Pick(parkingId8);
            var myReceiving9 = myParkingManager.Pick(parkingId9);

            // Assert
            Assert.Equal<Car>(myCar1, myReceiving1);
            Assert.Equal<Car>(myCar2, myReceiving2);
            Assert.Equal<Car>(myCar3, myReceiving3);
            Assert.Equal<Car>(myCar4, myReceiving4);
            Assert.Equal<Car>(myCar5, myReceiving5);
            Assert.Equal<Car>(myCar6, myReceiving6);
            Assert.Equal<Car>(myCar7, myReceiving7);
            Assert.Equal<Car>(myCar8, myReceiving8);
            Assert.Equal<Car>(myCar9, myReceiving9);

            Assert.Equal(new Tuple<string, int>("Station3", 10000), parkingId1);
            Assert.Equal(new Tuple<string, int>("Station3", 10001), parkingId2);
            Assert.Equal(new Tuple<string, int>("Station3", 10002), parkingId3);
            Assert.Equal(new Tuple<string, int>("Station4", 10000), parkingId4);
            Assert.Equal(new Tuple<string, int>("Station4", 10001), parkingId5);
            Assert.Equal(new Tuple<string, int>("Station4", 10002), parkingId6);
            Assert.Equal(new Tuple<string, int>("Station4", 10003), parkingId7);
            Assert.Equal(new Tuple<string, int>("Station4", 10004), parkingId8);
            Assert.Equal(new Tuple<string, int>("Park01", 10000), parkingId9);
        }

    }
}