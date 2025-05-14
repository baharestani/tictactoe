// See https://aka.ms/new-console-template for more information

using TicTacToe;

var board = new Board();
while (true)
{
    Console.Write("Enter row and column between 0 to 2 separated by space:");
    string? input = Console.ReadLine();
    Console.Clear();
    
    if (string.IsNullOrEmpty(input))
        break;

    try
    {
        (byte row, byte column) = Parse(input);
        board.MarkCell(row, column, 'X');
    }
    catch (Exception e)
    {
        WriteError(e.Message);
    }
    DrawBoard();
}

return;

(byte row,byte column) Parse(string input)
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