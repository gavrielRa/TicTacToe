using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_Tictactoe
{
    public partial class TixTacToe : Form
    {

        bool turn = true;//true = x, false = y;
        int turn_count = 0;



        public TixTacToe()
        {
            InitializeComponent();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Gavriel Rachmilov", "Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }//end try
            catch { };
        }

        //button click actions
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "O";
            else
                b.Text = "X";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        //check if ther is a winner
        private void checkForWinner()
        {
            bool ther_is_a_winner = false;

            //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                ther_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                ther_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                ther_is_a_winner = true;

            //vertical check
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                ther_is_a_winner = true;
            else if((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                ther_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                ther_is_a_winner = true;

            //diagonal check
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                ther_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                ther_is_a_winner = true;


            if (ther_is_a_winner)
            {
                String winner = "";
                if (turn)
                    winner = "X";
                else
                    winner = "O";

                MessageBox.Show("The Winner is: "+winner, "Winner");
                disableButtons();
            }//end if
            else if(turn_count == 9)
            {
                MessageBox.Show("The is a Draw!!!", "Winner");
            }


        } 
        //disable all buttons 
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }//end try
            catch { };
        }

 
    }
}
