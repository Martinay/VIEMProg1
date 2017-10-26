public class RawCoordinates
{
    public RawCoordinates(float[] x, float[] y, int width, int heigth)
    {
        Width = width*10;
        Height = heigth * 10;

        X = new int[x.Length];
        Y = new int[y.Length];

        for (int i = 0; i < x.Length; i++)
            X[i] = (int) ((x[i] + width/2)*10);


        for (int i = 0; i < y.Length; i++)
            Y[i] = (int)((-y[i] + heigth / 2)*10);

    }

    public int[] X { get; private set; }
    public int[] Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
}
