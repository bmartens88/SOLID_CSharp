namespace ArdalisRating
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        // SRP
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy");

            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
