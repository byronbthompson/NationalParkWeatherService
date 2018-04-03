using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Models.DAL
{
    public interface IWeatherDAL
    {
        List<Weather> GetWeatherByParkCode(string parkCode);
    }
}
