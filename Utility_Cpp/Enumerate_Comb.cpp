#include <functional>
#include <iostream>

void recursive_comb(int *indexes, int s, int rest,
                    std::function<void(int *)> f) {
  if (rest == 0) {
    f(indexes);
  } else {
    if (s < 0) return;
    recursive_comb(indexes, s - 1, rest, f);
    indexes[rest - 1] = s;
    recursive_comb(indexes, s - 1, rest - 1, f);
  }
}

// nCk‚Ì‘g‚Ý‡‚í‚¹‚É‘Î‚µ‚Äˆ—‚ðŽÀs‚·‚é
void foreach_comb(int n, int k, std::function<void(int *)> f) {
  int indexes[k];
  recursive_comb(indexes, n - 1, k, f);
}

int main() {
  long long count = 0;
  for (int i = 1; i <= 15; ++i) {
    foreach_comb(15, i, [&count](int *indexes) {
      // std::cout << indexes[0] << ',' << indexes[1] << ',' << indexes[2]
      // << std::endl;
      count += 1;
    });
  }
  std::cout << count << std::endl;
}