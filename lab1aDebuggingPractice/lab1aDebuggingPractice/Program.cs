using System;

namespace lab1aDebuggingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch(Exception e)
            {
                Console.WriteLine("Oops! Looks like you made a mistake somewhere.");
                Console.WriteLine(e.Message);
            }
        }

        static void StartSequence()
        {
            try
            {
                // Get a number from the user
                Console.WriteLine("Please enter a number greater than zero.");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                // Make an array of integers that's the same length as the users number
                int[] numberArr = new int[userNumber];

                // Input numbers into your new array
                Populate(numberArr);

                // Get the sum of all numbers
                int sum = GetSum(numberArr);

                // Get the product of the sum and an index value of the users choosing
                int prod = GetProduct(numberArr, sum);

                // Divide our product by a number the user enters.
                decimal quot = GetQuotient(prod);

                Console.WriteLine($"Your array length is {userNumber}");
                Console.WriteLine($"The numbers of your array are {string.Join(",",numberArr)}");
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {prod / sum} = {prod}");
                Console.WriteLine($"{prod} / {prod / quot} = {quot}");
                Console.WriteLine("Program is complete.");

            }
            catch (FormatException)
            {
                Console.WriteLine("The format is wrong! I don't know how though.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The thing is overflowing! Also I don't know what thing.");
            }
        }

        static void Populate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter a number: {i} of {arr.Length}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i=0; i<arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum<20)
            {
                throw new Exception($"Value of {sum} is too low.");
            }
            return sum;
            }

        static int GetProduct(int[] arr, int sum)
        {
            try
            {
            Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
            int product = sum * arr[Convert.ToInt32(Console.ReadLine())-1];
            return product;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }

        static decimal GetQuotient(int prod)
        {
            try
            {
            Console.WriteLine($"Please enter a number to divide your product {prod} by");
            decimal quot = decimal.Divide(prod, Convert.ToInt32(Console.ReadLine()));
            return quot;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
        }
    }

