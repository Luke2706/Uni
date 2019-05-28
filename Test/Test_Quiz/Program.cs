using System;

namespace test_quiz
{
    public delegate void TeilnehmerDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Teilnehmer t1 = new Teilnehmer("Johann Wolfgang Goethe");
            Teilnehmer t2 = new Teilnehmer("Eduard Mörike");
            Teilnehmer t3 = new Teilnehmer("Friedrich Schiller");
            Teilnehmer t4 = new Teilnehmer("Angeleooooo Merte");
            TeilnehmerDelegate[] teilnehmerArray = new TeilnehmerDelegate[4];
            teilnehmerArray[0] = t1.nenneName;
            teilnehmerArray[1] = t2.nenneName;
            teilnehmerArray[2] = t3.nenneName;
            teilnehmerArray[3] = t4.dasIstEinTest;
            TeilnehmerDelegate konferenzTeilnehmer = (TeilnehmerDelegate) Delegate.Combine(teilnehmerArray);
            konferenzTeilnehmer();
            Console.ReadKey();
        }
    }

    class Teilnehmer
    {
        String name;

        public Teilnehmer(String name)
        {
            this.name = name;
        }

        public void nenneName()
        {
            Console.WriteLine(name);
        }

        public void dasIstEinTest()
        {
            Console.WriteLine("uffff");
        }
    }
}
