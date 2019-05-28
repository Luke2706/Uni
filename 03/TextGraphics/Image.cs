// Nuremberg Institute of Applied Technology - Faculty of Computer Science 
// Programming II - Practical Exercise "Inheritance" - Summer Semester 2019
// Prof. Dr. Bartosz von Rymon Lipinski (bartosz.vonrymonlipinski@th-nuernberg.de)

using System;

using static System.Console;

namespace TextGraphics
{
  // Colored image for console display:

  public class Image
  {
    // Color data and image geometry:

    ConsoleColor[] colors;

    public uint Width { get; private set; }

    public uint Height { get; private set; }

    public uint Size { get => Width * Height;  }


    // Image construction:

    public Image(uint width, uint height)
    {
      Width = width;

      Height = height;

      colors = new ConsoleColor[Size];
    }


    // Color (image "pixel") access:

    void setColor(int x, int y, ConsoleColor color)
    {
      colors[x + y * Width] = color;
    }

    public void SetColor(int x, int y, ConsoleColor color)    
    {
      if (x >= 0 && x < Width && y >= 0 && y < Height)
      {
        setColor(x, y, color);
      }
    }

    ConsoleColor getColor(int x, int y) => colors[x + y * Width];

    public ConsoleColor GetColor(int x, int y) => x >= 0 && x < Width && y >= 0 && y < Height ? getColor(x, y) : ConsoleColor.Black;


    // Image fill (with constant color):

    public void Fill(ConsoleColor color)
    {
      for (int y = 0; y < Height; ++y)
      {
        for (int x = 0; x < Width; ++x)
        {
          setColor(x, y, color);
        }
      }
    }

    public void Fill()
    {
      Fill(BackgroundColor);
    }


    // Image console display:

    public void Display(bool fill = true)
    {
      // Hide console cursor and reset its position:

      CursorVisible = false;

      SetCursorPosition(0, 0);
     
      // Write each image "pixel" to console:

      for (int y = 0; y < Height; ++y)
      {
        for (int x = 0; x < Width; ++x)
        {
          ForegroundColor = getColor(x, y);

          Write("\u2588");  // Unicode character "block"       
        }

        SetCursorPosition(0, CursorTop + 1);
      }

      // Optionally, reset image (to black color):

      if (fill)
      {
        Fill();
      }
    }
  }
}
