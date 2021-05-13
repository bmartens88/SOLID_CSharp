namespace ArdalisRating
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger)
            : base(engine, logger) { }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating FLOOD policy...");
            _logger.Log("Validating policy");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Flood policy must specify Bond Amount and Valuation");
                return;
            }
            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                _logger.Log("Flood policy is not available for elevations at or below sea level");
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Log("Insufficient bond amount");
                return;
            }
            decimal multiple = policy.ElevationAboveSeaLevelFeet switch
            {
                < 100 => 2.0m,
                < 500 => 1.5m,
                < 1000 => 1.1m,
                _ => 1.0m
            };
            _engine.Rating = policy.BondAmount * 0.05m * multiple;
        }
    }
}
