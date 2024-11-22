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
	public int LeafNum { get; private set; }

	/// ノード全体の要素数
	public int Count { get => this.Node.Length - 1; }

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
		this.Node = new T[this.LeafNum << 1];
		for (int i = 1; i < this.Count; ++i) this.Node[i] = this.Identity;

		for (int i = 0; i < arr.Length; ++i) this.Node[this.LeafNum + i] = arr[i];

		// 親ノードの値を決めていく
		for (int i = this.LeafNum - 2; i >= 0; --i) {
			// 左右と比較
			this.Node[i] = this.Operator(this.Node[i << 1], this.Node[(i << 1) | 1]);
		}
	} // end of constructor

	/// index番目の値をvalueにする
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int index, T value) {
		// 葉の更新
		index += this.LeafNum;
		this.Node[index] = value;

		// 親の更新
		while ((index >>= 1) > 0) {
			// 左右と比較
			this.Node[index] = this.Operator(this.Node[index << 1], this.Node[(index << 1) | 1]);
		}
	} // end of update

	/// [l, r) の区間◯◯値を求める(求まる値はOperatorで指定されてる)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Query(int l, int r) {
		T leftResult = this.Identity;
		T rightResult = this.Identity;

		for (l += this.LeafNum, r += this.LeafNum; l < r; l >>= 1, r >>= 1) {
			if ((l & 1) > 0) leftResult = this.Operator(leftResult, this.Node[l++]);
			if ((r & 1) > 0) rightResult = this.Operator(this.Node[--r], rightResult);
		}

		return this.Operator(leftResult, rightResult);
	}// end of method
} // end of class


/// --------------------------------------------------------------------------------------------------------------------------
/// --------------------------------------------------------------------------------------------------------------------------
/// --------------------------------------------------------------------------------------------------------------------------


/// 通常のセグメント木(範囲検索、1つ更新をlogN)
/// long版、中身の改造は便利
public class SegmentTree {
	/// 一番下の葉の数 (2のべき乗になってるはず)
	public int LeafNum { get; private set; }

	/// ノード全体の要素数
	public int Count { get => this.Node.Length - 1; }

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
		for (int i = 1; i < this.Count; ++i) this.Node[i] = this.Identity;

		for (int i = 0; i < arr.Length; ++i) this.Node[this.LeafNum + i] = arr[i];

		// 親ノードの値を決めていく
		for (int i = this.LeafNum - 2; i >= 0; --i) {
			// 左右と比較
			this.Node[i] = this.Operator(this.Node[i << 1], this.Node[(i << 1) | 1]);
		}
	} // end of constructor

	/// index番目の値をvalueにする
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int index, long value) {
		// 葉の更新
		index += this.LeafNum;
		this.Node[index] = value;

		// 親の更新
		while ((index >>= 1) > 0) {
			// 左右と比較
			this.Node[index] = this.Operator(this.Node[index << 1], this.Node[(index << 1) | 1]);
		}
	} // end of update

	/// [l, r) の区間◯◯値を求める(求まる値はOperatorで指定されてる)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public long Query(int l, int r) {
		long leftResult = this.Identity;
		long rightResult = this.Identity;

		for (l += this.LeafNum, r += this.LeafNum; l < r; l >>= 1, r >>= 1) {
			if ((l & 1) > 0) leftResult = this.Operator(leftResult, this.Node[l++]);
			if ((r & 1) > 0) rightResult = this.Operator(this.Node[--r], rightResult);
		}

		return this.Operator(leftResult, rightResult);
	} // end of method
} // end of class
