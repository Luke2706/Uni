using System;
using System.Collections;

namespace Aufgabe4
{
    public abstract class KennzeichenTeile<T> : IComparer
    {
        private static readonly Type Kennzeichen = typeof(Kennzeichen);

        public abstract T Data { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }

        public int Compare(object x, object y)
        {
            // if objects are not of type Kennzeichen escape with -1
            if (!Kennzeichen.IsInstanceOfType(x) || !Kennzeichen.IsInstanceOfType(y))
                return -1;

            var a = x as Kennzeichen;
            var b = y as Kennzeichen;

            return Compare(a, b); // compare Kennzeichen with the correct implementation
        }

        protected abstract int Compare(Kennzeichen a, Kennzeichen b);

        protected static bool CheckMaxLetters(string data, int maxSize)
        {
            bool IsLetter(char check)
            {
                return check >= 'A' && check <= 'Z' || check >= 'a' && check <= 'z';
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (!IsLetter(data[i])) return false;
                if (i >= maxSize) return false;
            }

            return true;
        }
    }

    public class KennzeichenOrt : KennzeichenTeile<string>
    {
        public override string Data { get; set; }

        public KennzeichenOrt(string data)
        {
            if (!CheckMaxLetters(data, 3)) throw new InvalidKennzeichenStringException("Ort", data, 3);
            Data = data;
        }

        protected override int Compare(Kennzeichen a, Kennzeichen b)
        {
            return a.Ort.Data.CompareTo(b.Ort.Data); // using the CompareTo Method from String
        }
    }

    public class KennzeichenBuchstabe : KennzeichenTeile<string>
    {
        public override string Data { get; set; }

        public KennzeichenBuchstabe(string data)
        {
            if (!CheckMaxLetters(data, 2)) throw new InvalidKennzeichenStringException("Buchstabe", data, 2);
            Data = data;
        }

        protected override int Compare(Kennzeichen a, Kennzeichen b)
        {
            return a.Buchstabe.Data.CompareTo(b.Buchstabe.Data); // using the CompareTo Method from String
        }
    }

    public class KennzeichenZahl : KennzeichenTeile<int>
    {
        public override int Data { get; set; }

        public KennzeichenZahl(int data)
        {
            if (data < 1 || data > 9999) throw new InvalidKennzeichenIntergerExecption(1, 9999, data);
            Data = data;
        }

        protected override int Compare(Kennzeichen a, Kennzeichen b)
        {
            return a.Zahl.Data.CompareTo(b.Zahl.Data); // using the CompareTo Method from Interger
        }
    }
}