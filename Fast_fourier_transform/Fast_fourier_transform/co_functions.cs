using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_fourier_transform
{
    public static class co_functions
    {
        /// <summary>
        /// Function to Check the valid of Numerical text from textbox.text
        /// </summary>
        /// <param name="tB_txt">Textbox.text value</param>
        /// <param name="Negative_check">Is negative number Not allowed (True) or allowed (False)</param>
        /// <param name="zero_check">Is zero Not allowed (True) or allowed (False)</param>
        /// <returns>Return the validity (True means its valid) </returns>
        /// <remarks></remarks>
        public static bool Test_a_textboxvalue_validity(string tB_txt, bool Negative_check, bool zero_check)
        {
            bool Am_I_valid = false;
            double argresult = 0;
            // 'This function returns false if the textbox doesn't contains number 
            if (double.TryParse(tB_txt, out argresult) == true)
            {
                Am_I_valid = true;
                // -- Additional modificaiton to avoid negative number
                if (Negative_check == true)
                {
                    if (Convert.ToDouble(tB_txt) < 0)
                        Am_I_valid = false;
                }
                if (zero_check == true)
                {
                    if (Convert.ToDouble(tB_txt) == 0)
                        Am_I_valid = false;
                }
            }
            return Am_I_valid;
        }


        /// <summary>
        /// Function to return float values (single data)
        /// </summary>
        /// <param name="v1">double values</param>
        /// <returns>Returns the float for double</returns>
        /// <remarks></remarks>
        public static float tosingle(double v1)
        {
            return (float)Math.Round(v1, 12);
        }
    }
}
