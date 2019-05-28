// Nuremberg Institute of Applied Technology - Faculty of Computer Science 
// Programming II - Practical Exercise "Inheritance" - Summer Semester 2019
// Prof. Dr. Bartosz von Rymon Lipinski (bartosz.vonrymonlipinski@th-nuernberg.de)

namespace TextGraphics
{
    // List data structure for scene elements:

    class Scene
    {
        // Painting component, describing a shape object with 2d position information (left, top):

        public class Painting
        {
            public int Left, Top;
            public Shape Shape;
            public Painting(int left, int top, Shape shape)
            {
                Left = left;
                Top = top;
                Shape = shape;
            }
        }


        // Scene (list) element, consists of paintings and 2d positional offset information: 

        public class Element
        {
            public Painting[] Paintings;
            public Element Next;
            public int XOffset, YOffset;

            public Element(Painting[] paintings,int xOffset=0, int yOffset =0)
            {
                this.Paintings = paintings;
                this.XOffset = xOffset;
                this.YOffset = yOffset;
            }
        }

        // Access to first and last scene elements:

        public Element First { get; set; }

        public Element Last
        {
            get
            {
                if (First is null) return null;

                Element current = First;
                //Concept of linked list. If last Element is found it gets returned 
                while (current.Next != null)
                {
                    current = current.Next;
                    if (current.Next is null) return current;
                }

                return current;
            }
        }


        // Scene construction operations:

        public Element Add(params Painting[] paintings)
        {
            Element newElement = new Element(paintings);
            Element last = Last;
            
            //if last is null it also implicates that First is empty. So 'First' gets set.
            //Else we always can set the new element on last.next cause this returns the last element of the 'list'
            if (last is null)
            {
                First = newElement;
            }
            else
            {
                last.Next = newElement;
            }

            return newElement;

        }


        // Rendering of scene to a target image:

        public void Render(Image image)
        {
            // Traverse scene list elements and included paintings:

            for (Element element = First; element != null; element = element.Next)
            {
                foreach (Painting painting in element.Paintings)
                {
                    // Render each painting component using its 2d position and the offset of the corresponding scene element:

                    painting.Shape.Paint(painting.Left + element.XOffset, painting.Top + element.YOffset, image);
                }
            }
        }
    }
}