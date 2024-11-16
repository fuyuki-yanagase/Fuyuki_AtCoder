s = gets.chomp
qnum = gets.chomp.to_i
query = gets.chomp.split.map(&:to_i)

query.each do |q| 
	changed = false
	num = (q - 1) / s.length
	
	while num > 0 
		bekijo = 1
		while (bekijo * 2) <= num
			bekijo *= 2
		end
		# log2 = Math.log2(num)
		# bekijo = log2.to_i
		changed = !changed
		num = num - bekijo

		# puts "changed:#{changed} bekijo:#{bekijo} num:#{num}"
		# puts "changed:#{changed} log2:#{log2} bekijo:#{bekijo} num:#{num}"
	end

	ind = (q-1) % s.length

	if changed == false
		print(s[ind] + " ")
	else
		print(s[ind].swapcase + " ")
	end
end