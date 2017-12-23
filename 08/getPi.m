function [value]=getPi(n)
x=2*rand(1,n);
y=2*rand(1,n);

count=0;
parfor i=1:n
   if inCircle(x(i),y(i))
       count=count+1;
   end
end

value=4*count/n;
end