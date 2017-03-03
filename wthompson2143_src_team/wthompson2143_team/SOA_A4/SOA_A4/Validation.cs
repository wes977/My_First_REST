using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      ALL THE VALIDATION AND ALL THAT JAZZ YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA (Connor Johnson Sucks)
 */
namespace SOA_A4
{
    public class Validation
    {

        /*
 * Method  Name :       Name Validation 
 * Description :        Validating names and all that jazz 
 *                      
 */
        public string nameValidation(string words, string inputPlace)
        {
            string returner = "";
            if (words.Length > 50)
            {
                returner = inputPlace + " : is to long no more than 50 characters.";
            }
            if (!(Regex.IsMatch(words, @"[a-zA-Z]+")))
            {
                returner = inputPlace + " : Please make sure that there are only letters.";
            }

            return returner;
        }
        /*
* Method  Name :       Phone Validation 
* Description :        Validating Phones and all that jazz 
*                      
*/
        public string phoneValidation(string words)
        {
            string returner = "";
            if (words.Length > 12)
            {
                returner = "The phone number is to long no more than 12 characters.";
            }
            if (!(Regex.IsMatch(words, @"\b\d{3}[-.]+\d{3}[-.]+\d{4}\b")))
            {
                returner = "Please make sure your format matches XXX-XXX-XXXX for the phone number";
            }

            return returner;

        }
        /*
* Method  Name :       ID Validation 
* Description :        Validating ID and all that jazz 
*                      
*/
        public string IDValidation(string words)
        {
            string returner = "";

            if (!(Regex.IsMatch(words, @"(?:\d*\.)?\d+")))
            {
                returner = "only numbers can go in an ID input box ";
            }
            return returner;
        }
        /*
* Method  Name :       Price Validation 
* Description :        Validating Price and all that jazz 
*                      
*/
        public string priceValidation(string words)
        {
            string returner = "";

            if (!(Regex.IsMatch(words, @"(?:\d*\.)?\d+")))
            {
                returner = "only numbers can go in an price input box ";
            }
            return returner;
        }
        /*
* Method  Name :       Weight Validation 
* Description :        Validating Weight and all that jazz 
*                      
*/
        public string weightValidation(string words)
        {
            string returner = "";

            if (!(Regex.IsMatch(words, @"(?:\d*\.)?\d+")))
            {
                returner = "only numbers can go in an weight input box ";
            }
            return returner;
        }
        /*
* Method  Name :       Date Validation 
* Description :        Validating Date and all that jazz 
*                      
*/
        public string dateValidation(string words)
        {
            string returner = "";
            DateTime temp;
            if (!(Regex.IsMatch(words, @"\b[0-9]{1,2}[-]+[0-9]{1,2}[-]+\d{2}\b")))
            {
                returner = "please make sure the your format is correct for the data MM-DD-YY ";
            }
            if (!(DateTime.TryParse(words, out temp)))
            {
                returner = "please make sure the your format is correct for the data MM-DD-YY ";
            }
            return returner;
        }
        /*
* Method  Name :       Quantity Validation 
* Description :        Validating Quantity and all that jazz 
*                      
*/
        public string quantityValidation(string words)
        {
            string returner = "";
            int temp = 0;
            if (!(int.TryParse(words ,out  temp)))
            {
                returner = "The quantity was not just a number.";
            }
            return returner;
        }
    }
}