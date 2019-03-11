using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Ikco.Data
{
    public static class Functions
    {
        [DbFunction("CodeFirstDatabaseSchema", "ConvertDateToShamsi")]
        public static string ConvertDateToShamsi(DateTime? date, string type)
        {
            throw new NotSupportedException();
        }

        [DbFunction("CodeFirstDatabaseSchema", "GETDATE")]
        public static DateTime GetDate()
        {
            throw new NotSupportedException();
        }

        //        [DbFunction("CodeFirstDatabaseSchema", "ConvertDateToShamsi")]
        //        public static string ConvertDateToShamsiNullable(DateTime? date, string type)
        //        {
        //            throw new NotSupportedException();
        //        }
    }
}