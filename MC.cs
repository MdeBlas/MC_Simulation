using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{
    class MC
    {
        Discretization mydiscretization;
        OptionPayOff mypayoff;
        Statistics mystats;
        int Nsim;
        int N;
        double r;
        double T;
        double Spot;
        double[,] Paths;


        public MC(Discretization mydiscretization_, OptionPayOff mypayoff_, int Nsim_, int N_, double r_, double T_, double Spot_)
        {
            
            Nsim = Nsim_;
            N = N_;
            r = r_;
            T = T_;
            Spot = Spot_;
            mydiscretization = mydiscretization_;
            mypayoff = mypayoff_;
            mystats = new Statistics(Nsim);
            Paths = new double[N+1, Nsim];


        }

        public double Simulate()
        {
            double S;
            for (int sim = 0; sim < Nsim; sim++)
            {
                S = Spot;
                Paths[0, sim] = S;
                for (int step = 1; step < N+1; step++)
                {
                    S = mydiscretization.move(S);
                    Paths[step, sim] = S;
                }
                mystats.add(mypayoff.Payoff(S));
               
            }
            return mystats.Mean * Math.Exp(-r*T);
        }
        public  double[,] SimulatedPaths
        {
            get
            {
                return Paths;
            }
        }
        public double Stnd_Error()
        {
            return mystats.StndError();
        }
    }
}
