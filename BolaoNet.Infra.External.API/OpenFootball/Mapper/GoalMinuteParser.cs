namespace BolaoNet.Infra.External.API.OpenFootball.Mapper
{
    public static class GoalMinuteParser
    {
        public static (int Minute, int ExtraTime)
            Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (0, 0);

            value = value.Trim();

            var parts = value.Split('+');

            return parts.Length == 1
                ? (int.Parse(parts[0]), 0)
                : (int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}
