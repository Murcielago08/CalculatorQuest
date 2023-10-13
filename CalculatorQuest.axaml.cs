using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorQuest : Window
{
    public CalculatorQuest()
    {
        InitializeComponent();
    }
    public void DisplayCalc(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = ( sender as Button )!;
        if (OperationInput.Content == "Your calculation here...")
        {
            OperationInput.Content = "";
        }
        if (OperationResult.Content == "Your result here...")
        {
            OperationResult.Content = "";
        }
        OperationInput.Content += button.Content.ToString();
    }
    
    public void SendCalc(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Calc calc = new Calc();
        if (OperationInput.Content == "")
        {
            OperationInput.Content = "Insert a calcul";
        }
        else
        {
            OperationResult.Content = calc.Operator(OperationInput.Content.ToString());
            OperationInput.Content = "";
        }
        
    }

    public void SupCalc(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OperationInput.Content = "";
    }
    public void Supall(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OperationInput.Content = "";
        OperationResult.Content = "";
    }

    public void SupOneCalc(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string cal_string = OperationInput.Content.ToString();
        if (cal_string.Length != 0)
        {
            OperationInput.Content = cal_string.Remove(cal_string.Length -1, 1);
        }
    }

    public void ChangeSignInput(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Calc calc = new Calc();
        OperationInput.Content = calc.ChangeSign(OperationInput.Content.ToString());
    }

    public void CalcSquare(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Calc calc = new Calc();
        OperationResult.Content = calc.Square(OperationInput.Content.ToString());
        OperationInput.Content = "";
    }

    public void CalcSqrt(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Calc calc = new Calc();
        OperationResult.Content = calc.CalculateSquareRoot(OperationInput.Content.ToString());
        OperationInput.Content = "";
    }
    
    public void CalcInverse(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Calc calc = new Calc();
        OperationResult.Content = calc.CalculInverse(OperationInput.Content.ToString());
        OperationInput.Content = "";
    }
}