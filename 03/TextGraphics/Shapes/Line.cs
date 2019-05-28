using System;

namespace TextGraphics.Shapes
{
    /// <summary>
    /// Implementation of the Line classes which inherit from the Shape Class
    /// </summary>
    public class HorizontalLine : Shape
    {
        public HorizontalLine(uint width, ConsoleColor color) : base(color)
        {
            Width = width;
        }

        public override void Paint(int left, int top, Image image)
        {
            //Coloring the y-axis with the specify color
            for (int i = 0; i < Width; i++)
            {
                image.SetColor(left + i, top, Color);
            }
        }
    }

    public class VerticalLine : Shape
    {
        public VerticalLine(uint height, ConsoleColor color) : base(color)
        {
            Height = height;
        }

        public override void Paint(int left, int top, Image image)
        {
            //Coloring the x-axis with the specify color
            for (int i = 0; i < Height; i++)
            {
                image.SetColor(left, top + i, Color);
            }
        }
    }
}