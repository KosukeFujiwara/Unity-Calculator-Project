using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Text Formula;
    public Text Answer;
    public Button[] bNumber;
    public Button bDivide;
    public Button bMultiply;
    public Button bAdd;
    public Button bSubtract;
    public Button bEqual;
    public Button bClear;
    public Button bClearEntry;
    public Button bParcent;
    public Button bSquared;
    public Button bRoot;
    public Button bInvert;
    public Button bReciprocal;       

    // Start is called before the first frame update
    void Start()
    {
        Formula.text =  "";
        Answer.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputNumber(Text number)
    { 
        Formula.text += number.text;
    }

    public void InputDivide(Text divideButton)
    {
        if (Formula.text == "" || Formula.text.Contains("÷"))
        {
            return;
        }
        Formula.text += divideButton.text;
    }

    public void InputMultiply(Text multiplyButton)
    {
        if (Formula.text == "" || Formula.text.Contains("×"))
        {
            return;
        }
        Formula.text += multiplyButton.text;
    }

    public void InputAdd(Text addButton)
    {
        if (Formula.text == "" || Formula.text.Contains("+"))
        {
            return;
        }
        Formula.text += addButton.text;
    }

    public void InputSubtract(Text subtractButton)
    {
        if (Formula.text == "" || Formula.text.Contains("-"))
        {
            return;
        }
        Formula.text += subtractButton.text;
    }

    public void InputEqual(Text equal)
    {
        /*if (!Formula.text.Contains("÷"))
        {
            return;
        }*/
        if (Formula.text.Contains("÷"))
        {
            string[] inputString = Formula.text.Split('÷');
            double leftNumber = double.Parse(inputString[0]);
            double rightNumber = double.Parse(inputString[1]);

            if (rightNumber.Equals(0)) {
                Answer.text = "error";
                return;
            }

            double quotient = leftNumber / rightNumber;
            double remainder = leftNumber % rightNumber;
            Answer.text = quotient.ToString() + "..." + remainder.ToString();
        }
        else if (Formula.text.Contains("×"))
        {
            string[] inputString = Formula.text.Split('×');
            double leftNumber = double.Parse(inputString[0]);
            double rightNumber = double.Parse(inputString[1]);
            double product = leftNumber * rightNumber;
            Answer.text = product.ToString();
        }

        else if (Formula.text.Contains("+"))
        {
            string[] inputString = Formula.text.Split('+');
            double leftNumber = double.Parse(inputString[0]);
            double rightNumber = double.Parse(inputString[1]);
            double ans = leftNumber + rightNumber;
            Answer.text = ans.ToString();
        }
        else if (Formula.text.Contains("-"))
        {
            string[] inputString = Formula.text.Split('-');
            double leftNumber = double.Parse(inputString[0]);
            double rightNumber = double.Parse(inputString[1]);
            double ans = leftNumber - rightNumber;
            Answer.text = ans.ToString();
        }

    }

    public void InputScuared(Text squared)
    {
        if (Formula.text.Contains("+") || Formula.text.Contains("-") ||
                Formula.text.Contains("×") || Formula.text.Contains("÷"))
        {
            Answer.text = "error";
        }
        else
        {
            double ans = double.Parse(Formula.text) * double.Parse(Formula.text);
            Answer.text = ans.ToString();
        }
    }

    public void InputReciprocal(Text reciprocal)
    {
        if (Formula.text.Contains("+") || Formula.text.Contains("-") ||
        Formula.text.Contains("×") || Formula.text.Contains("÷"))
        {
            Answer.text = "error";
        }
        else
        {
            double ans = 1 / double.Parse(Formula.text);
            Answer.text = ans.ToString();
        }
    }

    public void InputRoot(Text root)
    {
        if (Formula.text.Contains("+") || Formula.text.Contains("-") ||
        Formula.text.Contains("×") || Formula.text.Contains("÷"))
        {
            Answer.text = "error";
        }
        else
        {
            double ans = System.Math.Sqrt(double.Parse(Formula.text));
            Answer.text = ans.ToString();
        }
    }

    public void InputInvert(Text invert)
    {
        double ans = double.Parse(Formula.text) * (-1);
        Answer.text = ans.ToString();
    }

    public void InputPercent(Text percent)
    {

    }


    public void InputBack(Text back)
    {
        char[] inputChar = Formula.text.ToCharArray();
        int i = inputChar.GetLength(0) - 1;

        Formula.text = "";

        for (int j=0; j<i; j++)
        {
            Formula.text += inputChar[j].ToString();
        }
    }

    public void InputClear(Text clear)
    {
        Formula.text = "";
        Answer.text = "";
    }

    string[] inputString;
    char inputOperator;
    public void InputClearEntry(Text clearEntry)
    {
        if (Formula.text.Contains("+") || Formula.text.Contains("-") ||
        Formula.text.Contains("×") || Formula.text.Contains("÷"))
        {
            if (Formula.text.Contains("+"))
            {
                inputString = Formula.text.Split('+');
                inputOperator = '+';
            }
            else if (Formula.text.Contains("-"))
            {
                inputString = Formula.text.Split('-');
                inputOperator = '-';
            }
            else if (Formula.text.Contains("×"))
            {
                inputString = Formula.text.Split('×');
                inputOperator = '×';
            }
            else if (Formula.text.Contains("÷"))
            {
                inputString = Formula.text.Split('÷');
                inputOperator = '÷';
            }
            double leftNumber = double.Parse(inputString[0]);
            Formula.text = leftNumber.ToString() + inputOperator.ToString();
        }
        else
        {
            Formula.text = "";
            Answer.text = "";
        }
               
        /*
        char[] inputChar = Formula.text.ToCharArray();
        int i = inputChar.GetLength(0)-1;
        while (i > 0)
        {
            if(inputChar[i]==('+') || inputChar[i] == ('-') ||
                inputChar[i] == ('×') || inputChar[i] == ('÷'))
            {
                for(int j=0; j<=i; j++)
                {
                    Formula.text = inputChar[j].ToString();
                }
            }
            else
            {
                i--;
            }      
        }*/

    }
    
}
