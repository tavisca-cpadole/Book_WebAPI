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

        public static bool BookObjectValidation(this Book input)
        {
            if (input.name.StringEmptyCheck()
                && input.id.IntNegativeCheck()
                && input.price.IntNegativeCheck()
                && input.author.StringEmptyCheck()
                && input.category.StringEmptyCheck()
                && input.author.StringWithOnlyAlphabets())
            {
                return true;
            }
            return false;
        }

    }
}
