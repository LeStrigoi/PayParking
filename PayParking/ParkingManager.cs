using System;
using CommandDotNet;
using PayParking.Useful;

namespace PayParking
{
    public class ParkingManager
    {

        private readonly ParkingOperations _parkingOperations;

        public ParkingManager(ParkingOperations operations)
        {
            _parkingOperations = operations;
        }

        [Command(Description = "Lists all the cars")]
        public void ListCars()
        {
            foreach (var car in _parkingOperations.OccupiedSpaces)
            {
                Console.WriteLine(car.PlateNumber);
            }
        }

        [Command(Description = "Lists the number of vacant lots")]
        public void VacantLots()
        {
            Console.WriteLine("Vacant lots: " + _parkingOperations.VacantLots);
        }


        [Command(Description = "Allocates the car a parking lot in case of vacancies")]
        public void StartParking(string plateNumber)
        {
            //Generate a key
            string key = new Random().Next(0, 100).ToString();
            string result= _parkingOperations.AddCar(plateNumber,String.Concat(key,plateNumber));

            if (result == Warnings.Succes)
            {
                Console.WriteLine("Generated key for lock. This key will be used for removing the car from the parking lot. Please write it down!");
                Console.WriteLine("Unlocking Key: " + key);

            }
            Console.WriteLine(result);
        }


        [Command(Description = "Deallocates the car")]
        public void StopParking(string plateNumber)
        {
            DateTime arrivalTime = DateTime.Now;
            Console.WriteLine("Please introduce unlocking key:");
            var key = Console.ReadLine();

            string result= _parkingOperations.RemoveCar(plateNumber, key, ref arrivalTime);

            if (result == Warnings.Succes)
            {
                string billingData = Billing.PrintBill(plateNumber, arrivalTime, DateTime.Now);
                Console.WriteLine(billingData);
            }
            Console.WriteLine(result);
        }

    }
}
