#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;


class MyPriorityQueue<T> {
	/// 内部で持つヒープ配列
	public List<T> heap = new List<T>();

	/// 現在の要素数
	public int Count { get { return heap.Count; } }

	/// 比較用関数 (第1引数の方が優先度が高いときにtrue)
	private Func<T, T, bool> Compare;

	public MyPriorityQueue(Func<T, T, bool> compare) {
		this.Compare = compare;
	}  // end of constructor

	/// 新規の値を追加する
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Enqueue(T num) {
		// 追加する要素のノード番号　
		int node = this.heap.Count;
		this.heap.Add(num);

		// 可能な限り親と交換
		while (node > 0) {
			// 親ノード
			int p = (node - 1) / 2;

			// 交換条件を満たさなくなったら終わり
			if (this.Compare(num, heap[p]) == false) break;

			// 親ノードの値を子に降ろす
			heap[node] = heap[p];
			node = p;
		} // end of while

		// 新規の値を下ろす場所を見つけたので終わり
		heap[node] = num;
	} // end of method

	/// 一番優先度の高い値を返す
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Peek() => this.heap[0];

	/// 一番優先度の高い値を返して削除する
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Dequeue() {
		// return用の優先度が一番高い値
		T ret = this.heap[0];

		// 先頭を削除
		this.Pop();

		return ret;
	} // end of method

	/// 一番優先度の高い値を削除する
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Pop() {
		// 根に持ってくる値
		T last = heap[this.heap.Count - 1];

		// 最後尾を削除 O(1)
		this.heap.RemoveAt(this.heap.Count - 1);

		// 要素がなくなったら終了
		if (this.heap.Count == 0) return;

		// 先頭を置き換えて降ろしていく
		int node = 0;
		while (node * 2 + 1 < this.heap.Count) {
			int a = node * 2 + 1;
			int b = node * 2 + 2;

			// 右の子が存在して、なおかつ優先度が高いならば
			if (b < this.heap.Count && this.Compare(this.heap[b], this.heap[a])) a = b;

			// 交換条件を満たさなくなったら終わり
			if (this.Compare(last, this.heap[a])) break;

			// 優先度の高い子を上げる
			this.heap[node] = this.heap[a];
			node = a;
		} // end of while

		// 先頭に持ってきた値の置き場所が決まったので更新
		this.heap[node] = last;
	} // end of method

} // end of class
