using System;
    
namespace TextGraphics.Shapes
{
   /// <summary>
   /// Implementation of the Point class which inherit from the Shape Class
   /// </summary>
    public class Point : Shape
    {
        public Point(ConsoleColor color) : base(color)
        {
        }

        public override void Paint(int left, int top, Image image)
        {
            //Color the specify point (on the specify x/y axis) with specify color
            image.SetColor(left, top, Color);
        }
    }

}