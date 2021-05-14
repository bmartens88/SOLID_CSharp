namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IRatingUpdate ratingUpdater)
            : base(ratingUpdater) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                _ratingUpdater.UpdateRating(policy.Dedutible < 500 ? 1000m : 900m);
            }
        }
    }
}
