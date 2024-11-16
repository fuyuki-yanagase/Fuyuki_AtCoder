#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;

/// <summary>双方向連結リスト(Dequeue)</summary>
public class LinkedList<T> : IEnumerable<T> where T : IEquatable<T> {
	/// <summary>リストの構成要素</summary>
	public class Node {
		public T value { get; set; }
		public Node next { get; set; }
		public Node prev { get; set; }
		public Node(T value) {
			this.value = value;
		}
	}
	public Node head;
	public Node tail;
	public int Count;
	public LinkedList() {
		this.head = null;
		this.tail = null;
		this.Count = 0;
	} // end of constructor

	/// <summary>先頭に追加</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void EnqueueFirst(T value) {
		var node = new Node(value);
		if (this.head == null) {
			this.head = node;
			this.tail = node;
		} else {
			node.next = this.head;
			this.head.prev = node;
			this.head = node;
		}
		this.Count += 1;
	} // end of method

	/// <summary>末尾に追加</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void EnqueueLast(T value) {
		var node = new Node(value);
		if (tail == null) {
			this.head = node;
			this.tail = node;
		} else {
			this.tail.next = node;
			node.prev = this.tail;
			this.tail = node;
		}
		this.Count += 1;
	} // end of method

	/// <summary>先頭要素削除</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T DequeueFirst() {
		if (this.head == null) return default(T);
		T ret = this.head.value;
		if (this.head.next != null) {
			this.head = this.head.next;
			this.head.prev = null;
		} else {
			this.head = null;
			this.tail = null;
		}
		this.Count -= 1;
		return ret;
	} // end of method

	/// <summary>末尾要素削除</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T DequeueLast() {
		if (this.tail == null) return default(T);
		T ret = this.tail.value;
		if (this.tail.prev != null) {
			this.tail = this.tail.prev;
			this.tail.next = null;
		} else {
			this.head = null;
			this.tail = null;
		}
		this.Count -= 1;
		return ret;
	} // end of method

	/// <summary>先頭要素取得(存在しなければdefault)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T PeekFirst() => this.head != null ? this.head.value : default(T);

	/// <summary>末尾要素取得(存在しなければdefault)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T PeekLast() => this.tail != null ? this.tail.value : default(T);

	/// <summary>valueが含まれるか</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Contains(T value) {
		var node = this.head;
		while (node != null) {
			if (node.value.Equals(value)) return true;
			node = node.next;
		}
		return false;
	} // end of method

	/// <summary>valueを持つ先頭の要素のインデックス</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int IndexAt(T value) {
		int index = -1;
		var node = this.head;
		while (node != null) {
			index += 1;
			if (node.value.Equals(value)) return index;
			node = node.next;
		}
		return index;
	} // end of method

	/// <summary>リストの表示(順方向)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void PrintForward() {
		var node = this.head;
		while (node != null) {
			Console.Write($"{node.value} ");
			node = node.next;
		}
		Console.WriteLine();
	} // end of method

	/// <summary>リストの表示(逆方向)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void PrintBackward() {
		var node = this.tail;
		while (node != null) {
			Console.Write($"{node.value} ");
			node = node.prev;
		}
		Console.WriteLine();
	} // end of method

	/// <summary>IEnumerable<T>の実装, foreachでの列挙可能に</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IEnumerator<T> GetEnumerator() {
		var node = this.head;
		while (node != null) {
			yield return node.value;
			node = node.next;
		}
	} // end of method

	/// <summary>IEnumerable<T>の実装</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
} // end of class

class Kyopuro {
	public static void Main() {
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
	} // end of func

	public void Solve() {

		var list = new LinkedList<long>();
		list.EnqueueFirst(1);
		list.EnqueueFirst(2);
		list.EnqueueLast(3);
		list.EnqueueLast(4);

		Console.WriteLine("リストの要素（前方向）:");
		list.PrintForward();

		Console.WriteLine("リストの要素（後方向）:");
		list.PrintBackward();

		Console.WriteLine();
		list.DequeueFirst();
		Console.WriteLine("先頭要素を削除後のリストの要素（前方向）:");
		list.PrintForward();

		list.DequeueLast();
		Console.WriteLine("末尾要素を削除後のリストの要素（前方向）:");
		list.PrintForward();

		Console.WriteLine("foreach");
		foreach (var v in list) {
			Console.Write(v + " ");
		}
		Console.WriteLine();

	} // end of method
} // end of class
