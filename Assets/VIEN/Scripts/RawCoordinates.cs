public class RawCoordinates
{
    public RawCoordinates(float[] x, float[] y, int width, int heigth)
    {
        Width = width;
        Height = heigth;

        X = new float[x.Length];
        Y = new float[y.Length];

        for (int i = 0; i < x.Length; i++)
            X[i] = x[i] + width/2;


        for (int i = 0; i < y.Length; i++)
            Y[i] = y[i] + heigth / 2;


        /*
        for (int i = 0; i < x.Length; i++)
            X[i] = x[i] * 100;


        for (int i = 0; i < y.Length; i++)
            Y[i] = y[i] * 100;
            */

    }

    public float[] X { get; private set; }
    public float[] Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
}
