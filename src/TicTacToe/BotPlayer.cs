namespace TicTacToe;

public class BotPlayer(string name, char symbol) : IPlayer
{
    public string Name => name;

    public char Symbol => symbol;

    public Cell MakeMove(Board board)
    {
        Func<Row, bool>[] criteria =
        [
            row => RowFinder.FindDoubleSelf(row, symbol),
            row => RowFinder.FindDoubleOpponent(row, symbol),
            row => RowFinder.FindSingleSelf(row, symbol),
            row => row.All(c => c.Value == '\0'),
            row => RowFinder.FindSingleOpponent(row, symbol),
            RowFinder.FIndSelfAndOpponent
        ];

        Row[] rows = board.AllRows;

        foreach (Func<Row, bool> predicate in criteria)
        {
            Row match = rows.FirstOrDefault(predicate);

            if (!match.IsEmpty)
            {
                return match.First(c => !c.IsMarked).Mark(symbol);
            }
        }

        throw new InvalidOperationException("Could not find the next move!");
    }
}

//  Priorities:
// 1. | X | X | - | Double self
// 2. | O | O | - | Double opponent
// 3. | X | - | - | Single self
// 4. | - | - | - | Empty row
// 5. | O | - | - | Single opponent
// 6. | X | O | - | self and opponent
// 7. | X | O | X | Full row