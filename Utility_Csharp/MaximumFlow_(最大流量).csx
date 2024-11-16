
using System.Runtime.CompilerServices;

/// to → 行先のnode
/// flow → 辺に流せる流量
/// reverse → 逆辺の位置
/// 	u→G[u][i].to の逆辺 G[u][i].to→u が G[G[u][i].to]の何番目にあるか
/// 	隣接リストで持つので順番が不定、毎回線形探索はしんどい
class Edge {
	public int to;
	public long capacity;
	public int reverse;
	public Edge(int to, long capacity, int reverse) {
		this.to = to;
		this.capacity = capacity;
		this.reverse = reverse;
	}
}

class MaximumFlow {
	/// グラフの要素数
	public int Count;

	/// 使用済みの頂点は必要ない
	public bool[] Used;

	/// 内部で保持する残余グラフ
	public List<List<Edge>> Graph;

	/// 要素数のみの空の残余グラフを作成
	/// 後からAddEdgeを呼び出して残余グラフを作る必要あり
	public MaximumFlow(int n) {
		// 残余グラフの用意
		this.Count = n;
		this.Used = new bool[this.Count];
		this.Graph = new List<List<Edge>>();
		for (int i = 0; i < this.Count; ++i) this.Graph.Add(new List<Edge>());
	} // end of constructor

	/// 残余グラフを作成してくれる(reverseは使わない)
	public MaximumFlow(List<List<Edge>> graph) {
		// 残余グラフの用意
		this.Count = graph.Count;
		this.Used = new bool[this.Count];
		this.Graph = new List<List<Edge>>();
		for (int i = 0; i < this.Count; ++i) this.Graph.Add(new List<Edge>());

		// 1本ずつ辺を追加する
		for (int i = 0; i < this.Count; ++i) {
			foreach (var e in graph[i]) {
				this.AddEdge(i, e.to, e.capacity);
			}
		}
	} // end of constructor

	/// 辺を追加する(1つずつ初期化する)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddEdge(int from, int to, long capacity) {
		// 頂点から出ている現在の要素数
		int fnum = this.Graph[from].Count;
		int tnum = this.Graph[to].Count;
		// 順方向にcapacity, 逆方向に0で残余グラフの辺を作成
		this.Graph[from].Add(new Edge(to, capacity, tnum));
		this.Graph[to].Add(new Edge(from, 0, fnum));
	} // end of method


	/// 深さ優先探索で残余グラフ上のstartからgoalまでの経路を１つ探索
	/// minFlowは経路上の残余グラフの最小capacity
	/// 流した流量を返す(流せないなら0)
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private long dfs(int node, int goal, long minFlow) {
		// goalについたら最小流量を返す
		if (node == goal) return minFlow;
		// 探索済み
		this.Used[node] = true;

		// dfs
		foreach (var edge in this.Graph[node]) {
			// 容量0は使えない
			if (edge.capacity == 0) continue;

			// 訪問済みは使用しない
			if (this.Used[edge.to]) continue;

			// 発見した流量
			long flow = this.dfs(edge.to, goal, Math.Min(minFlow, edge.capacity));

			// flowを流せる場合、残余グラフ順方向を減らして逆方向を増やす
			if (flow <= 0) continue;
			edge.capacity -= flow;
			this.Graph[edge.to][edge.reverse].capacity += flow;
			return flow;
		} // end of foreach

		// 経路が見つからなかった
		return 0;
	} // end of method

	/// startからgoalまでの最大流量を計算
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public long MaxFlow(int start, int goal) {
		long totalFlow = 0;
		while (true) {
			for (int i = 0; i < this.Count; ++i) this.Used[i] = false;
			long minFlow = this.dfs(start, goal, long.MaxValue);

			// フローを流せなくなったら終了
			if (minFlow == 0) break;
			totalFlow += minFlow;
		}
		return totalFlow;
	} // end of method
} // end of class