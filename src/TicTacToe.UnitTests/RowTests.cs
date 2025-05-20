namespace TicTacToe.UnitTests;

public class RowTests
{
    [Fact]
    public void GetEnumerator_ReturnsAllElementsInRow()
    {
        Row row;
        row[0] = new Cell('X');
        row[1] = new Cell('O');
        row[2] = new Cell('X');

        Cell[] elements = row.ToArray();

        Assert.Equal(3, elements.Length);
        Assert.Equal('X', elements[0].Value);
        Assert.Equal('O', elements[1].Value);
        Assert.Equal('X', elements[2].Value);
    }

    [Fact]
    public void GetEnumerator_EmptyRow_ReturnsDefaultCells()
    {
        var row = new Row();

        Cell[] elements = row.ToArray();

        Assert.Equal(3, elements.Length);
    }

    [Fact]
    public void IsEmpty_ForDefaultOfRow_ReturnsTrue()
    {
        Assert.True(default(Row).IsEmpty);
    }

    [Fact]
    public void IsEmpty_ForNewRow_ReturnsTrue()
    {
        var row = new Row();
        Assert.True(row.IsEmpty);
    }
}