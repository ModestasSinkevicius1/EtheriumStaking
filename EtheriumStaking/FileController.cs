using System;
using System.IO;

namespace EtheriumStaking
{
    class FileController
    {
        public void FileWrite(int row, DateTime nextRewardDate, float investmentAmount, 
            float rewardAmount, float totalReward, float rewardRate, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath + ".csv", true))
            {
                sw.WriteLine($"{row},{nextRewardDate.ToString("yyyy-MM-dd")},{investmentAmount.ToString("0.000000")}," +
                    $"{rewardAmount.ToString("0.000000")},{totalReward.ToString("0.000000")},{rewardRate.ToString("0.00")}%");
            }
        }
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath + ".csv"))           
                File.Delete(filePath + ".csv");
        }

        public void AddHeader(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath + ".csv", true))
            {
                sw.WriteLine("Line,Reward date,Investment amount,Reward amount,Total reward,Staking reward rate");
            }
        }
    }
}
