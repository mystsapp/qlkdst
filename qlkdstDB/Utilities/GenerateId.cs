using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlkdstDB.Utilities
{
    public class GenerateId
    {
        public string NextIdRevert(string lastID, string prefixID, string length)
        {
            if (lastID == "")
            {
                return length + prefixID;
            }
            int lengthNumerID = lastID.Length - prefixID.Length;
            int nextID = int.Parse(lastID.Substring(0, lengthNumerID)) + 1;

            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return zeroNumber + nextID.ToString() + prefixID;
                }
            }
            return nextID + prefixID;
        }
        public string NextId(string lastID, string prefixID, string length)
        {
            if (lastID == "")
            {
                return prefixID + length;
            }
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;
        }
    }
}
