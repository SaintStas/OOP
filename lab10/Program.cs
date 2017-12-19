using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace lab10
{
    public class Button
    {
        public int count;
        public string title;
        public Button(int count, string title)
        {
            this.count = count;
            this.title = title;
        }
        public void Show()
        {
            Console.WriteLine("\nButtons\nCount: {0}\nTitle: {1}\n", count, title);
        }
    }
    class Program
    {
        static void ButtonsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: 
                    Button new_butt = e.NewItems[0] as Button;
                    Console.WriteLine("Added new object: {0}", new_butt.title);
                    break;
                case NotifyCollectionChangedAction.Remove: 
                    Button old_butt = e.OldItems[0] as Button;
                    Console.WriteLine("Removed object: {0}", old_butt.title);
                    break;
                case NotifyCollectionChangedAction.Replace: 
                    Button replaced_butt = e.OldItems[0] as Button;
                    Button replacing_butt = e.NewItems[0] as Button;
                    Console.WriteLine("Object {0} replased object {1}", 
                                        replaced_butt.title, replacing_butt.title);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Working with ArrayList.");
            ArrayList list = new ArrayList() { 27, 54, 81, 108, 135 };
            list.Add("string");
            list.RemoveAt(5);
            Console.WriteLine("Length: {0}", list.Count);
            foreach (var element in list)
            { Console.Write(element + " "); }
            Console.WriteLine("\nThe object to search for ({0}) is at index {1}.", list[4], list.BinarySearch(list[4]));

            Console.WriteLine("\nWorking with Queue.");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(27);
            queue.Enqueue(54);
            queue.Enqueue(81);
            queue.Enqueue(108);
            queue.Enqueue(135);
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            { Console.Write(queue.Dequeue() + " "); }

            Console.WriteLine("\n\nWorking with Dictionary.");
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            dictionary.Add(1, 27);
            dictionary.Add(2, 54);
            dictionary.Add(3, 81);
            dictionary.Add(4, 108);
            dictionary.Add(5, 135);
            foreach (KeyValuePair<int, int> keyValue in dictionary)
            { Console.WriteLine(keyValue.Key + " - " + keyValue.Value); }
            Console.WriteLine("The value search for is {0}.", dictionary[3]);
            
            Console.WriteLine("\nWorking with Queue<Button>.");
            Button button1 = new Button(7, "accept");
            Button button2 = new Button(3, "cancle");
            Button button3 = new Button(1, "okay");
            Queue<Button> buttons = new Queue<Button>();
            buttons.Enqueue(button1);
            buttons.Enqueue(button2);
            buttons.Enqueue(button3);
            int quantity = buttons.Count;
            for (int i = 0; i < quantity; i++)
            { Console.Write(buttons.Dequeue().title + " "); }

            Console.WriteLine("\n\nWorking with Dictionary<int, Button>.");
            Dictionary<int, Button> dict_buttons = new Dictionary<int, Button>();
            dict_buttons.Add(1, button1);
            dict_buttons.Add(2, button2);
            dict_buttons.Add(3, button3);
            foreach (KeyValuePair<int, Button> keyValue in dict_buttons)
            { Console.WriteLine(keyValue.Key + " - " + keyValue.Value.title); }
            Console.WriteLine("The value search for is {0}.", dict_buttons[3]);

            Console.WriteLine("\nWorking with ObservableColletion<Button>.");
            ObservableCollection<Button> obs_buttons = new ObservableCollection<Button>();
            obs_buttons.CollectionChanged += ButtonsCollectionChanged;
            obs_buttons.Add(button1);
            obs_buttons.Add(button2);
            obs_buttons.Add(button3);
            obs_buttons.RemoveAt(2);
        }
    }
}
