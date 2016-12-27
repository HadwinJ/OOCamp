using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingDirector : ParkingManager
    {
        public string Report()
        {
            var report = new StringBuilder();
            foreach (var parkingStation in ParkingStations)
            {
                report.AppendLine("停车场编号：" + parkingStation.Name);
                report.AppendLine("\t车位数：" + parkingStation.TotalCapacity);
                report.AppendLine("\t空位数：" + parkingStation.AvailableNumber);
            }
            foreach (var parkingBoy in _parkingBoyList)
            {
                report.AppendLine("停车仔编号：" + parkingBoy.Name);
                foreach (var parkingStation in parkingBoy.ParkingStations)
                {
                    report.AppendLine("\t停车场编号：" + parkingStation.Name);
                    report.AppendLine("\t\t车位数：" + parkingStation.TotalCapacity);
                    report.AppendLine("\t\t空位数：" + parkingStation.AvailableNumber);
                }
                report.AppendLine("\tTotal车位数：" + parkingBoy.ParkingStations.Sum(ps=>ps.TotalCapacity));
                report.AppendLine("\tTotal空位数：" + parkingBoy.AvailableNumber);
            }
            // return "hello world \n2nd line \r\n3rd line ";
            return report.ToString();
        }
    }
}
