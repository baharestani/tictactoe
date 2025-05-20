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
        Cells[row, column].Mark(player); 
    }

    public bool IsMarked(int row, int column)
    {
        return Cells[row, column].Value != '\0';
    }

    public bool AllMarked()
    {
        return Cells.Cast<Cell>().All(c => c.IsMarked);
    }

    public bool IsEmpty()
    {
        return Cells.Cast<Cell>().All(c => c.IsClear);
    }

    public Row[] HRows
    {
        get
        {
            var rows = new Row[3];
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    rows[i][j] = Cells[i, j];
                }
            }

            return rows;
        }
    }

    public Row[] VRows
    {
        get
        {
            var rows = new Row[3];
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    rows[i][j] = Cells[j, i];
                }
            }

            return rows;
        }
    }

    public Row[] DRows
    {
        get
        {
            var rows = new Row[2];
            for (var i = 0; i < 3; i++)
            {
                rows[0][i] = Cells[i, i];
                rows[1][i] = Cells[i, 2 - i];
            }

            return rows;
        }
    }

    public Row[] AllRows =>
        HRows
            .Concat(VRows)
            .Concat(DRows)
            .ToArray();
}