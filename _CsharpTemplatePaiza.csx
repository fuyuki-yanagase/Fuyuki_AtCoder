#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

	/// 入出力
	[MethodImpl(256)]
	public static string read() => Console.ReadLine();
	[MethodImpl(256)]
	public static void write(dynamic d) => Console.Write(d);
	[MethodImpl(256)]
	public static void writeline(dynamic d) => Console.WriteLine(d);
	[MethodImpl(256)]
	public static void writeline() => Console.WriteLine();

	/// 答え出力
	[MethodImpl(256)]
	public static void writeyes() => Console.WriteLine("Yes");
	[MethodImpl(256)]
	public static void writeno() => Console.WriteLine("No");

	/// 任意の要素数・初期値の配列を作って初期化する
	[MethodImpl(256)]
	public static T[] makearr<T>(int num, T value) {
		var arr = new T[num];
		for (int i = 0; i < num; ++i) arr[i] = value;
		return arr;
	} // end of func

	/// 任意の要素数・初期値の２次元配列を作って初期化する
	[MethodImpl(256)]
	public static T[][] makearr2<T>(int height, int width, T value) {
		var arr = new T[height][];
		for (int i = 0; i < height; ++i) {
			arr[i] = new T[width];
			for (int j = 0; j < width; ++j) {
				arr[i][j] = value;
			}
		}
		return arr;
	}

	/// 任意の要素数・初期値の3次元配列を作って初期化する
	[MethodImpl(256)]
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
	}

	/// 任意の要素数・初期値のListを作って初期化する
	[MethodImpl(256)]
	public static List<T> makelist<T>(int num, T value) {
		return new List<T>(makearr(num, value));
	}

	/// 任意の要素数・初期値の2次元Listを作って初期化する
	[MethodImpl(256)]
	public static List<List<T>> makelist2<T>(int height, int width, T value) {
		var arr = new List<List<T>>();
		for (int i = 0; i < height; ++i) {
			arr.Add(makelist(width, value));
		}
		return arr;
	}

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
	}

	/// 1次元配列のディープコピー
	[MethodImpl(256)]
	public static T[] copyarr<T>(T[] arr) {
		T[] brr = new T[arr.Length];
		Array.Copy(arr, brr, arr.Length);
		return brr;
	}

	/// 2次元配列のディープコピー
	[MethodImpl(256)]
	public static T[][] copyarr2<T>(T[][] arr) {
		T[][] brr = new T[arr.Length][];
		for (int i = 0; i < arr.Length; ++i) {
			brr[i] = new T[arr[i].Length];
			Array.Copy(arr[i], brr[i], arr[i].Length);
		}
		return brr;
	}

	/// 3次元配列のディープコピー
	[MethodImpl(256)]
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
	}

	/// 1次元Listのディープコピー
	[MethodImpl(256)]
	public static List<T> copylist<T>(List<T> list) {
		return new List<T>(list);
	}

	/// 2次元Listのディープコピー
	[MethodImpl(256)]
	public static List<List<T>> copylist2<T>(List<List<T>> list) {
		List<List<T>> list2 = new List<List<T>>();
		for (int i = 0; i < list.Count; ++i) {
			list2.Add(new List<T>(list[i]));
		}
		return list2;
	}

	/// 3次元Listのディープコピー
	[MethodImpl(256)]
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
	}

	/// 1次元Listを出力
	[MethodImpl(256)]
	public static void printlist<T>(List<T> list) => writeline(string.Join(" ", list));

	/// 1次元配列を出力
	[MethodImpl(256)]
	public static void printlist<T>(T[] list) => writeline(string.Join(" ", list));

	/// 2次元リストを出力
	[MethodImpl(256)]
	public static void printlist2<T>(List<List<T>> list) {
		foreach (var l in list) {
			writeline(string.Join(" ", l));
		}
	}

	/// 2次元配列を出力
	[MethodImpl(256)]
	public static void printlist2<T>(T[][] list) {
		foreach (var l in list) {
			writeline(string.Join(" ", l));
		}
	}

	/// 1次元Listを出力
	[MethodImpl(256)]
	public static void printarr<T>(List<T> list) => writeline(string.Join(" ", list));

	/// 1次元配列を出力
	[MethodImpl(256)]
	public static void printarr<T>(T[] list) => writeline(string.Join(" ", list));

	/// 2次元リストを出力
	[MethodImpl(256)]
	public static void printarr2<T>(List<List<T>> list) {
		foreach (var l in list) {
			writeline(string.Join(" ", l));
		}
	}

	/// 2次元配列を出力
	[MethodImpl(256)]
	public static void printarr2<T>(T[][] list) {
		foreach (var l in list) {
			writeline(string.Join(" ", l));
		}
	}

	/// ジェネリックを出力
	[MethodImpl(256)]
	public static void printiter<T>(IEnumerable<T> generic) {
		foreach (var it in generic) write(it + " ");
		writeline();
	}
	/// ジェネリックを出力
	[MethodImpl(256)]
	public static void printlineiter<T>(IEnumerable<T> generic) {
		foreach (var it in generic) {
			writeline(it + " ");
		}
	}

	/// 数字を1つ各型で読み込み
	[MethodImpl(256)]
	public static int readint() => int.Parse(read());
	[MethodImpl(256)]
	public static long readlong() => long.Parse(read());
	[MethodImpl(256)]
	public static float readfloat() => float.Parse(read());
	[MethodImpl(256)]
	public static double readdouble() => double.Parse(read());

	/// 入力を空白区切りのstringで返す(変則的な入力に対応)
	[MethodImpl(256)]
	public static string[] readsplit() => read().Split(' ');

	/// 数字をスペース区切りで入力
	[MethodImpl(256)]
	public static int[] readints() => readsplit().Select(_ => int.Parse(_)).ToArray();
	[MethodImpl(256)]
	public static long[] readlongs() => readsplit().Select(_ => long.Parse(_)).ToArray();
	[MethodImpl(256)]
	public static float[] readfloats() => readsplit().Select(_ => float.Parse(_)).ToArray();
	[MethodImpl(256)]
	public static double[] readdoubles() => readsplit().Select(_ => double.Parse(_)).ToArray();

	/// 自由な型で2変数を入力
	[MethodImpl(256)]
	public static void readt2<T1, T2>(out T1 a, out T2 b) {
		string[] s = readsplit();
		a = (T1)GetConverter(typeof(T1)).ConvertFromString(s[0]);
		b = (T2)GetConverter(typeof(T2)).ConvertFromString(s[1]);
	}

	/// 自由な型で3変数を入力
	[MethodImpl(256)]
	public static void readt3<T1, T2, T3>(out T1 a, out T2 b, out T3 c) {
		string[] s = readsplit();
		a = (T1)GetConverter(typeof(T1)).ConvertFromString(s[0]);
		b = (T2)GetConverter(typeof(T2)).ConvertFromString(s[1]);
		c = (T3)GetConverter(typeof(T3)).ConvertFromString(s[2]);
	}

	/// 自由な型で4変数を入力
	[MethodImpl(256)]
	public static void readt4<T1, T2, T3, T4>(out T1 a, out T2 b, out T3 c, out T4 d) {
		string[] s = readsplit();
		a = (T1)GetConverter(typeof(T1)).ConvertFromString(s[0]);
		b = (T2)GetConverter(typeof(T2)).ConvertFromString(s[1]);
		c = (T3)GetConverter(typeof(T3)).ConvertFromString(s[2]);
		d = (T4)GetConverter(typeof(T4)).ConvertFromString(s[3]);
	}

	/// 小数点以下を16桁で表示(精度が厳しい問題に対応)
	[MethodImpl(256)]
	public static void WriteLine16<T>(T num) => writeline(string.Format("{0:0.################}", num));

	/// 整数を二進数で表示
	[MethodImpl(256)]
	public static void writeline2bit(int num) => writeline(Convert.ToString(num, 2));

	/// 整数を2進数表現した文字列に
	[MethodImpl(256)]
	public static string int2bit(int num) => Convert.ToString(num, 2);

	/// 整数を2進数表現した文字列に
	[MethodImpl(256)]
	public static string long2bit(long num) => Convert.ToString(num, 2);

	/// 出力のflush削除
	public static void preprocess() => System.Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });

	/// 出力をflush
	public static void finalprocess() => System.Console.Out.Flush();
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
	[MethodImpl(256)]
	public int CompareTo(Edge opp) => this.cost.CompareTo(opp.cost);

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



	} // end of method
} // end of class
