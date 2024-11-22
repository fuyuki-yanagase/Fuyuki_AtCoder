using System;
using System.Collections.Generic;

class Program {
	static void Main() {
		int[] nums = { 2, 3, 2, 4, 5, 3, 6, 4, 7 };

		int maxLength = LongestUniqueSubsequenceLength(nums);

		Console.WriteLine("最長部分列の長さ: " + maxLength);
	}

	static int LongestUniqueSubsequenceLength(int[] nums) {
		int start = 0; // 部分列の開始位置
		int maxLength = 0; // 最長部分列の長さ
		HashSet<int> seen = new HashSet<int>(); // 部分列に含まれる要素を記録するセット

		for (int end = 0; end < nums.Length; end++) {
			// 重複がなくなるまで start を進める
			while (seen.Contains(nums[end])) {
				seen.Remove(nums[start]);
				start++;
			}

			// 現在の要素をセットに追加
			seen.Add(nums[end]);

			// 部分列の長さを更新
			maxLength = Math.Max(maxLength, end - start + 1);
		}

		return maxLength;
	}
}
