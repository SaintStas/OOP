using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public partial class Stack
    {
        static Stack()
        {
            negativeStacks = 0;
            sessionId = DateTime.Now.Ticks;
        }
        // Приведёт к ошибке, т.к. пустой закрытый конструктор запрещает создавать объекты по-умолчанию.
        // private Stack() 
        // { }
        public Stack()
        {
            Stack.countStacks++;
            stack = new List<int>(5);
            size = stack.Capacity;
            PushArray();
            MakeStack();
        }
        public Stack(List<int> numbers)
        { 
            Stack.countStacks++;
            stack = numbers;
            size = stack.Count;
            MakeStack();
        }
        public List<int> Numbers
        {
            get 
            {
                return this.stack;
            }
            set 
            {
                Console.WriteLine("Changed numbers in stack: ");
                this.stack = value;
                foreach(var nums in stack)
                {
                     Console.Write($"{nums} ");
                }
                Console.WriteLine();
            } 
        }
        private void MakeStack()
        {
            stack.Reverse();
        }
        public void PushArray()
        {
            for (int i = 0; i < size; i++)
            {
                stack.Add(Convert.ToInt32(Console.ReadLine()));
            }
        }
        public void Push(ref int number)
        {
             stack.Insert(0, number);
        }
        public void Pop()
        {
            stack.RemoveAt(0);
        }
        public int StackLen()
        {
            int i;
            for (i = 0; i < stack.Count; i++)
            {
                i++;
            }
            return i;
        }
        public bool inNegative()
        {
            bool isNegative = false;
            for (int i = 0; i < stack.Count; i++)
            {
                if (stack[i] < 0)
                {
                    isNegative = true;
                    negativeStacks++;
                    return isNegative;
                }
            }
            return isNegative; 
        }
        public int GetTop()
        {
            return stack[0];
        }
       public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return stack.ToString();
        }
        public static object PrintClassData()
        {
            Console.WriteLine($"Information about class");
            Console.WriteLine("Count stacks: " + Stack.countStacks);
            Console.WriteLine("Count negative stacks: " + Stack.negativeStacks);
            Console.WriteLine("Session ID: " + Stack.sessionId);
            return 0;
        }
       public void Print(out int stackLen)
       {
           foreach (int element in stack)
           {
                Console.Write($"{element} ");
           }
            Console.WriteLine();
            stackLen = StackLen();
            Console.WriteLine($"Size of stack: {stackLen}");
            Console.WriteLine($"Stack owner: {StackOwner}");
       }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int stackLen;
            Stack firstStack = new Stack(); 
            firstStack.Numbers = new List<int>() {899, 3, 6, 1, 7};
            Console.WriteLine(firstStack.Numbers);
            Console.WriteLine();
            Console.WriteLine("Creating stacks.");
            List<int> numbers = new List<int>() {-27, 42, -56, 64, -128};
            Stack secondStack = new Stack(numbers);
            List<int> numbers1 = new List<int>() {-9, 34, 26, 81, 1};
            Stack thirdStack = new Stack(numbers1);
            List<int> numbers2 = new List<int>() {101, 108, 228, 1337, 1488};
            Stack firthStack = new Stack(numbers2);
            List<int> numbers3 = new List<int>() {-42, 42, 0, 2, 9};
            Stack fifthStack = new Stack(numbers3);
            List<int> numbers4 = new List<int>() {-27, 42, -56, 64, -128};
            Stack sixthStack = new Stack(numbers4);
            Console.WriteLine("Overrided functions.");
            Console.WriteLine(secondStack.GetHashCode());
            Console.WriteLine(secondStack.Equals(secondStack));
            Console.WriteLine(secondStack.ToString());
            Console.WriteLine();
            Console.WriteLine("Method Pop");
            secondStack.Pop();
            secondStack.Print(out stackLen);
            Console.WriteLine(secondStack.GetType());
            int numb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Method Push");
            secondStack.Push(ref numb);
            secondStack.Print(out stackLen);
            Stack[] stacks = new Stack[6];
            stacks[0] = firstStack;
            stacks[1] = secondStack;
            stacks[2] = thirdStack;
            stacks[3] = firthStack;
            stacks[4] = fifthStack;
            stacks[5] = sixthStack;
            List<int> tops = new List<int>(stacks.Length); 
            Console.WriteLine("Output stacks with negative elements");
            foreach (var stack in stacks)
            {
                tops.Add(stack.GetTop());
                if (stack.inNegative() == true)
                {
                    stack.Print(out stackLen);
                }
            }
            int max = tops[0];
            int min = tops[0];
            for (int i = 0; i < tops.Capacity; i++)
            {
                if (tops[i] > max)
                {
                    max = tops[i];
                }
                if (tops[i] < max)
                {
                    min = tops[i];
                }
            }
            Console.WriteLine("Output stacks with highest and lowest top-element");
            foreach (var stack in stacks)
            {
                if (stack.GetTop() == max)
                {
                    Console.WriteLine($"Stack with highest top\n");
                    stack.Print(out stackLen);
                }
                if (stack.GetTop() == min)
                {
                    Console.WriteLine($"Stack with lowest top\n");
                    stack.Print(out stackLen);
                }
            }
            Console.WriteLine();
            Stack.PrintClassData();
            
            // анонимный тип на основе Stack
            var anonStack = new { array = new List<int>() { 8, 1, 6, 3, 7 } };
            for (int i = (anonStack.array.Count - 1); i >= 0; --i)
            {
                Console.Write($"{anonStack.array[i]} ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}