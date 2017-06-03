using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    public class Argument
    {
        public bool ok;
        public double value;

        public Argument()
        {
            ok = false;
            value = 0;
        }
    };

    public class Arguments
    {
        public Argument mass { get; set; }     // mass of the body
        public Argument defaultH { get; set; } // start height
        public Argument g { get; set; }        // g
        public Argument angle { get; set; }    // [0; 90]

        public Argument v0 { get; set; }      // init velocity
        public Argument v1 { get; set; }      // first Boundary value
        public Argument v2 { get; set; }      // second Boundary value

        public Argument k1 { get; set; }      // first interval value
        public Argument k2 { get; set; }      // second inteval value
        public Argument k3 { get; set; }      // third interval value

        public Arguments()
        {
            mass = new Argument();
            defaultH = new Argument();
            g = new Argument();
            angle = new Argument();

            v0 = new Argument();
            v1 = new Argument();
            v2 = new Argument();

            k1 = new Argument();
            k2 = new Argument();
            k3 = new Argument();
        }

        public bool Accepted()
        {
            return (mass.ok && defaultH.ok && g.ok && angle.ok
                    && v0.ok && v1.ok && v2.ok
                    && k1.ok && k2.ok && k3.ok);
        }
    }
}
