using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Taxi_Qualifier.Common.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
    }
}
