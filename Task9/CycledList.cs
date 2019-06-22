using System;
using System.Collections.Generic;

namespace Task9
{
    public class CycledList
    {
        public ListMember Head { get; set; }
        public int Length { get; set; }

        public CycledList(int length)
        {
            Length = length;
            CreateList(1);
        }

        public int FindByValue(int value)
        {
            return FindByValue(value, Head);
        }
        
        public int FindByValue(int value, ListMember curMember)
        {
            if (curMember.Value == value)
            {
                return curMember.Index;
            }

            if (curMember.NextMember != Head)
            {
                return FindByValue(value, curMember.NextMember);
            }
            throw new ValueNotFoundException(value);
        }

        public void DeleteByValue(int value)
        {
            if (Head.Value == value)
            {
                if (Length == 1)
                {
                    Head = null;
                    Length = 0;
                    return;
                }
                Head = Head.NextMember;
                Length--;
            }
            else
            {
                DeleteByValue(value, Head.NextMember, Head);
            }
        }

        public void DeleteByValue(int value, ListMember curMember, ListMember prevMember)
        {
            if (curMember.NextMember == Head)
            {
                if (curMember.Value != value) throw new ValueNotFoundException(value);
                else
                {
                    prevMember.NextMember = Head;
                    Length--;
                }
            }
            else
            {
                if (curMember.Value == value)
                {
                    prevMember.NextMember = curMember.NextMember;
                    Length--;
                }
                else
                {
                    DeleteByValue(value, curMember.NextMember, curMember);
                }
            }
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
            if (Length == 0)
            {
                return "The list is empty";
            }
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

    public class ValueNotFoundException : Exception
    {
        private static string ModifyExceptionMessage(int value)
        {
            return $"{value} was not found in the list";
        }

        public ValueNotFoundException(int index) : base(ModifyExceptionMessage(index))
        {
            
        }
    }
    
    
}