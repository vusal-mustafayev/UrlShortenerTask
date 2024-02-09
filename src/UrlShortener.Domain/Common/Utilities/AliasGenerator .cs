namespace UrlShortener.Domain.Common.Utilities;
public class AliasGenerator : IAliasGenerator
{
    private const string MasterCharacterList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private const int ShortUrlLength = 6;

    public string Generate()
    {
        Random random = new();
        StringBuilder sb = new();

        for (int i = 0; i < ShortUrlLength; i++)
        {
            int randomIndex = random.Next(0, MasterCharacterList.Length);
            sb.Append(MasterCharacterList[randomIndex]);
        }
        return sb.ToString();
    }
}