namespace TicTacToe;

public class Board
{
    public readonly char[,] Cells = new char[3, 3];
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
}