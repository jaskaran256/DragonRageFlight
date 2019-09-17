using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonRageFlight
{
    abstract class Variables
    {
        public static Dragon[] dragon = new Dragon[4];
        public static Bettor[] dragonGambler = new Bettor[3];
        public static Random randomSpeed = new Random();
        public static int CurrentGambler { get; set; }
    }
}
