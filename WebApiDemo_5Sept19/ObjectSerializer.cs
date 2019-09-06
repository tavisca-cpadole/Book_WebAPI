using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public static class BookComparer
    {
        public static bool IsEquals(this Book object_A, Book Object_B)
        {
            if (object_A.name.Equals(Object_B.name))
            {
                if (object_A.author.Equals(Object_B.author))
                {
                    if (object_A.price.Equals(Object_B.price))
                    {
                        if (object_A.category.Equals(Object_B.category))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }



}
