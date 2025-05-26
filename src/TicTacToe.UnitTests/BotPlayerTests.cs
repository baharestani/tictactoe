namespace TicTacToe.UnitTests;

public class BotPlayerTests
{
    [Fact]
    public void MakeMove_ThrowsException_WhenNoValidMoveExists()
    {
        var board = new Board();
        for (byte row = 0; row < 3; row++)
        {
            for (byte col = 0; col < 3; col++)
            {
                board.MarkCell(row, col, row % 2 == 0 ? 'X' : 'O');
            }
        }
        var bot = new BotPlayer("Bot", 'X');

        Assert.Throws<InvalidOperationException>(() => bot.MakeMove(board));
    }

   
}