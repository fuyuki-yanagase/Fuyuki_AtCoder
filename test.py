def count_permutations(n_list, k):
    # メモ化用の辞書
    memo = {}

    def helper(n_list, k):
        if k == 0:
            return 1
        if tuple(n_list) in memo:
            return memo[tuple(n_list)]
        count = 0
        for i in range(len(n_list)):
            if n_list[i] > 0:
                new_list = n_list[:]
                new_list[i] -= 1
                count += helper(new_list, k - 1)
        memo[tuple(n_list)] = count
        return count

    return helper(n_list, k)

# 使用例
n_list = [2,1,1]  # ここに具体的な数値を入れてください
k = 2  # 例えば5個取り出すとき
print(count_permutations(n_list, k))