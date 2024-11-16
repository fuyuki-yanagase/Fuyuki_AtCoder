# このページを全部コピペ

$BIGMOD = (10**9) + 7

def nCk(n,k)
	b = (1..k).inject(1){|p, c| p * c % $BIGMOD}
	a = (0..k-1).inject(1){|p, c| p * (n - c) % $BIGMOD}
  a * Inv(b) % $BIGMOD
end

def nPk(n,k)
	return Fact(n) / Fact(n-k) % $BIGMOD
end

def Fact(n)
  (1..n).inject(1) { |r, i| (r * i) % $BIGMOD }
end

def Inv(n)
  PowPow(n, $BIGMOD - 2) % $BIGMOD
end

def PowPow(x, n)
  return 1 if n == 0
	return PowPow(x**2  % $BIGMOD, n / 2) if n.even?
  return PowPow(x, n-1) * x  % $BIGMOD 
end


(1..5).each do |i|
	#puts ppow(2, i)
	puts "nck:#{nCk(5,i)} npk:#{nPk(5,i)}"
end