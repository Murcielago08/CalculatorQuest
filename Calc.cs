using System;

namespace CalculatorQuest
{
    public class Calc
    {
        public string signe = "";
        public string[] parts;
        public string result;
        public int ope = 0;
        public bool neg = false;
        public int vir = 0;
        public Calc()
        {
            
        }
        private char[] _signs = { '+', '-', 'x', '/', '%' };
        public string Operator(string operation)
        {
            if (operation.Substring(0, 1) == "-")
            {
                operation = operation.Substring(1);
                neg = true;
            }
            
            if (operation.Substring(0, 1) == "+" || operation.Substring(0, 1) == "x" ||
            operation.Substring(0, 1) == "/" || operation.Substring(0, 1) == "%" || operation.Substring(0, 1) == ",")
            {
                return "No sign when you start (- it's ok)";
            }

            if (operation.Length == 1)
            {
                return operation;
            }
            
            for (int i = 0; i < operation.Length - 1; i++)
            {
                for (int a = 0; a < _signs.Length; a++)
                {
                    if (operation[i] == _signs[a])
                    {
                        signe = _signs[a].ToString();
                        ope += 1;
                    }

                    if (operation[i] == ',')
                    {
                        vir += 1;
                    }

                    if ((operation[i] == ',') &&  (operation[i+1] == ',')) 
                    {
                        return  "Only one virgule for one number please";
                    }
                }
            }

            if (ope > 1)
            {
                return "Only one operation please";
            }
            
            if (ope == 0)
            {
                return "Only one operation please";
            }

            if (ope < vir)
            {
                return "One virgule for one number";
            }
            
            parts = operation.Split(signe);
            switch (signe)
            {
                case "+":
                    if (neg == true)
                    {
                        result = (float.Parse(parts[0])*(-1) + float.Parse(parts[1])).ToString();
                    }
                    else
                    {
                        result = (float.Parse(parts[0]) + float.Parse(parts[1])).ToString();
                    }
                    //Console.WriteLine(result);
                    break;
                case "-":
                    if (neg == true)
                    {
                        result = (float.Parse(parts[0])*(-1) - float.Parse(parts[1])).ToString();
                    }
                    else
                    {
                        result = (float.Parse(parts[0]) - float.Parse(parts[1])).ToString();
                    }
                    //Console.WriteLine(result);
                    break;
                case "x":
                    result = (float.Parse(parts[0]) * float.Parse(parts[1])).ToString();
                    break;
                case "/":
                    if (parts[0] == "0" || parts[1] == "0")
                    {
                        result = "Division by 0 is IMPOSSIBLE";
                    }
                    else
                    {
                        result = (float.Parse(parts[0]) / float.Parse(parts[1])).ToString();
                    }
                    break;
                case "%":
                    if (parts[0] == "0" || parts[1] == "0")
                    {
                        result = "Modulo by 0 is IMPOSSIBLE";
                    }
                    else
                    {
                        result = (float.Parse(parts[0]) % float.Parse(parts[1])).ToString();
                    }
                   
                    break;
            }
            //Console.WriteLine(result);
            return result;
        }
        public string ChangeSign(string Nombre)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return "No result to change sign.";
            }

            if (Nombre[0] == '-')
            {
                Nombre = Nombre.Substring(1);
            }
            else
            {
                Nombre = "-" + Nombre;
            }

            return Nombre;
        }

        public string Square(string Number)
        {
            if (string.IsNullOrEmpty(Number))
            {
                return "No number for ²";
            }
            
            if (double.TryParse(Number, out double nombre))
            {
                double Sqare = nombre * nombre;
                return Sqare.ToString();
            }
            
            return "Erreur : Number invalid.";
        }
        
        public string CalculateSquareRoot(string Number)
        {
            if (string.IsNullOrEmpty(Number))
            {
                return "No number for Sqrt";
            }
            if (double.TryParse(Number, out double number))
            {
                if (number >= 0)
                {
                    double squareRoot = Math.Sqrt(number);
                    return squareRoot.ToString();
                }
                else
                {
                    return "Erreur : Number must be positive or zero.";
                }
            }
            
            return "Erreur : Number invalid.";
        }

        public string CalculInverse(string Number)
        {
            if (string.IsNullOrEmpty(Number))
            {
                return "No number for Sqrt";
            }
            
            if (double.TryParse(Number, out double number))
            {
                if (number != 0)
                {
                    double inverse = 1.0 / number;
                    return inverse.ToString();
                }
                else
                {
                    return "Impossible to calculate the inverse of zero.";
                }
            }
            else
            {
                return "Invalid entry. Please enter a valid number.";
            }

        }
    }
}