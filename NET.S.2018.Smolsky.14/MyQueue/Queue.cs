using System;

namespace MyQueue
{
    /// <summary>
    /// Provides functionality to work with queue of elements of any type T
    /// </summary>
    /// <typeparam name="T">type of elements in the queue</typeparam>
    public class Queue<T>
    {
        private T[] queue;

        /// <summary>
        /// Current number of elements in the queue
        /// </summary>
        public int Length
        {
            get
            {
                if (queue is null)
                {
                    return 0;
                }

                return queue.Length;
            }
        }

        /// <summary>
        /// Adds new element to the queue
        /// </summary>
        /// <param name="newElement"></param>
        public void Enqueue(T newElement)
        {
            if (queue == null)
            {
                queue = new T[0];
            }

            if (queue.Length == int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("queue is full, no more place to add elements");
            }

            T[] tempQueue = new T[queue.Length + 1];
            Array.Copy(queue, tempQueue, queue.Length);

            // queue.CopyTo(tempQueue, 0);
            tempQueue[tempQueue.Length - 1] = newElement;
            queue = tempQueue;
        }

        /// <summary>
        /// Gets the first element from the queue, shrinks the rest of the queue
        /// </summary>
        /// <returns>element of type T</returns>
        public T Dequeue()
        {
            if (queue is null)
            {
                throw new ArgumentOutOfRangeException("queue is null, nothing to dequeue");
            }

            // TODO: RRS - will it allow to cleanup not used anymore instances of arrays?
            T res = queue[0];

            if (queue.Length == 1)
            {
                queue = null;
                return res;
            }
            
            T[] newArray = new T[queue.Length - 1];
            Array.Copy(queue, newArray, queue.Length - 1);

            // queue.CopyTo(newArray, 1);
            queue = newArray;

            return res;
        }
    }
}