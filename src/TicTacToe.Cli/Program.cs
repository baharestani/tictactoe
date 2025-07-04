﻿using TicTacToe;
using TicTacToe.Cli;

var board = new Board();
var  game = new Game(board);
var lastError = string.Empty;
Cell? lastMarkedCell = null;
var symbols = new[] { 'X', 'O' };
var players = new IPlayer[2];
Console.WriteLine("Welcome to Tic Tac Toe!");
int numberOfPlayers = GetNumberOfPlayers();
int turn = Random.Shared.Next(numberOfPlayers);

for (var i = 0; i < numberOfPlayers; i++)
{
    players[i] = GetHumanPlayer(i);
}

if (numberOfPlayers == 1)
{
    players[1] = new BotPlayer("Computer", symbols[1]);
}

while (true)
{
    try
    {
        Console.Clear();
        WriteError(lastError);
        DrawBoard();

        IPlayer player = players[turn];
        Console.WriteLine($"{player.Name}'s turn ({player.Symbol})");

        lastMarkedCell = player.MakeMove(board);

        if (game.IsOver(out char? winnerSymbol))
        {
            Console.Clear();
            if (winnerSymbol == null)
            {
                Console.WriteLine("Game is over with no winner.");
            }
            else
            {
                IPlayer winner = players.Single(p => p.Symbol == winnerSymbol);
                Console.WriteLine($"{winner.Name}({winner.Symbol}) wins!");
            }
            DrawBoard();
            break;
        }
        
        turn = 1 - turn;
        lastError = string.Empty;
    }
    catch (Exception e)
    {
        lastError = e.Message;
    }
}

return;



void DrawBoard(){
    const int vScale = 2;
    var hLine = new string('─', 2 * vScale + 1);
    var padding = new string(' ', vScale );
    Console.WriteLine($"┌{hLine}┬{hLine}┬{hLine}┐");
    for (var i = 0; i < 3; i++)
    {
        Console.Write($"│{padding}");
        for (var j = 0; j < 3; j++)
        {
            if (lastMarkedCell == board.Cells[i, j])
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write(board.Cells[i, j].IsClear ? ' ' : board.Cells[i, j].Value);
            Console.ResetColor();
            Console.Write($"{padding}│{padding}");
        }

        Console.WriteLine();
        Console.WriteLine(i < 2 ? $"├{hLine}┼{hLine}┼{hLine}┤" : $"└{hLine}┴{hLine}┴{hLine}┘");
    }
}

void WriteError(string message)
{
    if (string.IsNullOrEmpty(message))
        return;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}

int GetNumberOfPlayers()
{
    while (true)
    {
        Console.Write("Enter number of players (1 or 2): ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int number) && number is 1 or 2)
        {
            return number;
        }

        Console.WriteLine("Invalid input. Please enter 1 or 2.");
    }
}

CliPlayer GetHumanPlayer(int index)
{
    Console.Write($"Enter name for player {index + 1}: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        name = $"Player{index + 1}";
    }

    return new CliPlayer(name, symbols[index]);
}
