using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspFactory.Parser
{
    public class OADateToDate
    {



        public static String ToDate(String OADate)
        {
            
            DateTime date;
            date = DateTime.FromOADate(Double.Parse(OADate));
            String Result = date.ToString("d");









            return Result;

        }






    }
}