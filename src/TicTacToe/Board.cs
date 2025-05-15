namespace TicTacToe;

using System.Linq;
public class Board
{
    public char[,] Cells { get; init; } = new char[3, 3];

    public void MarkCell(byte row, byte column, char player)
    {
        if (row >= 3 || column >= 3)
            throw new ArgumentOutOfRangeException();
        
        if (IsMarked(row, column))
            throw new InvalidOperationException("Cell is already marked");
        
        Cells[row, column] = player;
    }

    public bool IsMarked(int row, int column)
    {
        return Cells[row, column] != '\0';
    }

    public bool AllMarked()
    {
        return Cells.Cast<char>().All(c => c != '\0');
    }
}