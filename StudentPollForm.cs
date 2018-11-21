// Ex. 17.8: StudentPoll.cs
// Allow student to take a survey
// and view the results in a TextBox
using System;
using System.Windows.Forms;
using System.IO;

namespace StudentPoll
{
   public partial class StudentPollForm : Form
   {
      StreamWriter writer;
      StreamReader input;
      int number;
 

      // parameterless constructor
      public StudentPollForm()
      {
         InitializeComponent();

            //TODO ***************************
            //Create the StreamWriter object
            writer = new StreamWriter("numbers.txt");

      } // end constructor

      private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
                //TODO ************************
                //Add exception handling
                try
                {
                    if (String.IsNullOrEmpty(inputTextBox.Text))
                    {
                        MessageBox.Show("Please fill in the TextBox.");
                    } // end if
                    else
                    {

                        number = Convert.ToInt32(inputTextBox.Text);

                        //TODO ******************************
                        //  Validate that the number is 1 - 10. When valid, use method Write to put the value into the file
                        if (number > 0 && number < 11)
                        {
                            writer.Write(number + ",");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please only input numbers");
                }
               
            

            inputTextBox.Clear();
         } // end if
      }

        private void doneButton_Click_1(object sender, EventArgs e)
        {
            writer.Close();
            //TODO *********************************
            //Change properties such that the display button can be used and this button can't be used. The textbox should be read-only
            doneButton.Enabled = false;
            displayButton.Enabled = true;
        }

        private void displayButton_Click(object sender, EventArgs e)
      {
         input = new StreamReader("numbers.txt");

         string inputString = input.ReadToEnd();
         string[] stringArray;
         int[] frequency = new int[11];

            //TODO ******************
            //Split the read data into the array. Populate another integer array with the values from the string array converted
            //   to integers. Update the frequency array to include a count for each of the responses. Refer to Figure 8.8
            stringArray = inputString.Split(',');
            for (int i = 0; i < stringArray.Length; i++)
            
            {               
                
                for(int n = 0; n < frequency.Length; n++)
                {

                    if (stringArray[i] == "")
                    {
                        break;
                    }
                    else if(n + 1 == System.Convert.ToInt32(stringArray[i]))
                    {
                        frequency[n]++;
                        break;
                    }
                }
            }
        

         displayTextBox.Clear();
         displayTextBox.AppendText("Rating\tFrequency\n");

         //TODO *******************
         //Write out the ratings and frequencies
         for(int x = 0; x < 10; x++)
            {
                displayTextBox.AppendText((x + 1) + "\t" + frequency[x] + "\n");
            }
       
      } // end method displayButton_Click


    } // end class StudentPollForm
} // end namespace StudentPoll

