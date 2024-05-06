using System;

namespace oop_part3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node head = new Node(1);
            LinkedList x = new LinkedList(head);

            x.Append(66); x.Append(31); x.Append(4); x.Append(15);

            x.Prepend(99);

            Console.WriteLine(x.Pop());
            Console.WriteLine(x.Unqueue());
            IEnumerable<int> y = x.ToList();
            
           x.Sort();

           Console.WriteLine(x.ToString());

        }
    }

}


