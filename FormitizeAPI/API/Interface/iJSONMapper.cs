namespace Formitize.API.Interface
{
    public interface iJsonMapper
    {
        T From<T>(string result);
        string To<T>(T request);
    }
}