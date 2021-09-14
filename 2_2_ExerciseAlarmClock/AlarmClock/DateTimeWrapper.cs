using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    public interface IDateTime 
    {
        DateTime Now { get; }
    }

    public class DateTimeWrapper : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
