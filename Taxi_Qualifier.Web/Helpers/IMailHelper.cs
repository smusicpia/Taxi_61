﻿using Taxi_Qualifier.Common.Models;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
