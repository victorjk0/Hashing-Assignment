using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hashing_Assignment
{
    class HMacHandler
    {
        private HMAC hashMac;
        
        public void HMacSelector(string name)
        {

            switch (name)
            {
                case "1":
                    hashMac = new HMACSHA1();
                    break;
                case "2":
                    hashMac = new HMACMD5();
                    break;
                case "3":
                    hashMac = new HMACSHA256();
                    break;
                case "4":
                    hashMac = new HMACSHA384();
                    break;
                case "5":
                    hashMac = new HMACSHA512();
                    break;
            }
        }


        public string ReturnHmac(byte[] ba)
        {
            StringBuilder str = new StringBuilder(ba.Length * 2);

            foreach (byte b in ba)
                str.AppendFormat("{0:x2}",b);
            return str.ToString();
        }



        public bool CheckAuthenticity(byte[] mes, byte[] mac, byte[] key)
        {
            hashMac.Key = key;

            if (CompareByteArrays(hashMac.ComputeHash(mes), mac, hashMac.HashSize / 8) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] ComputeMAC(byte[] mes, byte[] key)
        {
            hashMac.Key = key;
            return hashMac.ComputeHash(mes);
        }

        public bool CompareByteArrays(byte[] a, byte[] b, int len)
        {
            for (int i = 0; i < len; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}
