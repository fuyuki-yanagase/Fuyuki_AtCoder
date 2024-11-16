#include "../_CppTemplate.cpp"

/// @brief ダイクストラ法である始点から全てのノードまでの距離を探索
/// @param graph vector<vector<pair<cost, node>>> i行目→頂点i j列目→{距離, 次の頂点}
/// @param start node
/// @return 距離を列挙した配列
// 問題に合わせてバイト数を変更
template <class T>
vector<T> dijkstra(const vector<vector<pair<T, T>>> &graph, int start) {
    // 変数用意
    int n = graph.size();

    // とりあえず最大値
    T MAX = sizeof(T) == 4 ? INT_MAX : LLONG_MAX;

    // 距離候補を保持する優先度付きキュー
    priority_queue<pair<T, T>, vector<pair<T, T>>, greater<pair<T, T>>> pque;

    // 確定した距離を保持するreturn用変数
    vector<T> distance(n, MAX);
    distance[start] = 0;
    pque.push(pair<T, T>(0, start));
    while (pque.size() > 0) {
        T d = pque.top().first;  // start から u までの距離
        T u = pque.top().second; // 距離を知りたいノード
        pque.pop();

        // 既に確定した距離以上なら更新余地がない
        if (distance[u] < d) continue;

        // 各種距離を追加
        for (auto next : graph[u]) {
            T cost      = next.first;
            T next_node = next.second;
            // 更新余地がない場合は次
            if (distance[next_node] <= d + cost) continue;
            distance[next_node] = d + cost;
            pque.push(pair<T, T>(d + cost, next_node));
        } // end of for
    }     // end of while

    return distance;
} // end of func