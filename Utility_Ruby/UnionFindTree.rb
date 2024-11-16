
class UnionFindTree
	#シンプルシンプルなUnionFind
	attr_accessor :nodes
	def initialize(size)
		@nodes = Array.new(size)
		size.times do |i|
			@nodes[i] = -1
		end
		nodes = @nodes
	end
 
	def findParent(x)
		if @nodes[x] < 0 then 
			return x
		else
			return findParent(@nodes[x])
		end
	end
 
	def unite(x, y)
		xx = findParent(x)
		yy = findParent(y)
		return if xx == yy
 
		xx, yy = yy, xx if @nodes[xx] > @nodes[yy]
 
		@nodes[xx] += @nodes[yy]
		@nodes[yy] = xx
	end
 
	def same(x, y)
		return findParent(x) == findParent(y)
	end
end



class UnionFindTree
	#0→連結成分のサイズ 1→parent 2→rank 3→連結成分に含まれる人
	attr_accessor :nodes
	def initialize(size)
		@nodes = Array.new(size)
		size.times do |i|
			@nodes[i] = [1, i, 0, [i]]
		end
		nodes = @nodes
	end

	# x番目の値の親を探す
	def findParent(x)
		if @nodes[x][1] == x then 
			return x
		else
			return findParent(@nodes[x][1])
		end
	end

	# 合併
	def unite(x, y)
		xx = findParent(x)
		yy = findParent(y)
		return if xx == yy

		xx, yy = yy, xx if @nodes[xx][2] > @nodes[yy][2]

		@nodes[xx][0] += @nodes[yy][0]
		@nodes[yy][1] = xx
		@nodes[xx][2] += 1 if @nodes[xx][2] == @nodes[y][2]
		@nodes[xx][3] += @nodes[yy][3]

		# if @nodes[xx][2] < @nodes[yy][2] then
		# 	@nodes[xx][1] = yy
		# 	@nodes[xx][0] += @nodes[yy][0]
		# 	@nodes[yy][0] = @nodes[xx][0]
		# else
		# 	@nodes[yy][1] = xx
		# 	@nodes[yy][0] += @nodes[xx][0]
		# 	@nodes[xx][0] = @nodes[yy][0]
		# 	@nodes[xx][2] += 1 if @nodes[xx][2] == @nodes[yy][2]
		# end
	end

	def same(x, y)
		return findParent(x) == findParent(y)
	end
end
