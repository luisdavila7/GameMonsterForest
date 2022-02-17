using System;
using GameMonsterForest.Classes;

namespace GameMonsterForest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Luis",150);
            int round = 0;

            while (round < 50)
            {
                Console.WriteLine(player.ToString());
                System.Threading.Thread.Sleep(1000);

                player.Heal();
                player.Explore();

                if (player.IsDead())
                {
                    Message.Danger("GAME OVER!!");
                    break;
                }
                round++;
            }
            if (!player.IsDead())
            {
                Message.Success("YOU ARE WINNER");
            }
            Console.Read();

        }
    }
}
