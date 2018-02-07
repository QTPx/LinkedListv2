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

		private ListItem _firstItem;
		private ListItem _lastItem;
		private int _itemCount;

		public object First
		{
			get
			{
				if (_firstItem == null)
				{
					return null;
				}
				else
				{
					return _firstItem.Item;
				}
			}
		}

		public object Last
		{
			get
			{
				if (_lastItem == null)
				{
					return null;
				}
				else
				{
					return _lastItem.Item;
				}
				
			}
		}

		public int Count
		{
			get { return _itemCount; }

		}

		public object Items(int index)
		{
			return ItemIndex(index).Item;
		}

		private ListItem ItemIndex(int index)
		{
			ListItem currentItem = _firstItem; ;
			if (_itemCount < index)
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
			if (_itemCount == 0)
			{
				_firstItem = newFirst;
				_lastItem = newFirst;
			}
			else
			{
			newFirst.Next = _firstItem;
			_firstItem = newFirst;
			}
			_itemCount++;
		}

		public void InsertLast(object o)
		{
			ListItem newLast = new ListItem(o);
			if(Count == 0)
			{
				_lastItem = newLast;
				_firstItem = newLast;
			}
			else
			{
				_lastItem.Next = newLast;
				_lastItem = newLast;
			}

			_itemCount++;
		}

		public void RemoveAt(int index)
		{
			ListItem currentItem = ItemIndex(index - 1);
			if (index == 0)
			{
				_firstItem = _firstItem.Next;
			}

			if (index == _itemCount - 1)
			{
				_lastItem = currentItem;
				_lastItem.Next = null;
			}
			else
			{
				currentItem.Next = ItemIndex(index + 1);
			}

			_itemCount--;
		}

		public override string ToString()
		{
			string result = "";
			for (int i = 0; i < _itemCount; i++)
			{
				result += ItemIndex(i).ToString() + "|";
				//if (i < _itemCount - 1)
				//{
				//	result += "|";
				//}
				
			}
			return result.TrimEnd('|');
		}
	}
}
