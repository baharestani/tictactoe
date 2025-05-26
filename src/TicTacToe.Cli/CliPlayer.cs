namespace TicTacToe.Cli;

public class CliPlayer(string name, char symbol) : IPlayer
{
    public string Name { get; } = name;
    public char Symbol { get; } = symbol;

    public Cell MakeMove(Board board)
    {
        string? input = GetInput();

        if (string.IsNullOrEmpty(input))
            Environment.Exit(0);

        (byte row, byte column) = ParseInput(input);
        return board.Cells[row, column].Mark(Symbol);
    }

    (byte row, byte column) ParseInput(string input)
    {
        string[] parts = input.Trim().Split(' ');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid input");
        if (!byte.TryParse(parts[0], out byte row) || !byte.TryParse(parts[1], out byte column))
            throw new ArgumentException("Invalid input");
        return (row, column);
    }

    string? GetInput()
    {
        Console.Write("Enter row and column between 0 to 2 separated by space: ");
        return Console.ReadLine();
    }
}