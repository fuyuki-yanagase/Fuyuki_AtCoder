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
