namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = "";
        private double currentResult = 0;
        private string currentOperation = "";
        private bool isOperationPressed = false;

        public MainPage()
        {
            InitializeComponent();
        }

        // När en knapp trycks (alla knappar utom "=" och "Clear")
        private void ONButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string buttonText = button.Text;

            if (char.IsDigit(buttonText[0]))  // Om det är en siffra
            {
                if (isOperationPressed)
                {
                    currentInput = buttonText;
                    isOperationPressed = false;
                }
                else
                {
                    currentInput += buttonText;
                }
            }
            else if (buttonText == "+" || buttonText == "-" || buttonText == "X" || buttonText == "/")
            {
                // Om en operation trycks
                if (!isOperationPressed)
                {
                    currentResult = Double.Parse(currentInput);
                    
                    currentOperation = buttonText;
                    isOperationPressed = true;
                    Calculate();
                }
            }
            else if (buttonText == "Clear")
            {
                // Rensa all input och resultat
                currentInput = "0";
                currentResult = 0;
                currentOperation = "";
                isOperationPressed = false;
                ResultDisplay.Text = currentInput;
            }

            ResultDisplay.Text = currentInput;
        }

        // När "=" knappen trycks
        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            Calculate();
        }
        private void Calculate()
        {
            double secondOperand = Double.Parse(currentInput);
            currentInput = "0";

            // Utför operation baserat på det som valts
            switch (currentOperation)
            {
                case "+":
                    currentResult += secondOperand;
                    break;
                case "-":
                    currentResult -= secondOperand;
                    break;
                case "X":
                    currentResult *= secondOperand;
                    break;
                case "/":
                    if (secondOperand != 0)
                    {
                        currentResult /= secondOperand;
                    }
                    else
                    {
                        ResultDisplay.Text = "Error";
                        return;
                    }
                    break;
            }

            ResultDisplay.Text = currentResult.ToString();
            currentOperation = "";
            isOperationPressed = false;
        }
    }
    
}



