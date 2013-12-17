using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    class Guy
    {
        public string  Name { get; set; }
        public Bet myBet = new Bet();
        public int Cash { get; set; }
        public Label cashLabel;
        public Label betLabel;

        public void UpdateLabels()
        {
            betLabel.Text = myBet != null ? myBet.GetDescription() : String.Format("{0} hasn't placed a bed", Name);
            cashLabel.Text = String.Format("{0} has {1} bucks", Name, Cash);
        }

        public void ClearBet()
        {
            myBet = null;
        }

        public bool PlaceBet(int amount, int dog)
        {
            
            if (amount < Cash)
            {
                myBet = new Bet()
                    {
                        Dog = dog,
                        Amount = amount,
                        Bettor = this
                    };
                return true;
            }
            else return false;
        }

        public void Collect(int winner) 
        {
            if (myBet != null)
            {
                Cash += myBet.PayOut(winner);
            }
            
        }
        
    }


}
