namespace EmpleoAPI.Config
{
    public class ApiRoutes
    {
        public const string Root = "api/";

        public static class City
        {
            public const string GetCityById = Root + "city/{id}";
            public const string GetAllCity = Root + "city/GetAllCity";
            public const string AddCity = Root + "city/AddCity";
            public const string ModifyCity = Root + "city/ModifyCity";
            public const string DeleteCity = Root + "city/{id}";
        }

        public static class Seller
        {
            public const string GetSellerById = Root + "seller/{id}";
            public const string GetAllSeller = Root + "seller/GetAllSeller";
            public const string AddSeller = Root + "seller/AddSeller";
            public const string ModifySeller = Root + "seller/ModifySeller";
            public const string DeleteSeller = Root + "seller/{id}";
        }
    }
}
