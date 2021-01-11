using UnityEngine;

namespace MyGame
{
    public class ObjectsIterator<T> where T : class
    {
        private T[] objects;
        private int current;

        public ObjectsIterator(T[] objects, int first = 0)
        {
            this.objects = objects;
            current = first;
        }

        public bool OutOfRange
        {
            get
            {
                return current >= objects.Length;
            }          
        }

        public T GetCurrent()
        {
            if (objects == null || objects.Length == 0) return null;
            return objects[current];
        }

        public void MoveToNext()
        {
            if (objects == null || objects.Length == 0) return;
         
            if (objects.Length != current)
            {
                current++;
            }         
        }

        public void MoveToBegin()
        {
            current = 0;
        }
    }
}