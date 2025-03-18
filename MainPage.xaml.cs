using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MathOperators;

public partial class MainPage : ContentPage
{
    private ObservableCollection<string> _expList;
    public MainPage()
    {
        InitializeComponent();
        
        _expList = new ObservableCollection<string>();
        _lstExpHistory.ItemsSource = _expList;
    }

    private double AddNumbers(double leftOperand, double rightOperand)
    {
        return leftOperand + rightOperand;
        
    }

    private double SubstractNumbers(double leftOperand, double rightOperand)
    {
        return leftOperand - rightOperand;
    }

    private double MultiplyNumbers(double leftOperand, double rightOperand)
    {
        return leftOperand * rightOperand;
    }

    private double DivideNumbers(double leftOperand, double rightOperand)
    {
        string divOp = _pckOperand.SelectedItem as string;
        if (divOp.Contains("Int", StringComparison.OrdinalIgnoreCase))
        {
            // Integer division
            return (int)leftOperand / (int)rightOperand;
        }
        else
        {
            // Real division
            return leftOperand / rightOperand;
        }
    }

    private double RemailderNumbers(double leftOperand, double rightOperand)
    {
        return leftOperand % rightOperand;
    }
    
    private double PerformArithmeticOperations(char operation, double leftOperand, double rightOperand)
    {
        switch (operation)
        {
            case '+':
                return AddNumbers(leftOperand, rightOperand);
            case '-':
                return SubstractNumbers(leftOperand, rightOperand);
            case '*':
                return MultiplyNumbers(leftOperand, rightOperand);
            case '/':
                return DivideNumbers(leftOperand, rightOperand);
            case '%':
                return RemailderNumbers(leftOperand, rightOperand);
            default:
                Debug.Assert(false, "Invalid operation");
                return 0;
        }
    }

    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        try
        {
            double leftOperand = double.Parse(_txtLeftOp.Text);
            double rightOperand = double.Parse(_txtRightOp.Text);
            char operation = ((string)_pckOperand.SelectedItem)[0];
            double result = PerformArithmeticOperations(operation, leftOperand, rightOperand);

            string expression = $"{leftOperand} {operation} {rightOperand} = {result.ToString()}";

            _expList.Add(expression);

            _txtMathExp.Text = expression;
        }
        catch (ArgumentNullException ex)
        {
            DisplayAlert("Error", "Please provide required arguments", "OK");
        }
        catch (FormatException ex)
        {
            DisplayAlert("Error", "Please provide valid numbers", "OK");
        }
        catch (DivideByZeroException ex)
        {
            DisplayAlert("Error", "Please provide valid numbers", "OK");
        }
        
    }
    
}