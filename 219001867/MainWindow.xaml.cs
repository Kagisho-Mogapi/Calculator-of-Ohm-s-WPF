using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _219001867
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate int OhmsLawDelegate(int val1, int val2);

        public MainWindow()
        {
            /*
             * Name              :
             * Purpose           :
             * Resuse            :
             * Method Parameters :
             * Output            :
             * 
            */
            InitializeComponent();


            calcTypes.Items.Add("Current");
            calcTypes.Items.Add("Resistance");
            calcTypes.Items.Add("Voltage");
            resultsBlock.Text = "Result";

            calcTypes.SelectedIndex = 0;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Name              :
             * Purpose           :
             * Resuse            :
             * Method Parameters :
             * Output            :
             * 
            */

            calcTypes.SelectedIndex = 0;
            value1.Text = "";
            value2.Text = "";
            results.Text = "";
            resultsBlock.Text = "Result";
        }

        private void CalcTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * Name              :
             * Purpose           :
             * Resuse            :
             * Method Parameters :
             * Output            :
             * 
            */

            switch (calcTypes.SelectedIndex)
            {
                case 0:
                    value1Block.Text = "Voltage";
                    value2Block.Text = "Resistance";
                    break;

                case 1:
                    value1Block.Text = "Voltage";
                    value2Block.Text = "Current";
                    break;

                case 2:
                    value1Block.Text = "Current";
                    value2Block.Text = "Resistance";
                    break;
            }

        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Name              :
             * Purpose           :
             * Resuse            :
             * Method Parameters :
             * Output            :
             * 
            */

            int num1, num2;
            num1 = Convert.ToInt32(value1.Text);
            num2 = Convert.ToInt32(value2.Text);
            OhmsLawDelegate ohmsLawDel = null;

            switch (calcTypes.SelectedIndex)
            {
                case 0:
                    resultsBlock.Text = "The calculated Current is";
                    ohmsLawDel = CalcCurrent;
                    break;

                case 1:
                    ohmsLawDel = CalcResistance;
                    resultsBlock.Text = "The calculated resistance is";
                    break;

                case 2:
                    resultsBlock.Text = "The calculated Voltage is";
                    ohmsLawDel = CalcVoltage;
                    break;
            }

            results.Text = $"{ohmsLawDel(num1, num2)}";
            
        }

        public int CalcVoltage(int current, int resistance)
        {
            //
            //Name		        : int CalcVoltage(int current, int resistance)
            //Purpose			: Calculate the Voltage using Ohm's Law 
            //Re-use			: None
            //Method Parameters	: - int current
            //              	    - current value in amps
            //                    - int resistance
            //                      - resistance value in ohms
            //Output Type       : int
            //                    - the calculated Voltage value
            //
            return current * resistance;

        } // end method

        public int CalcResistance(int voltage, int current)
        {
            //
            //Name		        : int CalcResistance(int voltage, int current)
            //Purpose			: Calculate the Resistance using Ohm's Law 
            //Re-use			: None
            //Method Parameters	: - int voltage
            //              	    - voltage value in volts
            //                    - int current
            //                      - current value in amps
            //Output Type       : int
            //                    - the calculated Resistance value
            //
            return voltage / current;

        } // end method

        public int CalcCurrent(int voltage, int resistance)
        {
            //
            //Name		        : int CalcCurrent(int voltage, int resistance)
            //Purpose			: Calculate the Current using Ohm's Law 
            //Re-use			: None
            //Method Parameters	: - int voltage
            //              	    - voltage value in volts
            //                    - int resistance
            //                      - resistance value in ohms
            //Output Type       : int
            //                    - the calculated Current value
            //
            return voltage / resistance;

        } // end method
        
    }
}
