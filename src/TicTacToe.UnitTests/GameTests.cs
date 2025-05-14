namespace TicTacToe.UnitTests;

public class GameTests
{
    [Fact]
    public void FindWinerWhenNoWinnerReturnsNull()
    {
        var board = new Board();
        board.MarkCell(0, 0, 'X');
        board.MarkCell(0, 1, 'O');
        board.MarkCell(0, 2, 'X');
        var game = new Game(board);
        var winner = game.FindWinner();
        Assert.Null(winner);
    }
    
    [Fact]
    public void FindWinerWhenDiagonalWinnerReturnsTheWinner()
    {
        var board = new Board();
        board.MarkCell(0, 0, 'X');
        board.MarkCell(1, 1, 'X');
        board.MarkCell(2, 2, 'X');
        var game = new Game(board);
        var winner = game.FindWinner();
        Assert.Equal('X', winner);
    }
    
    [Fact]
    public void FindWinerWhenAntiDiagonalWinnerReturnsTheWinner()
    {
        var board = new Board();
        board.MarkCell(0, 2, 'X');
        board.MarkCell(1, 1, 'X');
        board.MarkCell(2, 0, 'X');
        var game = new Game(board);
        var winner = game.FindWinner();
        Assert.Equal('X', winner);
    }
    
    [Fact]
    public void FindWinerWhenColumnWinnerReturnsTheWinner()
    {
        var board = new Board();
        board.MarkCell(0, 0, 'X');
        board.MarkCell(1, 0, 'X');
        board.MarkCell(2, 0, 'X');
        var game = new Game(board);
        var winner = game.FindWinner();
        Assert.Equal('X', winner);
    }
    
    [Fact]
    public void FindWinerWhenRowWinnerReturnsTheWinner()
    {
        var board = new Board();
        board.MarkCell(0, 0, 'X');
        board.MarkCell(0, 1, 'X');
        board.MarkCell(0, 2, 'X');
        var game = new Game(board);
        var winner = game.FindWinner();
        Assert.Equal('X', winner);
    }
    
}