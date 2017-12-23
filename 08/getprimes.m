function [ret]=getprimes(n,m)
   ret=[];
   parfor i=n:m
       if isPrime(i)
           ret=[ret i];
       end
   end
end