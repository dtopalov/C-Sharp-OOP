namespace _01.StrBuilderSubstr
{
    using System;
    using System.Text;

    public static class StringBuilderSubstring
    {
        public static StringBuilder Substring(this StringBuilder strBuilder, int index, int count)
        {
            string initialString = strBuilder.ToString();
            StringBuilder result = new StringBuilder(count);

            if (index < 0 || index > initialString.Length - 1)
            {
                throw new IndexOutOfRangeException("Starting index must be in the range [0, string.Length) and ");
            }

            if (count < 0 || index + count > initialString.Length - 1)
            {
                throw new ArgumentException("Count must be >= 0 and index + count must be < string.Length");
            }

            for (int i = index; i < index + count; i++)
            {
                result.Append(initialString[i]);
            }

            return result;
        }

        public static StringBuilder Substring(this StringBuilder strBuilder, int index)
        {
            string initialString = strBuilder.ToString();
            StringBuilder result = new StringBuilder(initialString.Length - index);

            if (index < 0 || index > initialString.Length - 1)
            {
                throw new IndexOutOfRangeException("Starting index must be in the range [0, string.Length) and ");
            }

           for (int i = index; i < initialString.Length; i++)
            {
                result.Append(initialString[i]);
            }

            return result;
        }
    }
}
