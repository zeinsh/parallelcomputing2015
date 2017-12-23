using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParProg3
{
    class MergeSorter
    {

        public static void trySort()
        {
            SortSeq();
           
        }

        private static int[] InitArray(int length)
        {
            int[] result = new int[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                result[i] = r.Next(100);
            }
            return result;
        }
        public static void SortSeq()
        {
            int[] example = InitArray(1000000);
            List<int> theList = new List<int>();
            theList.AddRange(example);
            Stopwatch st = new Stopwatch();
            st.Start();
            MergeSortSeq(theList, 0, theList.Count);
            st.Stop();
            string time = st.ElapsedMilliseconds.ToString();

        }

        public static void SortPar()
        {
            
            
        }
       
        
        private static void MergeSortSeq(List<int> org, int low, int hight)
        {

            if (hight - low <= 1)
                return;
            int mid = (hight + low) / 2;	

            MergeSortSeq(org, low, mid);
            MergeSortSeq(org, mid, hight);

            
            Merge(org, low, mid, hight);
        }

        private static void Merge(List<int> result,int low,int mid,int high)
        {
            int i, j;
            List<int> temporary = new List<int>();
            for (i = low, j = mid; i < mid && j < high; )
            {
                if (result[i] > result[j])
                {
                    temporary.Add(result[j]);
                    j++;
                }
                else
                {
                    temporary.Add(result[i]);
                    i++;
                }

            }

            while (i < mid)
                temporary.Add(result[i++]);
            while (j < high)
                temporary.Add(result[j++]);
            for( i=low,j=0;i<high&&j<temporary.Count;i++,j++)
            {
                result[i] = temporary[j];
            }
            
           
        }
    }
}
