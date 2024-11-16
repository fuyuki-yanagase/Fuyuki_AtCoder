#pragma warning disable

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using static System.Math;
using static Util;
using System.Runtime.CompilerServices;

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


public class Util {
	public static double PI = 3.141592653589793;
	public static long m107 = 1000000007;
	public static long m998 = 998244353;
	public static int a10_9 = 1000000000;
	public static long a10_18 = 1000000000000000000;
	public static int iinf = 1 << 31;
	// public static long linf = (1l << 61) - (1l << 31);
	public static long linf = (1l << 31) - 1;

	/// 打ちやすいように
	public static string read() => ReadLine();
	public static string readln() => ReadLine();
	public static string readline() => ReadLine();
	public static void write() => Write("");
	public static void write(string s) => Write(s);
	public static void write(char c) => Write(c);
	public static void write(int num) => Write(num);
	public static void write(long num) => Write(num);
	public static void write(double num) => Write(num);
	public static void writeln() => WriteLine("");
	public static void writeln(string s) => WriteLine(s);
	public static void writeln(char c) => WriteLine(c);
	public static void writeln(int num) => WriteLine(num);
	public static void writeln(long num) => WriteLine(num);
	public static void writeln(double num) => WriteLine(num);
	public static void writeline() => WriteLine("");
	public static void writeline(string s) => WriteLine(s);
	public static void writeline(char c) => WriteLine(c);
	public static void writeline(int num) => WriteLine(num);
	public static void writeline(long num) => WriteLine(num);
	public static void writeline(double num) => WriteLine(num);
	public static void print() => Write("");
	public static void print(string s) => Write(s);
	public static void print(char c) => Write(c);
	public static void print(int num) => Write(num);
	public static void print(long num) => Write(num);
	public static void print(double num) => Write(num);
	public static void println() => WriteLine("");
	public static void println(string s) => WriteLine(s);
	public static void println(char c) => WriteLine(c);
	public static void println(int num) => WriteLine(num);
	public static void println(long num) => WriteLine(num);
	public static void println(double num) => WriteLine(num);
	public static void printline() => WriteLine("");
	public static void printline(string s) => WriteLine(s);
	public static void printline(char c) => WriteLine(c);
	public static void printline(int num) => WriteLine(num);
	public static void printline(long num) => WriteLine(num);
	public static void printline(double num) => WriteLine(num);

	/// 任意の要素数・初期値の配列を作って初期化する
	public static T[] makearr<T>(int num, T value) {
		var arr = new T[num];
		for (int i = 0; i < num; ++i) arr[i] = value;
		return arr;
	} // end of func

	/// 任意の要素数・初期値の２次元配列を作って初期化する
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

	/// 任意の要素数・初期値の3次元配列を作って初期化する
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

	/// 任意の要素数・初期値のListを作って初期化する
	public static List<T> makelist<T>(int num, T value) {
		return new List<T>(makearr(num, value));
	} // end of func

	/// 任意の要素数・初期値の2次元Listを作って初期化する
	public static List<List<T>> makelist2<T>(int height, int width, T value) {
		var arr = new List<List<T>>();
		for (int i = 0; i < height; ++i) {
			arr.Add(makelist(width, value));
		}
		return arr;
	} // end of func

	/// 任意の要素数・初期値の3次元Listを作って初期化する
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

	/// 1次元配列のディープコピーを行う
	public static T[] copyarr<T>(T[] arr) {
		T[] brr = new T[arr.Length];
		Array.Copy(arr, brr, arr.Length);
		return brr;
	} // end of func 

	/// 2次元配列のディープコピーを行う
	public static T[][] copyarr2<T>(T[][] arr) {
		T[][] brr = new T[arr.Length][];
		for (int i = 0; i < arr.Length; ++i) {
			brr[i] = new T[arr[i].Length];
			Array.Copy(arr[i], brr[i], arr[i].Length);
		}
		return brr;
	} // end of func

	/// 3次元配列のディープコピーを行う
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

	/// 1次元Listのディープコピーを行う
	public static List<T> copylist<T>(List<T> list) {
		return new List<T>(list);
	} // end of func

	/// 2次元Listのディープコピーを行う
	public static List<List<T>> copylist2<T>(List<List<T>> list) {
		List<List<T>> list2 = new List<List<T>>();
		for (int i = 0; i < list.Count; ++i) {
			list2.Add(new List<T>(list[i]));
		}
		return list2;
	} // end of func

	/// 3次元Listのディープコピーを行う
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

	/// 1次元Listを出力
	public static void printlist<T>(List<T> list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// 1次元配列を出力
	public static void printlist<T>(T[] list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// 2次元リストを出力
	public static void printlist2<T>(List<List<T>> list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func

	/// 2次元配列を出力
	public static void printlist2<T>(T[][] list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func	

	/// 1次元Listを出力
	public static void printarr<T>(List<T> list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// 1次元配列を出力
	public static void printarr<T>(T[] list) {
		WriteLine(string.Join(" ", list));
	} // end of func

	/// 2次元リストを出力
	public static void printarr2<T>(List<List<T>> list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func

	/// 2次元配列を出力
	public static void printarr2<T>(T[][] list) {
		foreach (var l in list) {
			WriteLine(string.Join(" ", l));
		}
	} // end of func

	/// 数字を1つint型で読み込み
	public static int readint() {
		return int.Parse(ReadLine());
	} // end of func

	/// 数字を1つlong型で読み込み
	public static long readlong() {
		return long.Parse(ReadLine());
	} // end of func

	/// 入力を空白区切りのstringで返す(変則的な入力に対応)
	public static string[] readsplit() {
		return ReadLine().Split(' ');
	} // end of func

	/// 数字をスペース区切りでint型で入力
	public static int[] readints() {
		return ReadLine().Split(' ').Select(_ => int.Parse(_)).ToArray();
	} // end of func

	/// 数字をスペース区切りでlong型で入力
	public static long[] readlongs() {
		return ReadLine().Split(' ').Select(_ => long.Parse(_)).ToArray();
	} // end of func

	/// 数字をスペース区切りでfloat型で入力
	public static float[] readfloats() {
		return ReadLine().Split(' ').Select(_ => float.Parse(_)).ToArray();
	} // end of func

	/// 数字をスペース区切りでdouble型で入力
	public static double[] readdoubles() {
		return ReadLine().Split(' ').Select(_ => double.Parse(_)).ToArray();
	} // end of func

	/// 文字列をスペース区切りで入力
	public static string[] readstrings() {
		return ReadLine().Split(' ');
	} // end of func

	/// 読み込んだint2つをタプルで返す(分解代入用)
	public static (int, int) readintt2() {
		var arr = readints();
		return (arr[0], arr[1]);
	} // end of func

	/// 読み込んだint3つをタプルで返す(分解代入用)
	public static (int, int, int) readintt3() {
		var arr = readints();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// 読み込んだint4つをタプルで返す(分解代入用)
	public static (int, int, int, int) readintt4() {
		var arr = readints();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// 読み込んだlong2つをタプルで返す(分解代入用)
	public static (long, long) readlongt2() {
		var arr = readlongs();
		return (arr[0], arr[1]);
	} // end of func

	/// 読み込んだ数long3つをタプルで返す(分解代入用)
	public static (long, long, long) readlongt3() {
		var arr = readlongs();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// 読み込んだ数long4つをタプルで返す(分解代入用)
	public static (long, long, long, long) readlongt4() {
		var arr = readlongs();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// 読み込んだfloat2つをタプルで返す(分解代入用)
	public static (float, float) readfloatt2() {
		var arr = readfloats();
		return (arr[0], arr[1]);
	} // end of func

	/// 読み込んだfloat3つをタプルで返す(分解代入用)
	public static (float, float, float) readfloatt3() {
		var arr = readfloats();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// 読み込んだfloat4つをタプルで返す(分解代入用)
	public static (float, float, float, float) readfloatt4() {
		var arr = readfloats();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// 読み込んだdouble2つをタプルで返す(分解代入用)
	public static (double, double) readdoublet2() {
		var arr = readdoubles();
		return (arr[0], arr[1]);
	} // end of func

	/// 読み込んだdouble3つをタプルで返す(分解代入用)
	public static (double, double, double) readdoublet3() {
		var arr = readdoubles();
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// 読み込んだdouble4つをタプルで返す(分解代入用)
	public static (double, double, double, double) readdoublet4() {
		var arr = readdoubles();
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// 読み込んだstring2つをタプルで返す(分解代入用)
	public static (string, string) readstringt2() {
		var arr = ReadLine().Split(' ');
		return (arr[0], arr[1]);
	} // end of func

	/// 読み込んだstring3つをタプルで返す(分解代入用)
	public static (string, string, string) readstringt3() {
		var arr = ReadLine().Split(' ');
		return (arr[0], arr[1], arr[2]);
	} // end of func

	/// 読み込んだstring3つをタプルで返す(分解代入用)
	public static (string, string, string, string) readstringt4() {
		var arr = ReadLine().Split(' ');
		return (arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// 先頭に要素数(int)と次にでかい数字1つ
	public static (int, long) readintlongt2() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1]);
	} // end of func

	/// 先頭に要素数(int)と次にでかい数字2つ
	public static (int, long, long) readintlongt3() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1], arr[2]);
	} // end of func

	/// 先頭に要素数(int)と次にでかい数字2つ
	public static (int, long, long, long) readintlongt4() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// 小数点以下を16桁で表示(精度が厳しい問題に対応)
	public static void WriteLine16<T>(T num) {
		WriteLine(string.Format("{0:0.################}", num));
	} // end of func

	/// 整数を二進数で表示
	public static void WriteLine2bit(int num) {
		WriteLine(Convert.ToString(num, 2));
	} // end of func

	/// 整数を二進数で表示
	public static void WriteLine2bit(long num) {
		WriteLine(Convert.ToString(num, 2));
	} // end of func

	/// 整数を2進数表現した文字列に
	public static string IntToString2bit(int num) {
		return Convert.ToString(num, 2);
	} // end of func

	/// 整数を2進数表現した文字列に
	public static string LongToString2bit(long num) {
		return Convert.ToString(num, 2);
	} // end of func

	/// 出力のflush削除
	public static void preprocess() {
		var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
		System.Console.SetOut(sw);
	} // end of func

	/// 出力をflush
	public static void finalprocess() {
		System.Console.Out.Flush();
	} // end of func
} // end of class

/// 座標に便利
class YX {
	public int y;
	public int x;
	public YX(int y, int x) {
		this.y = y;
		this.x = x;
	}
} // end of class

/// グラフをするときに
class Edge {
	public int from;
	public int to;
	public long cost;
	public Edge(int from, int to, long cost) {
		this.from = from;
		this.to = to;
		this.cost = cost;
	}
} // end of class



/// <summary>
/// 遅延評価セグメント木 <br/>
/// 区間検索、区間更新がO(logN) <br/>
/// </summary>
class LazySegmentTree<T, F, T_op>
								// where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
								// where F : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
								where T_op : struct, ILazySegmentTreeOperator<T, F> {
	/// <summary>一番下の葉の数 (2のべき乗になってるはず)</summary>
	public int LeafNum { get; set; }

	/// <summary>ノード全体の要素数</summary>
	public int Count { get => this.Node.Length; }

	/// <summary実際に木を構築するノード</summary>
	public T[] Node { get; set; }

	/// <summary>
	/// 遅延評価をまとめた配列 <br/>
	/// 更新時はここをいじる <br/>
	/// </summary>
	public F[] Lazy { get; set; }

	/// <summary>
	/// 作用素 (TとTに対する演算結果Tを返す min, max, sumなど) <br/>
	/// 単位元、恒等写像、mapping, compositionがまとまっている <br/>
	/// </summary>
	private readonly T_op Operator = default(T_op);

	/// <summary>
	/// 元配列を渡してセグメントツリーの作成 <br/>
	/// それ以外はOperatorに定義  <br/>
	/// </summary>
	public LazySegmentTree(T[] arr) {
		// ノード数を　2^⌈log2(N)⌉　にする
		this.LeafNum = 1;
		while (this.LeafNum < arr.Length) this.LeafNum <<= 1;

		// 葉の初期化
		this.Node = new T[this.LeafNum * 2 - 1];
		for (int i = 0; i < this.Count; ++i) this.Node[i] = this.Operator.Identity;
		for (int i = 0; i < arr.Length; ++i) this.Node[this.LeafNum - 1 + i] = arr[i];

		// 遅延配列の初期化
		this.Lazy = new F[this.LeafNum * 2 - 1];
		for (int i = 0; i < this.Count; ++i) this.Lazy[i] = this.Operator.FIdentity;

		// 親ノードの値を決めていく
		for (int i = this.LeafNum - 2; i >= 0; --i) {
			// 左右と比較
			this.Node[i] = this.Operator.Operate(this.Node[2 * i + 1], this.Node[2 * i + 2]);
		}

	} // end of constructor

	/// <summary>
	/// k番目のノードを遅延評価する(ACLではApply) <br/>
	/// 着目ノードkに対して Node[k] = f(Node[k]) <br/>
	/// 着目ノードを更新したら、1つしたの子に伝播 <br/>
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Evaluate(int k, int l, int r) {
		// 遅延配列が恒等写像の時は更新内容がない
		if (EqualityComparer<F>.Default.Equals(this.Lazy[k], this.Operator.FIdentity)) return;

		// 注目ノードに遅延評価の写像を作用させる
		this.Node[k] = this.Operator.Mapping(this.Lazy[k], this.Node[k]);

		// 子を持っているなら(最下段の葉で無いなら)
		if (r - l > 1) {
			// composittionで遅延評価の写像を子に合成する
			this.Lazy[2 * k + 1] = this.Operator.Composition(this.Lazy[k], this.Lazy[2 * k + 1]);
			this.Lazy[2 * k + 2] = this.Operator.Composition(this.Lazy[k], this.Lazy[2 * k + 2]);
		}

		// 伝播が終わったので自ノードの遅延評価を恒等写像に戻す
		this.Lazy[k] = this.Operator.FIdentity;
	} // end of method



	/// <summary>
	/// [l, r)の範囲を更新する <br/>
	/// x は更新に使用する写像 min,maxならxと比較、addならxを足す <br/>
	///</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int l, int r, F x) {
		this.Update(l, r, 0, 0, this.LeafNum, x);
	} // end of Method

	/// <summary>
	/// [l, r)の範囲を更新する
	/// k は現在のノード番号 <br/>
	/// [a, b) はkが対応する半開区間 <br/>	
	/// x は更新に使用する写像 min,maxならxと比較、addならxを足す <br/>
	///</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int l, int r, int k, int a, int b, F x) {
		// 着目ノードを評価する
		this.Evaluate(k, a, b);

		// 現在の対応ノード区間が求めたい区間に含まれないときは更新なし
		if (r <= a || b <= l) return;

		// 現在の対応ノード区間が求めたい区間に完全に含まれるとき
		// → 遅延配列を評価
		if (l <= a && b <= r) {
			this.Lazy[k] = this.Operator.Composition(x, this.Lazy[k]);
			this.Evaluate(k, a, b);
		}

		// そうでないなら左右の子のノードを再帰的に計算
		// → 計算済みの値をもらって自身を更新
		else {
			int m = (a + b) / 2;
			this.Update(l, r, k * 2 + 1, a, m, x);
			this.Update(l, r, k * 2 + 2, m, b, x);
			this.Node[k] = this.Operator.Operate(this.Node[2 * k + 1], this.Node[2 * k + 2]);
		}
	} // end of method


	/// [l, r) の区間◯◯値を求める(求まる値はOperatorで指定されてる)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Query(int l, int r) {
		return this.Query(l, r, 0, 0, this.LeafNum);
	} // end of method

	/// [l, r) は求めたい半開区間 <br/>
	/// k は現在のノード番号 <br/>
	/// [a, b) はkに対応する半開区間 <br/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private T Query(int l, int r, int k, int a, int b) {
		// 現在の対応ノード区間が求めたい区間に含まれないとき
		// → 単位元を返す
		if (r <= a || b <= l) return this.Operator.Identity;

		// 着目ノードを評価する
		this.Evaluate(k, a, b);

		// 現在の対応ノード区間が求めたい区間に完全に含まれるとき
		// → 現在のノードの値を返す
		if (l <= a && b <= r) return this.Node[k];

		// 左半分と右半分で見る
		int m = (a + b) / 2;
		T leftValue = Query(l, r, k * 2 + 1, a, m);
		T rightValue = Query(l, r, k * 2 + 2, m, b);
		return this.Operator.Operate(leftValue, rightValue);
	} // end of method
} // end of class

/// <summary>
/// セグメント木の要素となるモノイド <br/>
/// 結合律 : Tの任意の元 a,b,c に対して (a・b)・c = a・(b・c) <br/>
/// 単位元 : Tの元 e が存在し、Tの任意の元 a に対して e・a = a・e = a <br/>
/// T → データの型 <br/>
/// F → 写像の型 <br/>
/// </summary>
/// <typeparam name="T">データの型</typeparam>
/// <typeparam name="F">写像の型</typeparam>
interface ILazySegmentTreeOperator<T, F> {
	/// <summary>
	/// 単位元 <br />
	/// minならばinf, maxならば-inf, sumならば0 <br />
	/// </summary>
	T Identity { get; }

	/// <summary>
	/// Mapping(<paramref name="FIdentity"/>, x) = x を満たす恒等写像。
	/// </summary>
	F FIdentity { get; }

	/// Tの元 x,y の演算を定義する
	/// min, max, sum などはモノイド
	T Operate(T x, T y);

	/// <summary>
	/// 写像　<paramref name="f"/> を <paramref name="x"/> に作用させる関数。
	/// </summary>
	T Mapping(F f, T x);

	/// <summary>
	/// 写像　<paramref name="nf"/> を既存の写像 <paramref name="cf"/> に対して合成した写像 <paramref name="nf"/>∘<paramref name="cf"/>。
	/// </summary>
	F Composition(F nf, F cf);
} // end of interface

class Kyopuro {
	public static void Main() {
		preprocess();
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
		finalprocess();
	} // end of func

	static readonly long linf = (1l << 31) - 1;

	// モノイドを定義 区間最小、範囲更新
	struct op_min : ILazySegmentTreeOperator<long, long> {
		public long Identity { get => linf; }
		public long FIdentity { get => linf; }
		public long Operate(long a, long b) => Min(a, b);
		public long Mapping(long f, long x) => f;
		public long Composition(long f, long g) => f;
	}

	// モノイドを定義 区間合計、範囲加算
	struct op_sum : ILazySegmentTreeOperator<(long, int), long> {
		public (long, int) Identity { get => (0l, 0); }
		public long FIdentity { get => 0l; }
		public (long, int) Operate((long, int) a, (long, int) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2);
		public (long, int) Mapping(long f, (long, int) x) => (x.Item1 + x.Item2 * f, x.Item2);
		public long Composition(long f, long g) => f + g;
	}

	public void Solve() {
		// https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=DSL_2_F&lang=ja
		var (n, q) = readintt2();
		var segtree = new LazySegmentTree<long, long, op_min>(makearr(n, linf));

		// sumの方法
		// var segtree = new LazySegmentTree<(long, int), long, op_sum>(makearr(n, 1));

		for (int i = 0; i < q; ++i) {
			var s = readsplit();
			if (s[0] == "0") {
				int l = int.Parse(s[1]);
				int r = int.Parse(s[2]) + 1;
				long x = long.Parse(s[3]);
				segtree.Update(l, r, x);
			} else {
				int l = int.Parse(s[1]);
				int r = int.Parse(s[2]) + 1;
				writeline(segtree.Query(l, r));
			}
		}
	} // end of func
} // end of class
