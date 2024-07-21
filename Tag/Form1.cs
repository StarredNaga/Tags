using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyWinForms
{
    public partial class Form1 : Form
    {
        List<Button> buttons = null;
        Button selectedButton = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
            selectedButton = button8;
        }

        private void StartGame()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8 };
            Random random = new Random();

            for (int i = 0; i < buttons.Count; i++)
            {
                int num = numbers[random.Next(numbers.Count)];
                buttons[i].Text = num.ToString();

                numbers.Remove(num);
            }
        }

        private void CheckWin()
        {
            bool win = true;

            for (int i = 0; i < buttons.Count; i++)
            {
                Button current = buttons[i];

                switch (current.Text)
                {
                    case "1":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(0, 0)) win = false;
                        break;

                    case "2":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(1, 0)) win = false;
                        break;

                    case "3":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(2, 0)) win = false;
                        break;

                    case "4":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(0, 1)) win = false;
                        break;

                    case "5":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(1, 1)) win = false;
                        break;

                    case "6":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(2, 1)) win = false;
                        break;

                    case "7":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(0, 2)) win = false;
                        break;

                    case "8":
                        if (tableLayoutPanel1.GetPositionFromControl(current) != new TableLayoutPanelCellPosition(1, 2)) win = false;
                        break;

                }
            }

            if (!win) return;

            MessageBox.Show("You Win!");
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int x = 0;
            int y = 0;
            int buttonX = tableLayoutPanel1.GetColumn(selectedButton);
            int buttonY = tableLayoutPanel1.GetRow(selectedButton);

            switch (e.KeyCode)
            {
                case Keys.W:
                    y = -1;
                    break;

                case Keys.S:
                    y = 1;
                    break;

                case Keys.D:
                    x = 1;
                    break;

                case Keys.A:
                    x = -1;
                    break;
            }

            if (buttonX + x > 2 || buttonX + x < 0 || buttonY + y > 2 || buttonY + y < 0) return;

            if (tableLayoutPanel1.GetControlFromPosition(buttonX + x, buttonY + y) == null)
            {
                try
                {
                    TableLayoutPanelCellPosition position = new TableLayoutPanelCellPosition(buttonX + x, buttonY + y);
                    tableLayoutPanel1.SetCellPosition(selectedButton, position);
                }
                catch (Exception) { }

                CheckWin();
            }
        }
    }

}
