using System.Collections.Generic;

public interface IOnSubmit
{
    void OnSubmit(IEnumerable<LineSegment> lines, int width, int height);
    
}