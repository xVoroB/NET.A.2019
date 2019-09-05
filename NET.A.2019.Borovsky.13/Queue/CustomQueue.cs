namespace HomeWork13
{
    using System;


    /// <summary>
    /// <see cref="CustomQueue{T}"/> class implements operations with queue.
    /// </summary>
    /// <typeparam name="T"> Generic param. </typeparam>
    public class CustomQueue<T>
    {
        private T[] queue;
        private int end;
        private int current;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueue{T}"/> class.
        /// </summary>
        /// <param name="startingQueue"> Initialized queue. </param>
        public CustomQueue(T[] startingQueue)
        {
            if (startingQueue != null)
            {
                this.queue = startingQueue;
                this.end = this.queue.Length;
                this.current = 0;
            }
            else
            {
                this.end = 0;
                this.current = 0;
            }
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
                    return this.queue.Length;
                }

                return -1;
            }
        }

        /// <summary>
        /// Gets all elements of queue.
        /// </summary>
        public T[] QueueArray
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
        /// Gets location of pointer.
        /// </summary>
        /// <returns> Pointer index. </returns>
        public int CurrentIndex => this.current + 1;

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
        /// Method to work with current element.
        /// </summary>
        /// <returns> Current chosen element. </returns>
        public T CurrentElement()
        {
            if (!this.IsEmpty())
            {
                return this.queue[this.current];
            }

            throw new Exception("Queue is empty");
        }

        /// <summary>
        /// Writes down to console current element.
        /// </summary>
        public void ShowCurrentElement()
        {
            Console.WriteLine(this.CurrentElement());
        }

        /// <summary>
        /// Moving pointer to the next position.
        /// </summary>
        public void Next()
        {
            if (this.current == this.queue.Length - 1)
            {
                throw new Exception("Can't go further");
            }

            this.current++;
        }

        /// <summary>
        /// Setting pointer to the previous position.
        /// </summary>
        public void Previous()
        {
            if (this.current == 0)
            {
                throw new Exception("Can't go before zero");
            }

            this.current--;
        }


        /// <summary>
        /// Resetting pointer.
        /// </summary>
        public void Reset() => this.current = 0;

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
                if (this.current > 0)
                {
                    this.BeforeCurrentRemove();
                    this.current--;
                }

                this.Remove();
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
                T[] temp = new T[this.end + 1];
                Array.Copy(this.queue, temp, this.end);
                temp[this.end] = element;
                this.queue = temp;
                this.end++;
            }
            else
            {
                throw new ArgumentNullException("Enter valid element to add");
            }
        }

        /// <summary>
        /// Removes first element from the queue;
        /// </summary>
        public void Remove()
        {
            T[] temp = new T[this.end - 1];
            Array.Copy(this.queue, 1, temp, 0, this.end - 1);
            this.queue = temp;
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
        public void Clear()
        {
            this.queue = new T[0];
            this.end = 0;
            this.current = 0;
        }

        /// <summary>
        /// Determines if the queue is empty.
        /// </summary>
        /// <returns> False if not empty. </returns>
        public bool IsEmpty()
        {
            if (this.queue.Length <= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Placing removing element to the start and pushing other.
        /// </summary>
        private void BeforeCurrentRemove()
        {
            for (int i = this.current; i > 0; i--)
            {
                T temp = this.queue[i];
                this.queue[i] = this.queue[i - 1];
                this.queue[i - 1] = temp;
            }
        }
    }
}
