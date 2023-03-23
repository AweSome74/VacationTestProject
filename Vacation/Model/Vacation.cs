namespace Vacation
{
    internal class Vacation
    {
        //период с 01.01.2023 по 14.01.2023 = 14 дней, т.е. отпуск с startDate по endDate включительно
        public int userId;
        public DateTime startDate;
        public DateTime endDate;

        public Vacation(int userId, DateTime startDate, DateTime endDate)
        {
            this.userId = userId;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public bool Intersects(Vacation vacation)
        {
            if (this.startDate >= vacation.startDate && this.startDate <= vacation.endDate)
                return true;

            if (this.endDate >= vacation.startDate && this.startDate <= vacation.endDate)
                return true;

            if (vacation.startDate >= this.startDate && vacation.startDate <= this.endDate)
                return true;

            if (vacation.endDate >= this.startDate && vacation.startDate <= this.endDate)
                return true;

            return false;
        }

        public bool IntersectsAlt(Vacation vacation)
        {
            var startDate = this.startDate > vacation.startDate ? this.startDate : vacation.startDate;
            var endDate = this.endDate < vacation.endDate ? this.endDate : vacation.endDate;
            return startDate <= endDate;
        }
    }
}
