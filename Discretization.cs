using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{
    public abstract class Discretization
    {
        protected Random myRandom = new Random();
        protected double dt;
        protected Model myModel;
        public Discretization (double dt_, Model myModel_){
            this.dt=dt_;
            this.myModel = myModel_;
                    }
        public abstract double move(double Spot);

    }
    public  class Euler : Discretization
    {
        
        public Euler(double dt_, Model myModel_)
            : base(dt_, myModel_) {}
        
        public override double move(double Spot)
        {
            return Spot + myModel.drift(Spot) * dt + myModel.diff(Spot) * Math.Sqrt(dt) * MathTools.NormInv(myRandom.NextDouble());
        }
    }

    
}
