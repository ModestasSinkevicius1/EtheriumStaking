using System;

namespace EtheriumStaking
{
    class Actual_365Calculator
    {
        private float investmentAmount;
        private float rewardRate;
        private DateTime stakingStartDate;        
        private int rewardPaymentDay;       

        public Actual_365Calculator(float investmentAmount, float rewardRate, DateTime stakingStartDate, 
            int rewardPaymentDay)
        {
            this.investmentAmount = investmentAmount;
            this.rewardRate = rewardRate;
            this.stakingStartDate = stakingStartDate;            
            this.rewardPaymentDay = rewardPaymentDay;           
        }

        public float CalculateRewardAmmount()
        {
            int days;
            
            //getting days between last and new reward date
            days = GetDaysUntilNextReward();

            //using 'Actual/365' method to get reward amount
            float rewardAmount = investmentAmount * ((float)rewardRate/100) * (float)days / 365;
            return rewardAmount;
        }

        private int GetDaysUntilNextReward()
        {
            DateTime tempDate = stakingStartDate;
            int remainingDays = 0;

            //determening how much days will take to reach another reward day
            do
            {
                tempDate = tempDate.AddDays(1);
                remainingDays++;
            }
            while (tempDate.Day != rewardPaymentDay);

            return remainingDays;
        }       
    }
}
