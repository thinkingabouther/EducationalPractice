using System;
using System.Collections;
using System.Collections.Generic;

namespace Task10
{
    public class CustomList<T> : IEnumerable<T> where T : class, IMember<T>
    {
        public int Length { get; set; } = 0;
        public T Head;

        private void AddTo(T elementToAdd, int index)
        {
            var curElem = Head;
            if (Length == 0)
            {
                Head = elementToAdd;
                Length++;
            }

            if (Length == index)
            {
                while (curElem.NextMember != null)
                {
                    curElem = curElem.NextMember;
                }

                curElem.NextMember = elementToAdd;
                Length++;
                return;
            } 
            
            if (index > Length) throw new TooLargeIndexException(index);
            int cnt = 0;
            while (cnt < index)
            {
                curElem = curElem.NextMember;
                cnt++;
            }

            var temp = curElem.NextMember;
            curElem.NextMember = elementToAdd;
            curElem.NextMember.NextMember = temp;
            Length++;
        }

        public void Add(T elementToAdd)
        {
            if (Length == 0)
            {
                Head = elementToAdd;
                Length++;
                return;
            }
            
            var curElem = Head;
            while (curElem.NextMember != null)
            {
                curElem = curElem.NextMember;
            }

            curElem.NextMember = elementToAdd;
            Length++;
        }

        private T GetByIndex(int index)
        {
            if (index >= Length) throw new TooLargeIndexException(index);
            var curElem = Head;
            int cnt = 0;
            while (cnt < index)
            {
                curElem = curElem.NextMember;
                cnt++;
            }

            return curElem;

        }

        public T this[int index]
        {
            get => GetByIndex(index);
            set => AddTo(value, index);
        }

        public void RemoveAt(int index)
        {
            if (index >= Length) throw new TooLargeIndexException(index);
            if (index == 0)
            {
                Head = Head.NextMember;
                Length--;
                return;
            }
            var curElem = Head;
            if (index == Length - 1)
            {
                while (curElem.NextMember != null) curElem = curElem.NextMember;
                Length--;
                curElem = null;
                return;
            }
            var cnt = 0;
            while (cnt < index-1)
            {
                curElem = curElem.NextMember;
                cnt++;
            }

            curElem.NextMember = curElem.NextMember.NextMember;

        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListEnumerator(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public class CustomListEnumerator : IEnumerator<T>
        {
            private T _head;
            private T _curElem;
            private bool _firstElementEnumerated = false;

            public CustomListEnumerator(T head)
            {
                _head = head;
                _curElem = head;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_curElem == null) return false;
                if (!_firstElementEnumerated)
                {
                    _firstElementEnumerated = true;
                    return true;
                }
                
                try
                {
                    if (_curElem.NextMember != null)
                    {
                        _curElem = _curElem.NextMember;
                        return true;
                    }
                    return false;
                }
                catch (NullReferenceException)
                {
                    throw new IterationException();
                }
            }

            public void Reset()
            {
                _curElem = _head;
                _firstElementEnumerated = false;
            }

            public T Current => _curElem;

            object IEnumerator.Current => Current;
        }
        
        public class IterationException : Exception
        {
            public IterationException() : base("Caught null reference exception")
            {

            }
        }

        public bool Contains(T element)
        {
            foreach (var elem in this)
            {
                if (element.Equals(elem)) return true;
            }

            return false;
        }
    }

    public interface IMember<T> where T : class
    {
        T NextMember { get; set; }
    }

    public class TooLargeIndexException : Exception
    {

        public TooLargeIndexException(int index) : base(ModifyExceptionMessage(index))
        {
            
        }
        private static string ModifyExceptionMessage(int index)
        {
            return $"{index} is out of list. Try lower one";
        }
    }

    
}