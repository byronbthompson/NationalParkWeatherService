using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Models.DAL
{
    public interface ISurveyDAL
    {
        bool AddSurvey(string parkCode, string email, string state, string activityLevel);
        List<Result> GetSurveyResults();
    }
}
