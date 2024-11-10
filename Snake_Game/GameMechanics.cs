using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class GameMechanics
    {
        Random random = new Random();
        Coord gridDimensions = new Coord(50, 20);

        Coord snakePos = new Coord(10, 1);
        Direction movementDirection = Direction.Down;
        List<Coord> snake = new List<Coord>();
        int tailLength = 1;

        int frameDelayMilli = 100;
        public int score = 0;
        Coord applePos;

        public GameMechanics()
        {
            applePos = new Coord(
                random.Next(1, gridDimensions.X - 1),
                random.Next(1, gridDimensions.Y - 1));
        }
       
        // To Initialize the board
        public void InitializeGrid()
        {
            for (int y = 0; y < gridDimensions.Y; y++)
            {
                for (int x = 0; x < gridDimensions.X; x++)
                {
                    Coord currentCoord = new Coord(x, y);

                    if (snakePos.Equals(currentCoord) || snake.Contains(currentCoord))
                        Console.Write("■");
                    else if (applePos.Equals(currentCoord))
                        Console.Write("a");
                    else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
        
        public void MoveSnake()
        {
            // The snakes initial movement
            snakePos.ApplyMovementDirection(movementDirection);

            // Handles the Eating as the snake moves around
            if (snakePos.Equals(applePos))
            {
                tailLength++;
                score++;
                applePos = new Coord(
                    random.Next(1, gridDimensions.X - 1),
                    random.Next(1, gridDimensions.Y - 1));
            }
            else if(snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimensions.X - 1 ||
        snakePos.Y == gridDimensions.Y - 1 || snake.Contains(snakePos))
            {
                score = 0;
                tailLength = 1;
                snakePos = new Coord(10, 1);
                snake.Clear();
                movementDirection = Direction.Down;
                
            }

            snake.Add(new Coord(snakePos.X, snakePos.Y));

            if(snake.Count > tailLength)
            {
                snake.RemoveAt(0);
            }

            DateTime time = DateTime.Now;

            while((DateTime.Now - time).Milliseconds < frameDelayMilli)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            movementDirection = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            movementDirection = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            movementDirection = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            movementDirection = Direction.Down;
                            break;
                    }
                }
            }
                    
        }

    }
}
