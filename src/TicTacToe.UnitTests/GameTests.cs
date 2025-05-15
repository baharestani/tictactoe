namespace TicTacToe.UnitTests;

public class GameTests
{
    [Fact]
    public void FindWinner_ReturnsWinner_WhenRowIsComplete()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'X', 'X', 'X' },
                { '\0', '\0', '\0' },
                { '\0', '\0', '\0' }
            }
        };
        var game = new Game(board);

        char? winner = game.FindWinner();

        Assert.Equal('X', winner);
    }
    
    [Fact]
    public void FindWinner_ReturnsWinner_WhenColumnIsComplete()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'O', '\0', '\0' },
                { 'O', '\0', '\0' },
                { 'O', '\0', '\0' }
            }
        };
         var game = new Game(board);
    
        var winner = game.FindWinner();

        Assert.Equal('O', winner);
    }
    
    [Fact]
    public void FindWinner_ReturnsWinner_WhenMainDiagonalIsComplete()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'X', '\0', '\0' },
                { '\0', 'X', '\0' },
                { '\0', '\0', 'X' }
            }
        };
        var game = new Game(board);
    
        var winner = game.FindWinner();
    
        Assert.Equal('X', winner);
    }
    
    [Fact]
    public void FindWinner_ReturnsNull_WhenNoWinnerExists()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'O', 'X', 'O' }
            }
        };
        var game = new Game(board);
    
        var winner = game.FindWinner();

        Assert.Null(winner);
    }

    [Fact]
    public void IsOver_ReturnsTrue_WhenWinnerIsFound()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'X', 'X', 'X' },
                { '\0', '\0', '\0' },
                { '\0', '\0', '\0' }
            }
        };
        var game = new Game(board);

        var isOver = game.IsOver(out var winner);

        Assert.True(isOver);
        Assert.Equal('X', winner);
    }
    
    [Fact]
    public void IsOver_ReturnsTrue_WhenBoardIsFullWithoutWinner()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'O', 'X', 'O' }
            }
        };
        var game = new Game(board);

        var isOver = game.IsOver(out var winner);

        Assert.True(isOver);
        Assert.Null(winner);
    }
    
    [Fact]
    public void IsOver_ReturnsFalse_WhenGameIsStillInProgress()
    {
        var board = new Board
        {
            Cells = new[,]
            {
                { 'X', '\0', 'O' },
                { '\0', 'X', '\0' },
                { '\0', '\0', '\0' }
            }
        };
        var game = new Game(board);

        var isOver = game.IsOver(out var winner);

        Assert.False(isOver);
        Assert.Null(winner);
    }
    
}