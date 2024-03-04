using System.Collections.Generic;
using System.Security.Cryptography;
using System.Transactions;

class Solution
{
    static void Main(string[] args)
    {
        // the purpose of this program is to take a set of characters and "shake things up" such that what was provided from the source web site will be unique.
        // this will be important to get a more secure password.
        //https://passwordsgenerator.net/
        //length = 50, quantity = 10, valid chars: #$%^&
        //join all strings together, and paste below 
        Solution oS = new Solution();
        string s = oS.Shuffle(1000,"vZhsLTgwb3%5UkuRm6Vf#2JPY^c$eMQrFxGnjtW4CqayDXBzSHKg7Cbt&4Jwm8$LHXujv3y9WTNGZ2r6kMRq%SxAch5EBaQepnzff4tSG6Lq&JBAn95W^wacby$Xdsre%T8PDHUQxM2CvpE3F7hKzgQc&BMqZpESau5e9hyK4#3FgtRYA2zUjC$xfd%rW7^DNPJGbmV6VG&9TCbuH3AYUgX86v^5$sJeMaNnfwE#jhRZ%p4WBL2QdxktP7ZREry%M8TJ24qxBa$9&XshFWQPt7LCSYmgAce#D5VkGf6KdbUpA4UKm8xWEJSYDwt2ypkrXRc3%ue^NZ7#fB&zgCh5MLjQqT6PFnuDK6S35#JqzaLWM^B%ZCfxmeg8swV7r4NHpQ$cTREA&XyPjYGFQagR%P6uGdLCZt3fjyJ2TqvkUMHBeDX$h^zsxbVwcm98#AYnr7mQPXw%#5z&d8rxcF$tC47E^nbkVAvTLfN3j9gDRUW2esGMSuB6");
        byte[] iterations = RandomNumberGenerator.GetBytes(1);
        int iteration = iterations[0];
        string Rtn = oS.GetNewStr(s, 50, iteration);
        //set breakpoint below to see contents of Rtn
        Console.ReadKey();
    }

    public string Shuffle(int cuts, string s)
    {
        string Rtn = s;
        for (int i=0;i<=(cuts-1);i++)
        {
            byte[] iterations = RandomNumberGenerator.GetBytes(1);
            int iteration = iterations[0];
            Rtn = Rtn.Substring(iteration)+ Rtn.Substring(0, iteration);
        }
        return Rtn;
    }
    public string GetNewStr(string s, int LengthNewPW, int iterations)
    {

        if (s.Length <= 255)
        {
            return "pass longer string!";
        }

        string newPW = string.Empty;
        for (int j = 0; j <= iterations; j++)
        {
            newPW = string.Empty;
            var byteArray = RandomNumberGenerator.GetBytes(s.Length);
            for (int i = 0; i <= (LengthNewPW-1); i++)
            {
                int Current = byteArray[i];
                newPW += s.Substring(Current, 1);
            }
        }
        return newPW;
    }

}



