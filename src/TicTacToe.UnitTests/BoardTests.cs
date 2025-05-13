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
    
}

