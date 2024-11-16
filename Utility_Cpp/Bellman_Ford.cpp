#include "../_CppTemplate.cpp"

typedef ll bf_type;
struct Edge {
    int     from;
    int     to;
    bf_type cost;
    Edge() {}
    Edge(int f, int t, bf_type c) : from(f), to(t), cost(c) {}
};

bool Bellman_Ford(vector<bf_type> &dist, const vector<Edge> &edges, int start_node = 0, int goal_node = -1) {
    // 頂点数n、エッジ数m
    int n = dist.size();
    int m = edges.size();

    // goal_nodeが指定されていなければ、最後のノードに指定
    if (goal_node == -1) goal_node = dist.size() - 1;

    // start_nodeからの距離をinfで初期化
    bf_type inf                 = sizeof(bf_type) == 4 ? INT_MAX : LLONG_MAX;
    rep(i, dist.size()) dist[i] = inf;
    dist[start_node]            = 0;

    // 各頂点は高々1回しか通らない
    vector<bool> posi(n, true); // 負の閉路検出用
    rep(i, n) {
        rep(j, m) {
            int     from = edges[j].from;
            int     to   = edges[j].to;
            bf_type cost = edges[j].cost;

            // 更新元がinfのときは、未到達点のため更新しない
            if (dist[from] == inf) continue;
            // 更新後の値が条件を満たさない場合は更新しない
            if (dist[to] <= dist[from] + cost) continue;

            dist[to] = dist[from] + cost;

            // 最適解は n - 1回で導かれる(各頂点は高々1回しか通らないことより)
            // → n 回目以降も更新されているならば、負の閉路がある
            if (i >= n - 1) posi[from] = false;
        }
    }

    // start_node → goal_node の経路間に負の閉路が存在するかを確認
    // (負の閉路はグラフ上に存在するが、経路上には存在しないパターンもある)
    rep(i, n) {
        rep(j, m) {
            int from = edges[j].from;
            int to   = edges[j].to;
            if (posi[from] == false) posi[to] = false;
        }
    }
    return posi[goal_node];
} // end of Bellman_Ford
