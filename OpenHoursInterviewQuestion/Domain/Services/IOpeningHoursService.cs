using OpenHoursInterviewQuestion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHoursInterviewQuestion.Domain.Services
{
    public interface IOpeningHoursService
    {
        string FormatOpeningHours(OpeningHours openingHours);
    }
}
