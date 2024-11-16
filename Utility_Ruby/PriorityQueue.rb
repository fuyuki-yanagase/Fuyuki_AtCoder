class PriorityQueue
  def initialize(array = [], is_desc = false)
		@data = []
		@is_desc = is_desc
    array.each{|a| insert(a)}
  end

  def insert(element)
    @data.push(element)
    bottom_up
  end

  def pop
    if size == 0
      return nil
    elsif size == 1
      return @data.pop
    else
      min = @data[0]
      @data[0] = @data.pop
      top_down
      return min
    end
  end


  def swap(i, j)
    @data[i], @data[j] = @data[j], @data[i]
  end

  def size
    @data.size
  end

  def parent_idx(target_idx)
    (target_idx - (target_idx.even? ? 2 : 1)) / 2
  end

  def bottom_up
    target_idx = size - 1
    return if target_idx == 0
    parent_idx = parent_idx(target_idx)
    while (@data[parent_idx] > @data[target_idx]) != @is_desc
      swap(parent_idx, target_idx)
      target_idx = parent_idx
      break if target_idx == 0
      parent_idx = parent_idx(target_idx)
    end
  end

  def top_down
    target_idx = 0

    # child がある場合
    while (has_child?(target_idx))

      a = left_child_idx(target_idx)
      b = right_child_idx(target_idx)

      if @data[b].nil?
        c = a
      else
        c = @data[a] <= @data[b] != @is_desc ? a : b
      end

      if @data[target_idx] > @data[c] != @is_desc
        swap(target_idx, c)
        target_idx = c
      else
        return
      end
    end
  end

  # @param Integer
  # @return Integer
  def left_child_idx(idx)
    (idx * 2) + 1
  end

  # @param Integer
  # @return Integer
  def right_child_idx(idx)
    (idx * 2) + 2
  end

  # @param Integer
  # @return Boolent
  def has_child?(idx)
    ((idx * 2) + 1) < @data.size
  end
end

#pp = PriorityQueue.new()

# n, m = gets.chomp.split(" ").map(&:to_i)
# arr = gets.chomp.split(" ").map{|a| a.to_i * -1}
# arr.each do |a|
# 	pp.insert(a)
# end
# m.times do |i|
# 	pp.insert((pp.pop / 2.0).ceil)
# end
# sum = 0;
# pp.size.times do |i|
# 	sum += pp.pop
# end
# puts sum.abs
arr = (0..10).to_a.shuffle
p arr
pq = PriorityQueue.new(arr, true)
11.times do 
	puts pq.pop
end

