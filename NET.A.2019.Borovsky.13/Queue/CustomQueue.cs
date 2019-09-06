namespace HomeWork13
{
    using System;
    using System.Collections;
    using System.Collections.Generic;


    /// <summary>
    /// Class implements operations with queue.
    /// </summary>
    /// <typeparam name="T"> Generic param. </typeparam>
    public class CustomQueue<T> : IEnumerator<T>
    {
        private List<T> queue;
        private int end;
        private int current;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueue{T}"/> class.
        /// </summary>
        /// <param name="startingQueue"> Initialized queue. </param>
        public CustomQueue(List<T> startingQueue)
        {
            if (startingQueue != null)
            {
                this.queue = startingQueue;
                this.end = this.queue.Count;
                this.current = -1;
            }
            else
            {
                this.end = 0;
                this.current = -1;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueue{T}"/> class.
        /// </summary>
        public CustomQueue()
        {
            this.queue = new List<T>();
            this.end = 0;
            this.current = -1;
        }

        /// <summary>
        /// Gets size of the queue. -1 if its empty.
        /// </summary>
        public int Size
        {
            get
            {
                if (!this.IsEmpty())
                {
                    return this.queue.Count;
                }

                return -1;
            }
        }

        /// <summary>
        /// Gets all elements of queue.
        /// </summary>
        public List<T> QueueList
        {
            get
            {
                if (!this.IsEmpty())
                {
                    return this.queue;
                }

                throw new ArgumentException("Queue is empty");
            }
        }

        /// <summary>
        /// Gets current element.
        /// </summary>
        /// <returns> Current chosen element. </returns>
        public T Current
        {
            get
            {
                if (this.current < 0)
                {
                    throw new ArgumentException("Index was out of range");
                }

                if (!this.IsEmpty())
                {
                    return this.queue[this.current];
                }

                throw new Exception("Queue is empty");
            }
        }

        /// <summary>
        /// Gets location of pointer.
        /// </summary>
        /// <returns> Pointer index. </returns>
        public int CurrentIndex => this.current + 1;

        /// <summary>
        /// Gets current object.
        /// </summary>
        object IEnumerator.Current => this.Current;

        /// <summary>
        /// Writes down to console all the queue.
        /// </summary>
        public void ShowAllElements()
        {
            foreach (var item in this.queue)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Writes down to console current element.
        /// </summary>
        public void ShowCurrentElement()
        {
            Console.WriteLine(this.Current);
        }

        /// <summary>
        /// Moving pointer to the next position.
        /// </summary>
        /// <returns> If moving was succesfull. </returns>
        public bool MoveNext()
        {
            if (this.current == this.queue.Count - 1)
            {
                this.current = 0;
                return false;
            }

            this.current++;
            return true;
        }

        /// <summary>
        /// Setting pointer to the previous position.
        /// </summary>
        public void MovePrevious()
        {
            if (this.current <= 0)
            {
                throw new Exception("Can't go before zero");
            }

            this.current--;
        }


        /// <summary>
        /// Resetting pointer.
        /// </summary>
        public void Reset() => this.current = -1;

        /// <summary>
        /// Writing down to console pointer position.
        /// </summary>
        public void ShowCurrentIndex() => Console.WriteLine(this.current + 1);

        /// <summary>
        /// Removing current selected element.
        /// </summary>
        public void RemoveCurrent()
        {
            if (!this.IsEmpty())
            {
                if (this.current >= 0)
                {
                    this.queue.RemoveAt(this.current);
                }
            }
            else
            {
                throw new Exception("Queue is empty");
            }
        }

        /// <summary>
        /// Adds an element to the queue.
        /// </summary>
        /// <param name="element"> Element to add </param>
        public void Add(T element)
        {
            if (element != null)
            {
                this.queue.Add(element);
                this.end++;
            }
            else
            {
                throw new ArgumentNullException("Enter valid element to add");
            }
        }

        /// <summary>
        /// Removes first element from the queue.
        /// </summary>
        public void Remove()
        {
            this.queue.RemoveAt(0);
            this.end--;
        }

        /// <summary>
        /// Determines first element.
        /// </summary>
        /// <returns> First element. </returns>
        public T HeadValue()
        {
            if (!this.IsEmpty())
            {
                return this.queue[0];
            }

            throw new Exception("Queue is empty");
        }

        /// <summary>
        /// Determines last element.
        /// </summary>
        /// <returns> Last element. </returns>
        public T LastValue()
        {
            if (!this.IsEmpty())
            {
                return this.queue[this.end - 1];
            }

            throw new Exception("Queue is empty");
        }

        /// <summary>
        /// Method to delete all the queue.
        /// </summary>
        public void Dispose()
        {
            this.queue.RemoveRange(0, this.end);
            this.current = -1;
        }

        /// <summary>
        /// Determines if the queue is empty.
        /// </summary>
        /// <returns> False if not empty. </returns>
        public bool IsEmpty()
        {
            if (this.queue.Count <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
