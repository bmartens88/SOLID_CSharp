namespace ArdalisRating
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(IRatingUpdate ratingUpdater)
            : base(ratingUpdater) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating FLOOD policy...");
            Logger.Log("Validating policy");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Flood policy must specify Bond Amount and Valuation");
                return;
            }
            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                Logger.Log("Flood policy is not available for elevations at or below sea level");
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount");
                return;
            }
            decimal multiple = policy.ElevationAboveSeaLevelFeet switch
            {
                < 100 => 2.0m,
                < 500 => 1.5m,
                < 1000 => 1.1m,
                _ => 1.0m
            };
            _ratingUpdater.UpdateRating(policy.BondAmount * 0.05m * multiple);
        }
    }
}
