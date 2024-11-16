#include "../_CppTemplate.cpp"

template <typename T>
T kurikaeshi_pow(T a, T b) {
    T ret = 1;
    while (b > 0) {
        if (b & 1 == 1) ret *= a;
        a *= a;
        b >>= 1;
    }
    return ret;
} // end of func

template <typename T>
T kurikaeshi_pow_mod(T a, T b, ll mod) {
    T ret = 1;
    while (b > 0) {
        if (b & 1 == 1) ret = (ret * a) % mod;
        a = (a * a) % mod;
        b >>= 1;
    }
    return ret;
} // end of func