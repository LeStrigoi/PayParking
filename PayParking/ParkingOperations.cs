using PayParking.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayParking
{
    public class ParkingOperations
    {
        public List<ParkingSpace> OccupiedSpaces { get; set; } = new List<ParkingSpace>();
        public int Capacity { get; set; } = 10;

        public int VacantLots { get { return (Capacity-OccupiedSpaces.Count); } }


        public string AddCar(string plateNumber, string lockKey)
        {
            if (plateNumber == null || lockKey == null) return Warnings.Null;
            if (OccupiedSpaces.Count < Capacity)
            {
                if (OccupiedSpaces.FirstOrDefault(a => a.PlateNumber == plateNumber) == null)
                {
                    ParkingSpace park = new ParkingSpace() { PlateNumber = plateNumber, ArrivalTime = DateTime.Now, LockKey = lockKey};
                    OccupiedSpaces.Add(park);
                    return Warnings.Succes;
                }
                else
                {
                    return Warnings.Duplicate;
                }
            }
            else
            {
                return Warnings.FullParking;
            }
        }

        public string RemoveCar(string plateNumber,string key,ref DateTime arrivalTime)
        {
            if (plateNumber == null || key == null) return Warnings.Null;
            if (OccupiedSpaces.FirstOrDefault(a => a.PlateNumber == plateNumber) != null)
            {
                ParkingSpace car = OccupiedSpaces.FirstOrDefault(a => a.PlateNumber == plateNumber);
                if (car.LockKey == key)
                {
                    OccupiedSpaces.Remove(car);
                    arrivalTime = car.ArrivalTime;
                    return Warnings.Succes;
                }
                else
                {
                    return Warnings.InvalidKey;
                }
            }
            else
            {
                return Warnings.NoCar;
            }
        }



    }
}
