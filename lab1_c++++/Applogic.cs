using System;

public class BLogic
{
    double _number;
    double _summary;
    string _operation;

    public double SetupAndStartBLogic(ref double num, ref double sum, ref string operation)
    {
        double result = 0.0;
        switch (operation)
        {
            case "+":
                result = num + sum;
                break;
            case "-":
                result = sum - num;
                break;
            case "/":
                //тут надо подумать, как вывести ошибку
                if (num != 0)
                    result = sum / num;
                break;
            case "*":
                result = num * sum;
                break;
        }
    }

}
