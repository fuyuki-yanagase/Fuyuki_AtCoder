#pragma warning disable

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;


/// 通常のセグメント木(範囲検索、1つ更新をlogN)
/// ジェネリック版、中身の改造には不向き
public class SegmentTreeGeneric<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> {
	/// 一番下の葉の数 (2のべき乗になってるはず)
	public int LeafNum { get; set; }

	/// ノード全体の要素数
	public int Count { get => this.Node.Length; }

	/// 実際に木を構築するノード
	public T[] Node { get; set; }

	/// 作用素 (TとTに対する演算結果Tを返す min, max, sumなど)
	private Func<T, T, T> Operator;

	/// モノイドの単位元 (オペレーターの演算に影響を及ぼさない)
	private T Identity;

	/// 元配列を渡してセグメントツリーの作成
	/// 初期値はminやmaxなどで変わると思うので与える(デフォルト=0のはず)
	public SegmentTreeGeneric(Func<T, T, T> op, T[] arr, T identity = default(T)) {
		// 作用素を保存
		this.Operator = op;

		// 単位元を保存
		this.Identity = identity;

		// ノード数を　2^⌈log2(N)⌉　にする
		this.LeafNum = 1;
		while (this.LeafNum < arr.Length) this.LeafNum <<= 1;

		// 葉の初期化
		this.Node = new T[this.LeafNum * 2 - 1];
		for (int i = 0; i < this.Count; ++i) this.Node[i] = this.Identity;
		for (int i = 0; i < arr.Length; ++i) this.Node[this.LeafNum - 1 + i] = arr[i];

		// 親ノードの値を決めていく
		for (int i = this.LeafNum - 2; i >= 0; --i) {
			// 左右と比較
			this.Node[i] = this.Operator(this.Node[2 * i + 1], this.Node[2 * i + 2]);
		}
	} // end of constructor

	/// index番目の値をvalueにする
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int index, T value) {
		// 葉の更新
		index += this.LeafNum - 1;
		this.Node[index] = value;

		// 親の更新
		while (index > 0) {
			index = (index - 1) / 2;
			// 左右と比較
			this.Node[index] = this.Operator(this.Node[2 * index + 1], this.Node[2 * index + 2]);
		}
	} // end of update

	/// [l, r) の区間◯◯値を求める(求まる値はOperatorで指定されてる)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Query(int l, int r) {
		return this.Query(l, r, 0, 0, this.LeafNum);
	} // end of method

	/// [l, r) は求めたい半開区間
	/// k は現在のノード番号
	/// [a, b) はkに対応する半開区間
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private T Query(int l, int r, int k, int a, int b) {
		// 現在の対応ノード区間が求めたい区間に含まれないとき
		// → 単位元を返す
		if (r <= a || b <= l) return this.Identity;

		// 現在の対応ノード区間が求めたい区間に完全に含まれるとき
		// → 現在のノードの値を返す
		if (l <= a && b <= r) return this.Node[k];

		// 左半分と右半分で見る
		int m = (a + b) / 2;
		T leftValue = Query(l, r, k * 2 + 1, a, m);
		T rightValue = Query(l, r, k * 2 + 2, m, b);
		return this.Operator(leftValue, rightValue);
	} // end of method
} // end of class


/// --------------------------------------------------------------------------------------------------------------------------
/// --------------------------------------------------------------------------------------------------------------------------
/// --------------------------------------------------------------------------------------------------------------------------


/// 通常のセグメント木(範囲検索、1つ更新をlogN)
/// long版、中身の改造は便利
public class SegmentTree {
	/// 一番下の葉の数 (2のべき乗になってるはず)
	public int LeafNum { get; set; }

	/// ノード全体の要素数
	public int Count { get => this.Node.Length; }

	/// 実際に木を構築するノード
	public long[] Node { get; set; }

	/// 作用素 (TとTに対する演算結果Tを返す min, max, sumなど)
	private Func<long, long, long> Operator;

	/// モノイドの単位元 (オペレーターの演算に影響を及ぼさない)
	private long Identity;

	/// 元配列を渡してセグメントツリーの作成
	/// 初期値はminやmaxなどで変わると思うので与える(デフォルト=0のはず)
	public SegmentTree(Func<long, long, long> op, long[] arr, long identity = default(long)) {
		// 作用素を保存
		this.Operator = op;

		// 単位元を保存
		this.Identity = identity;

		// ノード数を　2^⌈log2(N)⌉　にする
		this.LeafNum = 1;
		while (this.LeafNum < arr.Length) this.LeafNum <<= 1;

		// 葉の初期化
		this.Node = new long[this.LeafNum * 2 - 1];
		for (int i = 0; i < this.Count; ++i) this.Node[i] = this.Identity;
		for (int i = 0; i < arr.Length; ++i) this.Node[this.LeafNum - 1 + i] = arr[i];

		// 親ノードの値を決めていく
		for (int i = this.LeafNum - 2; i >= 0; --i) {
			// 左右と比較
			this.Node[i] = this.Operator(this.Node[2 * i + 1], this.Node[2 * i + 2]);
		}
	} // end of constructor

	/// index番目の値をvalueにする
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int index, long value) {
		// 葉の更新
		index += this.LeafNum - 1;
		this.Node[index] = value;

		// 親の更新
		while (index > 0) {
			index = (index - 1) / 2;
			// 左右と比較
			this.Node[index] = this.Operator(this.Node[2 * index + 1], this.Node[2 * index + 2]);
		}
	} // end of update

	/// [l, r) の区間◯◯値を求める(求まる値はOperatorで指定されてる)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public long Query(int l, int r) {
		return this.Query(l, r, 0, 0, this.LeafNum);
	} // end of method

	/// [l, r) は求めたい半開区間
	/// k は現在のノード番号
	/// [a, b) はkに対応する半開区間
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private long Query(int l, int r, int k, int a, int b) {
		// 現在の対応ノード区間が求めたい区間に含まれないとき
		// → 単位元を返す
		if (r <= a || b <= l) return this.Identity;

		// 現在の対応ノード区間が求めたい区間に完全に含まれるとき
		// → 現在のノードの値を返す
		if (l <= a && b <= r) return this.Node[k];

		// 左半分と右半分で見る
		int m = (a + b) / 2;
		long leftValue = Query(l, r, k * 2 + 1, a, m);
		long rightValue = Query(l, r, k * 2 + 2, m, b);
		return this.Operator(leftValue, rightValue);
	} // end of method
} // end of class
