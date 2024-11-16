# xのn乗を繰り返し二乗法で
def PowPow(x, n)
  return 1 if n == 0
	return PowPow(x**2, n / 2) if n.even?
  return PowPow(x, n-1) * x
end

# MODをとる場合
$BIGMOD = 10**9 + 7
def PowPow(x, n)
  return 1 if n == 0
	return PowPow(x**2  % $BIGMOD, n / 2) if n.even?
  return PowPow(x, n-1) * x  % $BIGMOD 
end