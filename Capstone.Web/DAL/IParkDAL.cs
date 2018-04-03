using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models.DAL
{
    public interface IParkDAL
    {
        List<Park> GetAllParks();
        Park GetPark(string parkCode);
    }
}