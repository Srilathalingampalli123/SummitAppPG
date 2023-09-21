namespace SummitAppDemo.Routes
{
    public class APIRoutes
    {
        public const string Root = "api";

        public const string Customers = Root + "/customers";
        public const string CustomerFNAs = Root + "/customerfnas/{id}";

        public const string CustomerAddresses = Customer + "/address";
        public const string CustomerAddress = Customer + "/address/{addressId}";


        public const string CustomerBanks = Customer + "/bank";
        public const string CustomerBank = Customer + "/bank/{bankId}";

        public const string CustomerDocs = Customer + "/docs";
        public const string CustomerDoc = Customer + "/docs/{docId}";

        public const string CustomerDocArtifacts = CustomerDoc + "/artifacts";
        public const string CustomerDocArtifact = CustomerDoc + "/artifacts/{artifactId}";
    }
}
