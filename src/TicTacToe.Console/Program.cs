using TicTacToe;

var board = new Board();
var  game = new Game(board);
var players = new[] { 'X', 'O' };
int turn = Random.Shared.Next(2);

while (true)
{
    try
    {
        char player = players[turn];
        DrawBoard();
        Console.WriteLine($"{player}'s turn");

        string? input = GetInput();

        if (string.IsNullOrEmpty(input))
            break;

        Console.Clear();
        (byte row, byte column) = ParseInput(input);
        board.MarkCell(row, column, player);
        if (game.IsOver(out char? winner))
        {
            DrawBoard();

            Console.WriteLine(winner != null ? $"Player {winner} wins!" : "Game is over");
            break;
        }
        
        turn = 1 - turn;
    }
    catch (Exception e)
    {
        WriteError(e.Message);
    }

}

return;

(byte row,byte column) ParseInput(string input)
{
    string[] parts = input.Trim().Split(' ');
    if (parts.Length != 2)
        throw new ArgumentException("Invalid input");
    if (!byte.TryParse(parts[0], out byte row) || !byte.TryParse(parts[1], out byte column))
        throw new ArgumentException("Invalid input");
    return (row, column);
}

void DrawBoard(){
    const string hLine = "─────";
    Console.WriteLine($"┌{hLine}┬{hLine}┬{hLine}┐");
    for (int i = 0; i < 3; i++)
    {
        Console.Write("│  ");
        for (int j = 0; j < 3; j++)
        {
            Console.Write(board.Cells[i, j] == '\0' ? ' ' : board.Cells[i, j]);
            Console.Write("  │  ");
        }

        Console.WriteLine();
        Console.WriteLine(i < 2 ? $"├{hLine}┼{hLine}┼{hLine}┤" : $"└{hLine}┴{hLine}┴{hLine}┘");
    }
}

void WriteError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}

string? GetInput()
{
    Console.Write("Enter row and column between 0 to 2 separated by space: ");
    return Console.ReadLine();
}