using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp14
{
	public class LinkedList
	{
		private class ListItem
		{
			public object Item { get; }
			public ListItem Next { get; set; }
			public ListItem(object o)
			{
				Item = o;
			}
			public override string ToString()
			{
				return Item.ToString();
			}

		}

		private ListItem firstItem;
		private ListItem lastItem;
		private int itemCount;

		public object First
		{
			get
			{
				if (firstItem == null)
				{
					return null;
				}
				else
				{
					return firstItem.Item;
				}
			}
		}

		public object Last
		{
			get
			{
				if (lastItem == null)
				{
					return null;
				}
				else
				{
					return lastItem.Item;
				}
				
			}
		}

		public int Count
		{
			get { return itemCount; }

		}

		public object Items(int index)
		{
			return ItemIndex(index).Item;
		}

		private ListItem ItemIndex(int index)
		{
			ListItem currentItem = firstItem; ;
			if (itemCount < index)
			{
				throw new ArgumentOutOfRangeException("");
			}
			else
			{
				for (int i = 0; i < index; i++)
				{
					currentItem = currentItem.Next;
				}
			}

			return currentItem;
		}


		public void InsertFirst(object o)
		{
			ListItem newFirst = new ListItem(o);
			if (itemCount == 0)
			{
				firstItem = newFirst;
				lastItem = newFirst;
			}
			else
			{
			newFirst.Next = firstItem;
			firstItem = newFirst;
			}
			itemCount++;
		}

		public void InsertLast(object o)
		{
			ListItem newLast = new ListItem(o);
			if(Count == 0)
			{
				lastItem = newLast;
				firstItem = newLast;
			}
			else
			{
				lastItem.Next = newLast;
				lastItem = newLast;
			}

			itemCount++;
		}

		public void RemoveAt(int index)
		{
			ListItem currentItem = ItemIndex(index - 1);
			if (index == 0)
			{
				firstItem = firstItem.Next;
			}

			if (index == itemCount - 1)
			{
				lastItem = currentItem;
				lastItem.Next = null;
			}
			else
			{
				currentItem.Next = ItemIndex(index + 1);
			}

			itemCount--;
		}

		public override string ToString()
		{
			string result = "";
			for (int i = 0; i < itemCount; i++)
			{
				result += ItemIndex(i).ToString() + "|";
				//if (i < itemCount - 1)
				//{
				//	result += "|";
				//}
				
			}
			return result.TrimEnd('|');
		}
	}
}
