using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    public class Queue<T>
    {
        public T[] queue;
        private int end;

        public Queue(T[] startingQueue)
        {
            if (startingQueue != null)
            {
                queue = startingQueue;
                end = queue.Length;
            }
            else
            {
                end = 0;
            }
        }

        public void ShowElements()
        {
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public int Size()
        {
            if (!IsEmpty())
            {
                return queue.Length;
            }
            return -1;
        }

        public void Add(T element)
        {
            if (element != null)
            {
                T[] temp = new T[end + 1];
                Array.Copy(queue, temp, end);
                temp[end] = element;
                queue = temp;
                end++;
            }
            else
            {
                throw new ArgumentNullException("Enter valid element to add");
            }
        }

        public void Remove()
        {
            T[] temp = new T[end - 1];
            Array.Copy(queue, 1, temp, 0, end - 1);
            queue = temp;
            end--;
        }

        public T HeadValue()
        {
            if (!IsEmpty())
            {
                return queue[0];
            }
            throw new Exception("Queue is empty");
        }

        public T LastValue()
        {
            if (!IsEmpty())
            {
                return queue[end - 1];
            }
            throw new Exception("Queue is empty");
        }

        public void Clear()
        {
            queue = new T[0];
            end = 0;
        }

        public bool IsEmpty()
        {
            if (queue.Length <= 0)
            {
                return true;
            }
            return false;
        }
    }

}
