using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TimeService : ITimeService
    {

        public TimeService()
        {
        }

        public DateTime Now()
        {
            return DateTime.UtcNow; ;
        }

    }
}
