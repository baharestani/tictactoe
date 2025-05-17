namespace TicTacToe;

using System.Linq;

public class Board
{
    public Cell[,] Cells { get; init; } = new Cell[,]
    {
        { '\0', '\0', '\0' },
        { '\0', '\0', '\0' },
        { '\0', '\0', '\0' }
    };

    public void MarkCell(byte row, byte column, char player)
    {
        if (row >= 3 || column >= 3)
            throw new ArgumentOutOfRangeException();

        Cells[row, column].Mark(player); 
    }

    public bool IsMarked(int row, int column)
    {
        return Cells[row, column] != '\0';
    }

    public bool AllMarked()
    {
        return Cells.Cast<Cell>().All(c => c.IsMarked);
    }

    public bool IsEmpty()
    {
        return Cells.Cast<Cell>().All(c => !c.IsMarked);
    }

    public Cell[][] Rows
    {
        get
        {
            var rows = new Cell[3][];
            for (var i = 0; i < 3; i++)
            {
                rows[i] = new Cell[3];
                for (var j = 0; j < 3; j++)
                {
                    rows[i][j] = Cells[i, j];
                }
            }

            return rows;
        }
    }
}