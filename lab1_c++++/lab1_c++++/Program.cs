using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
//    public double calculate(double resultValue, double secondNum, string operationPerformed, double result)
//    {
//        //       double secondNum = Double.Parse(textBox_Result.Text);
//        switch (operationPerformed)
//        {
//            case "+":
//                result = ((resultValue + secondNum));
//                break;
//            case "-":
//                result = ((resultValue - secondNum));
//                break;
//            case "*":
//                result = ((resultValue * secondNum));
//                break;
//            case "/":
//                if (secondNum == 0)
//                    MessageBox.Show($"Деление на ноль запрещено!", "Информация");
//                else
//                    result = ((resultValue / secondNum));
//                break;
//        }
//        return result;
//    }
}
