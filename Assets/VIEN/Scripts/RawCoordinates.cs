using System.Collections.Generic;
using UnityEngine;

public class RawCoordinates
{
    public RawCoordinates(IEnumerable<Vector3> coordinates)
    {
        X = new List<float>();
        Y = new List<float>();

        foreach(var coordinate in coordinates)
        {
            X.Add(coordinate.x);
            Y.Add(coordinate.y);
        }

        /*
        this.width = width * 10;
        this.height = height * 10;

        for (int i = 0; i < x.Length; i++)
            X[i] = (int) ((x[i] + width/2)*10);


        for (int i = 0; i < y.Length; i++)
            Y[i] = (int)((-y[i] + heigth / 2)*10);
*/
    }

    public List<float> X { get; private set; }
    public List<float> Y { get; private set; }
}
