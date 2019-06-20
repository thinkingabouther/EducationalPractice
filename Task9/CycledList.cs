using System;
using System.Collections.Generic;

namespace Task9
{
    public class CycledList
    {
        public ListMember Head { get; set; }
        public int Length { get; }
        
        public CycledList(int length)
        {
            Length = length;
            CreateList(1);
        }

        public int FindByIndex(int index)
        {
            return FindByIndex(index, Head);
        }
        
        public int FindByIndex(int index, ListMember curMember)
        {
            if (curMember.Index == index)
            {
                return curMember.Value;
            }

            if (curMember.NextMember != null)
            {
                return FindByIndex(index, curMember.NextMember);
            }
            throw new IndexNotFoundException(index);
        }

        public void CreateList(int count)
        {
            var currValue = Utilities.ConsoleInputParse.Int($"Input element with number {count}");
            if (count == 1)
            {
                Head = new ListMember(count, currValue);
            }
            else
            {
                if (currValue > 0)
                {
                    var temp = Head;
                    Head = new ListMember(count, currValue);
                    Head.NextMember = temp;
                }
                
                if (currValue < 0)
                {
                    var curElem = Head;
                    while (curElem.NextMember != null)
                    {
                        curElem = curElem.NextMember;
                    }
                    curElem.NextMember = new ListMember(count, currValue);
                }
                
                if (currValue == 0)
                {
                    var curElem = Head;
                    if (curElem.Value < 0)
                    {
                        var temp = curElem;
                        Head = new ListMember(count, currValue);
                        Head.NextMember = temp;
                    }
                    else
                    {
                        while (curElem.NextMember != null && curElem.NextMember.Value > 0)
                        {
                            curElem = curElem.NextMember;
                        }

                        if (curElem.NextMember == null) curElem.NextMember = new ListMember(count, currValue);
                        else
                        {
                            var temp = curElem.NextMember;
                            curElem.NextMember = new ListMember(count, currValue);
                            curElem.NextMember.NextMember = temp;
                        }
                    }
                }
                
            }
            if (count < Length) CreateList(count+1);
            if (count == Length)
            {
                var curElem = Head;
                while (curElem.NextMember != null)
                {
                    curElem = curElem.NextMember;
                }

                curElem.NextMember = Head;
            }

        }

        public string GetAllMembers()
        {
            string output = "";
            var curElem = Head;
            while (curElem.NextMember != null)
            {
                output += curElem + "\n";
                if (curElem.NextMember == Head) break;
                curElem = curElem.NextMember;
            }

            return output;
        }



        public class ListMember
        {
            public int Value { get; }
            public int Index { get; }
            public ListMember NextMember { get; set; }

            public ListMember(int index, int value)
            {
                Index = index;
                Value = value;
            }


            public override string ToString()
            {
                return $"Element with index {Index}, value {Value}";
            }
        }
    }

    public class IndexNotFoundException : Exception
    {
        private static string ModifyExceptionMessage(int index)
        {
            return $"{index} was not found in the list";
        }

        public IndexNotFoundException(int index) : base(ModifyExceptionMessage(index))
        {
            
        }
    }
    
    
}