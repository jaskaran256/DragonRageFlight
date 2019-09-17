using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonRageFlight
{
    public class Bet : Dragon
    {
        public int betBalance { get; set; }
        public Bettor betPlacer { get; set; }
        public int betDragon { get; set; }
        
        public int CashOut(int Winner)
        {
            if(Winner == betDragon)
            {
                return betBalance * 4;
            }
            else
            {
                return (0 - betBalance);
            }
        }
    }
}
