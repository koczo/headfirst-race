using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ADayAtTheRaces
{
    public partial class UserControlMainGame : UserControl
    {
        bool finish;
        MySqlDBConnect db = new MySqlDBConnect();
        int winner;
        List<Greyhound> dogs;
        List<Guy> guys;
        Random random = new Random();
        private string gamerLogin;

        public string GamerLogin
        {
            get { return String.IsNullOrEmpty(gamerLogin)?"Somebody":gamerLogin; }
            set { gamerLogin = value; }
        }
        

        public UserControlMainGame()
        {
            InitializeComponent();
            buttonRace.Enabled = false;
        }

        private void UserControlMainGame_Load(object sender, EventArgs e)
        {
            labelName.Text = GamerLogin;
            labelMinimumBet.Text += String.Format(" {0} bucks", numericUpDownBetAmount.Minimum);
            dogs = new List<Greyhound>();
            dogs.Add(new Greyhound() { myPictureBox = pictureBoxDog1, StartingPosition = pictureBoxDog1.Left, RacetrackLength = pictureBoxRaceTrack.Right - pictureBoxDog1.Right });
            dogs.Add(new Greyhound() { myPictureBox = pictureBoxDog2, StartingPosition = pictureBoxDog2.Left, RacetrackLength = pictureBoxRaceTrack.Right - pictureBoxDog1.Right });
            dogs.Add(new Greyhound() { myPictureBox = pictureBoxDog3, StartingPosition = pictureBoxDog3.Left, RacetrackLength = pictureBoxRaceTrack.Right - pictureBoxDog1.Right });
            dogs.Add(new Greyhound() { myPictureBox = pictureBoxDog4, StartingPosition = pictureBoxDog4.Left, RacetrackLength = pictureBoxRaceTrack.Right - pictureBoxDog1.Right });


            guys = new List<Guy>();
            guys.Add(new Guy() { Name = GamerLogin, betLabel = labelJoe, cashLabel = labelGamer3Cash, Cash = 50, myBet = null });
            guys.Add(new Guy() { Name = "Bob", betLabel = labelBob, cashLabel = labelGamer2Cash, Cash = 50, myBet = null });
            guys.Add(new Guy() { Name = "Al", betLabel = labelAl, cashLabel = labelGamer1Cash, Cash = 50, myBet = null });

            foreach (Guy guy in guys)
            {
                guy.UpdateLabels();
            }
        }


   

        private void groupBoxBettingPerlor_Enter(object sender, EventArgs e)
        {

        }

        private void buttonRace_Click(object sender, EventArgs e)
        {
            buttonBet.Enabled = false;
            while (!finish)
            {
                winner = 1;
                foreach (Greyhound dog in dogs)
                {
                    finish = dog.Run();
                    dog.myPictureBox.Invalidate();
                    Thread.Sleep(7);
                    Application.DoEvents();
                    if (finish)
                    {
                        break;
                    }
                    winner++;
                }
            }
            string message = String.Format("Wygrał pies numer #{0}", winner.ToString());
            MessageBox.Show(message, "Rezultat wyścigu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Nie ma bazy 
            //db.Insert(message); 
            //
            foreach (Guy guy in guys)
            {
                guy.Collect(winner);
                guy.ClearBet();
                guy.UpdateLabels();
            }
            buttonRace.Enabled = false;
            buttonBet.Enabled = true;
            Reset();
        }

     
        public void Reset()
        {
            finish = false;
            foreach (Greyhound dog in dogs)
            {
                dog.TakeStartingPosition();
            }
        }

        private void buttonBet_Click(object sender, EventArgs e)
        {

            if (guys[0].PlaceBet((int)numericUpDownBetAmount.Value, (int)numericUpDownBetOnDogNumber.Value))
            {
                guys[0].UpdateLabels();
            }



            if (guys[1].PlaceBet(random.Next(5, 16), random.Next(1, 5)))
            {
                guys[1].UpdateLabels();
            }



            if (guys[2].PlaceBet(random.Next(5, 16), random.Next(1, 5)))
            {
                guys[2].UpdateLabels();
            }


            numericUpDownBetAmount.Value = numericUpDownBetAmount.Minimum;
            numericUpDownBetOnDogNumber.Value = numericUpDownBetOnDogNumber.Minimum;
            buttonRace.Enabled = true;

        } 

       

        

      
    }
}
