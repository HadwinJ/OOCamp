using Xunit;
using CarParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Tests
{
    public class ParkingDirectorTests
    {
        [Fact()]
        public void ParkingDirectorTest()
        {
            var parkingDirector = new ParkingDirector();
            Assert.NotNull(parkingDirector);
        }

        [Fact()]
        public void Report_Default()
        {
            // Arrange
            var parkingDirector = new ParkingDirector();

            // Act
            var outputReport = parkingDirector.Report();
            var reportInLines = outputReport.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert
            Assert.Equal("停车场编号：Park01", reportInLines[0]);
            Assert.Equal("\t车位数：10", reportInLines[1]);
            Assert.Equal("\t空位数：10", reportInLines[2]);
            Assert.Equal("停车场编号：Park02", reportInLines[3]);
            Assert.Equal("\t车位数：10", reportInLines[4]);
            Assert.Equal("\t空位数：10", reportInLines[5]);
        }

        [Fact()]
        public void Report_WithParkingBoy()
        {
            // Arrange
            var parkingDirector = new ParkingDirector();
            var parkingBoy = new ParkingBoy("TestParkingBoy", new List<ParkingStation>
            {
                //new ParkingStation("Boy's ParkingStation 01", 3),
                new ParkingStation("Boy's ParkingStation 02", 5),
                new ParkingStation("Boy's ParkingStation 05", 7)
            });
            parkingDirector.AddParkingBoy(parkingBoy);

            // Act
            var outputReport = parkingDirector.Report();
            var reportInLines = outputReport.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert
            Assert.Equal("停车场编号：Park01", reportInLines[0]);
            Assert.Equal("\t车位数：10", reportInLines[1]);
            Assert.Equal("\t空位数：10", reportInLines[2]);
            Assert.Equal("停车场编号：Park02", reportInLines[3]);
            Assert.Equal("\t车位数：10", reportInLines[4]);
            Assert.Equal("\t空位数：10", reportInLines[5]);
            Assert.Equal("停车仔编号：TestParkingBoy", reportInLines[6]);
            Assert.Equal("\t停车场编号：Boy's ParkingStation 02", reportInLines[7]);
            Assert.Equal("\t\t车位数：5", reportInLines[8]);
            Assert.Equal("\t\t空位数：5", reportInLines[9]);
            Assert.Equal("\t停车场编号：Boy's ParkingStation 05", reportInLines[10]);
            Assert.Equal("\t\t车位数：7", reportInLines[11]);
            Assert.Equal("\t\t空位数：7", reportInLines[12]);
            Assert.Equal("\tTotal车位数：12", reportInLines[13]);
            Assert.Equal("\tTotal空位数：12", reportInLines[14]);
        }



    }
}