namespace Vacation
{
    internal static class VacationHelper
    {
        private const int vacationLength = 13;
        private const int userId = 1;

        public static List<Vacation> GetUserVacations()
        {
            var firstStartDate = GetRandomDate();
            var secondStartDate = GetRandomDate();

            while (Math.Abs((firstStartDate - secondStartDate).TotalDays) <= vacationLength)
            {
                secondStartDate = GetRandomDate();
            }

            return new List<Vacation> {
                new Vacation(userId, firstStartDate, firstStartDate.AddDays(vacationLength)),
                new Vacation(userId, secondStartDate, secondStartDate.AddDays(vacationLength))
            };
        }

        public static List<Vacation> GetOrganizationVacations()
        {
            var result = new List<Vacation>();
            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var randomUserId = random.Next(userId + 1, 1000);
                var randomDate = GetRandomDate();
                var randomLength = random.Next(vacationLength, 27);

                result.Add(new Vacation(randomUserId, randomDate, randomDate.AddDays(randomLength)));
            }

            return result;
        }

        private static DateTime GetRandomDate()
        {
            var random = new Random();

            var month = random.Next(1, 12);
            int day;

            if (month == 12)
                day = random.Next(1, 14);
            else
                day = random.Next(1, 28);

            return new DateTime(2023, month, day);
        }
    }
}
