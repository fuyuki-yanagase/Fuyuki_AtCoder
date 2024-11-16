#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;
using static System.ComponentModel.TypeDescriptor;
using static Util;

class Util {
	public const long m107 = 1000000007;
	public const long m998 = 998244353;
	public const int i10_5 = 100000;
	public const int i20_5 = 200000;
	public const long l10_5 = 100000;
	public const long l20_5 = 200000;
	public const int i10_9 = 1000000000;
	public const long l10_9 = 1000000000;
	public const long l10_18 = 1000000000000000000;
	public const int iinf = 1 << 30;
	public const long linf = 1l << 60;

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

	/// <summary>Yes出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeyes() => WriteLine("Yes");

	/// <summary>No出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeno() => WriteLine("No");

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

	/// <summary>Yes出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printyes() => WriteLine("Yes");

	/// <summary>No出力</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void printno() => WriteLine("No");

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

	/// 任意の要素数・初期値の3次元Listを作って初期化する
	[MethodImpl(256)]
	public static List<List<List<T>>> makelist3<T>(int height, int width, int depth, T value) {
		var arr = new List<List<List<T>>>();
		for (int i = 0; i < height; ++i) {
			arr.Add(new List<List<T>>());
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
			for (int j = 0; j < list[i].Count; ++j) {
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
	public static int readint() => int.Parse(ReadLine());

	/// <summary>数字を1つlong型で読み込み</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long readlong() => long.Parse(ReadLine());

	/// <summary>数字を1つfloat型で読み込み</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float readfloat() => float.Parse(ReadLine());

	/// <summary>数字を1つfloat型で読み込み</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double readdouble() => double.Parse(ReadLine());

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


	/// 自由な型で2変数を入力
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void readt2<T1, T2>(out T1 a, out T2 b) {
		string[] s = readsplit();
		a = (T1)GetConverter(typeof(T1)).ConvertFromString(s[0]);
		b = (T2)GetConverter(typeof(T2)).ConvertFromString(s[1]);
	} // end of func

	/// 自由な型で3変数を入力
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void readt3<T1, T2, T3>(out T1 a, out T2 b, out T3 c) {
		string[] s = readsplit();
		a = (T1)GetConverter(typeof(T1)).ConvertFromString(s[0]);
		b = (T2)GetConverter(typeof(T2)).ConvertFromString(s[1]);
		c = (T3)GetConverter(typeof(T3)).ConvertFromString(s[2]);
	} // end of func

	/// 自由な型で4変数を入力
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void readt4<T1, T2, T3, T4>(out T1 a, out T2 b, out T3 c, out T4 d) {
		string[] s = readsplit();
		a = (T1)GetConverter(typeof(T1)).ConvertFromString(s[0]);
		b = (T2)GetConverter(typeof(T2)).ConvertFromString(s[1]);
		c = (T3)GetConverter(typeof(T3)).ConvertFromString(s[2]);
		d = (T4)GetConverter(typeof(T4)).ConvertFromString(s[3]);
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

	/// <summary>先頭に要素数(int)と次にでかい数字3つ</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, long, long, long) readintlongt4() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], arr[1], arr[2], arr[3]);
	} // end of func

	/// <summary>int, int, longの形式で読み込み</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, int, long) readintintlong() {
		var arr = ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
		return ((int)arr[0], (int)arr[1], arr[2]);
	} // end of func

	/// <summary>小数点以下を16桁で表示(精度が厳しい問題に対応)</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeline16<T>(T num) {
		WriteLine(string.Format("{0:0.################}", num));
	} // end of func

	/// <summary>整数を二進数で表示</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeline2bit(int num) {
		WriteLine(Convert.ToString(num, 2));
	} // end of func

	/// <summary>整数を二進数で表示</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void writeline2bit(long num) {
		WriteLine(Convert.ToString(num, 2));
	} // end of func

	/// <summary>整数を2進数表現した文字列に</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string i2s2bit(int num) {
		return Convert.ToString(num, 2);
	} // end of func

	/// <summary>整数を2進数表現した文字列に</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string l2s2bit(long num) {
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

/// Dictionayに初期値を与える(RubyのHash.new(0)みたいに)
class HashMap<K, V> : Dictionary<K, V> {
	new public V this[K i] {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get { V v; return TryGetValue(i, out v) ? v : base[i] = default(V); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set => base[i] = value;
	}
} // end of class

/// Dictionayに初期値を与える(RubyのHash.new(0)みたいに)
class SortedMap<K, V> : SortedDictionary<K, V> {
	new public V this[K i] {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get { V v; return TryGetValue(i, out v) ? v : base[i] = default(V); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set => base[i] = value;
	}
} // end of class

/// 座標に便利(値型だけど16byteまではstructが速い)
struct YX<T> {
	public T y;
	public T x;
	public YX(T y, T x) {
		this.y = y;
		this.x = x;
	}
	public override string ToString() => $"y:{y} x:{x}";
} // end of class

/// グラフをするときに(値型だけど16byteまではstructが速い)
struct Edge : IComparable<Edge> {
	public int from;
	public int to;
	public long cost;
	public Edge(int from, int to, long cost = 0) {
		this.from = from;
		this.to = to;
		this.cost = cost;
	}

	/// コスト順にソートできるように
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int CompareTo(Edge opp) => this.cost.CompareTo(opp.cost);

	/// デバッグ出力用
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override string ToString() => $"cost:{cost} from:{from} to:{to}";
} // end of class

class Kyopuro {
	public static void Main() {
		preprocess();
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
		finalprocess();
	} // end of func

	public void Solve() {
		writeline("");
		writeline("fugafuga");


	} // end of method
} // end of class
