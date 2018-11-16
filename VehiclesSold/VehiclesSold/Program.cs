/* Author: Steven Mitchell
 * Date: November 14 2018
 * Program Name: Vehicles Sold
 * Program Description: Allows user to enter number of vehicles sold each day of the week and displays numbers with average 
 *                      number of vehicles sold per day, highest number of vehicles sold, and lowest number of vehicles sold
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesSold
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program name displayed on console window
            Console.Title = "Vehicles Sold";

            //Constants
            const int minNumber = 0;    //Minimum allowable entry
            const int maxNumber = 50;   //Maximum allowable entry
            
            //Variables
            int[] vehiclesSold = new int[7];        //Array that hold the number of vehicles sold on each day of the week
            int[] days = { 1, 2, 3, 4, 5, 6, 7 };   //Array containing the numbers of the days of the week
            int dailySales;                         //Number of sales on each individual day of the week
            int highestDay = 0;                     //Day with the highest number of vehicles sales
            int highest = 0;                        //Most vehicles sold during the week
            bool repeat = true;                     //True/False value for whether user would like to run program again
            bool isValid;                           //True/False value for testing whether user entry is valid
                                      
            
            //Loops program if condition is met
            do
            {
                double average = 0; //Average number of vehicles sold per day
                int lowestDay = 0;  //Day with the lowest number of vehicle sales
                int lowest = 50;    //Least vehicles sold during the week

                //Clears the console
                Console.Clear();

                //Sets count to 1
                //Runs loop while count is less than or equal to the lengh of vehiclesSold array
                //Increments count by 1 each iteration
                for (int count = 1; count <= vehiclesSold.Length; count++)
                {
                    //Runs loop as long as user input is not valid
                    do
                    {
                        //Prompts user for entry
                        Console.Write("Please enter the number of vehicles sold on day {0}: ", count);
                        //Checks that user entry is valid
                        isValid = int.TryParse(Console.ReadLine(), out dailySales);
                        
                        //If user entry is not a valid whole number between 0 and 50
                        if(!isValid || dailySales < minNumber || dailySales > maxNumber)
                        {
                            //Changes text colour to red
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Displays error message
                            Console.WriteLine("Error: Entry must be a numeric whole number between {0} and {1}", minNumber, maxNumber);
                            //Changes text colour back to gray
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                    } while (!isValid || dailySales < minNumber || dailySales > maxNumber);//Condition to be checked before running loop again

                    //Places user input into the current array index
                    vehiclesSold[count - 1] = dailySales;
                }
                
                //Sets count2 to 0
                //Runs loop while count2 is less than the lenght of the vehiclesSold array
                //increments count2 on each iteration
                for (int count2 = 0; count2 < vehiclesSold.Length; count2++)
                {
                    //If the value stored in the current vehiclesSold array index is less than the current lowest number
                    if (vehiclesSold[count2] < lowest)
                    {
                        //Makes the lowest variable equal to the new lowest number
                        lowest = vehiclesSold[count2];
                        //makes the lowestDay variable equal to the value stored in the current days array index
                        lowestDay = days[count2];
                    }

                    //If the value stored in the current vehiclesSold array index is greater than the highest number
                    if (vehiclesSold[count2] > highest)
                    {
                        //Makes the highest variable equal to the new highest number
                        highest = vehiclesSold[count2];
                        //Makes the highestDay vriable equal to the value stored in the current days array index
                        highestDay = days[count2];
                    }
                }

                //Runs through each element in the vehiclesSold array
                foreach (int element in vehiclesSold)
                {
                    //Adds together the value of the average variable and the element
                    average += element;
                }

                //Calculates average by dividing the total number of vehicles sold by the number of days
                average = average / vehiclesSold.Length;

                //Rounds average to a single decimal place when needed
                average = Math.Round(average, 0);

                //Clears the console
                Console.Clear();

                //Banner at the top of the console
                Console.WriteLine(@"=================================================================
                          VEHICLES SOLD
-----------------------------------------------------------------");

                //Sets count3 to 0
                //Runs loop while count3 isless than the length of the days array
                //increments count3 on each iteration
                for (int count3 = 0; count3 < days.Length; count3++)
                {
                    //Displays the each day of the week with the number of vehicles sold on those days
                    Console.Write(@"  D{0}: {1:00} ", days[count3], vehiclesSold[count3]);
                }

                //Bottom line of the banner
                Console.WriteLine(@"
-----------------------------------------------------------------");

                //Displays the average number of vehicles sold on each day of the week
                Console.WriteLine("\nThe average number of vehicles sold per day was {0} vehicles.", average);

                //Displays the day on which the most vehicles were sold
                Console.WriteLine("The highest number of vehicles sold on day {0}", highestDay);

                //Displays the day on which the least vehicles were sold
                Console.WriteLine("The lowest number of vehicles sold on day {0}", lowestDay);
                
                //Asks user if they would like to input data for another week
                Console.WriteLine("\nWould you like to process another week?");
                Console.Write("\nPlease press [y] to continue or any other key to exit: ");
                repeat = Console.ReadKey().KeyChar == 'y';

            } while (repeat);//Condition to be checked before running program again
        }
    }
}
