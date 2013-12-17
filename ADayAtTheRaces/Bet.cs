using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADayAtTheRaces
{
    class Bet
    {
        public int Amount = 0;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            return Amount > 0 ? String.Format("{0} bets {1} on  dog #{2}", Bettor.Name, Amount, Dog)
                : String.Format("{0} hasn't placed a bed", Bettor.Name);
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
            {
                return Amount;
            }
            else
                return -1 * Amount;
        }
    }
}
