#pragma warning disable

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using static System.Math;


public class Kyopuro {
	public static void Main() {
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
	} // end of func



	public int LowerBound<T>(T[] a, T v) {
		return LowerBound(a, v, Comparer<T>.Default);
	}

	public int LowerBound<T>(T[] a, T v, Comparer<T> cmp) {
		var l = 0;
		var r = a.Length - 1;
		while (l <= r) {
			var mid = l + (r - l) / 2;
			var res = cmp.Compare(a[mid], v);
			if (res == -1) l = mid + 1;
			else r = mid - 1;
		}
		return l;
	}

	public int LowerBound<T>(List<T> a, T v) {
		return LowerBound(a, v, Comparer<T>.Default);
	}

	public int LowerBound<T>(List<T> a, T v, Comparer<T> cmp) {
		var l = 0;
		var r = a.Count - 1;
		while (l <= r) {
			var mid = l + (r - l) / 2;
			var res = cmp.Compare(a[mid], v);
			if (res == -1) l = mid + 1;
			else r = mid - 1;
		}
		return l;
	}



	public int UpperBound<T>(T[] a, T v) {
		return UpperBound(a, v, Comparer<T>.Default);
	}

	public int UpperBound<T>(T[] a, T v, Comparer<T> cmp) {
		var l = 0;
		var r = a.Length - 1;
		while (l <= r) {
			var mid = l + (r - l) / 2;
			var res = cmp.Compare(a[mid], v);
			if (res <= 0) l = mid + 1;
			else r = mid - 1;
		}
		return l;
	}


	public int UpperBound<T>(List<T> a, T v) {
		return UpperBound(a, v, Comparer<T>.Default);
	}

	public int UpperBound<T>(List<T> a, T v, Comparer<T> cmp) {
		var l = 0;
		var r = a.Count - 1;
		while (l <= r) {
			var mid = l + (r - l) / 2;
			var res = cmp.Compare(a[mid], v);
			if (res <= 0) l = mid + 1;
			else r = mid - 1;
		}
		return l;
	}

	public void Solve() {

		var a = new[] { 1, 2, 2, 2, 4, 4, 4, 5, 6 };
		for (int i = 0; i <= 7; i++) {
			Console.WriteLine(LowerBound(a, i));
		}
		WriteLine();

		for (int i = 0; i <= 7; i++) {
			Console.WriteLine(UpperBound(a, i));
		}



	}
} // end of class
