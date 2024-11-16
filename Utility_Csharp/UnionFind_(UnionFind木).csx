#pragma warning disable

using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Console;
using static System.Math;

/// union by rankと経路圧縮をする
/// O(a(N)) 
class UnionFind {
	/// 親のノード番号
	public int[] parents;

	/// 属する集合の要素数　
	public int[] sizes;

	/// ノード数NのUnionFindを作成
	public UnionFind(int n) {
		this.parents = new int[n];
		this.sizes = new int[n];
		for (int i = 0; i < n; ++i) {
			// 初期状態では親を持たない
			this.parents[i] = -1;
			// 集合サイズは1
			this.sizes[i] = 1;
		}
	} // end of constructor

	/// ノードiの親を返す
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int Root(int node) {
		// 根を見つけたらノード番号を変えす
		if (this.parents[node] == -1) return node;

		// 根までの経路を全て根に直接つなぐ
		else {
			int parent = this.Root(this.parents[node]);
			this.parents[node] = parent;
			return parent;
		}
	} // end of method

	/// ノードuとvの属する集合を結合する
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Unite(int u, int v) {
		int ru = this.Root(u);
		int rv = this.Root(v);
		if (ru == rv) return;
		// 大きい集合の根に結合(union by rank)
		// 高さが高々log2になる
		if (ru > rv) {
			int tmp = ru;
			ru = rv;
			rv = tmp;
		}
		this.parents[ru] = rv;
		this.sizes[rv] = this.sizes[ru] + this.sizes[rv];
		this.sizes[ru] = this.sizes[rv];
	} // end of method

	/// ノードuとvが同じ集合に属しているか
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Connected(int u, int v) {
		return this.Root(u) == this.Root(v);
	} // end of method
} // end of class
