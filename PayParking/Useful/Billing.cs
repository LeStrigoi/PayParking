using System;
using System.Collections.Generic;
using System.Text;

namespace PayParking.Useful
{
    public static class Billing
    {
        private const int _initialTax = 10;
        private const int _tax = 5;
        public static string PrintBill(string id,DateTime startTime,DateTime endTime)
        {
            int sum = ((endTime-startTime).Hours - 1) * _tax + _initialTax;
            return ("$Plate number: {id}/n Arrival time: {startTime}/n Departure time: {endTime}/n Sum to pay: {sum}");
        }
    }
}
