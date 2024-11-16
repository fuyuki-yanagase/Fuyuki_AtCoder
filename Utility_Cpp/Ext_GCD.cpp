#include "../_CppTemplate.cpp"

// 拡張ユークリッドの互除法
// 返り値: a と b の最大公約数
// ax + by = gcd(a, b) を満たす (x, y) が格納される
ll extGCD(ll a, ll b, ll &x, ll &y) {
    if (b == 0) {
        x = 1;
        y = 0;
        return a;
    }
    ll d = extGCD(b, a % b, y, x);
    y -= a / b * x;
    return d;
} // end of extGCD