using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public static class BookComparer
    {
        public static bool IsEquals(this Book object_A, Book Object_B)
        {
            var isAuthorValid = object_A.author.Equals(Object_B.author);
            var isPriceValid = object_A.price.Equals(Object_B.price);
            var isCategoryValid = object_A.category.Equals(Object_B.category);
            var isNameValid = object_A.name.Equals(Object_B.name);
            var isIdValid = object_A.id.Equals(Object_B.id);

            if (isAuthorValid && isPriceValid && isCategoryValid && isNameValid && isIdValid)
            {
                return true;
            }
            else
            {
                return false;
            }

            //if (object_A.name.Equals(Object_B.name))
            //{
            //    if (object_A.author.Equals(Object_B.author))
            //    {
            //        if (object_A.price.Equals(Object_B.price))
            //        {
            //            if (object_A.category.Equals(Object_B.category))
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
        }
    }



}
