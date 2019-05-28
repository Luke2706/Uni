// Nuremberg Institute of Applied Technology - Faculty of Computer Science 
// Programming II - Practical Exercise "Inheritance" - Summer Semester 2019
// Prof. Dr. Bartosz von Rymon Lipinski (bartosz.vonrymonlipinski@th-nuernberg.de)

using System;
using System.Diagnostics;
using TextGraphics.Shapes;
// Required for StopWatch

using static System.Console;

namespace TextGraphics
{
  // Application class:

  class Program
  {
    // Animation timing:

    const long cloudAnimationDelay = 500;  // ms


    // Application routine:

    static void Main()
    {
      // Build scene:

      Scene scene = new Scene();

      // Add background scene element:

      scene.Add
      (
        new Scene.Painting(0, 0, new FilledRectangle(79, 20, ConsoleColor.Cyan)),
        new Scene.Painting(0, 20, new FilledRectangle(79, 4, ConsoleColor.DarkGreen))
      );

      // Add sun scene element:

      scene.Add
      (
        new Scene.Painting(64, 3, new FilledRectangle(6, 3, ConsoleColor.Yellow))
      );

      // Add tree scene element:

      scene.Add
      (
        new Scene.Painting(50, 14, new Rectangle(2, 6, ConsoleColor.DarkRed)),
        new Scene.Painting(46, 10, new FilledRectangle(10, 5, ConsoleColor.DarkGreen))
      );

      // Add cloud scene element (and keep reference for animation):

      Scene.Element cloud = scene.Add
      (
        new Scene.Painting(5, 5, new HorizontalLine(8, ConsoleColor.White)),
        new Scene.Painting(2, 6, new FilledRectangle(12, 2, ConsoleColor.White)),
        new Scene.Painting(18, 6, new HorizontalLine(3, ConsoleColor.White)),
        new Scene.Painting(9, 7, new Rectangle(8, 2, ConsoleColor.White))
      );

      // Add person scene element (and keep reference for user control):

      Scene.Element person = scene.Add
      (
        new Scene.Painting(8, 18, new VerticalLine(2, ConsoleColor.DarkBlue)),
        new Scene.Painting(10, 18, new VerticalLine(2, ConsoleColor.DarkBlue)),
        new Scene.Painting(8, 15, new FilledRectangle(3, 3, ConsoleColor.Red)),
        new Scene.Painting(9, 14, new Point(ConsoleColor.DarkGray))
      );
      

      // Prepare render target and animation (stop watch):

      Image image = new Image(79, 24);      

      Stopwatch cloudAnimationWatch = new Stopwatch();

      cloudAnimationWatch.Start();


      // Run rendering and animation loop:

      ConsoleKey key = 0;

      do
      {
        // Render scene:

        scene.Render(image);

        image.Display();

        // Animate cloud:

        if (cloudAnimationWatch.ElapsedMilliseconds >= cloudAnimationDelay)
        {
          ++cloud.XOffset;

          if (cloud.XOffset > 77)
          {
            cloud.XOffset = -19;
          }

          cloudAnimationWatch.Restart();
        }

        // Process user input:

        if (KeyAvailable)
        {
          key = ReadKey(true).Key;
        }
        else
        {
          key = 0;
        }

        switch (key)
        {
          // Move person left:

          case ConsoleKey.LeftArrow:

            if (person.XOffset > -8)
            {
              --person.XOffset;
            }

            break;

          // Move person right:

          case ConsoleKey.RightArrow:

            if (person.XOffset < 68)
            {
              ++person.XOffset;
            }

            break;
          }
      }
      while (key != ConsoleKey.Escape);
    }
  }
}
