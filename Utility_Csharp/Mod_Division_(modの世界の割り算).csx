#pragma warning disable

using System.Runtime.CompilerServices;

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
long ModDiv(long nume, long deno, long mod) {
	return nume * KurikaeshiPow(deno, mod - 2, mod) % mod;
} // end of method


// https://drken1215.hatenablog.com/entry/2018/06/08/210000

/// 拡張ユークリッド互除法 
/// ax + by = gcd(a, b) となる(x, y)を求める
/// a^(-1) mod p を求めることは、 ax + py = 1 となるxを求めることに等しい
long ExtendGCD(long a, long b, ref long x, ref long y) {
	if (b == 0) {
		x = 1l;
		y = 0l;
		return a;
	}
	long d = ExtendGCD(b, a % b, ref y, ref x);
	y -= a / b * x;
	return d;
} // end of method

/// 負のmodに対応
[MethodImpl(MethodImplOptions.AggressiveInlining)]
long Mod(long a, long mod) => (a % mod + mod) % mod;

/// 逆元を計算 (a, mod が互いに素である)
[MethodImpl(MethodImplOptions.AggressiveInlining)]
long ModInv(long a, long mod) {
	long x = 0, y = 0;
	ExtendGCD(a, mod, ref x, ref y);
	return Mod(x, mod);
} // end of method
