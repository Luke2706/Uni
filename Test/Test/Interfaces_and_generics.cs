using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;

namespace Test
{
    public class List<T> : IEnumerable
    {
        public List()
        {
        }

        public List(T item)
        {
            First = new ListLogic(item, null);
        }

        private ListLogic First { get; set; }

        private ListLogic Last
        {
            get
            {
                if (First is null) return null;

                ListLogic current = First;
                while (current.NextList != null)
                {
                    current = current.NextList;
                    if (current.NextList is null) return current;
                }

                return current;
            }
        }

        public void Add(T item)
        {
            ListLogic last = Last;
            if (last is null)
            {
                First = new ListLogic(item, null);
            }
            else
            {
                last.NextList = new ListLogic(item, null);
            }
        }

        public int Count()
        {
            var counter = 0;
            if (First is null) return counter;
            ListLogic counting = First;

            while (counting.NextList != null)
            {
                counting = counting.NextList;
                counter++;
            }
            return counter + 1;
        }

        public IEnumerator GetEnumerator()
        {
            var tmp = First;
            while (tmp != null)
            {
                yield return tmp.Item;
                tmp = tmp.NextList;
            }
        }

        public class ListLogic
        {
            public readonly T Item;
            public ListLogic NextList;

            public ListLogic(T item, ListLogic nextList)
            {
                Item = item;
                NextList = nextList;
            }
        }
    }
}