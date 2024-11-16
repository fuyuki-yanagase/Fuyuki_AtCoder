#pragma warning disable

using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;
using static System.ComponentModel.TypeDescriptor;


class Kyopuro {
	public static void Main() {
		var kyopuro = new Kyopuro();
		kyopuro.Solve();
	} // end of func

	/// a^nを繰り返し二乗法
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public long KurikaeshiPow(long a, long n, long mod = long.MaxValue) {
		if (n == 0) return 1;
		if (n == 1) return a % mod;

		long ret = 1;
		while (n > 0) {
			// a^(2^k) をかけていく k = nを二進数表現したときに1が立っているbit
			if ((n & 1) == 1) ret = (ret * a) % mod;
			n >>= 1;
			a = (a * a) % mod;
		}

		return ret;
	} // end of method

	/// (nume / deno) % mod を計算
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	long ModDiv(long nume, long deno, long mod = 998244353l) {
		return (nume * KurikaeshiPow(deno, mod - 2, mod)) % mod;
	} // end of method

	/// nCkを計算する
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	long nCk(long n, long k, long mod = 998244353l) {
		// nck = n! / (k! * (n - k)!)
		// → fact[n!] * inv[k!] * inv[(n - k)!]
		long nume = 1, deno = 1;
		for (long i = 0l; i < k; ++i) nume = nume * (n - i) % mod;
		for (long i = 2l; i <= k; ++i) deno = deno * i % mod;
		return ModDiv(nume, deno, mod);
	} // end of method

	/// nPkを計算する
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	long nPk(long n, long k, long mod = 998244353l) {
		long npk = 1;
		for (long i = k; i <= n; ++i) npk = (npk * i) % mod;
		return npk;
	} // end of method

	/// [0, n]の範囲で a^(-1) mod p を計算
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	long[] EnumInv(long n, long mod = 998244353l) {
		var inv = new long[n + 1];
		inv[0] = 1;
		inv[1] = 1;
		for (long i = 2; i <= n; ++i) {
			inv[i] = mod - inv[mod % i] * (mod / i) % mod;
		}
		return inv;
	} // end of method

	/// [0, n]の範囲で a! を計算
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	long[] EnumFact(long n, long mod = 998244353l) {
		var fact = new long[n + 1];
		fact[0] = 1;
		for (long i = 1; i <= n; ++i) {
			fact[i] = fact[i - 1] * i % mod;
		}
		return fact;
	} // end of method

	public void Solve() {

		long n = 5;
		long k = 3;

		var inv = EnumInv(5, 7);
		for (int i = 1; i < inv.Length; ++i) Console.Write(inv[i] + " ");
		Console.WriteLine();
		for (int i = 1; i <= 5; ++i) {
			Console.Write(ModDiv(1, i) + " ");
		}
		Console.WriteLine();
		var fact = EnumFact(7);
		for (int i = 1; i < fact.Length; ++i) Console.Write(fact[i] + (i == fact.Length - 1 ? "\n" : " "));

	} // end of method
} // end of class
