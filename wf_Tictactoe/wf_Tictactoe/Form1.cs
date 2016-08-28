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

        bool turn = true;//true = X, false = O;
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


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { };

            }
        }

        //button click actions
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
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
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                ther_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                ther_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                ther_is_a_winner = true;

            //diagonal check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                ther_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                ther_is_a_winner = true;


            if (ther_is_a_winner)
            {
                String winner = "";
                if (turn)
                {
                    winner = "O";
                    o_count.Text =(Int32.Parse(o_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_count.Text = (Int32.Parse(x_count.Text) + 1).ToString();

                }
                MessageBox.Show("The Winner is: "+winner, "Winner");
                disableButtons();
            }//end if
            else if(turn_count == 9)
            {
                MessageBox.Show("The is a Draw!!!", "Winner");
                draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
            }


        } 
        //disable all buttons 
        private void disableButtons()
        {

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { };

            }
        }




        private void mouse_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }

        private void resetAllFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGameToolStripMenuItem_Click(sender,e);
            x_count.Text = "0";
            o_count.Text = "0";
            draw_count.Text = "0";
        }
    }
}
