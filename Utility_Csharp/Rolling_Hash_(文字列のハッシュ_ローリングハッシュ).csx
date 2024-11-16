#pragma warning disable

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;

/// ハッシュ値で部分文字列が一致するか検索
/// 文字列の範囲指定[l, r]は1..Nの範囲(0からではないので注意)
/// 2^61-1 をmodとして使用する(128bitを使う)
class RollingHash {
	/// 計算したハッシュ値
	public long[][] hash;

	/// B進法の底
	public Int128[][] bases;

	/// hashを作るときのmod
	public long mod = (1l << 61) - 1;

	/// ハッシュを計算する文字列
	public string s;

	/// sの各文字を数値に変換('a'からの距離)
	public long[] codes;

	/// sの長さ
	public int n;

	/// ハッシュ衝突を回避するために複数乱数を用いる
	public int randomNum;

	public RollingHash(string s, int randomNum = 1) {
		this.s = s;
		this.n = this.s.Length;
		this.randomNum = randomNum;
		// charをlongに変換
		this.codes = new long[this.n];
		for (int i = 0; i < this.n; ++i) {
			this.codes[i] = this.s[i] - 'a';
		}

		// ハッシュ配列の用意
		this.bases = new Int128[this.randomNum][];
		this.hash = new long[this.randomNum][];
		var random = new Random();
		for (int i = 0; i < this.randomNum; ++i) {
			this.bases[i] = new Int128[this.n + 1];
			this.hash[i] = new long[this.n + 1];

			// b^iとhashを計算
			long b = random.NextInt64(this.mod);
			this.bases[i][0] = 1;
			for (int j = 1; j <= this.n; ++j) {
				Int128 b128 = (Int128)(b);
				Int128 bi = (b128 * this.bases[i][j - 1]) % this.mod;
				this.bases[i][j] = bi;

				Int128 h = (b128 * this.hash[i][j - 1] + this.codes[j - 1]) % this.mod;
				this.hash[i][j] = (long)h;
			}
		} // end of for
	} // end of constructor

	/// [l, r]の部分文字列のハッシュ値を計算(乱数の数だけハッシュ生成)
	public List<long> CalcHashes(int l, int r) {
		var list = new List<long>();

		for (int i = 0; i < this.randomNum; ++i) {
			Int128 val = this.hash[i][r] - ((this.hash[i][l - 1] * this.bases[i][r - l + 1]) % this.mod);
			if (val < 0) val += mod;
			list.Add((long)val);
		}
		return list;
	} // end of method


	/// [l1, r1]と[l2, r2]の部分文字列のハッシュを複数乱数で比較して、文字列が一致するか確認
	public bool CompareHash(int l1, int r1, int l2, int r2) {
		var arr = this.CalcHashes(l1, r1);
		var brr = this.CalcHashes(l2, r2);

		// 全て一致していればOK
		// 1つの乱数だと異なる文字列で同じハッシュ値になることがある
		// →複数乱数で比較して、全て一致すれば衝突した可能性は乗算で低くなる
		for (int i = 0; i < this.randomNum; ++i) {
			if (arr[i] != brr[i]) return false;
		}
		return true;
	} // end of method
} // end of class



/// ハッシュ値で部分文字列が一致するか検索
/// 文字列の範囲指定[l, r]は1..Nの範囲(0からではないので注意)
/// m107をmodとして使用する(衝突する可能性もあるので複数乱数でB進法にする)
/// (全ての乱数で生成したハッシュが一致すれば文字列も一致する)
class RollingHashLong {
	/// 計算したハッシュ値
	public long[][] hash;

	/// B進法の底
	public long[][] bases;

	/// hashを作るときのmod
	public long mod = 1000000007;

	/// ハッシュを計算する文字列
	public string s;

	/// sの各文字を数値に変換('a'からの距離)
	public long[] codes;

	/// sの長さ
	public int n;

	/// ハッシュ衝突を回避するために複数乱数を用いる
	public int randomNum;

	public RollingHashLong(string s, int randomNum = 1) {
		this.s = s;
		this.n = this.s.Length;
		this.randomNum = randomNum;
		// charをlongに変換
		this.codes = new long[this.n];
		for (int i = 0; i < this.n; ++i) {
			this.codes[i] = this.s[i] - 'a';
		}

		// ハッシュ配列の用意
		this.bases = new long[this.randomNum][];
		this.hash = new long[this.randomNum][];
		var random = new Random();
		for (int i = 0; i < this.randomNum; ++i) {
			this.bases[i] = new long[this.n + 1];
			this.hash[i] = new long[this.n + 1];

			// b^iとhashを計算
			long b = random.NextInt64(this.mod);
			this.bases[i][0] = 1;
			for (int j = 1; j <= this.n; ++j) {
				this.bases[i][j] = (b * this.bases[i][j - 1]) % this.mod;

				this.hash[i][j] = (b * this.hash[i][j - 1] + this.codes[j - 1]) % this.mod;
			}
		} // end of for
	} // end of constructor

	/// [l, r]の部分文字列のハッシュ値を計算(乱数の数だけハッシュ生成)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public List<long> CalcHashes(int l, int r) {
		var list = new List<long>();

		for (int i = 0; i < this.randomNum; ++i) {
			Int128 val = this.hash[i][r] - ((this.hash[i][l - 1] * this.bases[i][r - l + 1]) % this.mod);
			if (val < 0) val += mod;
			list.Add((long)val);
		}
		return list;
	} // end of method


	/// [l1, r1]と[l2, r2]の部分文字列のハッシュを複数乱数で比較して、文字列が一致するか確認
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool CompareHash(int l1, int r1, int l2, int r2) {
		var arr = this.CalcHashes(l1, r1);
		var brr = this.CalcHashes(l2, r2);

		// 全て一致していればOK
		// 1つの乱数だと異なる文字列で同じハッシュ値になることがある
		// →複数乱数で比較して、全て一致すれば衝突した可能性は乗算で低くなる
		for (int i = 0; i < this.randomNum; ++i) {
			if (arr[i] != brr[i]) return false;
		}
		return true;
	} // end of method
} // end of class