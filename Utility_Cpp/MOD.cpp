#include "../_CppTemplate.cpp"

// mod n ‚Å‚Ì‹tŒ³‚ðo‚·

const ll mod 998244353 long long power(long long a, long long b) {
    long long x = 1, y = a;
    while (b > 0) {
        if (b & 1ll) {
            x = (x * y) % mod;
        }
        y = (y * y) % mod;
        b >>= 1;
    }
    return x % mod;
}
long long modular_inverse(long long n) {
    return power(n, mod - 2);
}
