namespace BooksApi.Core.Shared
{
    public static class CheckField
    {
        public static bool IsNumber(int number)
        {
            return int.TryParse(number.ToString(), out number);
        }
    }
}