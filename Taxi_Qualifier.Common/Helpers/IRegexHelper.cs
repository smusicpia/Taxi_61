using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi_Qualifier.Common.Helpers
{
    public interface IRegexHelper
    {
        bool IsValidEmail(string emailaddress);
    }
}
