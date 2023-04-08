using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    
    public partial class Form1 : Form
    {
        private static int Count = 0;
        private int Get2or4Number()
        {
            var rnd = new Random();
            int number = rnd.Next(100);
            if (number > 10)
                return 2;
            else
                return 4;
        }

        private void SetToCell()
        {
            var rnd = new Random();
            int cell = 0;
            do
            {
                cell = rnd.Next(0, 15);
            } while (!(buttonList[cell].Text.Length==0));
            int number = Get2or4Number();
            buttonList[cell].Text = Convert.ToString(number);
            buttonList[cell].Font = new Font("Times New Roman", 15, FontStyle.Bold);
            buttonList[cell].ForeColor = Color.Black;
            buttonList[cell].BackColor = Color.FromArgb(100, 150, number / 10 < 256 ? number / 10 : 255, number < 256 ? number : 255);
        }

        private bool ToRight()
        {
            bool tmp = false;
            int number = 0;
            for (int k = 1; k < 4; k++)
            {
                for (int line = 0; line <= 3; line++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        //Thread.Sleep(500);
                        if (!(buttonList[line * 4 + row].Text.Length==0))
                        {
                            if (!(buttonList[line * 4 + row + 1].Text.Length==0))
                            {
                                if (buttonList[line * 4 + row].Text.Equals(buttonList[line * 4 + row + 1].Text))
                                {
                                    number = Math.Abs(Convert.ToInt32(buttonList[line * 4 + row].Text) * 2);
                                    Count += number/2;
                                    count.Text = Count.ToString();
                                    buttonList[line * 4 + row + 1].Font = new Font("Times New Roman", 15, FontStyle.Bold);
                                    buttonList[line * 4 + row + 1].ForeColor = Color.Black;
                                    buttonList[line * 4 + row + 1].BackColor = Color.FromArgb(100, 150, number / 10 < 256 ? number / 10 : 255, number < 256 ? number : 255);
                                    buttonList[line * 4 + row + 1].Text = $"{number * -1}";
                                    buttonList[line * 4 + row].Text = "";
                                    buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                    buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                    tmp = true;
                                }
                            }
                            else
                            {
                                buttonList[line * 4 + row + 1].Text = buttonList[line * 4 + row].Text;
                                buttonList[line * 4 + row + 1].Font = buttonList[line * 4 + row].Font;
                                buttonList[line * 4 + row + 1].ForeColor = buttonList[line * 4 + row].ForeColor;
                                buttonList[line * 4 + row + 1].BackColor = buttonList[line * 4 + row].BackColor;
                                buttonList[line * 4 + row].Text = "";
                                buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                tmp = true;
                            }
                        }
                    }
                }
            }
            foreach (var button in buttonList)
            {
                button.Text = button.Text.Replace("-", "");
            }
            return tmp;
        }

        private bool ToLeft()
        {
            bool tmp = false;
            int number = 0;
            for (int k = 1; k < 4; k++)
            {
                for (int line = 3; line >= 0; line--)
                {
                    for (int row = 3; row > 0; row--)
                    {
                        if (!(buttonList[line * 4 + row].Text.Length == 0))
                        {
                            if (!(buttonList[line * 4 + row - 1].Text.Length == 0))
                            {
                                if (buttonList[line * 4 + row].Text.Equals(buttonList[line * 4 + row - 1].Text))
                                {
                                    number = Math.Abs(Convert.ToInt32(buttonList[line * 4 + row].Text) * 2);
                                    Count += number/2;
                                    count.Text = Count.ToString();
                                    buttonList[line * 4 + row - 1].Font = new Font("Times New Roman", 15, FontStyle.Bold);
                                    buttonList[line * 4 + row - 1].ForeColor = Color.Black;
                                    buttonList[line * 4 + row - 1].Text = $"{number * -1}";
                                    buttonList[line * 4 + row - 1].BackColor = Color.FromArgb(100, 150, number / 10 < 256 ? number / 10 : 255, number < 256 ? number : 255);
                                    buttonList[line * 4 + row].Text = "";
                                    buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                    buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                    tmp = true;
                                }
                            }
                            else
                            {
                                buttonList[line * 4 + row - 1].Text = buttonList[line * 4 + row].Text;
                                buttonList[line * 4 + row - 1].Font = buttonList[line * 4 + row].Font;
                                buttonList[line * 4 + row - 1].ForeColor = buttonList[line * 4 + row].ForeColor;
                                buttonList[line * 4 + row - 1].BackColor = buttonList[line * 4 + row].BackColor;
                                buttonList[line * 4 + row].Text = "";
                                buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                tmp = true;
                            }
                        }
                    }
                }
            }
            foreach (var button in buttonList)
            {
                button.Text = button.Text.Replace("-", "");
            }
            return tmp;
        }

        private bool ToUp()
        {
            bool tmp = false;
            int number = 0;
            for (int k = 1; k < 4; k++)
            {
                for (int row = 3; row >= 0; row--)
                {
                    for (int line = 3; line > 0; line--)
                    {
                        if (!(buttonList[line * 4 + row].Text.Length == 0))
                        {
                            if (!(buttonList[line * 4 + row - 4].Text.Length == 0))
                            {
                                if (buttonList[line * 4 + row].Text.Equals(buttonList[line * 4 + row - 4].Text))
                                {
                                    number = Math.Abs(Convert.ToInt32(buttonList[line * 4 + row].Text) * 2);
                                    Count += number/2;
                                    count.Text = Count.ToString();
                                    buttonList[line * 4 + row - 4].Font = new Font("Times New Roman", 15, FontStyle.Bold);
                                    buttonList[line * 4 + row - 4].ForeColor = Color.Black;
                                    buttonList[line * 4 + row - 4].BackColor = Color.FromArgb(100, 150, number / 10 < 256 ? number / 10 : 255, number < 256 ? number : 255);
                                    buttonList[line * 4 + row - 4].Text = $"{number * -1}";
                                    buttonList[line * 4 + row].Text = "";
                                    buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                    buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                    tmp = true;
                                }
                            }
                            else
                            {
                                buttonList[line * 4 + row - 4].Text = buttonList[line * 4 + row].Text;
                                buttonList[line * 4 + row - 4].Font = buttonList[line * 4 + row].Font;
                                buttonList[line * 4 + row - 4].ForeColor = buttonList[line * 4 + row].ForeColor;
                                buttonList[line * 4 + row - 4].BackColor = buttonList[line * 4 + row].BackColor;
                                buttonList[line * 4 + row].Text = "";
                                buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                tmp = true;
                            }
                        }
                    }
                }
            }
            foreach (var button in buttonList)
            {
                button.Text = button.Text.Replace("-", "");
            }
            return tmp;
        }

        private bool ToDown()
        {
            bool tmp = false;
            int number = 0;
            for (int k = 1; k < 4; k++)
            {
                for (int row = 0; row <= 3; row++)
                {
                    for (int line = 0; line < 3; line++)
                    {
                        if (!(buttonList[line * 4 + row].Text.Length == 0))
                        {
                            if (!(buttonList[line * 4 + row + 4].Text.Length == 0))
                            {
                                if (buttonList[line * 4 + row].Text.Equals(buttonList[line * 4 + row + 4].Text))
                                {
                                    number = Math.Abs(Convert.ToInt32(buttonList[line * 4 + row].Text) * 2);
                                    Count += number/2;
                                    count.Text = Count.ToString();
                                    buttonList[line * 4 + row + 4].Font = new Font("Times New Roman", 15, FontStyle.Bold);
                                    buttonList[line * 4 + row + 4].ForeColor = Color.Black;
                                    buttonList[line * 4 + row + 4].BackColor = Color.FromArgb(100, 150, number / 10 < 256 ? number / 10 : 255, number < 256 ? number : 255);
                                    buttonList[line * 4 + row + 4].Text = $"{number * -1}";
                                    buttonList[line * 4 + row].Text = "";
                                    buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                    buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                    tmp = true;
                                }
                            }
                            else
                            {
                                buttonList[line * 4 + row + 4].Text = buttonList[line * 4 + row].Text;
                                buttonList[line * 4 + row + 4].Font = buttonList[line * 4 + row].Font;
                                buttonList[line * 4 + row + 4].ForeColor = buttonList[line * 4 + row].ForeColor;
                                buttonList[line * 4 + row + 4].BackColor = buttonList[line * 4 + row].BackColor;
                                buttonList[line * 4 + row].Text = "";
                                buttonList[line * 4 + row].ForeColor = Color.Aquamarine;
                                buttonList[line * 4 + row].BackColor = Color.Aquamarine;
                                tmp = true;
                            }
                        }
                    }
                }
            }
            foreach (var button in buttonList)
            {
                button.Text = button.Text.Replace("-", "");
            }
            return tmp;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initial settings
            #region
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "2048 game";
            Size = new Size(530, 560);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(400, 200);
            #endregion


            //Creation of the buttons field
            #region
            int size = 100;     //Size of the playfield button
            int line = 1;
            int position = 1;
            bool exit = true;
            do
            {
                btn = new Button();
                btn.Text = "";
                btn.ForeColor = Color.Aquamarine;
                btn.BackColor = Color.Aquamarine;
                btn.KeyDown += Form1_KeyDown;
                btn.Size = new Size(size, size);
                btn.Enabled = false;
                btn.Location = new Point(position * size - 40, line * size - 30);
                buttonList.Add(btn);
                this.Controls.Add(btn);
                position++;
                if (position > 4)
                {
                    position = 1;
                    line++;
                }
                if (line > 4)
                    exit = false;
            } while (exit);

            //Creation the direction and count buttons
            #region
            count = new Button();
            count.Text = "0";
            count.ForeColor = Color.Black;
            count.BackColor = Color.AntiqueWhite;
            count.Size = new Size(100, 30);
            count.Location = new Point(210, 5);
            count.Enabled = false;
            count.Font = new Font("Times New Roman", 15, FontStyle.Bold);
            this.Controls.Add(count);

            //right = new Button();
            //right.Text = "R";
            //right.BackColor = Color.LightGreen;
            //right.Size = new Size(30, 400);
            //right.Location = new Point(460, 70);
            //this.Controls.Add(right);
            //right.Click += Right_Click;

            //left = new Button();
            //left.Text = "L";
            //left.BackColor = Color.LightGreen;
            //left.Size = new Size(30, 400);
            //left.Location = new Point(30, 70);
            //this.Controls.Add(left);
            //left.Click += Left_Click;

            //up = new Button();
            //up.Text = "Up";
            //up.BackColor = Color.LightGreen;
            //up.Size = new Size(400, 30);
            //up.Location = new Point(60, 40);
            //this.Controls.Add(up);
            //up.Click += Up_Click;

            //down = new Button();
            //down.Text = "down";
            //down.BackColor = Color.LightGreen;
            //down.Size = new Size(400, 30);
            //down.Location = new Point(60, 470);
            //this.Controls.Add(down);
            //down.Click += Down_Click;
            #endregion

            //Creation of the first two numbers
            #region
            SetToCell();
            SetToCell();
            #endregion

            #endregion
        }

        //Action if direction buttons click
        #region
        private void Down_Click(object sender, EventArgs e)
        {
            if (ToDown())
                SetToCell();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (ToUp())
                SetToCell();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            if (ToLeft())
                SetToCell();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (ToRight())
                SetToCell();
        }
        #endregion



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ToUp();
                SetToCell();
            }
            else if (e.KeyCode == Keys.Down)
            {
                ToDown();
                SetToCell();
            }
            else if (e.KeyCode == Keys.Left)
            {
                ToLeft();
                SetToCell();
            }
            else if (e.KeyCode == Keys.Right)
            {
                ToRight();
                SetToCell();
            }
        }
        List<Button> buttonList = new List<Button>();
        Button btn; //Buttons of the cells
        Button right;
        Button left;
        Button up;
        Button down;
        Button count;


    }
}
