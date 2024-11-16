n = 8
[false, true].repeated_permutation(n) do |bits|
	p bits
end
exit



n = 8
cnt = 0
(0..n-1).to_a.permutation do |bits|
	#p bits
	cnt += 1
end
puts cnt