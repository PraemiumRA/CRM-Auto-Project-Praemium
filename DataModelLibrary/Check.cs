﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DataModelLibrary
{
    /// <summary>
    /// Checks data values.
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Checks input string value from data.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isSpecialName"></param>
        /// <returns></returns>
        public static string CheckInputStringValue(string value, bool isSpecialName = false)
        {
            string pattern = String.Empty;

            if (!isSpecialName)
                pattern = @"^\D[a-zA-Z0-9]*$";
            else
                pattern = @"^\D[a-zA-Z]*$";

            StringBuilder builder;
            if (Regex.IsMatch(value, pattern))
            {
                builder = new StringBuilder(value.Substring(1));
                builder.Insert(0, value[0].ToString().ToUpper());
                return builder.ToString();
            }
            else
                throw new Exception("Input value is not correct.");
        }

        /// <summary>
        /// Checks number from data.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int CheckNumber(string count)
        {
            int tempCount = 0;
            int.TryParse(count, out tempCount);

            if (tempCount <= 0)
                tempCount = 1;

            return tempCount;
        }
    }
}
