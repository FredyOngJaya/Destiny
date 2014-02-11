using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;

namespace Destiny.Main
{
    public class ClassGlobal
    {
        public static string _confFile = "DestinyConfig.txt";
        public static int _lastItemID;
        public static int _lastViewID;
        public static string _pathDataGRF;
        public static string _pathSPRDrop;
        public static string _pathSPRMan;
        public static string _pathSPRWoman;
        public static string _pathItemCollection;
        public static string _pathItemIcon;
        public static string _pathLUA;
        public static string textBox10;
        public static string textBox11;
        public static string textBox12;

        public static void LoadData()
        {
            if (File.Exists(_confFile))
            {
                StreamReader _conf = new StreamReader(_confFile);
                string _line;
                while (!_conf.EndOfStream)
                {
                    _line = _conf.ReadLine();
                    string[] _split = _line.Split(';');
                    if (_split[0].Equals("textBoxLastItemID")) _lastItemID = Convert.ToInt32(_split[1]);
                    else if (_split[0].Equals("textBoxLastViewID")) _lastViewID = Convert.ToInt32(_split[1]);
                    else if (_split[0].Equals("textBoxPathDataGRF")) _pathDataGRF = _split[1];
                    else if (_split[0].Equals("textBoxPathSPRDrop")) _pathSPRDrop = _split[1];
                    else if (_split[0].Equals("textBoxPathSPRMan")) _pathSPRMan = _split[1];
                    else if (_split[0].Equals("textBoxPathSPRWoman")) _pathSPRWoman = _split[1];
                    else if (_split[0].Equals("textBoxPathItemCollection")) _pathItemCollection = _split[1];
                    else if (_split[0].Equals("textBoxPathItemIcon")) _pathItemIcon = _split[1];
                    else if (_split[0].Equals("textBoxPathLUA")) _pathLUA = _split[1];
                    else if (_split[0].Equals("textBox10")) textBox10 = _split[1];
                    else if (_split[0].Equals("textBox11")) textBox11 = _split[1];
                    else if (_split[0].Equals("textBox12")) textBox12 = _split[1];
                }
                _conf.Close();
            }
        }

        public static string GetMD5(string _string)
        {
            MD5 _md5 = MD5.Create();
            byte[] _input = Encoding.ASCII.GetBytes(_string);
            byte[] _hash = _md5.ComputeHash(_input);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < _hash.Length; i++)
            {
                output.Append(_hash[i].ToString("X2"));
            }
            return output.ToString();
        }

        public static string GetSHA1(string _string)
        {
            SHA1 _sha1 = SHA1.Create();
            byte[] _input = Encoding.ASCII.GetBytes(_string);
            byte[] _hash = _sha1.ComputeHash(_input);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < _hash.Length; i++)
            {
                output.Append(_hash[i].ToString("X2"));
            }
            return output.ToString();
        }

        public static string GetSHA256(string _string)
        {
            SHA256 _sha256 = SHA256.Create();
            byte[] _input = Encoding.ASCII.GetBytes(_string);
            byte[] _hash = _sha256.ComputeHash(_input);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < _hash.Length; i++)
            {
                output.Append(_hash[i].ToString("X2"));
            }
            return output.ToString();
        }

        public static string GetSHA384(string _string)
        {
            SHA384 _sha384 = SHA384.Create();
            byte[] _input = Encoding.ASCII.GetBytes(_string);
            byte[] _hash = _sha384.ComputeHash(_input);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < _hash.Length; i++)
            {
                output.Append(_hash[i].ToString("X2"));
            }
            return output.ToString();
        }

        public static string GetSHA512(string _string)
        {
            SHA512 _sha512 = SHA512.Create();
            byte[] _input = Encoding.ASCII.GetBytes(_string);
            byte[] _hash = _sha512.ComputeHash(_input);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < _hash.Length; i++)
            {
                output.Append(_hash[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}
