﻿using System;
namespace HelloWorld
{
    public class Calculator
    {
        public Calculator()
        {
        }
        public int Add(int left, int right)
        {
            return left + right;
        }
        public int Subtract(int left, int right)
        {
            return left - right;
        }

        public int Multiply(int left, int right){
            return left * right;
        }
    
        public int Division(int left, int right){
            if (right == 0){
                return 0;
            }
            return left / right;
        }

        public int Modulus(int left, int right){
            return left % right;
        }


    }
}
