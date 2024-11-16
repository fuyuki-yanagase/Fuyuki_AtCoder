n = 19
arr = (0..100).to_a.map{|a| a * 2}

def BinarySearch(arr, n)
	l = 0
	r = arr.length
	prev = -1
	while l < r 
		mid = (l + r) / 2
		return mid if mid == prev 
		if arr[mid] == n 
			return mid 
		elsif n < arr[mid] 	
			r = mid 
		else
			l = mid 
		end
		prev= mid
	end
	return -1
end

0.upto(100)  do |i|
	puts BinarySearch(arr, i)
end