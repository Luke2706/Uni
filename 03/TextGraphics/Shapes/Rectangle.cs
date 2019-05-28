using System;

namespace TextGraphics.Shapes
{
    /// <summary>
    /// Implementation of the Rectangle classes. The Rectangle class inherit from the Shape Class.
    /// The Filled Rectangle inherit from Rectangle
    /// </summary>
    public class Rectangle : Shape
    {
        public Rectangle(uint width, uint height, ConsoleColor color) : base(color)
        {
            Width = width;
            Height = height;
        }

        public override void Paint(int left, int top, Image image)
        {
            // saving the coordinates (x and y axis) from the 'begin' to the 'end'
            int yBegin = top, yEnd = (int) (top + Height - 1);
            int xBegin = left, xEnd = (int) (left + Width - 1);

            //Coloring the x-axis with the specify color
            for (int i = 0; i < Width; i++)
            {
                image.SetColor(left + i, yBegin, Color);
                image.SetColor(left + i, yEnd, Color);
            }
            
            //Coloring the y-axis with the specify color
            for (int i = 0; i < Height; i++)
            {
                image.SetColor(xBegin, top + i, Color);
                image.SetColor(xEnd, top + i, Color);
            }
        }
    }

    public class FilledRectangle : Rectangle
    {
        public FilledRectangle(uint width, uint height, ConsoleColor color) : base(width, height, color)
        {
        }

        public override void Paint(int left, int top, Image image)
        {    
            //Coloring the y-axis along the x-axis with the specify color
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    image.SetColor(left + x, top + y, Color);
                }
            }
        }
    }
    
}