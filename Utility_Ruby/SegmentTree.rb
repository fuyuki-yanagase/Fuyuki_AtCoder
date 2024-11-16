# you can write to stdout for debugging purposes, e.g.
# puts "this is a debug message"

# 参考
#https://tsutaj.hatenablog.com/entry/2017/03/29/204841


# 範囲は半開区間[a, b)なことに注意!
class SegmentTree
    attr_accessor :nodes 
    
    # セグメント木の構築
    def initialize(n, max=Float::INFINITY)
        @n = 1
        @max = max
        while @n < n do @n *= 2 end 
        @nodes = Array.new(@n * 2 - 1, @max)
    end

    def initialize(array, max=Float::INFINITY)
        @n = 1
        @max = max
        n = array.length
        while @n < n do @n *= 2 end 
        @nodes = Array.new(@n * 2 - 1, @max)
 
        n.times do |i| 
            @nodes[i + @n - 1] = array[i]
        end
        (@n - 2).downto(0) do |i|
            @nodes[i] = [@nodes[i * 2 + 1], @nodes[i * 2 + 2]].min 
        end 
    end

    # k番目のnodeをaに変更
    def update(k, a)
        k += @n - 1

        # 最下段のnodeから親に上がっていきながら更新する
        @nodes[k] = a 
        while k > 0 
            k = (k - 1) / 2 
            @nodes[k] = [@nodes[2 * k + 1], @nodes[2 * k + 2]].min
        end
    end

    # 区間[a, b)の範囲で最小値を返す
    # k → 現在のノードのインデックス
    # l, r → 対象区間
    def query(a, b, k = 0, l = 0, r = @n)
        # 要求区間と対象区間が交わらない時はnil
        return @max if r <= a || b <= l

        # 要求区間が対象区間を完全に覆う場合 → 対象区間を答えの計算に使用
        #puts "@nodes[k]:#{@nodes[k]}, k:#{k}"
        return @nodes[k] if a <= l && r <= b  

        # 要求区間が対象区間の一部と被覆 → 子の探索
        # 新規対象区間は現在の対象区間の半分
        left  = query(a, b, 2 * k + 1, l, (l + r) / 2)
        right = query(a, b, 2 * k + 2, (l + r) / 2, r)
        #puts "a:#{a} b:#{b} l:#{l} r:#{r} k:#{k} left:#{left} right:#{right}"
        return left < right ? left : right
    end
end
