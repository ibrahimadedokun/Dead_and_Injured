﻿
using System;

namespace Refactored
{
    public class Operation
    {
        /// <summary>
        /// Verify text provided by user is not empty
        /// </summary>
        /// <param name="msg">Display message that tells user what needs to be entered</param>
        /// <returns></returns>
        public static string TextValidator(string msg)
        {
            Console.Write(msg);
            string input;
            do
            {
                input = ReadInput();
                if (input == "")
                {
                    Tools.ColorfulWrite("Enter a valid username: ");
                }
            }
            while (input == "");
            return input;
        }

        /// <summary>
        /// Validate user input is an integer of the required length
        /// </summary>
        /// <param name="numberLength">Length of the number to validate</param>
        /// <param name="isSecret">Set to true if digits are not to be displayed</param>
        /// <returns></returns>
        public static int NumberValidator(string msg, int numberLength, bool isSecret = false)
        {
            string option;
            int result;
            bool isNumberValid = false;
            Console.Write(msg);
            do
            {
                do
                {
                    if (isSecret == true)
                    {
                        option = MaskInput();
                    }
                    else
                    {
                        option = ReadInput();
                    }

                } while (IsRepeated(option));                              
                
                isNumberValid = int.TryParse(option, out result);
                if (isNumberValid != true)
                {
                    Tools.ColorfulWrite("Enter digits only: ");
                }
                else if (option.Length != numberLength)
                {
                    Tools.ColorfulWrite($"Enter {numberLength} digits: ");
                }
            }
            while (isNumberValid != true || option.Length != numberLength);
            return result;
        }

        static string ReadInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string input= Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        //I have adapted this masker() {password masking console application} from Stack Overflow
        //https://stackoverflow.com/questions/3404421/password-masking-console-application
        static string MaskInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string password = "";
            do
            {
                ConsoleKeyInfo press = Console.ReadKey(true);
                //Display * while any other key but Backspace and Enter are pressed
                if (press.Key != ConsoleKey.Backspace && press.Key != ConsoleKey.Enter)
                {
                    password += press.KeyChar; //Add the pressed character to the password string
                    Console.Write("*");
                }
                else
                {
                    //Delete characters respectively for the number of Backspace entered while a character is still being displayed
                    if (press.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (press.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("");
                        break;
                    }
                }
            } while (true);

            Console.ResetColor();
            return password;
        }

        static bool IsRepeated(string s)
        {
            bool status = false;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = (i + 1); j < s.Length; ++j)
                {
                    if (s[i] == s[j])
                    {
                        Tools.ColorfulWrite("Do not repeat digits: ");
                        return true;
                    }
                }
            }
            return status;
        }
    }
}
