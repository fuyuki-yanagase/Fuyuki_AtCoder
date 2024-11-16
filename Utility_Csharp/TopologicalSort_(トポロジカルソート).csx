
/// 隣接グラフに対してトポロジカルソートをする
/// 出来ない場合は要素0の配列を返す
public List<int> TopologicalSort(List<List<int>> graph) {
	// ノード数
	int n = graph.Count;

	// 各ノードの入次数を記録
	int[] inputNodes = new int[n];
	for (int i = 0; i < n; ++i) {
		foreach (int to in graph[i]) {
			inputNodes[to] += 1;
		}
	}

	// 入力の次数が0のノードを記録
	var queue = new Queue<int>();
	for (int i = 0; i < n; ++i) {
		if (inputNodes[i] > 0) continue;
		queue.Enqueue(i);
	}

	// トポロジカルソート結果
	List<int> sorted = new List<int>();

	// 手順1 : 入次数が0のノードをキューに追加
	// 手順2 : キューからノードを取り出しソート結果に追加
	// 手順3 : 隣接するノードの入次数を-1
	// 手順4 : 手順1 ~ 手順3 を繰り返し
	while (queue.Count > 0) {
		// キューから取り出し
		int node = queue.Dequeue();

		// 隣接するノードの入次数を-1
		foreach (int to in graph[node]) {
			inputNodes[to] -= 1;
			// 入次数が0ならキューに追加
			if (inputNodes[to] == 0) queue.Enqueue(to);
		}

		// ソート結果に追加
		sorted.Add(node);
	}

	// ソートしたノード数がgraphのノード数と一致すればトポロジカルソート成功
	// 一致しなければトポロジカルソートできないグラフ(非DAG)
	return sorted.Count == n ? sorted : new List<int>();
} // end of method