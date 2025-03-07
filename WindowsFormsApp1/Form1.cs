using System;
using System.Windows.Forms;

namespace XOX_Game
{
    public partial class Form1 : Form
    {
        private char currentPlayer = 'X';
        private Button[,] buttons = new Button[3, 3];

        public Form1()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Width = 100,
                        Height = 100,
                        Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold),
                        Location = new System.Drawing.Point(j * 100, i * 100)
                    };
                    buttons[i, j].Click += Button_Click;
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Text == "")
            {
                clickedButton.Text = currentPlayer.ToString();
                if (CheckWin())
                {
                    MessageBox.Show($"{currentPlayer} Kazandı!");
                    ResetGame();
                }
                else if (IsDraw())
                {
                    MessageBox.Show("Berabere!");
                    ResetGame();
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Text != "" && buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text)
                    return true;
                if (buttons[0, i].Text != "" && buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text)
                    return true;
            }
            if (buttons[0, 0].Text != "" && buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
                return true;
            if (buttons[0, 2].Text != "" && buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text)
                return true;
            return false;
        }

        private bool IsDraw()
        {
            foreach (var button in buttons)
            {
                if (button.Text == "") return false;
            }
            return true;
        }

        private void ResetGame()
        {
            foreach (var button in buttons)
            {
                button.Text = "";
            }
            currentPlayer = 'X';
        }
    }
}
