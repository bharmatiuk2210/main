using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime result = new DateTime();
            result = startDate.AddDays(dayCount);


            if (weekEnds == null)
            {
                return result.AddDays(-1);
            }
            else
            {
                TimeSpan[] timeSpans = new TimeSpan[weekEnds.Length];

                for (int i = 0; i < weekEnds.GetLength(0); i++)
                {
                    if (result > weekEnds[i].StartDate)
                    {
                        if (weekEnds[i].StartDate > weekEnds[i].EndDate)

                        {
                            Console.WriteLine("Дата окончания выходных {0} раньше чем дата их начала {1}", weekEnds[i].EndDate, weekEnds[i].StartDate);
                            break;
                        }

                        if (weekEnds[i].StartDate == weekEnds[i].EndDate)
                        {
                            timeSpans[i] = new TimeSpan(864000000000);
                            result = result + timeSpans[i];
                        }

                        if (weekEnds[i].StartDate < weekEnds[i].EndDate)
                        {
                            timeSpans[i] = weekEnds[i].EndDate - weekEnds[i].StartDate;
                            result = result + timeSpans[i];
                        }
                    }
                }
            }
            return result;
        }
    }
}

