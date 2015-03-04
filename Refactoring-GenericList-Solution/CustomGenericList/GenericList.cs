namespace GenericList
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndexInRange(index);

                return this.elements[index];
            }
        }

        public void Add(T value)
        {
            if (this.Count >= this.Capacity)
            {
                Array.Resize(ref this.elements, this.elements.Length * 2);
            }

            this.elements[Count] = value;
            this.Count++;
        }

        public void InsertAt(T value, int index)
        {
            this.ValidateIndexInRange(index);

            if (this.Count >= this.Capacity)
            {
                Array.Resize(ref this.elements, this.elements.Length * 2);
            }

            T[] newElements = new T[Capacity + 1];

            for (int i = 0; i < index; i++)
            {
                newElements[i] = this.elements[i];
            }
            newElements[index] = value;
            for (int i = index + 1; i <= this.Count; i++)
            {
                newElements[i] = this.elements[i - 1];
            }

            this.elements = newElements;
            this.Count++;
        }

        public void Remove(T value)
        {
            int index = this.Find(value); 
            this.RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndexInRange(index);
            T[] newElements = new T[Capacity];

            for (int i = 0; i < index; i++)
            {
                newElements[i] = this.elements[i];
            }
            for (int i = index; i < this.Count; i++)
            {
                newElements[i] = this.elements[i + 1];
            }

            this.elements = newElements;
            this.Count--;
        }

        public void Clear()
        {
            Array.Clear(this.elements, 0, this.elements.Length);
            this.Count = 0;
        }

        public int Find(T element)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public T Min()
        {
            T min = this.elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = this.elements[i];
                if (listItem.CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.elements[0];
            for (int i = 1; i < Count; i++)
            {
                T listItem = this.elements[i];
                if (listItem.CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder listOutput = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                listOutput.AppendFormat("[{0}] = {1}{2}",
                    index, elements[index], Environment.NewLine);
            }

            return listOutput.ToString();
        }

        private void ValidateIndexInRange(int index)
        {
            if ((index < 0) || (this.Count <= index))
            {
                throw new IndexOutOfRangeException(string.Format("Index must be in range [{0}, {1}]", 0, this.Count - 1));
            }
        }
    }
}
