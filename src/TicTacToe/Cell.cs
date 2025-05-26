namespace TicTacToe;

public class Cell(char value = Cell.DefaultValue)
{
    private const char DefaultValue = '\0';
    public char Value { get; private set; } = value;

    public bool IsMarked => Value != DefaultValue;
    public bool IsClear => Value == DefaultValue;

    public static implicit operator char(Cell cell) => cell.Value;

    public static implicit operator Cell(char value) => new(value);

    public Cell Mark(char symbol)
    {
        if (IsMarked)
            throw new InvalidOperationException("Cell is already marked");

        Value = symbol;
        return this;
    }

}