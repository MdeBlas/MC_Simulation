using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{

    public abstract class OptionPayOff
    {
        protected double Strike;

        public  OptionPayOff(double Strike_)
        {
            Strike = Strike_;
        }

        public  abstract double Payoff(double Spot);
    }

    public class CallPayOff : OptionPayOff
    {
     

       public CallPayOff(double Strike_) : base(Strike_) { }

  

        public override double Payoff(double Spot)
        {
            return Math.Max(Spot - Strike, 0);
        }
    }
    public class PutPayOff : OptionPayOff
    {
        public PutPayOff(double Strike_) : base(Strike_) { }
        public override double Payoff(double Spot)
        {
            return Math.Max(Strike - Spot, 0);
        }
    }

}
