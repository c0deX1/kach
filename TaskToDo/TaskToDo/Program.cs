using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData = args[0];
            string outputData = args[1];

            string[] lines = File.ReadAllLines(inputData);
            int myId = Int32.Parse(lines[0]);
            int workersAmmount = Int32.Parse(lines[1]);
            /*
            ArrayList arr = new ArrayList();
            string[] dataItems = lines[2].Split(' ');
            foreach (string dataItem in dataItems)
            {
                arr.Add(Int32.Parse(dataItem));
            }
            */
            ulong n = 100000;
            ulong step = n / (ulong)workersAmmount;
            ulong sum = 0;
            for (ulong i = (ulong)myId * step; i < ((ulong)myId + 1) * step; i++)
            {
                int devidersAmm = 0;
                for (ulong j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                        devidersAmm++;
                    if (devidersAmm > 2)
                        break;
                }
                if (devidersAmm == 2)
                    sum += i;   
            }
            File.WriteAllText(outputData, sum.ToString());
            
        }
    }
}
