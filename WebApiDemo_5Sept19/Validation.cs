using System.Collections.Generic;
using System.Linq;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public static class Validation
    {
        public static bool StringEmptyCheck(this string input)
        {
            if (input != null && input.Trim() != "")
                return true;
            else
                return false;
        }

        public static bool IntNegativeCheck(this int input)
        {
            if (input > 0)
                return true;
            else
                return false;
        }

        public static bool StringWithOnlyAlphabets(this string input)
        {
            if (input.Any(char.IsDigit))
                return false;
            return true;

        }

        public static List<string> BookObjectValidation(this Book input)
        {
            List<string> error_message = new List<string>();
            if (!input.name.StringEmptyCheck()) {
                error_message.Add("Name Entered Is Empty, Please Enter a name");
            }
            if (!input.id.IntNegativeCheck()){
                error_message.Add("Negative Id Is Entered, Please Enter Positive Id");
            }
            if (!input.price.IntNegativeCheck()){
                error_message.Add("Negative Price Is Entered, Please Enter Positive Price");
            }
            if (!input.author.StringEmptyCheck()) {
                error_message.Add("Author Name Entered Is Empty, Please Enter a Valid Author name");
            }
            if (!input.category.StringEmptyCheck()) {
                error_message.Add("Category Name Entered Is Empty, Please Enter a Valid Category name");
            }
            if (!input.author.StringWithOnlyAlphabets()) {
                error_message.Add("Author Name Entered has digits in it, Author Name cannot have digits");
            }

            return error_message;
        }

    }
}
