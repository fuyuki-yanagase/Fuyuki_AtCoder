#include <cmath>
#include <iomanip>
#include <iostream>
#include <limits>
#include <map>
#include <queue>
#include <string>
#include <unordered_map>
#include <vector>
const double PI = 3.141592653589793;
#define rep(i, n) for (int i = 0; i < (int)(n); i++)
typedef long long int ll;
using namespace std;

/* 小数点n以下で四捨五入する */
double round_n(double number, int n) {
    if (n == 0)
        return number;

    else if (n > 0) {
        number = number * pow(10, n - 1); // 四捨五入したい値を10の(n-1)乗倍する。
        number = round(number);           // 小数点以下を四捨五入する。
        number /= pow(10, n - 1);         // 10の(n-1)乗で割る。
        return number;
    }

    else {
        number = number * pow(10, n);
        number = round(number);
        number = number * pow(10, -1 * n);
        return number;
    }
}