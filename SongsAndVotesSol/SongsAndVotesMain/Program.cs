using System;
using SongsAndVotesCommon;


namespace SongsAndVotesMain
{



    public class Program
    {

        public static void Main(string[] args)
        {

            // Test the user repo.
            //UserRepoTest.LaunchTestSuite();
            UserRepo.Start();
            Console.ReadKey(true);
        }
    }
}
