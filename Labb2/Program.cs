using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine("list 1 index of 1,2,3: " + list1[0] + ", " + list1[1] + ", " + list1[2] + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine("updated list1: " +list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine("list2: " + list2 + "\n");
            Console.WriteLine("added lists: " + (list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine("in circle: " + circleList.CircleContent(new Position(5, 5), 4) + "\n");


            //VG

            SortedPosList AList = new SortedPosList();
            AList.Add(new Position(3, 7));
            AList.Add(new Position(1, 4));
            AList.Add(new Position(2, 6));
            AList.Add(new Position(2, 3));

            SortedPosList BList = new SortedPosList();
            BList.Add(new Position(3, 7));
            BList.Add(new Position(1, 2));
            BList.Add(new Position(3, 6));
            BList.Add(new Position(2, 3));
            //testar att lägga ta bort alla förekommande positioner ifrån den första listan
            Console.WriteLine("a - b lists: " + (AList * BList) + "\n");
            Console.WriteLine("b - a lists: " + (BList * AList) + "\n");

            string testPath = @"/Users/dev/Documents/C# grunder/Labb2/Labb2/Data.txt";

            //testar att spara till filen
            BList.Save(testPath);
            Console.WriteLine("saved: " + BList);

            //laddar in blistan ifrån filen
            SortedPosList listFromFile = new SortedPosList(testPath);
            Console.WriteLine("from file: " + listFromFile);

            //updaterar filen med det nya värdet
            listFromFile.Add(new Position(8, 8));

            //skriver ut innehålle ifrån filen
            listFromFile = new SortedPosList(testPath);
            Console.WriteLine("updated file: " + listFromFile);
        }
    }
}
