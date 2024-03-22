using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public static void printBoard(char[,] board)
        {
            Console.WriteLine("    0 1 2");
            Console.WriteLine("  ———————");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " | ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static char hasWon(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != '-')
                    return board[i, 0];

                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[1, i] != '-')
                    return board[0, i];
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != '-')
                return board[0, 0];

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != '-')
                return board[0, 2];

            return '-';
        }

        public static bool hasTied(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                        return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            char[,] board = { { '-','-','-'},
                              { '-','-','-'},
                              { '-','-','-'} };

            Console.WriteLine("Hello! Are you ready to play Tic Tac Toe? (yes/no)");
            string answer = Console.ReadLine();
            if (answer == "yes" || answer == "Yes")
                Console.WriteLine("Cool. Let's start then!");
            else
            {
                Console.WriteLine("Okay, we will play next time!");
                return;
            }

            Console.WriteLine("Player 1, what's your name?");
            string name1 = Console.ReadLine();

            Console.WriteLine("Player 2, what's your name?");
            string name2 = Console.ReadLine();

            Random random = new Random();
            char playerTurn = (random.Next(0, 2) == 0) ? 'X' : 'O';

            int row, col;

            while (true)
            {
                printBoard(board);
                Console.WriteLine((playerTurn == 'X' ? name1 : name2) + "'s turn (" + playerTurn + "):");

                Console.WriteLine("Enter a row (0, 1 or 2): ");
                if (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2)
                {
                    Console.WriteLine("Invalid input! Please enter a valid row (0, 1, or 2).");
                    continue;
                }

                Console.WriteLine("Enter a col (0, 1 or 2): ");
                if (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid input! Please enter a valid column (0, 1, or 2).");
                    continue;
                }

                if (board[row, col] != '-')
                {
                    Console.WriteLine("Someone has already made a move there!");
                    continue;
                }

                board[row, col] = playerTurn;
                playerTurn = (playerTurn == 'X') ? 'O' : 'X';

                char check = hasWon(board);
                if (check != '-')
                {
                    printBoard(board);
                    Console.WriteLine("Game over. " + ((check == 'X') ? name1 : name2) + " has won!");
                    break;
                }

                if (hasTied(board))
                {
                    printBoard(board);
                    Console.WriteLine("Game over. It's a tie!");
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
