﻿using System;

namespace DoubleConversion
{
    public class DoubleToBinary
    {
        /// <summary>
        /// Method converts number wtih floating point into binary form with double precision.
        /// </summary>
        /// <param name="inputDouble"> Double number to parse </param>
        /// <returns> String with binary form of input number </returns>
        public static string Convert(double inputDouble)
        {
            string signString = "", exponentString = "", mantissaString = "";
            int count = 0;
            long exponentInt;
            bool firstZero = true;

            if (inputDouble < 0)
            {
                signString += "1";
                inputDouble = -inputDouble;
            }
            else
            {
                signString += "0";
            }

            exponentInt = (long)inputDouble;
            inputDouble = inputDouble - exponentInt;
            
            while (exponentInt / 2 > 0)
            {
                if (!firstZero)
                {
                    if (exponentInt % 2 == 0)
                    {
                        mantissaString += "0";
                    }
                    else
                    {
                        mantissaString += "1";
                    }
                }
                else
                {
                    if (exponentInt % 2 != 0)
                    {
                        mantissaString += "1";
                        firstZero = false;
                    }
                }
                exponentInt /= 2;
                count++;
            }

            char[] temp = mantissaString.ToCharArray();
            Array.Reverse(temp);
            mantissaString = new string(temp);

            while (inputDouble != 0 && mantissaString.Length < 52)
            {
                inputDouble *= 2;
                if (inputDouble >= 1)
                {
                    mantissaString += "1";
                    --inputDouble;
                }
                else
                {
                    mantissaString += "0";
                }
            }

            exponentInt = count + 1023;

            firstZero = true;

            while (exponentInt / 2 > 0)
            {
                if (!firstZero)
                {
                    if (exponentInt % 2 == 0)
                    {
                        exponentString += "0";
                    }
                    else
                    {
                        exponentString += "1";
                    }
                }
                else
                {
                    if (exponentInt % 2 != 0)
                    {
                        firstZero = false;
                        exponentString += "1";
                    }
                }
                exponentInt /= 2;
            }
            exponentString += "1";

            temp = exponentString.ToCharArray();
            Array.Reverse(temp);
            exponentString = new string(temp);

            for (int i = exponentString.Length; i < 11; i++)
            {
                exponentString += "0";
            }
            for (int i = mantissaString.Length; i < 52; i++)
            {
                mantissaString += "0";
            }

            return signString + exponentString + mantissaString;
        }
    }
}
