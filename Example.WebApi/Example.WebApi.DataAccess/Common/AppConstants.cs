using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.Common
{
    public class AppConstants
    {
        public static string UserName = "Anonymous";
        public static int fetchNoOfRecently = 5;
        public class Transaction
        {
            public class Status
            {
                public static string Success = "S";
                public static string Failed = "F";
                public static string Canceled = "C";
                public static string Waiting = "W";
            }
        }

        public class Customers
        {
            public class Status
            {
                public static string Active = "A";
                public static string DeActive = "D";
                public static string Cancel = "C";
                public static string Locked = "L";
                public static string Suspend = "S";
            }
        }
    }
}
