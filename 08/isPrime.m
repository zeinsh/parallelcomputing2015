function [ ret] = isPrime( n )
    ret=1;
    for i=2:n-1
        if mod(n,i)==0
            ret=0;
        end
    end
end

