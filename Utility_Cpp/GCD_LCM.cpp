#include "../_CppTemplate.cpp"

ll GCD(ll a, ll b) {
  if (a == 0 || b == 0) return 0;
  while (a != 0 && b != 0) {
    if (a > b)
      a = a % b;
    else
      b = b % a;
  }
  return max(a, b);
}

ll LCM(ll a, ll b) {
  if (a == 0 || b == 0) return 0;
  return a * b / GCD(a, b);
}