using System;

namespace DISAssignment1
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 5, b = 15;
			printPrimeNumbers(a, b);

			double result = getSeriesResult(5);
			Console.WriteLine("result is {0}",result);

			long decimalnumber = 15;
			long binaryValueofNumber = decimalToBinary(decimalnumber);
			Console.WriteLine("Binary Value of decimal number {0} is {1}",decimalnumber,binaryValueofNumber);

			long binarynumber = 1111;
			long decimalvaluefnumber = binaryToDecimal(binarynumber);
			Console.WriteLine("Decimal Value of binary number {0} is {1}", binarynumber, decimalvaluefnumber);

			int n = 5;
			printTriangle(n);

			int[] numbers = {1,2,3,2,2,1,3,2};
			computeFrequency(numbers);

			Console.WriteLine("Press any key to exit");
			Console.ReadKey(true);

		}// end of main

		public static void printPrimeNumbers(int x, int y)
		{
			try
			{
				Console.WriteLine("Prime Numbers between {0} and {1} are", x, y);

				for (int i = x; i <= y; i++) // iterating the loop between the range of numbers entered
				{
					int numberoffactors = 0;   // intialising variable number of factors to store total number of factors of a number

					for (int a = 2; a <= i / 2; a++) /* checking whether the given number is divisble by any number from
						                             2 to half of the number , as greatest factor a number other than itself
													 can be half the number*/
					{
						if ((i % a) == 0)
							numberoffactors++; // if reminder is zero then incrementing numberoffactors as a new factor is found
					}
					if (numberoffactors == 0)   // checking whether number of factors is zero or not and printing prime numbers
						Console.Write(i + ", ");
				}
				Console.WriteLine();
			}
			catch
			{
				Console.WriteLine("An error occured");
			}
		} // end of printPrimeNumbers

		public static double getSeriesResult(int n)
		{
			double i = 1, positivesum = 0, negativesum = 0; // intialising loop control variable and positive,negative terms sum.
			try
			{
				while (i < n) // rotating the loop till we complete all the terms until the given numbers are reached.
				{
					if (i % 2 != 0)	// condition to check whether the term is odd or even.
						positivesum += (factorial(i) / ++i); /* calling factorial method to calculate the factorial value and
																summing all the postive values which are odd terms*/
					else
						negativesum -= (factorial(i) / ++i); /* calling factorial method to calculate the factorial value and
																summing all the negative values which are even terms*/
				}
			}
			catch
			{
				Console.WriteLine("An error occured while calculationg getSeriesResult");
			}
			return (positivesum + negativesum);  // summing both postive and negative values of the series and returning.
		} // end of getSeriesResult

		public static double factorial(double n)
		{
			if (n == 0)
				return 1; // returning 1 as 0! =1
			else
				return n * factorial(n - 1); /* This is a recursive method i.e., which calls itself
												for each call n*n-1*n-2*n-3---*1 is retruned by calling factorial(n-1)
												for every value of n until (n-1) becomes zero*/
		} // end of factorial

		public static long decimalToBinary(long n)
		{
			String strremainder = string.Empty;  // declaring an string and intialising with empty value.
			char[] array;						// decalring char array, it will be used to hold binary characters.
			try
			{
				long remainder;					// variable to hold remainder
				while (n>0)						// repeating the loop until n > 0 to find the remainder during each division
				{
					remainder = (n % 2);		// calculating remainder
					strremainder += remainder.ToString(); // converting the remainder to string and appending it to string.
					n = n / 2;					// setting n to n/2 to find remainder for next division
				}
			}
			catch
			{
				Console.WriteLine("An error occured while computing decimaltoBinary");
			}
			array = strremainder.ToCharArray();  // converting string containing binary value to char array
			Array.Reverse(array);				 /* as the binary digits are in reverse order in char array 
													,reversing char array to get correct order of binary digits*/

			String Result = new string(array); // converting char array contating proper sequence of binary digits to string.
			return long.Parse(Result); //parsing string to long
		} // end of decimalToBinary

		public static long binaryToDecimal(long n)
		{
			long decimalnumber = 0; 
			try
			{
				char[] array = n.ToString().ToCharArray();  // converting input binary value to array of characters
				for (int i=0; i<= (array.Length-1); i++)
				{
					int x = Convert.ToInt32(array[i].ToString());  // convert each binary char to int
					decimalnumber += x* calcTwoPower(array.Length-1-i); /* multiplying each binary digit with appropriate power of 2 
																			by calling calcTwoPower recursive function and adding it to same number */
				}
			}
			catch
			{
				Console.WriteLine("An error occured while computing binarytoDecimal");
			}
			return decimalnumber;  // returning  decimal value of binary number
		} //end of binaryToDecimal
		public static long calcTwoPower(int n)
		{
			if (n == 0)
				return 1;
			else
				return 2 * calcTwoPower(n - 1); /* recursively calling the same function to return power of 2, 2*2*--*n
												depending upon the n value passed to the function */
		} //end of twopower

		public static void printTriangle(int n)
		{
			try
			{
				int rows = 5;   // number of rows that needs to be there in traingle
				int emptyspaces, startpoint;  // intialising emptyspace which is used to create spaces and startpoint which defines the beginning of *
				for (int i = 1; i <= rows; i++) // Indicates the number of rows in trinagle
				{
					for (emptyspaces = 1; emptyspaces <= (rows-i); emptyspaces++) // creating empty spaces after which * starts  
						Console.Write(" ");
					for (startpoint = 1; startpoint <= i; startpoint++) // printing half of the *'s  and one additional * in each row
						Console.Write('*');
					for (startpoint = (i - 1); startpoint >= 1; startpoint--) /*prints remaining *'s , as each row has odd number of *'s  
																				it prints half of *'s minus one * and completes the row*/
					Console.Write('*');
					Console.WriteLine("\r\n");    // \r\n prints one extra empty line on console
				}
			}
			catch
			{
				Console.WriteLine("An error occured while computing printTriangle");
			}
		} //end of printTriangle

		public static void computeFrequency(int[] a)
		{
			int[] frequency = new int[a.Length]; // intialising array called frequency with length same as input array to store freq of numbers
			int count;   // variable used to calculate frequency of each number in array
			Console.WriteLine("Number" + " " + "Frequency");
			try
			{
				for (int i = 0; i < a.Length; i++)
				{
					frequency[i] = -1;    // intialising all the elements of freqency array with -1 value using a for loop
				}
				for (int i=0; i<a.Length; i++) // loop to calculate ferquency
				{
					count = 1;  // intialising count with 1 as every number is present once in array (number itself)
					for (int x=i+1; x<a.Length; x++) /* loop to compare the array elements , 
														it starts comparison from the next element to the current element in loop*/
					{
						if (a[i] == a[x]) // checking whether the elements are equal or not
						{
							count++; // increasing the count by 1 whenever one such element is found 
							frequency[x] = 0;  /* setting the frequency of the elements which are equal to	
											    current loop element as it helps in printing frequencies and
												anyways as the numbers are same if we assign frequency to first element of such group 
												it would suffice our requirement */
						}
					}
					if (frequency[i] != 0) // checking whether frequency!=0, repeated elements other than first element in group will have 0 freq.
					{
						frequency[i] = count; // assigning the count to frequency
						Console.WriteLine(a[i] + "    " + frequency[i]); // printing numbers and their corresponding frequency
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("An error occured while computing computeFrequency and the error message is "+ex.Message);
			}
		} //end of computeFrequency
	}
}
