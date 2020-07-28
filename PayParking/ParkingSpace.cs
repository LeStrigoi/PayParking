using System;
using System.Collections.Generic;
using System.Text;

namespace PayParking
{
    public class ParkingSpace
    {
        public string PlateNumber { get; set; }
        /// <summary>
        /// The Lock Key is used as a token for the car owner. Only the one that parked the car should know the key and is allowed to leave the parking lot.
        /// </summary>
        public string LockKey { get; set; }

        /// <summary>
        /// The arrival time is used for billing
        /// </summary>
        public DateTime ArrivalTime { get; set; }

    }
}
