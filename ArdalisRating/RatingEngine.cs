namespace ArdalisRating
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public IRatingContext Context { get; set; } = new DefaultRatingContext();

        public RatingEngine()
        {
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy");

            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
