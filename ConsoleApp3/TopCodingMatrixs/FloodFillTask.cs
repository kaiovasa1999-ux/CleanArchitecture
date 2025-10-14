namespace TopCodingMatrixs;

public class FloodFillTask
{
    int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        int[][] image2 = new int[image.Length][];
        for (int i = 0; i < image.Length; i++)
        {
            image2[i] = new int[image[i].Length];
            for (int j = 0; j < image[i].Length; j++)
            {
                image2[i][j] = image[i][j];
            }
        }

        int initialColor = image[sr][sc];
        if (initialColor != color) 
        {
            ImageUpdate(image2, sr, sc, color, initialColor);
        }

        return image2;
    }

    void ImageUpdate(int[][] image, int sr, int sc, int newcolor, int initialColor)
    {
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length) return;
        if (image[sr][sc] != initialColor) return;
        if (image[sr][sc] == newcolor) return;

        image[sr][sc] = newcolor;

        ImageUpdate(image, sr + 1, sc, newcolor, initialColor);
        ImageUpdate(image, sr - 1, sc, newcolor, initialColor);
        ImageUpdate(image, sr, sc + 1, newcolor, initialColor);
        ImageUpdate(image, sr, sc - 1, newcolor, initialColor);
    }
}