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
        Assert.Throws<IndexOutOfRangeException>(() => 
            board.MarkCell(3, 0, 'O'));
    }
    
    [Fact]
    public void MarkCellWhenColumnOutOfRangeCellsThrows()
    {
        var board = new Board();
        Assert.Throws<IndexOutOfRangeException>(() => 
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
    public void Rows_Changing_ChangesCorrespondingCells()
    {
        var board = new Board();
        Row[] rows = board.AllRows;
        rows[0][0].Mark('x');
        Assert.Equal('x', board.Cells[0, 0].Value);
    }    
    
    [Fact]
    public void HRows_Each_HasCorrectValues()
    {
        var board = new Board
        {
            Cells = new Cell[,]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' }
            }
        };
        Row[] rows = board.HRows;
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
    public void VRows_Each_HasCorrectValues()
    {
        var board = new Board
        {
            Cells = new Cell[,]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' }
            }
        };
        Row[] columns = board.VRows;
        Assert.Equal('a', columns[0][0].Value);
        Assert.Equal('d', columns[0][1].Value);
        Assert.Equal('g', columns[0][2].Value);

        Assert.Equal('b', columns[1][0].Value);
        Assert.Equal('e', columns[1][1].Value);
        Assert.Equal('h', columns[1][2].Value);

        Assert.Equal('c', columns[2][0].Value);
        Assert.Equal('f', columns[2][1].Value);
        Assert.Equal('i', columns[2][2].Value);
    }

    [Fact]
    public void DRows_Each_HasCorrectValues()
    {
        var board = new Board
        {
            Cells = new Cell[,]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' }
            }
        };
        Row[] rows = board.DRows;
        Assert.Equal('a', rows[0][0].Value);
        Assert.Equal('e', rows[0][1].Value);
        Assert.Equal('i', rows[0][2].Value);

        Assert.Equal('c', rows[1][0].Value);
        Assert.Equal('e', rows[1][1].Value);
        Assert.Equal('g', rows[1][2].Value);
    }
    
}

