using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validate_Details
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LabelName.Visible = false;
            LabelAd.Visible = false;
            LabeZip.Visible = false;
            Labelphone.Visible = false;
            LabelCity.Visible = false;
            LabelEmail.Visible = false;
            if (TextBox2.Text == TextBox1.Text)
            {

                Error_Detect("* Should not be same as Family");
                return;
            }

            if (TextBox3.Text.Length < 3)
            {
                Error_DetectAd("* Enter at least 3 letters");
                return;
            }
            

            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBox4.Text, @"^\d{6}$"))
            {
                Error_DetectZi("* Zip Code must be 6 digits.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBox5.Text, @"^\d{2}-\d{10}$"))
            {
                Error_DetectPh("* Enter Valid P.No.");
                return;
            }
            if (TextBox6.Text.Length < 3)
            {
                Error_DetectCi("* Enter at least 3 letters");
                return;
            }
            if (!Email_Validation(TextBox7.Text))
            {
                Error_Detectemail("* Enter Valid Email Id.");
                return;
            }
        }
        protected bool Email_Validation(string Email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }
        private void Error_Detect(string errorMessage)
        {
            LabelName.CssClass = "Error";
            LabelName.Text = errorMessage;
            LabelName.Visible = true;
        }
        private void Error_Detectemail(string errorMessage)
        {
            LabelEmail.CssClass = "Error1";
            LabelEmail.Text = errorMessage;
            LabelEmail.Visible = true;
        }
        private void Error_DetectAd(string errorMessage)
        {
            LabelAd.CssClass = "Error1";
            LabelAd.Text = errorMessage;
            LabelAd.Visible = true;
        }
        private void Error_DetectCi(string errorMessage)
        {
            LabelCity.CssClass = "Error1";
            LabelCity.Text = errorMessage;
            LabelCity.Visible = true;
        }
        private void Error_DetectZi(string errorMessage)
        {
            LabeZip.CssClass = "Error1";
            LabeZip.Text = errorMessage;
            LabeZip.Visible = true;
        }
        private void Error_DetectPh(string errorMessage)
        {
            Labelphone.CssClass = "Error1";
            Labelphone.Text = errorMessage;
            Labelphone.Visible = true;
        }


    }
}