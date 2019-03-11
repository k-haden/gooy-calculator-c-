//////////////////////////////HEADER//////////////////////////////////////////
//Kelli Haden
//TINFO 200
//Calculator
///////////////////////////CHANGE HISTORY/////////////////////////////////////
//Date          Developer   Description
//01/22/2019    khaden2     Created GUI. Used table for buttons
//01/25/2019    khaden2     Created event methods
//02/02/2019    khaden2     Implemented back and decimal button functions

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string operation = string.Empty;
        double memoryLoc = 0.0;
        bool operationStarted = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            operationStarted = false;
        }

        private void numberBtn_Click(object sender, EventArgs e)
        {
            if (operationStarted == false)
            {
                display.Text = "0";
            }
            if(display.Text == "0")
            {
                display.Clear();
            }
            //Button tmpButton = (Button)sender;
            //string tmpValue = tmpButton.Text;
            //display.Text += tmpValue;

            display.Text += ((Button)sender).Text;
            operationStarted = true;
        }
        private void posNegBtn_Click(object sender, EventArgs e)
        {
            double temp = double.Parse(display.Text);
            display.Text = "" + -temp;
        }
        private void operatorBtn_Click(object sender, EventArgs e)
        {
            // save the operation requested (+,-,*,/)
            Button btn = (Button)sender;
            operation = btn.Text;

            // save the first operand (from display)
            memoryLoc = double.Parse(display.Text);
            operationStarted = true;
            display.Clear();
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    display.Text = (memoryLoc + double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (memoryLoc - double.Parse(display.Text)).ToString();
                    break;
                case "*":
                    display.Text = (memoryLoc * double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    display.Text = (memoryLoc / double.Parse(display.Text)).ToString();
                    break;
                default:
                    Console.WriteLine("Error: Should be unreachable code.");
                    break;
            }

            // signal that operation is complete, flag is unset
            operationStarted = false;
            operation = string.Empty;
        }
        //removes last character from display
        private void backBtn_Click(object sender, EventArgs e)
        {
            display.Text = display.Text.Remove(display.Text.Length - 1);
        }
        //check for decimal in display
        private void decimalPtBtn_Click(object sender, EventArgs e)
        {
            if (display.Text.Contains(".") == false)
            {
                display.Text += ".";
            }
        }
    }
}
