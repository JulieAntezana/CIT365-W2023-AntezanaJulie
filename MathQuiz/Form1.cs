using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        // These integer variables store the numbers 
        // for the addition problem. 
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int minuend;
        int subtrahend;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // These integer variables store the numbers 
        // for the division problem. 
        int dividend;
        int divisor;

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problem 
        /// values and starting the timer. 
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Set timeLabel backcolor to transparent
            timeLabel.BackColor = Color.Transparent;
            timeLabel.ForeColor = Color.Black;
            sum.BackColor = Color.White;
            sum.ForeColor = Color.Black;
            difference.BackColor = Color.White;
            difference.ForeColor = Color.Black;
            product.BackColor = Color.White;
            product.ForeColor = Color.Black;
            quotient.BackColor = Color.White;
            quotient.ForeColor = Color.Black;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
            startButton.BackColor = Color.Gray;
        }

        /// <summary>
        /// Check the answers to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void Answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Sum_ValueChanged(object sender, EventArgs e)
        {
            if ((addend1 + addend2 == sum.Value) && timeLeft > 0)
            {
                sum.BackColor = Color.Green;
                sum.ForeColor = Color.White;
                SystemSounds.Question.Play();
            }
        }
        private void Difference_ValueChanged(object sender, EventArgs e)
        {
            if ((minuend - subtrahend == difference.Value) && timeLeft > 0)
            {
                difference.BackColor = Color.Green;
                difference.ForeColor = Color.White;
                SystemSounds.Question.Play();
            }
        }

        private void Product_ValueChanged(object sender, EventArgs e)
        {
            if ((multiplicand * multiplier == product.Value) && timeLeft > 0)
            {
                product.BackColor = Color.Green;
                product.ForeColor = Color.White;
                SystemSounds.Question.Play();
            }
        }

        private void Quotient_ValueChanged(object sender, EventArgs e)
        {
            if ((dividend / divisor == quotient.Value) && timeLeft > 0)
            {
                quotient.BackColor = Color.Green;
                quotient.ForeColor = Color.White;
                SystemSounds.Question.Play();
            }
        }
        private void Form1_Load(object sender, CancelEventArgs e)
        {
            dateShow.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            dateShow.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                SystemSounds.Asterisk.Play();
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.BackColor = Color.Blue;
                startButton.ForeColor = Color.White;
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() returns false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft < 5)
                {
                    timeLabel.BackColor = Color.IndianRed;
                    timeLabel.ForeColor = Color.White;
                }
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                SystemSounds.Beep.Play();
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                startButton.BackColor = Color.Blue;
                startButton.ForeColor = Color.White;
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                //SystemSounds.Beep.Play();
            }
        }


    }
}

