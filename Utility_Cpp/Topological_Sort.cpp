#include "../_CppTemplate.cpp"

// 参考
// https://qiita.com/Morifolium/items/6c8f0a188af2f9620db2
// https://hcpc-hokudai.github.io/archive/graph_topological_sort_001.pdf

// 有向非巡回グラフ(DAG:Directed Acyclic Graph)
// 隣接行列に対してトポロジカルソートする
// できない場合は要素0の配列を返す
vi topological_sort(const vvi &graph) {
    // ノード数
    const int n = graph.size();

    // 各ノードの入次数を記録
    vi input_nodes(n, 0);
    rep(i, n) {
        for (int dist : graph[i]) {
            input_nodes[dist] += 1;
        }
    } // end of for

    // 入力の本数が0のノードを記録
    queue<int> que;
    rep(i, n) {
        if (input_nodes[i] > 0) continue;
        que.push(i);
    } // end of for

    // トポロジカルソートした結果を記録する配列
    vi sorted_arr;

    // 手順1 : 入次数が0のノードをキューに追加
    // 手順2 : キューからノードを取り出しソート結果に追加
    // 手順3 : 隣接するノードの入次数を-1
    // 手順4 : 手順1 ~ 手順3 を繰り返し
    while (que.empty() == false) {
        // キューから取り出し
        int v = que.front();
        que.pop();

        // 隣接するノードの入次数を-1
        for (int next : graph[v]) {
            input_nodes[next] -= 1;
            // 入次数が0ならノードに追加
            if (input_nodes[next] == 0) que.push(next);
        } // end of for

        // ソート結果に追加
        sorted_arr.emplace_back(v);
    } // end of while

    // ソートしたノード数がgrpahのノード数と一致すればトポロジカルソート成功
    // 一致しなければトポロジカルソートできないグラフ
    return sorted_arr.size() == n ? sorted_arr : vi(0);
} // end of func