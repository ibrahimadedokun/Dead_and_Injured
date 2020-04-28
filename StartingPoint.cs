
using System;

namespace Refactored
{
    class StartingPoint
    {
        static string promptUsername = "Enter your preferred username: ";
        static string promptSecretDigits = "Enter the secret digits: ";
        static int digitsToBeGuessedLength = 4;
        static string userCreated = " successfully created!";

        static void Main()
        {
            User PlayerOne = CreateUser("PLAYER ONE");
            User PlayerTwo = CreateUser("PLAYER TWO");            

            Console.ReadKey();
        }

        static User CreateUser(string userToBeCreated)
        {
            Tools.ColorfulWriteLine(userToBeCreated, ConsoleColor.DarkYellow);
            string name = Operation.TextValidator(promptUsername);
            int secretDigits = Operation.NumberValidator(promptSecretDigits, digitsToBeGuessedLength, true);
            User user = new User(name, secretDigits);
            Tools.ColorfulWriteLine(user.Name + userCreated, ConsoleColor.Green);
            Console.WriteLine();

            return user;
        }

    }
}

