namespace task01;
public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }
        else
        {
            string word = "";
            input = input.ToLower();
            foreach (char ch in input)
            {
                if (!char.IsPunctuation(ch) && !char.IsWhiteSpace(ch))
                {
                    word += ch;
                }
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}