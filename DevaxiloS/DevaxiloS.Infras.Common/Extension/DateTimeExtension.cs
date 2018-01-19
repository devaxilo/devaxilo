using System;

namespace DevaxiloS.Infras.Common.Extension
{
    public static class DateTimeExtension
    {
        public static bool CanJoinLottery(this DateTime input)
        {
            var dateNow = DateTime.UtcNow.Date;
            var startDate = dateNow.AddDays(-1).AddHours(13);
            var endDate = dateNow.AddHours(10).AddMinutes(45);
            return input >= startDate && input <= endDate;
        }
    }
}
