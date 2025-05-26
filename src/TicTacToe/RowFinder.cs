namespace TicTacToe;

public static class RowFinder
{
    public static bool FindDoubleSelf(Row row, char self)
    {
        Cell[] marked = row.Where(c => c.IsMarked).ToArray();
        return marked.Length == 2 && marked.All(c => c.Value == self);
    }

    public static bool FindDoubleOpponent(Row row, char self)
    {
        Cell[] marked = row.Where(c => c.IsMarked).ToArray();
        return marked.Length == 2 && marked.All(c => c.Value != self);
    }

    public static bool FindSingleSelf(Row row, char self)
    {
        Cell[] marked = row.Where(c => c.IsMarked).ToArray();
        return marked.Length == 1 && marked.Single().Value == self;
    }

    public static bool FindSingleOpponent(Row row, char self)
    {
        Cell[] marked = row.Where(c => c.IsMarked).ToArray();
        return marked.Length == 1 && marked.Single().Value != self;
    }

    public static bool FIndSelfAndOpponent(Row row)
    {
        Cell[] marked = row.Where(c => c.IsMarked).ToArray();
        return marked.Length == 2 && marked[0].Value != marked[1].Value;
    }
}