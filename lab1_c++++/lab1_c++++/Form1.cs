using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        double memorySave = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (((textBox_Result.Text == "0") || (isOperationPerformed)) && (button.Text != ","))
                textBox_Result.Clear();

            isOperationPerformed = false;
 //           Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (!textBox_Result.Text.Contains(","))
                    textBox_Result.Text = textBox_Result.Text + button.Text;

            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;


        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string potentionalDot = Convert.ToString(textBox_Result.Text.ElementAt(textBox_Result.Text.Length - 1));
            if (potentionalDot == ",")
                MessageBox.Show($"Операция невозможна, если на конце числа стоит точка", "Информация");
            else
            {
                if (resultValue != 0)
                {
 //                   equal_btn.PerformClick();
                    operationPerformed = button.Text;
                    labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                    isOperationPerformed = true;
                }
                else
                {
                    operationPerformed = button.Text;
                    resultValue = Double.Parse(textBox_Result.Text);
                    labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                    isOperationPerformed = true;
                }
            }
        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            equal_btn.Enabled = true;
        }

        private void equal_btn_Click(object sender, EventArgs e)
        {
            double secondNum = Double.Parse(textBox_Result.Text);
            double savedNum = secondNum;
            switch (operationPerformed)
            {
                case "+":
                    textBox_Result.Text = ((resultValue + secondNum).ToString());
                    break;
                case "-":
                    textBox_Result.Text = ((resultValue - secondNum).ToString());
                    break;
                case "*":
                    textBox_Result.Text = ((resultValue * secondNum).ToString());
                    break;
                case "/":
                        if (secondNum == 0) 
                                MessageBox.Show($"Деление на ноль запрещено!", "Информация");
                        else
                            textBox_Result.Text = ((resultValue / secondNum).ToString());
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
            equal_btn.Enabled = false;
 //           MessageBox.Show($"Операция выполнена успешно, для повторных вычислений перезапустите калькулятор, нажав С", "Информация");

        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            string potentionalDot = Convert.ToString(textBox_Result.Text.ElementAt(textBox_Result.Text.Length - 1));
 //           if (potentionalDot == ",")
 //               MessageBox.Show($"Операция невозможна, если на конце числа стоит точка", "Информация");
            resultValue = Convert.ToDouble(textBox_Result.Text);
            if (resultValue < 0)
                MessageBox.Show("Корень из отрицательного числа запрещен!", "Информация");
            else
                textBox_Result.Text = Convert.ToString(Math.Sqrt(resultValue));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != "")
                memorySave = Double.Parse(textBox_Result.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (memorySave != 0)
                textBox_Result.Text = memorySave.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string potentionalDot = Convert.ToString(textBox_Result.Text.ElementAt(textBox_Result.Text.Length - 1));
            if (potentionalDot == ",")
                textBox_Result.Text = (Double.Parse(textBox_Result.Text) * -1).ToString() + ",";
            else
                textBox_Result.Text = (Double.Parse(textBox_Result.Text) * -1).ToString();
        }
    }
}