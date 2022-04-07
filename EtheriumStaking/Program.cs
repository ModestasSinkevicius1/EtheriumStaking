using System;

namespace EtheriumStaking
{
    class Program
    {
        static void Main(string[] args)
        {           
            mainTask(25, 10, DateTime.Parse("2019-04-15"), 24, 23, true);
            bonusTask1(25, 8, DateTime.Parse("2019-04-15"), 24, 23, true);
            bonusTask2();
        }

        static void mainTask(double investmentAmount, float rewardRate, DateTime startDate,
            int duration, int paymentDay, bool reinvestDay)
        {
            Actual_365Calculator a365c;

            NextRewardDateCalculator nrdc;

            FileController fc = new FileController();                              

            fc.DeleteFile("etheriumStackSchedule_mainTask");
            fc.AddHeader("etheriumStackSchedule_mainTask");

            int row = 0;
            float totalReward = 0;
            DateTime nextRewardDate = startDate;

            /*checks if user stack start day is over reward day. If it is then additional stacking
            calculation is needed*/
            if (startDate.Day > paymentDay)
                duration++;

            //A loop which creates etherium schedule
            for (int i = 0; i <= duration; i++)
            {
                //the last payment day to be considered as the day of which person started investing from the start
                if (i == duration)
                    paymentDay = startDate.Day;

                //calculates reward amount based of Actual/365 method
                a365c = new Actual_365Calculator((float)investmentAmount, rewardRate, nextRewardDate,
                 paymentDay);

                //determines what is the next date for reveiving reward
                nrdc = new NextRewardDateCalculator(nextRewardDate, paymentDay);

                //overwrites reward date to next reward date
                nextRewardDate = nrdc.GetNextRewardDate();

                totalReward += a365c.CalculateRewardAmmount();
                row++;

                //writes output to given file path
                fc.FileWrite(row, nextRewardDate, (float)investmentAmount, a365c.CalculateRewardAmmount(), totalReward, rewardRate,
                    "etheriumStackSchedule_mainTask");

                //if user decided to reuse reward as new investement
                if (reinvestDay)
                    investmentAmount += a365c.CalculateRewardAmmount();               
            }
        }

        static void bonusTask1(double investmentAmount, float rewardRate, DateTime startDate,
            int duration, int paymentDay, bool reinvestDay)
        {
            Actual_365Calculator a365c;

            NextRewardDateCalculator nrdc;

            FileController fc = new FileController();                     

            fc.DeleteFile("etheriumStackSchedule_bonusTask1");
            fc.AddHeader("etheriumStackSchedule_bonusTask1");

            int row = 0;
            float totalReward = 0;
            DateTime nextRewardDate = startDate;

            /*checks if user stack start day is over reward day. If it is then additional stacking
            calculation is needed*/
            if (startDate.Day > paymentDay)
                duration++;

            //A loop which creates etherium schedule
            for (int i = 0; i <= duration; i++)
            {
                //the last payment day to be considered as the day of which person started investing from the start
                if (i == duration)
                    paymentDay = startDate.Day;

                //calculates reward amount based of Actual/365 method
                a365c = new Actual_365Calculator((float)investmentAmount, rewardRate, nextRewardDate,
                 paymentDay);

                //determines what is the next date for reveiving reward
                nrdc = new NextRewardDateCalculator(nextRewardDate, paymentDay);

                //overwrites reward date to next reward date
                nextRewardDate = nrdc.GetNextRewardDate();

                totalReward += a365c.CalculateRewardAmmount();
                row++;

                //writes output to given file path
                fc.FileWrite(row, nextRewardDate, (float)investmentAmount, a365c.CalculateRewardAmmount(), totalReward, rewardRate,
                    "etheriumStackSchedule_bonusTask1");

                //if user decided to reuse reward as new investement
                if (reinvestDay)
                    investmentAmount += a365c.CalculateRewardAmmount();               
            }
        }

        static void bonusTask2()
        {
            Actual_365Calculator a365c;

            NextRewardDateCalculator nrdc;

            FileController fc = new FileController();

            try
            {
                Console.WriteLine("Invesment amount");
                double investmentAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Reward rate");
                int rewardRate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Staking start date (ex. 2022-08-01)");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Duration (months)");
                int duration = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Payment day");
                int paymentDay = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Reinvest rewards? (yes/no)");
                bool reinvestDay = (Console.ReadLine() == "yes") ? true : false;
            
                fc.DeleteFile("etheriumStackSchedule_bonusTask2");
                fc.AddHeader("etheriumStackSchedule_bonusTask2");

                int row = 0;
                float totalReward = 0;
                DateTime nextRewardDate = startDate;

                /*checks if user stack start day is over reward day. If it is then additional stacking
                calculation is needed*/
                if (startDate.Day > paymentDay)
                    duration++;

                //A loop which creates etherium schedule
                for (int i = 0; i <= duration; i++)
                {
                    //the last payment day to be considered as the day of which person started investing from the start
                    if (i == duration)
                        paymentDay = startDate.Day;

                    //calculates reward amount based of Actual/365 method
                    a365c = new Actual_365Calculator((float)investmentAmount, rewardRate, nextRewardDate,
                     paymentDay);

                    //determines what is the next date for reveiving reward
                    nrdc = new NextRewardDateCalculator(nextRewardDate, paymentDay);

                    //overwrites reward date to next reward date
                    nextRewardDate = nrdc.GetNextRewardDate();

                    totalReward += a365c.CalculateRewardAmmount();
                    row++;

                    //writes output to given file path
                    fc.FileWrite(row, nextRewardDate, (float)investmentAmount, a365c.CalculateRewardAmmount(), totalReward, rewardRate,
                        "etheriumStackSchedule_bonusTask2");

                    //if user decided to reuse reward as new investement
                    if (reinvestDay)
                        investmentAmount += a365c.CalculateRewardAmmount();               
                }
                Console.WriteLine("A output file has been created. End of program" );
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bad input: " + ex);
                Console.ReadLine();
            }
        }
    }
}
