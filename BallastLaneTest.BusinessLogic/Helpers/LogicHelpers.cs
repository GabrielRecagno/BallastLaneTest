

namespace BallastLaneTest.BusinessLogic.Helpers
{
    public static class LogicHelpers
    {
        public static bool IsValidIsbn(string isbn)
        {
            // Check that the ISBN is either 10 or 13 digits
            if (isbn.Length != 10 && isbn.Length != 13)
            {
                return false;
            }

            // Check that the ISBN contains only digits and hyphens
            if (!isbn.All(c => char.IsDigit(c) || c == '-'))
            {
                return false;
            }

            // Check the ISBN-10 or ISBN-13 checksum, as appropriate
            if (isbn.Length == 10 && !IsValidIsbn10(isbn))
            {
                return false;
            }
            else if (isbn.Length == 13 && !IsValidIsbn13(isbn))
            {
                return false;
            }

            return true;
        }

        private static bool IsValidIsbn10(string isbn)
        {
            // Remove hyphens from the ISBN
            isbn = isbn.Replace("-", "");

            // Calculate the ISBN-10 checksum
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (10 - i) * (isbn[i] - '0');
            }
            int checksum = (11 - (sum % 11)) % 11;

            // Check that the checksum matches the final digit of the ISBN
            return (checksum == (isbn[9] - '0') || (checksum == 10 && isbn[9] == 'X'));
        }

        private static bool IsValidIsbn13(string isbn)
        {
            // Remove hyphens from the ISBN
            isbn = isbn.Replace("-", "");

            // Calculate the ISBN-13 checksum
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += (i % 2 == 0) ? (isbn[i] - '0') : 3 * (isbn[i] - '0');
            }
            int checksum = (10 - (sum % 10)) % 10;

            // Check that the checksum matches the final digit of the ISBN
            return (checksum == (isbn[12] - '0'));
        }     

    }
}
