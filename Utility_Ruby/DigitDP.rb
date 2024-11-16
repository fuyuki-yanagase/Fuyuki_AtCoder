# ABC 007 D問題
# str = "432141" などの数値の文字列
def DigitDP(str)
	n = str.length
	# 桁, 4または9を含むか(0→含まない 1→含む), 確定してる桁が同じか(入れる値が現在の桁の値までで制限されているか)
	dp = Array.new(n + 1).map{Array.new(2)}.map{|a| a.map{Array.new(2,0)}}
	dp[0][0][0] = 1
	
	(n).times do |i|
		now = str[i].to_i
		2.times do |j|
			2.times do |k|
				10.times do |d|
					ii = i + 1; jj = j; kk = k;
					
					# すでに4または9が入っている or 次に4 or 9を入れるならガバに
					jj = 1 if j == 1 || d == 4 || d == 9
					
					# それまでの桁が入力と同じなら
					if k == 0 then
						# 現在の数値以上を入れられない
						next if d > now
						# 現在の数値より小さいなら次から何でも入れられる
						kk = 1 if d < now
					end
					#puts "ii:#{ii} jj:#{jj} kk:#{kk} i:#{i} j:#{j} k:#{k}"
					dp[ii][jj][kk] += dp[i][j][k]
				end
			end
		end
	end
	
	return dp[n][1].inject(:+)
end


# ABC 154 e問題
n = "0" + gets.chomp
kkk = gets.chomp.to_i
# 桁, 回数,  0→それまでの桁と確定してる桁が同じ 1→小さいので何でも入る
dp = Array.new(n.length + 1).map{Array.new(kkk + 1)}.map{|a| a.map{Array.new(2,0)}}
dp[0][0][0] = 1

n.length.times do |i|
	now = n[i].to_i
	(kkk+1).times do |j|
		2.times do |k|
			10.times do |d|
				ii = i + 1; jj = j; kk = k;
				jj += 1 if d != 0
				next if jj > kkk
				if k == 0 then
					next if d > now
					kk = 1 if d < now
				end
				#puts "i:#{i} j:#{j} k:#{k} ii:#{ii} jj:#{jj} kk:#{kk}"
				dp[ii][jj][kk] += dp[i][j][k]
			end
		end
	end
end 
puts dp[n.length][kkk].inject(:+)
