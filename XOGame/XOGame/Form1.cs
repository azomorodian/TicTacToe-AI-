using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XOGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MiniMax mx = new MiniMax();
        XOProblem Game = new XOProblem();
        private void button1_Click(object sender, EventArgs e)
        {
        }
        Presentation p;
        private void Form1_Load(object sender, EventArgs e)
        {
            Game.Turn = 1;
            p = new Presentation(230, 230, pictureBox1);
            p.Update();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (Game.TermianlTest())
            {
                MessageBox.Show("Game Finished. \r\n Please press New Game button");
                return;
            }
            int Col = (e.X - 20) / p.CellW;
            int Row = (e.Y - 20) / p.CellH;
            if (p.State[Row, Col] == 0)
            {
                p.State[Row, Col] = Game.Turn;
                Game.CopyState(ref p.State);
                p.Update();
                if (Game.GoalTest(Game.Turn) == 1)
                {
                    MessageBox.Show("Congradulation " + (Game.Turn == 1 ? "X" : "O") + " Wins!!!!");
                    return;
                }
                if (Game.TermianlTest())
                {
                    MessageBox.Show(" Draw ! ");
                    return;
                }

                Game.Turn = 3 - Game.Turn;
                                
            }
            else
                MessageBox.Show("Please Select Empty Cells");
            
            
            
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Turn = 1;
            Game.NewGame();
            p.CopyState(ref Game.State);
            p.Update();

        }

        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mx = new MiniMax();
            XOProblem decistionNode = new XOProblem();
            decistionNode.Turn = Game.Turn;
            decistionNode.CopyState(ref Game.State);
            mx.WhomDecision = Game.Turn;
            XOProblem res = mx.MinmaxDecision(decistionNode);
            if (res != null)
            {
                Game.State[res.action.row,res.action.col] = Game.Turn;
                p.CopyState(ref Game.State);
                p.Update();
                if (Game.GoalTest(Game.Turn) == 1)
                {
                    MessageBox.Show("Congradulation " + (Game.Turn == 1 ? "X" : "O") + " Wins!!!!");
                    return;
                }
                if (Game.TermianlTest())
                {
                    MessageBox.Show(" Draw ! ");
                    return;
                }

                Game.Turn = 3 - Game.Turn;
            }

        }
    }
}
