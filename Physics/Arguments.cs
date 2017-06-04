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
        public Argument k { get; set; }
        public Argument p { get; set; }

        public Arguments()
        {
            mass = new Argument();
            defaultH = new Argument();
            g = new Argument();
            angle = new Argument();

            v0 = new Argument();
            p = new Argument();
            k = new Argument();
        }

        public bool Accepted()
        {
            return (mass.ok && defaultH.ok && g.ok && angle.ok
                    && v0.ok && k.ok && p.ok);
        }
    }
}
