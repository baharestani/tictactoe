// global using Row = TicTacToe.Cell[];

using System.Collections;
using System.Runtime.CompilerServices;

namespace TicTacToe;

[InlineArray(3)]
public struct Row : IEnumerable<Cell>
{
    private Cell _element0;

    public bool IsEmpty => this.All(c => c is null);

    public IEnumerator<Cell> GetEnumerator()
    {
        for (var i = 0; i < 3; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}