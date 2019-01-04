using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var poem = new ArrayList();
            var poem2 = new ArrayList();
            int cnt = 0;
            var poemP3 = new List<Song>();
            //List<Neighbor> floorNeighbors = new List<Neighbor>();

            var floorNeighbors = new Dictionary<int, Neighbor>();
            int flatToFind;

            //ArrayListExample();
            //B7 P1 ArrayListPoemSort///////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Введите пять строк");
            for (int i = 0; i < 5; i++)
            {
                poem.Add(Console.ReadLine());
            }

            poem.Sort();
            poem.RemoveAt(poem.Count - 1);
            string[] ArrayP1 = new string[poem.Count];
            cnt = 0;

            foreach (var item in poem)
            {
                ArrayP1[cnt] = (string)item;
                cnt++;
            }

            PrintValue(ArrayP1);

            //B7 P2 ArrayListOfSortSong///////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Введите пять строк");
            for (int i = 0; i < 5; i++)
            {
                Song OneSong = new Song();
                OneSong.Lyrics = Console.ReadLine();
                poem2.Add(OneSong);
            }
            //poem.Sort();
            poem2.RemoveAt(poem2.Count - 1);
            string[] ArrayP2 = new string[poem2.Count];
            cnt = 0;
            foreach (Song item in poem2)
            {
                ArrayP2[cnt] = Convert.ToString(item);   //System.InvalidCastException: 'Не удалось привести тип объекта "Song" к типу "System.String".'
                cnt++;
            }
            PrintValue(ArrayP2);

            //B7 P3 GenerecListOfSongSort///////////////////////////////////////////////////////////////////////////////////////////    
            Console.WriteLine("Введите пять строк");
            for (int i = 0; i < 5; i++)
            {
                Song OneSong = new Song();
                OneSong.Lyrics = Console.ReadLine();
                poemP3.Add(OneSong);
            }
            //poemP3.Sort(); //ArgumentException: По крайней мере в одном объекте должен быть реализован интерфейс IComparable.
            //Добавил интерфейс IComparable<> в класс Song
            poemP3.Sort();

            poemP3.RemoveAt(poemP3.Count - 1);
            string[] ArrayP3 = new string[poemP3.Count];
            cnt = 0;
            foreach (Song item in poemP3)
            {
                ArrayP3[cnt] = Convert.ToString(item);
                cnt++;
            }
            PrintValue(ArrayP3);

            //B7 P4 GenerecListOfneighborSearch///////////////////////////////////////////////////////////////////////////////////////////
            // Console.WriteLine("Введите пять строк");
            //for (int i = 0; i < 3; i++)
            //{
            //    var neighb = new Neighbor { fullName = "neighbor" + i, flatNumder = 40 + i, phoneNumber = "123" + i + i + i + i + i };
            //    floorNeighbors.Add(neighb);
            //    Console.WriteLine($"{floorNeighbors[i].fullName} {floorNeighbors[i].flatNumder}  {floorNeighbors[i].phoneNumber}");
            //}
            //Console.WriteLine("Введите номер квартиры");
            //flatToFind = Convert.ToInt32(Console.ReadLine());

            //foreach (var item in floorNeighbors)
            //{
            //    if (item.flatNumder == flatToFind)
            //    {
            //        Console.WriteLine(item);
            //        break;
            //    }
            //}

            //B7 P5 DictionaryOfNeighborSearch///////////////////////////////////////////////////////////////////////////////////////////

            for (int i = 0; i < 3; i++)
            {
                var neighb = new Neighbor { fullName = "neighbor" + i, flatNumder = 40 + i, phoneNumber = "123" + i + i + i + i + i };
                floorNeighbors.Add(neighb.flatNumder, neighb);
                Console.WriteLine(neighb);
            }
            Console.WriteLine("Введите номер квартиры");
            flatToFind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(floorNeighbors[flatToFind]);

            Console.ReadLine();
        }




        public static void ArrayListExample()
        {
            var poem = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                var song = new Song();
                song.Lyrics = Console.ReadLine();
                poem.Add(song);
            }

            //poem.Sort();
            poem.RemoveAt(poem.Count - 1);

            object[] myArray = poem.ToArray();

            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }

        }

        public static void PrintValue(IEnumerable myArray)
        {
            Console.WriteLine("PrintValue");
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        class Song : IComparable<Song>
        {
            public string Lyrics;

            public override string ToString()
            {
                return this.Lyrics;
            }

            public int CompareTo(Song other)
            {
                if (other == null) return 1;
                return Lyrics.CompareTo(other.Lyrics);
            }
        }

        class Neighbor
        {
            public string fullName;
            public int flatNumder;
            public string phoneNumber;

            public override string ToString()
            {
                return $"{fullName} квартира № {flatNumder}, телефон {phoneNumber} ";
            }

        }
    }
}
