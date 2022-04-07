using System;

namespace EtheriumStaking
{
    class NextRewardDateCalculator
    {
        private DateTime stakingStartDate;
        private int rewardDay;

        public NextRewardDateCalculator(DateTime stakingStartDate, int rewardDay)
        {
            this.stakingStartDate = stakingStartDate;
            this.rewardDay = rewardDay;
        }
        public DateTime GetNextRewardDate()
        {
            /*if investment day started later than reward day on that month then this month is skipped
            for next reward day*/
            if (stakingStartDate.Day >= rewardDay)           
                stakingStartDate = stakingStartDate.AddMonths(1);                          

            DateTime rewardDate = Convert.ToDateTime($"{stakingStartDate.Year}-{stakingStartDate.Month}-{rewardDay}");

            return rewardDate;
        }
    }
}
