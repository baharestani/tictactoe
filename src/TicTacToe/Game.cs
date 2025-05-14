namespace TicTacToe;

public class Game(Board board)
{
    public char? FindWinner()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board.Cells[i, 0] != '\0' && board.Cells[i, 0] == board.Cells[i, 1] && board.Cells[i, 1] == board.Cells[i, 2])
                return board.Cells[i, 0];
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board.Cells[0, i] != '\0' && board.Cells[0, i] == board.Cells[1, i] && board.Cells[1, i] == board.Cells[2, i])
                return board.Cells[0, i];
        }

        // Check diagonals
        if (board.Cells[0, 0] != '\0' && board.Cells[0, 0] == board.Cells[1, 1] && board.Cells[1, 1] == board.Cells[2, 2])
            return board.Cells[0, 0];

        if (board.Cells[0, 2] != '\0' && board.Cells[0, 2] == board.Cells[1, 1] && board.Cells[1, 1] == board.Cells[2, 0])
            return board.Cells[0, 2];

        return null; // No winner
    }
}