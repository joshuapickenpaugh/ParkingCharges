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
                //Exits loop, then calculates:
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
            //Reset customer counter:
            x = 1;
            lstCustomers = CalculateCharges(lstCustomers);

            Console.WriteLine("________________________________________________________");

            //Outputs:
            foreach (double charge in lstCustomers)
            {
                Console.WriteLine("Customer " + x +": " + string.Format("${0:0.00}", charge));
                x = x + 1;
            }

            Console.WriteLine("_____________________________");
            Console.WriteLine("Hit any key to close program.");
            Console.ReadKey();
        }

        //Calculates charges:
        public static List<double> CalculateCharges(List<double> lstCusts)
        {
            //Holds current charges:
            List<double> lstCharges = new List<double>();

            //Constants:
            const double MIN_CHARGE_3_HOURS = 2.00;
            const double EACH_ADDITIONAL_HOUR = 0.50;

            //Iterates through list, calculates charges:
            foreach (double customer in lstCusts)
            {

                //Under three hours parked:
                if (customer <= 3.0)
                {
                    lstCharges.Add(MIN_CHARGE_3_HOURS);
                }
                //Over three hours parked:
                else
                {
                    //Holds leftover time over 3 hours:
                    double dblLeftover = customer - 3.0;

                    //Formats leftover amount so it can be split:
                    string strCustomer = string.Format("{0:#,###0.00}", dblLeftover);

                    //Splits the leftover double into two numbers:
                    var varLeftover = strCustomer.ToString().Split('.');
                    double dblFirstPart = double.Parse(varLeftover[0]);
                    double dblSecPart = double.Parse(varLeftover[1]);

                    //Calculates for the whole number:
                    dblFirstPart = dblFirstPart * EACH_ADDITIONAL_HOUR;

                    //Calculates for the decimal (anything larger than zero gets charged 
                    //the whole amount):
                    if (dblSecPart > .0)
                    {
                        dblSecPart = EACH_ADDITIONAL_HOUR;
                    }

                    //Totals:
                    double dblTotalCharge = dblFirstPart + dblSecPart + MIN_CHARGE_3_HOURS;

                    //Max charge per day is $10.00, and no one can park 
                    //longer than a 24-hour period:
                    if (dblTotalCharge >= 10.00)
                    {
                        dblTotalCharge = 10.00;
                    }

                    //Adds to list:
                    lstCharges.Add(dblTotalCharge);
                }
            }
            return lstCharges;
        }
    }
}
