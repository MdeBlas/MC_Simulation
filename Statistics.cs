sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{
    public class Statistics
    {
        double[] SimPrices;
        double[] runningavg;
        int counter;
        double sum;
        double mean;

        public Statistics(int Nsims)
        {
            SimPrices = new double[Nsims];
            runningavg = new double[Nsims];
            counter = 0;
            mean = 0;
            sum = 0;
        }
        public void add(double newPrice)
        {
            sum = sum + newPrice;
            SimPrices[counter] = newPrice;
                      
            counter++;
            mean = sum / counter;
            runningavg[counter-1] = mean;
        }
      
        public double StndError()
        {
            double temp=0;
            for (int i = 0; i < counter; i++)
            {
                temp += Math.Pow(SimPrices[i]-mean,2);           
            }
            temp = temp / counter;
            return Math.Pow(temp, 0.5) / Math.Pow(counter, 0.5);
        }
        public double[] RunningAvg
        {
            get
            {
                return runningavg;
            }
        }
        public double Mean
        {
            get
            {
                return mean;
            }
        }
    }
}
