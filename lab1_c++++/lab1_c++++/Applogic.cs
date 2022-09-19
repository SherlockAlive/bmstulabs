using System;

public class BLogic
{
    private double _number;
    private double _summary;
    private string _operation;
    private double _memory;

    public double Number
    {
        get => _number;
        set => _number = value;
    }

    public double Summary
    {
        get => _summary;
        set => _summary = value;
    }

    public string Operation
    {
        get => _operation;
        set => _operation = value;
    }

    public double Memory
    {
        get => _memory;
        set => _memory = value;
    }

    public double SetupAndStartBLogic()
    {
        double result = 0.0;
        switch (_operation)
        {
            case "+":
                result = _number + _summary;
                break;
            case "-":
                result = _summary - _number;
                break;
            case "/":
                //тут надо подумать, как вывести ошибку
                if (_number != 0.0)
                    result = _summary / _number;
                break;
            case "*":
                result = _number * _summary;
                break;
            case "sqrt":
                if (_number >= 0)
                    result = Math.Sqrt(_number);
                break;
        }
        return result;
    }

}
