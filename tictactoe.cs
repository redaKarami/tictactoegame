using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool onPlay = true; //setting a bool to control the game end and start
            string[] boardLine1 = new string[] { "_", "_", "_" }; // drawing board with arrays
            string[] boardLine2 = new string[] { "_", "_", "_" };
            string[] boardLine3 = new string[] { "_", "_", "_" };
            bool cpuHasWon = false; //sets bool to control computer's loss and win
            bool playerHasWon = false; // same thing for the player
            boardPrinter(boardLine1, boardLine2, boardLine3); // calling the function that draws the game board
            int userChoiceToInt = 0; //the player will input his moves with integer inputs
            int cpuChoice = 0; //sets an integer for the cpu's move

            // a list of possible moves so its impossible to do the same move twice 
            List<int> possibleMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
            Console.WriteLine("You are X, choose from 1 to 9 to put your X");
            while (onPlay == true)
            {
                //player always starts first
                bool isPlayerTurn = true;
                Console.WriteLine("Your Move :");

                while (isPlayerTurn == true)
                {
                    //making sure the player doesnt input something other than an integer
                    while (!int.TryParse(Console.ReadLine(), out userChoiceToInt))
                    {
                        Console.WriteLine("Please input a valid move (not already made by the Player or the Computer)");
                    }
                    //also making sure that the move he put is possible to make
                    if (!possibleMoves.Contains(userChoiceToInt) || userChoiceToInt == cpuChoice)
                    {
                        Console.WriteLine("Please input a valid move that is not already done");
                        continue; 
                    }

                    // player's move
                    if (userChoiceToInt < 4)
                    {
                        // a logic to put the player's "X" in the appropriate place in the board
                        boardLine1[userChoiceToInt - 1] = "X";
                        Console.WriteLine("---------------");
                        //removes the player's move from the possible moves list
                        possibleMoves.Remove(userChoiceToInt);
                    }
                    else if (userChoiceToInt > 3 && userChoiceToInt < 7)
                    {
                        boardLine2[userChoiceToInt - 4] = "X";
                        Console.WriteLine("----------------");
                        possibleMoves.Remove(userChoiceToInt);
                    }
                    else if (userChoiceToInt > 6)
                    {
                        boardLine3[userChoiceToInt - 7] = "X";
                        Console.WriteLine("----------------");
                        possibleMoves.Remove(userChoiceToInt);
                    }
                    //prints the board again with the player's move
                    boardPrinter(boardLine1, boardLine2, boardLine3);

                    // Check if the player has won
                    if ((boardLine1[0] == "X" && boardLine1[1] == "X" && boardLine1[2] == "X")
                        || (boardLine2[0] == "X" && boardLine2[1] == "X" && boardLine2[2] == "X")
                        || (boardLine3[0] == "X" && boardLine3[1] == "X" && boardLine3[2] == "X")
                        || (boardLine1[1] == "X" && boardLine2[1] == "X" && boardLine3[1] == "X")
                        || (boardLine1[0] == "X" && boardLine2[0] == "X" && boardLine3[0] == "X")
                        || (boardLine1[2] == "X" && boardLine2[2] == "X" && boardLine3[2] == "X")
                        || (boardLine1[2] == "X" && boardLine2[1] == "X" && boardLine3[0] == "X")
                        || (boardLine1[0] == "X" && boardLine2[1] == "X" && boardLine3[2] == "X"))
                    {
                        Console.WriteLine("You won!");
                        playerHasWon = true;
                        onPlay = false;
                        break;
                    }
                    /*if you see here why i made playerHasWon and cpuHasWon booleans, it's to avoid a tie if the player
                    or the cpu wins with a full board*/
                    else if(boardLine1[0] != "_" && boardLine1[1] != "_" && boardLine1[2] != "_"
                        && boardLine2[0] != "_" && boardLine2[1] != "_" && boardLine2[2] != "_"
                        && boardLine3[0] != "_" && boardLine3[1] != "_" && boardLine3[2] != "_"
                        && cpuHasWon == false && playerHasWon == false)
                    {
                        Console.WriteLine("Tie !");
                        onPlay = false;
                        break;
                    }                   
                    else
                    {
                        //player's turn has finished
                        isPlayerTurn = false;
                    }
                }

                // Check if the game has ended after the player's turn
                if (!onPlay)
                {
                    break;
                }
                // cpu's turn
                // clearing the console for better gaming experience
                Console.Clear();
                Console.WriteLine("----------------");
                Console.WriteLine("The computer made it's move");
                //cpu's move will be a random number
                Random rnd = new Random();
                cpuChoice = rnd.Next(1, 10);
                /* checks if the cpu's choice is the same as the player's one or it's not in the possible moves to avoid 
                making a move twice*/
                while (cpuChoice == userChoiceToInt || !possibleMoves.Contains(cpuChoice))
                {
                    cpuChoice = rnd.Next(1, 10);
                }

                if (cpuChoice < 4)
                {
                    boardLine1[cpuChoice - 1] = "O";
                }
                else if (cpuChoice > 3 && cpuChoice < 7)
                {
                    boardLine2[cpuChoice - 4] = "O";
                }
                else
                {
                    boardLine3[cpuChoice - 7] = "O";
                }
                //removes the cpu's choice from the possible move
                possibleMoves.Remove(cpuChoice);
                //redraws the board
                boardPrinter(boardLine1, boardLine2, boardLine3);

                // Check if the CPU has won
                if ((boardLine1[0] == "O" && boardLine1[1] == "O" && boardLine1[2] == "O")
                    || (boardLine2[0] == "O" && boardLine2[1] == "O" && boardLine2[2] == "O")
                    || (boardLine3[0] == "O" && boardLine3[1] == "O" && boardLine3[2] == "O")
                    || (boardLine1[1] == "O" && boardLine2[1] == "O" && boardLine3[1] == "O")
                    || (boardLine1[0] == "O" && boardLine2[0] == "O" && boardLine3[0] == "O")
                    || (boardLine1[2] == "O" && boardLine2[2] == "O" && boardLine3[2] == "O")
                    || (boardLine1[2] == "O" && boardLine2[1] == "O" && boardLine3[0] == "O")
                    || (boardLine1[0] == "O" && boardLine2[1] == "O" && boardLine3[2] == "O"))
                {
                    Console.WriteLine("The Computer Won!");
                    cpuHasWon = true;
                    onPlay = false;
                    break;
                }
                else if(boardLine1[0] != "_" && boardLine1[1] != "_" && boardLine1[2] != "_"
                        && boardLine2[0] != "_" && boardLine2[1] != "_" && boardLine2[2] != "_"
                        && boardLine3[0] != "_" && boardLine3[1] != "_" && boardLine3[2] != "_"
                        && cpuHasWon == false && playerHasWon == false)
                {
                    Console.WriteLine("Tie !");
                    onPlay = false;
                    break;
                }
                else
                {
                    //it's player's turn
                    isPlayerTurn = true;
                }
            }
        }
        //Method that returns nothing but writes the game board
        public static void boardPrinter(string[] boardLine1, string[] boardLine2, string[] boardLine3)
        {
            string bl1 = string.Join(" ", boardLine1);
            string bl2 = string.Join(" ", boardLine2);
            string bl3 = string.Join(" ", boardLine3);
            Console.WriteLine(bl1);
            Console.WriteLine(bl2);
            Console.WriteLine(bl3);
        }
    }
}
