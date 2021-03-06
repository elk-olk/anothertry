﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static bool PERFORM_LONG_UI_CHECKS = true;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();

        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
               builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 10)));
            }

            return builder.ToString();
        }

    }
}
