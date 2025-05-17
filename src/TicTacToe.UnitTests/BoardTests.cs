namespace TicTacToe.UnitTests;

public class BoardTests
{
    [Fact]
    public void IsMarkedWhenMarkedReturnsTrue()
    {
        var board = new Board();
        
        board.MarkCell(0, 0, 'X');
        
        Assert.True(board.IsMarked(0, 0));
        
    }
    
    [Fact]
    public void IsMarkedWhenNotMarkedReturnsFalse()
    {
        var board = new Board();
        
        Assert.False(board.IsMarked(0, 0));
        
    }

    [Fact]
    public void MarkCellWhenCellIsAlreadyMarkedThrows()
    {
        var board = new Board();
        board.MarkCell(0, 0, 'X');
        Assert.Throws<InvalidOperationException>(() => 
            board.MarkCell(0, 0, 'O'));
    }

    [Fact]
    public void MarkCellWhenRowOutOfRangeCellsThrows()
    {
        var board = new Board();
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            board.MarkCell(3, 0, 'O'));
    }
    
    [Fact]
    public void MarkCellWhenColumnOutOfRangeCellsThrows()
    {
        var board = new Board();
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            board.MarkCell(0, 3, 'O'));
    }

    [Fact]
    public void IsEmpty_ReturnsTrue_WhenBoardIsEmpty()
    {
        var board = new Board();

        var result = board.IsEmpty();

        Assert.True(result);
    }

    [Fact]
    public void IsEmpty_ReturnsFalse_WhenBoardHasMarkedCells()
    {
        var board = new Board();
        board.MarkCell(0, 0, 'X');

        var result = board.IsEmpty();

        Assert.False(result);
    }

    [Fact]
    public void Rows_Each_Has3Cells()
    {
        var board = new Board
        {
            Cells = new Cell[3, 3]
            {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'X', 'O', 'X' }
            }
        };
        var rows = board.Rows;
        Assert.Equal(3, rows[0].Length);
        Assert.Equal(3, rows[1].Length);
        Assert.Equal(3, rows[2].Length);
    }
    
    [Fact]
    public void Rows_Each_HasCorrectValues()
    {
        var board = new Board
        {
            Cells = new Cell[3, 3]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' }
            }
        };
        Cell[][] rows = board.Rows;
        Assert.Equal('a', rows[0][0].Value);
        Assert.Equal('b', rows[0][1].Value);
        Assert.Equal('c', rows[0][2].Value);
        Assert.Equal('d', rows[1][0].Value);
        Assert.Equal('e', rows[1][1].Value);
        Assert.Equal('f', rows[1][2].Value);
        Assert.Equal('g', rows[2][0].Value);
        Assert.Equal('h', rows[2][1].Value);
        Assert.Equal('i', rows[2][2].Value);
    }

    [Fact]
    public void Rows_Changing_ChangesCorrespondingCells()
    {
        var board = new Board
        {
            Cells = new Cell[3, 3]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' }
            }
        };
        Cell[][] rows = board.Rows;
        rows[0][0].Value = 'x';
        Assert.Equal('x', board.Cells[0, 0].Value);
    }
    
}

