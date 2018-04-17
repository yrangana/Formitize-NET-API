using Formitize.API;
namespace Tests.UnitTests
{
    public class Helper
    {

        public static Credentials createCredentials()
        {
            return new Credentials("APIDemo", "APIDemo", "apidemo123");

        }

        public static Credentials createBadCredentials()
        {
            return new Credentials("APIDemo", "APIDemo", "WRONG_PASSWORD");

        }


    }
}
