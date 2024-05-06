using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_part3
{
    public class LinkedList
    {
        protected Node Head;

        public LinkedList(Node head)
        {
            Head = head;    
        }

        public bool isEmpty() { return Head == null; }  

        public void Append(int input_number)
        {
            if(isEmpty()) 
            {
                Head = new Node(input_number);
            }

            Node p = Head;

            while (p.Next != null) 
            {
                p = p.Next;
            }

            p.Next = new Node(input_number);
        }

        public void Prepend(int input_number)
        {
            if(isEmpty())
            {
                Append(input_number);
            }

            Head = new Node(input_number, Head);
        }

        public int Pop()
        {
            if(isEmpty())
            {
                Console.WriteLine("linked list is empty, defualt output - 0");
                return 0;
            }

            Node p = Head;
            int output;


            if (p.Next == null)
            {
                output = p.Value;
                Head = null;
                return output;
            }

            while (p.Next.Next != null) { p = p.Next; }

            output = p.Next.Value;
            p.Next.Next = null;
            return output;          
        }

        public int Unqueue()
        {
            if (isEmpty())
            {
                return Pop();
            }

            int output = Head.Value;
            Head = Head.Next;
            return output;     
        }

        public int Length()
        {
            int length = 0;
            if (isEmpty())
            {
                return length;  
            }

            Node p = Head;  

            while (p.Next != null) 
            {
                length ++;   
                p = p.Next;
            }
            return length;
        }
        public IEnumerable<int> ToList()
        {
            IEnumerable<int> list = new List<int>();
            Node p = Head;
            while(p.Next != null)
            {
                List<int> iEnumerableToList = list.ToList();    
                iEnumerableToList.Add(p.Value);
                list = iEnumerableToList;
                p = p.Next;
            }
            return list;    
        }

        public bool IsCircular()
        {
            if (isEmpty())
            {
                return false;
            }

            Node p = Head;

            while (p.Next != null) 
            {
                if (p.Next == Head)
                {
                    return true;
                }

                p = p.Next; 
            }
            return false;              
        }

        public void Sort()
        {
            List<int> list = ToList().ToList();   
            list.Sort();
            Head = ListToLinkedList(list);  

        }

        public Node ListToLinkedList(List<int> list)
        {
            Node Head = new Node(list[0]);
            Node p = Head;  
            for (int i = 1; i < list.Count; i++) 
            {
                p.Next = new Node(list[i]);
                p = p.Next;
            }
            return Head;
        }

        public Node GetMaxNode()
        {
            Node max = Head;
            Node p = Head;  
            while (p != null) 
            {
                if (p.Value > max.Value)  
                    max = p;
                p = p.Next;
            }
            return max; 
        }
        public Node GetMinNode()
        {
            Node min = Head;
            Node p = Head;
            while (p != null)
            {
                if (p.Value < min.Value)
                    min = p;
                p = p.Next;
            }
            return min;
        }

        public override string ToString()
        {
            Node p = Head;
            string output = "";
            while (p != null)
            {
                output += $"{p.Value},";
                p = p.Next;
            }
            return output;
        }

    }
}
