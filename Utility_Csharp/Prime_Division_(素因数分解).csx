#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;
using static Util;
using System.Diagnostics;

#region using(AtCoder等非対応)
// using pii = (int, int);
// using pll = (long, long);
// using pdd = (double, double);
// using pss = (string, string);
// using pis = (int, string);
// using psi = (string, int);
// using pls = (long, string);
// using psl = (string, long);
// using pds = (double, string);
// using psd = (string, double);
// using pid = (int, double);
// using pdi = (double, int);
// using pld = (long, double);
// using pdl = (double, long);
// using vb = bool[];
// using vvb = bool[][];
// using vvvb = bool[][][];
// using vi = int[];
// using vvi = int[][];
// using vvvi = int[][][];
// using vl = long[];
// using vvl = long[][];
// using vvvl = long[][][];
// using vd = double[];
// using vvd = double[][];
// using vvvd = double[][][];
// using vs = string[];
// using vvs = string[][];
// using vvvs = string[][][];
// using listb = System.Collections.Generic.List<bool>;
// using llistb = System.Collections.Generic.List<System.Collections.Generic.List<bool>>;
// using lllistb = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<bool>>>;
// using listi = System.Collections.Generic.List<int>;
// using llisti = System.Collections.Generic.List<System.Collections.Generic.List<int>>;
// using lllisti = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>;
// using listl = System.Collections.Generic.List<long>;
// using llistl = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
// using lllistl = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<long>>>;
// using listd = System.Collections.Generic.List<double>;
// using llistd = System.Collections.Generic.List<System.Collections.Generic.List<double>>;
// using lllistd = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<double>>>;
// using lists = System.Collections.Generic.List<string>;
// using llists = System.Collections.Generic.List<System.Collections.Generic.List<string>>;
// using lllists = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<string>>>;
// using mii = System.Collections.Generic.SortedDictionary<int, int>;
// using mll = System.Collections.Generic.SortedDictionary<long, long>;
// using mss = System.Collections.Generic.SortedDictionary<string, string>;
// using mis = System.Collections.Generic.SortedDictionary<int, string>;
// using msi = System.Collections.Generic.SortedDictionary<string, int>;
// using mls = System.Collections.Generic.SortedDictionary<long, string>;
// using msl = System.Collections.Generic.SortedDictionary<string, long>;
// using umii = System.Collections.Generic.Dictionary<int, int>;
// using umll = System.Collections.Generic.Dictionary<long, long>;
// using umss = System.Collections.Generic.Dictionary<string, string>;
// using umis = System.Collections.Generic.Dictionary<int, string>;
// using umsi = System.Collections.Generic.Dictionary<string, int>;
// using umls = System.Collections.Generic.Dictionary<long, string>;
// using umsl = System.Collections.Generic.Dictionary<string, long>;
// using seti = System.Collections.Generic.SortedSet<int>;
// using setl = System.Collections.Generic.SortedSet<long>;
// using sets = System.Collections.Generic.SortedSet<string>;
// using useti = System.Collections.Generic.HashSet<int>;
// using usetl = System.Collections.Generic.HashSet<long>;
// using usets = System.Collections.Generic.HashSet<string>;
#endregion


class Util {
	public static double PI = 3.141592653589793;
	public static long m107 = 1000000007;
	public static long m998 = 998244353;
	public static int a10_9 = 1000000000;
	public static long a10_18 = 1000000000000000000;
	public static int iinf = 1 << 30;
	public static long linf = (1l << 61) - (1l << 31);

	/// <summary>1行読みこみ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string read() => ReadLine();

	/// <summary>1行読みこみ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string readln() => ReadLine();

	/// <summary>1行読みこみ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string readline() => ReadLine();

	/// <summary>改行なし出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void write() => Write("");

	/// <summary>改行なし出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void write<T>(T value) => Write(value);

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeln() => WriteLine("");

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeln<T>(T value) => WriteLine(value);

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeline() => WriteLine("");

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeline<T>(T value) => WriteLine(value);

	/// <summary>改行なし出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void print() => Write("");

	/// <summary>改行なし出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void print<T>(T value) => Write(value);

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void println() => WriteLine("");

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void println<T>(T value) => WriteLine(value);

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printline() => WriteLine("");

	/// <summary>改行あり出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printline<T>(T value) => WriteLine(value);

	/// <summary>任意の要素数・初期値の配列を作って初期化する</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] makearr<T>(int num, T value) {
		var arr = new T[num];
		for (int i = 0; i < num; ++i) arr[i] = value;
		return arr;
	} // end of func

	/// <summary>任意の要素数・初期値の２次元配列を作って初期化する</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[][] makearr2<T>(int height, int width, T value) {
		var arr = new T[height][];
		for (int i = 0; i < height; ++i) {
			arr[i] = new T[width];
			for (int j = 0; j < width; ++j) {
				arr[i][j] = value;
			}
		}
		return arr;
	} // end of func

	/// <summary>任意の要素数・初期値の3次元配列を作って初期化する</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[][][] makearr3<T>(int height, int width, int depth, T value) {
		var arr = new T[height][][];
		for (int i = 0; i < height; ++i) {
			arr[i] = new T[width][];
			for (int j = 0; j < width; ++j) {
				arr[i][j] = new T[depth];
				for (int k = 0; k < depth; ++k) {
					arr[i][j][k] = value;
				}
			}
		}
		return arr;
	} // end of func

	/// <summary>任意の要素数・初期値のListを作って初期化する</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static List<T> makelist<T>(int num, T value) {
		return new List<T>(makearr(num, value));
	} // end of func

	/// <summary>任意の要素数・初期値の2次元Listを作って初期化する</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static List<List<T>> makelist2<T>(int height, int width, T value) {
		var arr = new List<List<T>>();
		for (int i = 0; i < height; ++i) {
			arr.Add(makelist(width, value));
		}
		return arr;
	} // end of func

	/// <summary>任意の要素数・初期値の3次元Listを作って初期化する</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static List<List<List<T>>> makelist3<T>(int height, int width, int depth, T value) {
		var arr = new List<List<List<T>>>();
		for (int i = 0; i < height; ++i) {
			arr[i] = new List<List<T>>();
			for (int j = 0; j < width; ++j) {
				arr[i].Add(makelist(depth, value));
			}
		}
		return arr;
	} // end of func

	/// <summary>1次元配列のディープコピーを行う</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] copyarr<T>(T[] arr) {
		T[] brr = new T[arr.Length];
		Array.Copy(arr, brr, arr.Length);
		return brr;
	} // end of func 

	/// <summary>2次元配列のディープコピーを行う</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[][] copyarr2<T>(T[][] arr) {
		T[][] brr = new T[arr.Length][];
		for (int i = 0; i < arr.Length; ++i) {
			brr[i] = new T[arr[i].Length];
			Array.Copy(arr[i], brr[i], arr[i].Length);
		}
		return brr;
	} // end of func

	/// <summary>3次元配列のディープコピーを行う</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[][][] copyarr3<T>(T[][][] arr) {
		T[][][] brr = new T[arr.Length][][];
		for (int i = 0; i < arr.Length; ++i) {
			brr[i] = new T[arr[i].Length][];
			for (int j = 0; j < arr[i].Length; ++j) {
				brr[i][j] = new T[arr[i][j].Length];
				Array.Copy(arr[i][j], brr[i][j], arr[i][j].Length);
			}
		}
		return brr;
	} // end of func

	/// <summary>1次元Listのディープコピーを行う</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static List<T> copylist<T>(List<T> list) {
		return new List<T>(list);
	} // end of func

	/// <summary>2次元Listのディープコピーを行う</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static List<List<T>> copylist2<T>(List<List<T>> list) {
		List<List<T>> list2 = new List<List<T>>();
		for (int i = 0; i < list.Count; ++i) {
			list2.Add(new List<T>(list[i]));
		}
		return list2;
	} // end of func

	/// <summary>3次元Listのディープコピーを行う</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static List<List<List<T>>> copylist3<T>(List<List<List<T>>> list) {
		List<List<List<T>>> list2 = new List<List<List<T>>>();
		for (int i = 0; i < list.Count; ++i) {
			List<List<T>> tmplist = new List<List<T>>();
			for (int j = 0; j < list[i].Count; ++i) {
				tmplist.Add(new List<T>(list[i][j]));
			}
			list2.Add(tmplist);
		}
		return list2;
	} // end of func

	/// <summary>1次元Listを出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printlist<T>(List<T> list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// <summary>1次元配列を出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printlist<T>(T[] list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// <summary>2次元リストを出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printlist2<T>(List<List<T>> list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func

	/// <summary>2次元配列を出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printlist2<T>(T[][] list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func	

	/// <summary>1次元Listを出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printarr<T>(List<T> list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// <summary>1次元配列を出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printarr<T>(T[] list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// <summary>2次元リストを出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printarr2<T>(List<List<T>> list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func

	/// <summary>2次元配列を出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printarr2<T>(T[][] list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func

	/// <summary>ジェネリックを出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printiter<T>(IEnumerable<T> generic) {
		foreach (var it in generic) {
			Write(it + " ");
		}
		WriteLine();
	} // end of func

	/// <summary>ジェネリックを出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printlineiter<T>(IEnumerable<T> generic) {
		foreach (var it in generic) {
			WriteLine(it + " ");
		}
	} // end of func

	/// <summary>数字を1つint型で読み込み</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int readint() {
		return int.Parse(ReadLine());
	} // end of func

	/// <summary>数字を1つlong型で読み込み</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long readlong() {
		return long.Parse(ReadLine());
	} // end of func

	/// <summary>入力を空白区切りのstringで返す(変則的な入力に対応)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string[] readsplit() {
		return ReadLine().Split(' ');
	} // end of func

	/// <summary>数字をスペース区切りでint型で入力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int[] readints() {
		return ReadLine().Split(' ').Select(_ => int.Parse(_)).ToArray();
	} // end of func

	/// <summary>数字をスペース区切りでlong型で入力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long[] readlongs() {
		return ReadLine().Split(' ').Select(_ => long.Parse(_)).ToArray();
	} // end of func

	/// <summary>数字をスペース区切りでfloat型で入力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float[] readfloats() {
		return ReadLine().Split(' ').Select(_ => float.Parse(_)).ToArray();
	} // end of func

	/// <summary>数字をスペース区切りでdouble型で入力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double[] readdoubles() {
		return ReadLine().Split(' ').Select(_ => double.Parse(_)).ToArray();
	} // end of func

	/// <summary>文字列をスペース区切りで入力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string[] readstrings() {
		return ReadLine().Split(' ');
	} // end of func

	/// <summary>読み込んだint2つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, int) readintt2() {
		var arr = readints();
		return (arr[0], arr[1]);
	} // end of func

	/// <summary>読み込んだint3つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, int, int) readintt3() {
		var arr = readints();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// <summary>読み込んだint4つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, int, int, int) readintt4() {
		var arr = readints();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>読み込んだlong2つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (long, long) readlongt2() {
		var arr = readlongs();
		return (arr[0], arr[1]);
	} // end of func

	/// <summary>読み込んだ数long3つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (long, long, long) readlongt3() {
		var arr = readlongs();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// <summary>読み込んだ数long4つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (long, long, long, long) readlongt4() {
		var arr = readlongs();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>読み込んだfloat2つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (float, float) readfloatt2() {
		var arr = readfloats();
		return (arr[0], arr[1]);
	} // end of func

	/// <summary>読み込んだfloat3つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (float, float, float) readfloatt3() {
		var arr = readfloats();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// <summary>読み込んだfloat4つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (float, float, float, float) readfloatt4() {
		var arr = readfloats();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>読み込んだdouble2つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (double, double) readdoublet2() {
		var arr = readdoubles();
		return (arr[0], arr[1]);
	} // end of func

	/// <summary>読み込んだdouble3つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (double, double, double) readdoublet3() {
		var arr = readdoubles();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// <summary>読み込んだdouble4つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (double, double, double, double) readdoublet4() {
		var arr = readdoubles();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>読み込んだstring2つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (string, string) readstringt2() {
		var arr = ReadLine().Split(' ');
		return (arr[0], arr[1]);
	} // end of func

	/// <summary>読み込んだstring3つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (string, string, string) readstringt3() {
		var arr = ReadLine().Split(' ');
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// <summary>読み込んだstring3つをタプルで返す(分解代入用)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (string, string, string, string) readstringt4() {
		var arr = ReadLine().Split(' ');
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>先頭に要素数(int)と次にでかい数字1つ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, long) readintlongt2() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1]);
	} // end of func

	/// <summary>先頭に要素数(int)と次にでかい数字2つ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, long, long) readintlongt3() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1], arr[2]);
	} // end of func

	/// <summary>先頭に要素数(int)と次にでかい数字2つ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, long, long, long) readintlongt4() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>小数点以下を16桁で表示(精度が厳しい問題に対応)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteLine16<T>(T num) {
		WriteLine(string.Format("{0:0.################}", num));
	} // end of func

	/// <summary>整数を二進数で表示</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteLine2bit(int num) {
		WriteLine(Convert.ToString(num, 2));
	} // end of func

	/// <summary>整数を二進数で表示</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteLine2bit(long num) {
		WriteLine(Convert.ToString(num, 2));
	} // end of func

	/// <summary>整数を2進数表現した文字列に</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string IntToString2bit(int num) {
		return Convert.ToString(num, 2);
	} // end of func

	/// <summary>整数を2進数表現した文字列に</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string LongToString2bit(long num) {
		return Convert.ToString(num, 2);
	} // end of func

	/// <summary>出力のflush削除</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void preprocess() {
		var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
		System.Console.SetOut(sw);
	} // end of func

	/// <summary>出力をflush</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void finalprocess() {
		System.Console.Out.Flush();
	} // end of func
} // end of class

/// 座標に便利(値型だけど16byteまではstructが速い)
struct YX {
	public int y;
	public int x;
	public YX(int y, int x) {
		this.y = y;
		this.x = x;
	}
} // end of class

/// グラフをするときに(値型だけど16byteまではstructが速い)
struct Edge {
	public int from;
	public int to;
	public long cost;
	public Edge(int from, int to, long cost) {
		this.from = from;
		this.to = to;
		this.cost = cost;
	}
} // end of class

class Kyopuro {
	public static void Main() {
		preprocess();
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
		finalprocess();
	} // end of func

	/// <summary> ミラーラビンの素数判定法 </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsPrime(long n) {
		// 例外と自明処理
		if (n <= 1) return false;
		if (n == 2) return true;
		if (n % 2 == 0) return false;

		// n - 1 = 2^s * d と表す
		long s = 0;
		long d = n - 1;
		while (d % 2 == 0) {
			s += 1;
			d >>= 1;
		}

		// このパターンで2^64以下を網羅
		// 本来は不確定なヒューリスティック法だがこのパターンだと2^64以下で必ず判定可能なことが保証
		var arr = new long[] { 2, 325, 9375, 28178, 450775, 9780504, 1795265022 };
		foreach (var a in arr) {
			if (a % n == 0) return true;
			System.Int128 x = KurikaeshiPow(a, d, n);
			if (x == 1) continue;

			long t;
			for (t = 0; t < s; ++t) {
				if (x == n - 1) break;
				x = x * x % n;
			}
			if (t == s) return false;
		}
		return true;
	} // end of method

	/// <summary>a^nを繰り返し二乗法</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public long KurikaeshiPow(System.Int128 a, System.Int128 n, long m = long.MaxValue) {
		System.Int128 mod = m;
		if (n == 0) return 1;
		if (n == 1) return (long)(a % mod);

		System.Int128 ret = 1;
		while (n > 0) {
			// a^(2^k) をかけていく k = nを二進数表現したときに1が立っているbit
			if ((n & 1) == 1) ret = (ret * a) % mod;
			n >>= 1;
			a = (a * a) % mod;
		}

		return (long)ret;
	} // end of method

	/// 最大公約数を計算 long
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public long Gcd(long a, long b) {
		a = Abs(a);
		b = Abs(b);
		if (b == 0) return a;
		else return Gcd(b, a % b);
	} // end of method

	/// <summary> Pollard ロー法、nが合成数のときnの非自明な約数を高確率で求める </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	long pollard(long n) {
		if (n % 2 == 0) return 2; // 偶数のときは2を約数に持つ
		if (IsPrime(n)) return n; // 素数の時は自身のみ


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		System.Int128 func(System.Int128 x) {
			return (x * x + 1) % n;
		}

		long step = 0;
		while (true) {
			step += 1;
			System.Int128 x = step;
			System.Int128 y = func(x);

			while (true) {
				long p = Gcd((long)(y - x + n), n);
				if (p == 0 || p == n) break;
				if (p != 1) return p;
				x = func(x);
				y = func(func(y));
			}
		}

		return 0;
	} // end of method


	/// <summary> ポラードのロー法で素因数分解 </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	List<long> _PrimeFactorize(long n) {
		if (n == 1) return new List<long>();

		// 約数を1つ用意
		long p = pollard(n);
		// 約数が自身と一致する → 素数である → 素因数は自身のみ
		if (p == n) return new List<long>(new long[] { n });

		// 約数で分割する
		var left = _PrimeFactorize(p);
		var right = _PrimeFactorize(n / p);

		left.AddRange(right);
		return left;
	}

	/// <summary> ポラードのロー法で素因数分解 </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	List<long> PrimeFactorize(long n) {
		var primes = _PrimeFactorize(n);
		primes.Sort();
		return primes;
	} // end of method

	public void Solve() {
		// https://atcoder.jp/contests/abc169/tasks/abc169_d

		long n = readlong();
		var primes = PrimeFactorize(n);
		var dict = new Dictionary<long, long>();
		foreach (var p in primes) {
			if (dict.ContainsKey(p)) dict[p] += 1;
			else dict[p] = 1;
		}

		long ans = 0;
		foreach (var v in dict.Values) {
			long count = 0;
			long hoge = 1;
			long vv = v;
			while (hoge <= vv) {
				count += 1;
				vv -= hoge;
				hoge += 1;
			}
			// writeline($"v:{v} count:{count}");
			ans += count;
		}
		// printlist(primes);
		writeline(ans);

	} // end of method
} // end of class
