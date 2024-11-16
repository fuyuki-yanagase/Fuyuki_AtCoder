#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;
using static Util;


class Util {
	public const long m107 = 1000000007;
	public const long m998 = 998244353;
	public const int a10_9 = 1000000000;
	public const long a10_18 = 1000000000000000000;
	public const int iinf = 1 << 30;
	public const long linf = (1l << 61) - (1l << 31);
}


class Kyopuro {
	public static void Main() {
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
	} // end of func

	/// ある値X未満の最大値のkeyを返す
	/// 存在しなければiinf
	public int FindMaxLessThanX(SortedSet<int> set, int x) {
		foreach (int num in set.GetViewBetween(set.Min, x - 1).Reverse()) return num;
		return iinf;
	} // end of func

	/// ある値X未満の最大値のkeyを返す
	/// 存在しなければlinf
	public long FindMaxLessThanX(SortedSet<long> set, long x) {
		foreach (long num in set.GetViewBetween(set.Min, x - 1).Reverse()) return num;
		return linf;
	} /// end of func

	  /// ある値X未満の最大値のkeyを返す
	  /// 存在しなければiinf
	public int FindMaxLessThanX(int[] arr, int x) {
		int left = 0;
		int right = arr.Length - 1;
		int mid;
		int max = -iinf;

		while (left <= right) {
			mid = (left + right) / 2;
			if (arr[mid] < x) {
				max = arr[mid];
				left = mid + 1;
			} else {
				right = mid - 1;
			}
		}
		return max > -iinf ? max : -iinf;
	} // end of func

	/// ある値X未満の最大値のkeyを返す
	/// 存在しなければlinf
	public long FindMaxLessThanX(long[] arr, long x) {
		long left = 0;
		long right = arr.Length - 1;
		long mid;
		long max = -linf;

		while (left <= right) {
			mid = (left + right) / 2;
			if (arr[mid] < x) {
				max = arr[mid];
				left = mid + 1;
			} else {
				right = mid - 1;
			}
		}
		return max > -linf ? max : -linf;
	} // end of func

	/// ある値X未満の最大値のkeyを返す
	/// 存在しなければiinf
	public int FindMaxLessThanX(List<int> arr, int x) {
		int left = 0;
		int right = arr.Count - 1;
		int mid;
		int max = -iinf;

		while (left <= right) {
			mid = (left + right) / 2;
			if (arr[mid] < x) {
				max = arr[mid];
				left = mid + 1;
			} else {
				right = mid - 1;
			}
		}
		return max > -iinf ? max : -iinf;
	} // end of func

	/// ある値X未満の最大値のkeyを返す
	/// 存在しなければlinf
	public long FindMaxLessThanX(List<long> arr, long x) {
		int left = 0;
		int right = arr.Count - 1;
		int mid;
		long max = -linf;

		while (left <= right) {
			mid = (left + right) / 2;
			if (arr[mid] < x) {
				max = arr[mid];
				left = mid + 1;
			} else {
				right = mid - 1;
			}
		}
		return max > -linf ? max : -linf;
	} // end of func

	public void Solve() {

		var arr = new long[] { 1, 4, 6, 8, };
		for (long i = 0; i < 10; ++i) {
			long m = FindMaxLessThanX(arr, i);
			Console.WriteLine($"i:{i} m:{m}");
		}

	} // end of method
} // end of class
