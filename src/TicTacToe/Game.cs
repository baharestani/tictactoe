namespace TicTacToe;

public class Game(Board board)
{
    public char? FindWinner()
    {
        Row winnerRow = board.AllRows.FirstOrDefault(r => r[0].IsMarked && r.All(c => c.Value == r[0].Value));
        if (winnerRow.IsEmpty)
        {
            return null;
        }

        return winnerRow[0].Value;
    }

    public bool IsOver(out char? winner)
    {
        winner = FindWinner();
        // Game is over if there is a winner or all cells are marked
        return winner != null || board.AllMarked();
    }
}