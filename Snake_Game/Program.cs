using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game;

namespace Program
{
    public class MainGame
    {
       
        static void Main(string[] args)
        {
            var game = new GameMechanics();
            

            Console.WriteLine("Welcome To The Snake Game");
            Console.WriteLine();
            Console.WriteLine("Let's Play!");

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Score: {game.score}");
                game.InitializeGrid();
                game.MoveSnake();

            }
        
        }
    }
}
