using System;
namespace PracticeExercise2
{
    public interface IList<T>
    {
        T Get(int index);

        void Append(T value);
        void Prepend(T value);

        void InsertAfter(T newValue, T existingValue);
        void InsertAt(T value, int index);

        void Remove(T value);
        void RemoveAt(int index);

        T? First { get; }
        T? Last { get; }
        bool IsEmpty { get; }
        int Length { get; }

        int FirstIndexOf(T value);
        bool Contains(T value);

        void Clear();
        IList<T> Reverse();
    }
}

