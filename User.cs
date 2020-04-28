
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Refactored
{
    class User
    {
        private string name;
        private int secretDigits;
        private bool isActive;
        private bool isNumberGuessed;
        private List<int> myPlayedDigits = new List<int>();

        //---------------------------------------------------------
        public const int NUM_OF_DIGITS_TO_BE_GUESSED = 4;
        static string promptUsername = "Enter your preferred username: ";
        static string promptSecretDigits = "Enter the secret digits: ";
        static string userCreated = " successfully created!";
        //-----------------------------------------------------

        //This will prevent the name to be changed after initialization by the constructor
        public string Name
        {
            get { return this.name; } 
        }

        public List<int> PlayedDigits
        {
            get { return this.myPlayedDigits; }
        }
        
        public int SecretDigits 
        {
            get { return this.secretDigits; } 
        }

        public bool IsActive 
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }

        public bool IsGuessed
        {
            get { return this.isNumberGuessed; }
            set { this.isNumberGuessed = value; }
        }
        
        public User(string name, int secretDigits)
        {
            this.name = name;
            this.secretDigits = secretDigits;
        }

        public static User CreateUser(string userToBeCreated)
        {
            Tools.ColorfulWriteLine(userToBeCreated, ConsoleColor.DarkYellow);
            string name = Operation.TextValidator(promptUsername);
            int secretDigits = Operation.NumberValidator(promptSecretDigits, NUM_OF_DIGITS_TO_BE_GUESSED, true);
            User user = new User(name, secretDigits);
            Tools.ColorfulWriteLine(user.Name + userCreated, ConsoleColor.Green);
            Console.WriteLine();

            return user;
        }

        public void Challenge(User opponent)
        {
            //Switch between the 2 players
            Console.WriteLine("{0} is active", this.Name);
            this.IsActive = false;
            opponent.IsActive = true;

            //Compare the numbers entered with the secret digits
            int digitsGuessed = Operation.NumberValidator($"Guess {opponent.Name}'s secret digits: ", NUM_OF_DIGITS_TO_BE_GUESSED);
            myPlayedDigits.Add(digitsGuessed); //Populate the list for future reference
            opponent.isNumberGuessed = Compare(digitsGuessed, opponent.secretDigits);

            Console.WriteLine();
        }

        static bool Compare(int firstNumber, int secondNumber)
        {
            int deadCounter = 0, injuredCounter = 0;
            string first = firstNumber.ToString();
            string second = secondNumber.ToString();

            for (int i = 0; i < first.Length; ++i)
            {
                for (int j = 0; j < second.Length; ++j)
                {
                    //To avoid multiple countings of 'dead' digits
                    if (first[i] == second[j])
                    {
                        if (first[i] == second[i])
                        {
                            deadCounter++;
                        }
                        else
                        {
                            injuredCounter++;
                        }
                    }
                }
            }

            if(deadCounter == 0 && injuredCounter == 0)
            {
                Tools.ColorfulWriteLine("That ain't the number");
            }
            else
            {
                if(deadCounter == first.Length)
                {
                    Tools.ColorfulWriteLine("All dead", ConsoleColor.Green);
                    return true;
                }
                else
                {
                    Tools.ColorfulWriteLine($"{deadCounter} dead, {injuredCounter} injured", ConsoleColor.Yellow);
                }
            }
            return false;
        }
    }    
}

