using System.Collections.Generic;

public class EmptyOnSubmit : IOnSubmit
{
    public void OnSubmit(IEnumerable<LineSegment> lines, int width, int height)
    {
    }
}