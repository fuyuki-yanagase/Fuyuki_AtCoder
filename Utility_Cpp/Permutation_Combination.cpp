#include <algorithm>
#include <functional>

#include <iostream>

// nPn‚Ì‡—ñ‚É‘Î‚µ‚Äˆ—‚ğÀs‚·‚é
void foreach_permutation(int n, std::function<void(int *)> f) {
    int indexes[n];
    for (int i = 0; i < n; i++)
        indexes[i] = i;
    do {
        f(indexes);
    } while (std::next_permutation(indexes, indexes + n));
}

int main() {
    foreach_permutation(3, [](int *indexes) {
        std::cout << indexes[0] << ',' << indexes[1] << ',' << indexes[2] << std::endl;
    });
}

#include <functional>
#include <iostream>
void recursive_comb(int *indexes, int s, int rest, std::function<void(int *)> f) {
    if (rest == 0) {
        f(indexes);
    } else {
        if (s < 0) return;
        recursive_comb(indexes, s - 1, rest, f);
        indexes[rest - 1] = s;
        recursive_comb(indexes, s - 1, rest - 1, f);
    }
}

// nCk‚Ì‘g‚İ‡‚í‚¹‚É‘Î‚µ‚Äˆ—‚ğÀs‚·‚é
void foreach_comb(int n, int k, std::function<void(int *)> f) {
    int indexes[k];
    recursive_comb(indexes, n - 1, k, f);
}

int main() {
    // foreach_comb(5, 3, [](int *indexes) {
    //     std::cout << indexes[0] << ',' << indexes[1] << ',' << indexes[2] << std::endl;
    // });
}