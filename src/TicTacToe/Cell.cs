namespace TicTacToe;

public class Cell
{
    protected bool Equals(Cell other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Cell)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public char Value { get; set; }

    public bool IsMarked => Value != '\0';

    public static implicit operator char(Cell cell) => cell.Value;

    public static implicit operator Cell(char value) => new()
        { Value = value };


    public static bool operator ==(Cell left, Cell right)
    {
        return left.Value.Equals(right);
    }

    public static bool operator !=(Cell left, Cell right)
    {
        return !(left == right);
    }
}