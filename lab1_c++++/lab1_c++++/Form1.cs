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
        double resultValue = 0;
        double memorySave = 0;
        double onDisplay = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        private BLogic _bl = new BLogic();

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
            if (resultValue != 0)
            {
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
        private void clear_btn_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            memorySave = 0;
            onDisplay = 0;
            operationPerformed = "";
            isOperationPerformed = false;
            equal_btn.Enabled = true;
        }

        private void equal_btn_Click(object sender, EventArgs e)
        {
            onDisplay = Double.Parse(textBox_Result.Text);
            resultValue = setupBLogicAndStart();
            textBox_Result.Text = resultValue.ToString();
            labelCurrentOperation.Text = "";
            equal_btn.Enabled = false;
            //MessageBox.Show($"Операция выполнена успешно, для повторных вычислений перезапустите калькулятор, нажав С", "Информация");

        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            operationPerformed = "sqrt";
            onDisplay = Convert.ToDouble(textBox_Result.Text);
            //тут ошибку если что надо будеит вывести
            resultValue = setupBLogicAndStart();
            textBox_Result.Text = resultValue.ToString();

            //resultValue = Convert.ToDouble(textBox_Result.Text);
            //if (resultValue < 0)
            //    MessageBox.Show("Корень из отрицательного числа запрещен!", "Информация");
            //else
            //    textBox_Result.Text = Convert.ToString(Math.Sqrt(resultValue));
        }

        private void button_ms_Click(object sender, EventArgs e)
        {
            //Как оно работает
            if (textBox_Result.Text != "")
                memorySave = Double.Parse(textBox_Result.Text);
        }

        private void button_mc_Click(object sender, EventArgs e)
        {
            //как оно работает
            if (memorySave != 0)
                textBox_Result.Text = memorySave.ToString();
        }

        private void button_plus_minus_Click(object sender, EventArgs e)
        {
            string potentionalDot = Convert.ToString(textBox_Result.Text.ElementAt(textBox_Result.Text.Length - 1));
            if (textBox_Result.Text == "0")
                textBox_Result.Text = "-0";
            else if (textBox_Result.Text == "0,")
                textBox_Result.Text = "-0,";
            else if (potentionalDot == ",")
                textBox_Result.Text = (Double.Parse(textBox_Result.Text) * -1).ToString() + ",";
            else
                textBox_Result.Text = (Double.Parse(textBox_Result.Text) * -1).ToString();
        }

        private double setupBLogicAndStart()
        {
            _bl.Number = onDisplay;
            _bl.Summary = resultValue;
            _bl.Operation = operationPerformed;

            return _bl.SetupAndStartBLogic();
        }
    }
}