namespace TicTacToe;

public interface IPlayer
{
    string Name { get; }
    char Symbol { get; }
    Cell MakeMove(Board board);
}