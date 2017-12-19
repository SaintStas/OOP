using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{   
    public static class StringChanger
    {
        public static string RemoveMarks(string str)
        {
            char[] marks = { '!', '?', ',', '.', '-', ':', ';' };
            for (int i = 0; i < str.Length; i++)
            {
                if (marks.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        public static string RemoveSpaces(string str)
        {
            return str.Replace("  ", string.Empty);
        }
        public static string AddSymbols(string str, char ch, int pos)
        {
            return str.Insert(pos, Convert.ToString(ch));
        }
        public static string ToUpperCase(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                   str = str.Replace(str[i], Char.ToUpper(str[i]));
                }
            }
            return str;
        }
        public static string Reverse(string str)
        {
            char[] symbols = str.ToCharArray();
            Array.Reverse(symbols);
            return new string(symbols);
        }
    }
    public class User
    {
        public int compression;
        public int offset;
        public delegate void GetMove(string message); 
        public delegate void GetCompress(string message);
        public event GetMove Move; 
        public event GetCompress Compress;
        public User(int compression, int offset)
        {
            this.compression = compression;
            this.offset = offset;
        }
        public void Moving(int distance)
        {
            offset += distance;
            if (Move != null)
            {
                Move("User moved " + offset + " meters.");
            }
        }
        public void Compressing(int value)
        {
            compression -= value;
            if (Compress != null)
            {
                Compress("User compressed data to " + compression + ".");
            }   
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User(27, 0);
            User user2 = new User(1448, 0);
            user1.Move += (string message) => Console.WriteLine(message);
            user1.Compress += (string message) => Console.WriteLine(message);
            user1.Moving(10);
            user1.Compressing(5);
            user2.Move += (string message) => Console.WriteLine(message);
            user2.Moving(300);
            user2.Move -= (string message) => Console.WriteLine(message);
            user2.Compressing(1128);
            Console.WriteLine(user2.compression + "\n");
            Console.WriteLine("String handle\n-----------------------------\n");
            string str = "s,t,r.i    ;n  g!";
            Func<string, string> Handler = StringChanger.RemoveMarks;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Handler = StringChanger.RemoveSpaces;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Handler = StringChanger.ToUpperCase;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Func<string, char, int, string> Symbols = StringChanger.AddSymbols;
            Symbols = StringChanger.AddSymbols;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Symbols(str, 'Q', 4));
            Handler = StringChanger.Reverse;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str)); 
        }
    }
}