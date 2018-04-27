﻿﻿﻿using System;
namespace HelloWorld
{
    public class Runner
    {
        public Runner()
        {
        }

        public void Run()
        {
			Console.WriteLine("Hello World!");
			Console.WriteLine("This is line 2");
			Console.WriteLine("This is line 3");
            Console.WriteLine("This is a change to Runner by User 1");
            Console.WriteLine("This change was made by user 2");
            Console.WriteLine("User 1 made this change");
            Console.WriteLine("Let's add this in terminal");

            var calculator = new Calculator();
            int sum = calculator.Add(5, 7);
            Console.WriteLine(sum);

            Console.WriteLine($"The difference between 5 and 7 is {calculator.Subtract(5, 7)}");
            Console.WriteLine($"The product of 5 and 7 is {calculator.Multiply(5, 7)}");
			Console.WriteLine($"The quotient of 20 and 3 is {calculator.Division(20, 3)}");
			Console.WriteLine($"The modulus of 20 and 3 is {calculator.Modulus(20, 3)}");



		}
    }
}
