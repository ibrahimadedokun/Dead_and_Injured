
using System;

namespace Refactored
{
    class StartingPoint
    {
        static void Main()
        {
            User PlayerOne = User.CreateUser("PLAYER ONE");
            User PlayerTwo = User.CreateUser("PLAYER TWO");

            while(!PlayerOne.IsGuessed && !PlayerTwo.IsGuessed)
            {
                if (PlayerTwo.IsActive)
                {
                    PlayerTwo.Challenge(PlayerOne);
                }
                else
                {
                    PlayerOne.Challenge(PlayerTwo);
                }
            }
            Console.ReadKey();
        }        
    }
}

