namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger)
            : base(engine, logger) { }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                _engine.Rating = policy.Dedutible < 500 ? 1000m : 900m;
            }
        }
    }
}
