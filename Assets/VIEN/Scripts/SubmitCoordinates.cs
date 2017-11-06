using System.Collections.Generic;

public class SubmitCoordinates
{
    public SubmitCoordinates(List<RawCoordinates> coordinates, int width, int height)
    {
        Coordinates = coordinates;
        Width = width;
        Height = height;
    }
    
    public List<RawCoordinates> Coordinates { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}