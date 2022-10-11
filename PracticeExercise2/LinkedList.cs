using System;
using System.Reflection;

namespace PracticeExercise2
{

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next=null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

    public class LinkedList<T> : IList<T>
    {
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public T? First => IsEmpty ? default(T) : Head.Data;

        public T? Last => IsEmpty ? default(T) : Tail.Data;

        public bool IsEmpty => Length == 0; 

        private int length = 0;
        public int Length => length;

        public void Append(T value)
        {

            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            length++;

        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;
        }

        public bool Contains(T value)
        {
            var currentNode = Head;
            for (int i = 0; i < length; i++)
            {
                if (currentNode.Data.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while(currentNode!=null)
            {
                if( currentNode.Data.Equals(value) )
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }
            var currentNode = Head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Data;
        }

        public void InsertAfter(T newValue, int existingValue)
        {
            var currentNode = Head;
            var newNode = new LinkedListNode<T>(newValue);
            for (int i = 0; i < length; i++)
            {
                if (currentNode.Data.Equals(existingValue))
                {
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                    if (newNode.Next == null)
                    {
                        Tail = newNode;
                    }
                    length++;
                    return;
                }
                currentNode = currentNode.Next;
            }

            Append(newValue);
        }

        public void InsertAt(T value, int index)
        {
            if ((index > (length)) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                Prepend(value);
            }
            else if (index == length)
            {
                Append(value);
                length++;
            }
            else
            {
                var newNode = new LinkedListNode<T>(value);
                var currentNode = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
                if (currentNode == Tail)
                {
                    Tail = newNode;
                }
                length++;
            }

            //in class work:

            //if (index < 0 || index > length)
            //{
            //    throw new IndexOutOfRangeException();
            //}

            //if (index == 0)
            //{
            //    Prepend(value);
            //}

            //var currentNode = Head;
            //int currentIndex = 0;

            //while (currentNode != null)
            //{
            //    if (currentIndex == index - 1)
            //    {
            //        var newNode = new LinkedListNode<T>(value);
            //        newNode.Next = currentNode.Next;
            //        currentNode.Next = newNode;

            //        if (currentNode == Tail)
            //        {
            //            Tail = newNode;
            //        }
            //        length++;
            //    }
            //    currentNode = currentNode.Next;
            //    currentIndex++;
            //}
        }

        public void Prepend(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            length++;
        }

        public void Remove(T value)
        {
            // If list is empty, we're done, son. 
            if( IsEmpty )
            {
                return;
            }

            // Remove head
            if( Head.Data.Equals(value) )
            {
                // 1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Head = Head.Next;
                }
                length--;

                return;
            }

            // Remove non-head node
            var currentNode = Head;
            while( currentNode != null)
            {
                if ( currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    length--;

                    if( nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }

                    return;
                }

                currentNode = currentNode.Next;
            }

        }

        public void RemoveAt(int index)
        {
            if ((index > (length - 1)) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            var value = Get(index);
            Remove(value);
        }

        public IList<T> Reverse()
        {
            IList<T> reversedList = new LinkedList<T>();
            var currentNode = Head;
            for (int i = 0; i < length; i++)
            {
                reversedList.Prepend(currentNode.Data);
                currentNode = currentNode.Next;
            }

            return reversedList;
        }

        public override string ToString()
        {
            string result = "[";

            for(var currentNode = Head; currentNode !=null; currentNode = currentNode.Next )
            {
                result += currentNode.ToString();
                if(currentNode != Tail)
                {
                    result += ", ";
                }

            }
            result += "]";

            return result;

        }
    }
}

