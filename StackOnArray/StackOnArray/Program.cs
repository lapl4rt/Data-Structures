using System;

namespace StackOnArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            StackOnArray<int> stint = new StackOnArray<int>();
            Random rand = new Random();
            int[] elements = new int[20];
            for (int i = 0; i < 20; i++)
                elements[i] = rand.Next(20);
            stint.Push(elements);
            stint.Print();
            stint.Clear();
        }
    }

    public class StackOnArray<T>
    {
        private T[] _set;
        private int capacity;
        private int size;

        public int Count
        {
            get { return size; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public StackOnArray()
        {
            size = 0;
            capacity = 2;
            _set = new T[Capacity];
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public T Pop()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty");
            return _set[--size];
        }

        public T Peek()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty");
            return _set[size - 1];
        }

        public void Push(T element)
        {
            //if overflow
            if (size == Capacity)
                Realloc();
            _set[size++] = element;
        }

        private void Realloc(int times = 2)
        {
            T[] newSet = new T[times * size];
            _set.CopyTo(newSet, 0);
            _set = newSet;
            Capacity = _set.Length;
        }


        public void Push(params T[] elements)
        {
            foreach (var el in elements)
                Push(el);
        }

        public void Clear()
        {
            size = 0;
            Capacity = 10;
            _set = new T[Capacity];
        }

        public void Print()
        {
            for (int i = Count - 1; i >= 0; i--)
                Console.Write(_set[i] + " ");
            Console.WriteLine();
        }
    }

}
