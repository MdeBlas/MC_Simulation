using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{
    class Program
    {
        static void Main(string[] args)

        {
            double T;
            double K;
            double S;
            double vol;
            double r;
            double dt;
            int N;
            int Nsim;
            int OptionType;

            OptionPayOff myPayOff;
            Model myModel;
            Discretization MyDiscretization;
            

            Console.WriteLine("Input Expiry");
             T=Read<double>();
            Console.WriteLine("Input Strike");
            K = Read<double>();
            Console.WriteLine("Input Spot");
            S = Read<double>();
            Console.WriteLine("Inpuut Vol");
            vol = Read<double>();
            Console.WriteLine("Input r");
            r  = Read<double>();
            Console.WriteLine("Currently only European option using BGM in Euler scheme avalible ");
            Console.WriteLine("Input 0 for Call, otherwise Put ");
            OptionType = Read<int>();
            if (OptionType==0)
            {
                myPayOff = new CallPayOff(K);
            }
            else
            {
                myPayOff = new PutPayOff(K);
            }
            Console.WriteLine("Input N , number of steps used in the simulation ");
            N = Read<int>();
            dt = T / N;
            Console.WriteLine("Input Number of Paths used in the simulation");
            Nsim = Read<int>();

            myModel = new Geometric(r, vol);
            MyDiscretization = new Euler(dt, myModel);
            
            MC myMC = new MC(MyDiscretization, myPayOff, Nsim, N, r, T, S);
            
            Console.WriteLine("Price of the Option is:");
            Console.WriteLine( myMC.Simulate());
            Console.WriteLine("Standard Error is:");
            Console.WriteLine(myMC.Stnd_Error());
            Console.ReadKey();
           

        }


        public static T Read<T>()
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if(converter != null)
            {
                return (T)converter.ConvertFromString(Console.ReadLine());
            }
            return default(T);
        }
        public static void Print(double[,] Simulations)
        {

        }

       
    }
}

