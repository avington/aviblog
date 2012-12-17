namespace AviBlog.Core.Services.Search
{
    public static class LuceneSearchHelper
    {
        public static string RemoveSpecialLuceneCharactors(this string queryString)
        {
            string[] specialLuceneCharacters =
                {
                    @"\", "+", "-", "&&", "||", "!", "(", ")", "{", "}"
                    , "[", "]", "^", "\"", "~", "*", "?", ":"
                };
            foreach (string character in specialLuceneCharacters)
            {
                if (string.IsNullOrEmpty(queryString) || !queryString.Contains(character)) continue;
                queryString = queryString.Replace(character, @"\" + character);
            }
            return queryString;
        }
    }
}