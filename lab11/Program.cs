using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Stack
    {
        public List<int> stack;
        public Stack(List<int> numbers)
        { 
            this.stack = numbers;
            MakeStack();
        }
        public int Length 
        {
            get { return stack.Count; } 
        }
        public int this[int number]
        {
            get { return stack[number]; }
            set { stack[number] = value; } 
        }
        private void MakeStack()
        {
            stack.Reverse();
        }
        public void Push(ref int number)
        {
             stack.Insert(0, number);
        }
        public void Pop()
        {
            stack.RemoveAt(0);
        }
        public bool inNegative()
        {
            bool isNegative = false;
            for (int i = 0; i < stack.Count; i++)
            {
                if (stack[i] < 0)
                {
                    isNegative = true;
                    return isNegative;
                }
            }
            return isNegative; 
        }
        public int GetTop()
        {
            return stack[0];
        }
        public int GetMin()
        {
            return stack.Min();
        }
        public int GetMax()
        {
            return stack.Max();
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < stack.Count; i++)
            {
                sum += stack[i];
            }
            return sum;
        }
       public void Print()
       {
           foreach (int element in stack)
           { Console.Write(element + " "); }
           Console.WriteLine();
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] year = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 3;
            var length = from month in year where month.Length == n select month;
            var alphabeth = from month in year orderby month select month;
            var sumWinMounth = from month in year where month == year[0] || 
                                                        month == year[1] || 
                                                        month == year[11] || 
                                                        month == year[5] ||
                                                        month == year[6] ||
                                                        month == year[7] select month; 
            var umonths = from month in year where month.Contains('u') && month.Length >= 4 select month;  
            Console.WriteLine("Select by string length");
            foreach (string months in length)
            { Console.WriteLine(months); }
            Console.WriteLine("\nSort by alphabeth");
            foreach (string months in alphabeth)
            { Console.WriteLine(months); }
            Console.WriteLine("\nSelect by char 'u' and string length");
            foreach (string months in umonths)
            { Console.WriteLine(months); }
            Console.WriteLine("\nSelect only summer's and winter's months");
            foreach (string months in sumWinMounth)
            { Console.WriteLine(months); }
            
            Console.WriteLine("\nWorking with List<Stack>");
            List<int> numbers0 = new List<int>() {899, 3, 6, 1, 7};
            Stack firstStack = new Stack(numbers0);
            List<int> numbers = new List<int>() {-27, 42, -56, 64, -128};
            Stack secondStack = new Stack(numbers);
            List<int> numbers1 = new List<int>() {9, 34, 26, 81, 1};
            Stack thirdStack = new Stack(numbers1);
            List<int> numbers2 = new List<int>() {101, 108, 228, 1337, 1488};
            Stack firthStack = new Stack(numbers2);
            List<int> numbers3 = new List<int>() {0};
            Stack fifthStack = new Stack(numbers3);
            List<int> numbers4 = new List<int>() {-27, -56, -158};
            Stack sixthStack = new Stack(numbers4);
            Stack[] stacks = new Stack[6];
            stacks[0] = firstStack;
            stacks[1] = secondStack;
            stacks[2] = thirdStack;
            stacks[3] = firthStack;
            stacks[4] = fifthStack;
            stacks[5] = sixthStack;
            var minMaxTop = from stack in stacks where stack.GetTop() == stack.GetMin() || stack.GetTop() == stack.GetMax() select stack;
            Console.WriteLine("Stacks where top element equal the min or max element");
            foreach (var stack in minMaxTop)
            { stack.Print(); }
            Console.WriteLine("\nNegative stacks");
            var negative = from stack in stacks where stack.inNegative() select stack;  
            foreach (var stack in negative)
            { stack.Print(); }
            Console.WriteLine("\nMinimal stack");
            var minStack = stacks.Min(stack => stack.Length);
            Console.WriteLine(minStack);
            Console.WriteLine("\nStack length is '1' or '3'");
            var oneThreeLength = from stack in stacks where stack.Length == 1 || stack.Length == 3 select stack;
            foreach (var stack in oneThreeLength)
            { stack.Print(); }
            Console.WriteLine("\nSorted stack by count elements");
            var sortedStack = from stack in stacks orderby stack.Sum() select stack; 
            foreach (var stack in sortedStack)
            { stack.Print(); }

            
        }
    }
}
