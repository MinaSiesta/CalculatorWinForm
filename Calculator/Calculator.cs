namespace Calculator
{
    public partial class Calculator : Form
    {
        string firstNumber = "0";
        string secondNumber = "0";
        double firstNum, secondNum;
        char function;
        double result = 0;
        string userInput = "";

        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function decides if the global variable userInput is empty, 
        /// in that case the text from calc display is assigned to firstNumber string variable
        /// so you can continue calculating with your previous result (with the displayed text). 
        /// Else userInput is assigned to firstNumber.
        /// function +,-,*,/ is asigned depending on argument
        /// userInput and result is returned to default value
        /// </summary>
        /// <param name="a"></param>
        private void functonButtons(char a)
        {
            firstNumber = userInput != "" ? userInput : calculatorDisplay.Text;
            function = a;
            userInput = "";
            result = 0;
        }

        /// <summary>
        /// If userInput and the result is longer than 12 characters, call func errorHandeling
        /// Else empty the calc display text. If result is not zero add result transformed to string,
        /// and also add the argument value to userInput and set result to zero.
        /// If the result is zero, add the argument value to userInput.
        /// Display the userInput.
        /// </summary>
        /// <param name="a"></param>
        private void numButton(string a)
        {
            if (userInput.Length < 12 && result.ToString().Length < 12)
            {
                calculatorDisplay.Text = "";
                userInput += result != 0 ? result.ToString() + a : a;
                result = 0;
                calculatorDisplay.Text += userInput;
            }
            else
            {
                errorHandeling();
            }
        }

        /// <summary>
        /// Sets variables to default value
        /// </summary>
        private void autoClear()
        {
            firstNumber = "";
            secondNumber = "";
            result = 0;
            userInput = "";
            calculatorDisplay.Text = "0";
        }

        /// <summary>
        /// Display Error
        /// Wait 3sec then sets variables to default value
        /// </summary>
        private void errorHandeling()
        {
            calculatorDisplay.Text = "Error";
            Task.Delay(3000).Wait();
            autoClear();
        }

        /// <summary>
        /// When equal button is pressed, display the result if there is any (=display stays the same).
        /// If the first number is not empty, assign userInput to secondNumber then parse both of them
        /// Display the calculated result depending on variable function. If there is a zero division, call the errorHandeling func
        /// Empty userInput and function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void equalButton_Click(object sender, EventArgs e)
        {
            if (result != 0) calculatorDisplay.Text = result.ToString();
            if (firstNumber != "")
            {
                secondNumber = userInput != "" ? userInput : "0";
                firstNum = double.Parse(firstNumber);
                secondNum = double.Parse(secondNumber);

                switch (function)
                {
                    case '+':
                        result = firstNum + secondNum;
                        break;

                    case '-':
                        result = firstNum - secondNum;
                        break;

                    case '*':
                        result = firstNum * secondNum;
                        break;

                    case '/':
                        if (secondNum == 0) errorHandeling(); else result = firstNum / secondNum;
                        break;
                }

                calculatorDisplay.Text = result.ToString();
                userInput = "";
                function = ' ';
            }

        }

        private void autoClearButton_Click(object sender, EventArgs e)
        {
            autoClear();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            functonButtons('+');
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            functonButtons('-');
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            functonButtons('*');
        }

        private void divisionButton_Click(object sender, EventArgs e)
        {
            functonButtons('/');
        }

        private void numZeroButton_Click(object sender, EventArgs e)
        {
            numButton("0");
        }

        private void numOneButton_Click(object sender, EventArgs e)
        {
            numButton("1");
        }

        private void numTwoButton_Click(object sender, EventArgs e)
        {
            numButton("2");
        }

        private void numThreeButton_Click(object sender, EventArgs e)
        {
            numButton("3");
        }

        private void numFourButton_Click(object sender, EventArgs e)
        {
            numButton("4");
        }

        private void numFiveButton_Click(object sender, EventArgs e)
        {
            numButton("5");
        }

        private void numSixButton_Click(object sender, EventArgs e)
        {
            numButton("6");
        }

        private void numSevenButton_Click(object sender, EventArgs e)
        {
            numButton("7");
        }

        private void numEightButton_Click(object sender, EventArgs e)
        {
            numButton("8");
        }

        private void numNineButton_Click(object sender, EventArgs e)
        {
            numButton("9");
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            numButton(",");
        }
    }
}