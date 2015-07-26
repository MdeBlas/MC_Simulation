using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{
    public abstract class Model
    {
        protected double r;
        protected double vol;

        public Model(double r_, double vol_)
        {
            this.r = r_;
            this.vol = vol_;
        }
        public abstract double diff( double Spot );
        public abstract double drift(double Spot);
    }

    public class Geometric : Model
    {


        public Geometric(double r_, double vol_):base (r_,vol_){ }
        public override double diff(double Spot)
        {
            return Spot * vol;
        }

        public override double drift(double Spot)
        {
            return Spot * r; ;
        }
    }

     

}
