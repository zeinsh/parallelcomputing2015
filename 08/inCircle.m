function [ret]=inCircle(x,y)
if (x-1)^2+(y-1)^2<=1
    ret=1;
else
    ret=0;
end
end