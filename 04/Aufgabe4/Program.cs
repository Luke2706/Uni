using System;
using System.Collections;

namespace Aufgabe4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            KennzeichenOrt[] dbOrte =
            {
                new KennzeichenOrt("S"), 
                new KennzeichenOrt("N"), 
                new KennzeichenOrt("HAC")
            };

            KennzeichenBuchstabe[] dbBuchstaben =
            {
                new KennzeichenBuchstabe("IN"), 
                new KennzeichenBuchstabe("IT"),
                new KennzeichenBuchstabe("K")
            };

            KennzeichenZahl[] dbZahlen =
            {
                new KennzeichenZahl(1337), 
                new KennzeichenZahl(2019),
                new KennzeichenZahl(512)
            };

            Kennzeichen[] alleKennzeichen = new Kennzeichen[3];
            for (int i = 0; i < alleKennzeichen.Length; i++)
            {
                alleKennzeichen[i] = new Kennzeichen(dbOrte[i], dbBuchstaben[i], dbZahlen[i]);
            }

            Array.Sort(alleKennzeichen, (IComparer) new KennzeichenOrt("A"));
            for (int i = 0; i < alleKennzeichen.Length; i++)
                Console.WriteLine(alleKennzeichen[i]);

            Console.WriteLine();

            Array.Sort(alleKennzeichen, (IComparer) new KennzeichenBuchstabe("A"));
            for (int i = 0; i < alleKennzeichen.Length; i++)
                Console.WriteLine(alleKennzeichen[i]);

            Console.WriteLine();

            Array.Sort(alleKennzeichen, (IComparer) new KennzeichenZahl(1));
            for (int i = 0; i < alleKennzeichen.Length; i++)
                Console.WriteLine(alleKennzeichen[i]);

            try
            {
                KennzeichenZahl invalid = new KennzeichenZahl(12345);
            }
            catch (InvalidKennzeichenException e)
            {
                Console.WriteLine(e.KennzeichenNachricht);
            }

            try
            {
                KennzeichenBuchstabe invalid = new KennzeichenBuchstabe("ABC");
            }
            catch (InvalidKennzeichenException e)
            {
                Console.WriteLine(e.KennzeichenNachricht);
            }

            try
            {
                KennzeichenOrt invalid = new KennzeichenOrt("ABCD");
            }
            catch (InvalidKennzeichenException e)
            {
                Console.WriteLine(e.KennzeichenNachricht);
            }

            try
            {
                KennzeichenZahl invalid = new KennzeichenZahl(-1);
            }
            catch (InvalidKennzeichenException e)
            {
                Console.WriteLine(e.KennzeichenNachricht);
            }
        }
    }

    public class Kennzeichen
    {
        // only readable and internally available
        internal readonly KennzeichenOrt Ort;
        internal readonly KennzeichenBuchstabe Buchstabe;
        internal readonly KennzeichenZahl Zahl;

        public Kennzeichen(KennzeichenOrt ort, KennzeichenBuchstabe buchstabe, KennzeichenZahl zahl)
        {
            Ort = ort;
            Buchstabe = buchstabe;
            Zahl = zahl;
        }

        public override string ToString()
        {
            return $"{Ort} {Buchstabe} {Zahl}";
        }
    }
}