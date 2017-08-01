//Joshua Pickenpaugh
//August 1st, 2017
//Parking Charges

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCharges
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables:
            int intInfiniteLoop = 0;
            int x = 1;
            List<double> lstCustomers = new List<double>();
            string strCustomer;
            double dblCustomer = 0;

            //Message:
            Console.WriteLine("Enter each customer's hours parked, or type '.' to quit:");
            Console.WriteLine("________________________________________________________");

            //Loop for user input:
            while (intInfiniteLoop == 0)
            {               
                Console.Write("Enter Customer " + x + " total hours parked: ");
                x = x + 1;

                strCustomer = Console.ReadLine();
                if (strCustomer == ".")
                {
                    intInfiniteLoop = 1;
                    goto Finish;
                }
                else
                {
                    dblCustomer = Convert.ToDouble(strCustomer);
                    lstCustomers.Add(dblCustomer);
                }                
            }

            Finish:
            lstCustomers = CalculateCharges(lstCustomers);


            Console.WriteLine("END OF PROGRAM.");


        }

        //Calculates charges:
        public static List<double> CalculateCharges(List<double> lstcusts)
        {
            List<double> lstcharges = new List<double>();

            const double MIN_CHARGE_3_HOURS = 2.00;
            const double EACH_ADDITIONAL_HOUR = 0.50;

            foreach (double customer in lstcusts)
            {
                if (customer <= 3.0)
                {
                    lstcharges.Add(2.00);
                }
                else
                {
                    double leftover;
                    leftover = customer - 3.0;
                    leftover * 

                }
            }
            return lstcharges;
        }
    }
}
