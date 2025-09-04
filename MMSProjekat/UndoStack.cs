using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSProjekat
{
    internal class UndoStack
    {
        private List<UndoStackItem> stack;
        private int index;

        public UndoStack()
        {
            stack = new List<UndoStackItem>();
            index = -1;
        }

        public void PushToStack(UndoStackItem item)
        {
            stack.Add(item);
            index++;
        }

        public int PopFromStack()
        {
            UndoStackItem usi = stack[index];
            stack.RemoveAt(index);
            index--;
            return index;
        }

        public void AddNewFilterToStack(UndoStackItem item)
        {
            if (index + 1 < stack.Count)
            {
                stack.RemoveRange(index + 1, stack.Count - (index + 1));
            }
            stack.Add(item);
            index++; ;
        }

        public List<UndoStackItem> GetList()
        {
            return stack;
        }

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int i)
        {
            index = i;
        }

        public void Clear()
        {
            stack.Clear();
            index = -1;
        }


        public UndoStackItem GetFromIndexPos()
        {
            return stack[index];
        }
    }

    internal class UndoStackItem
    {
        private Bitmap bmp;
        private string filterName;

        public UndoStackItem()
        {
            bmp = null;
            filterName = "GRESKA";
        }

        public UndoStackItem(Bitmap bitmap, string name)
        {
            bmp = bitmap;
            filterName = name;
        }

        public Bitmap GetBitmap()
        {
            return bmp;
        }

        public void SetBitmap(Bitmap bitmap)
        {
            bmp = bitmap;
        }

        public string GetFilterName()
        {
            return filterName;
        }

        public void SetFilterName(string name)
        {
            filterName = name;
        }

    }
}
