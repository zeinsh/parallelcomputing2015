close all;
clc;
%% 1. define spmd 
% single program multiple data
spmd
    for i=1:10
        disp(i)
    end
end
%% 2. broadcasting
x=1;
spmd
    disp(x)
end
%% slice input
% example
% divide data between labs
a=ceil(rand(1,10)*10)
spmd
   for i=labindex:numlabs:10
      disp(a(i)) 
   end
end
%% reduction , distributed sum
% example
a=ceil(rand(1,10)*10);
s=0;
spmd
   for i=labindex:numlabs:10
     s=s+a(i); 
   end
end
sm=sum(s{:});
%% distributed code
x=1;
spmd
   switch (labindex)
       case 1
           disp('I am first lab')
       case 2
           disp('I am second lab')
           x=4;
   end
   y=x+1;
end
y{:}
%% distributed
% arrays are distributed according to the last dimension
rng=[1:9;1:9]
d=distributed(rng);
spmd
   s=getLocalPart(d);
   disp(s) 
end