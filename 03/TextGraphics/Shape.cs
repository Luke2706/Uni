// Nuremberg Institute of Applied Technology - Faculty of Computer Science 
// Programming II - Practical Exercise "Inheritance" - Summer Semester 2019
// Prof. Dr. Bartosz von Rymon Lipinski (bartosz.vonrymonlipinski@th-nuernberg.de)

using System;

namespace TextGraphics
{
    // Shape base class, representing a 2d geometric object:
    //!!!Please note: You can find the implementation of the geometric objects in the folder 'Shapes' categorized after figures!!!   

    public class Shape
    {
        // Shape color:
        public ConsoleColor Color;
        protected uint Width, Height;


        // Shape construction:

        protected Shape(ConsoleColor color)
        {
            Color = color;
        }


        // Base method for shape rendering (to a target image):

        public virtual void Paint(int left, int top, Image image)
        {
        }
    }
}