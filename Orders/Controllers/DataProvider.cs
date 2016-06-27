using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orders.Models;

namespace Orders.Controllers
{
    public class DataProvider
    {
        static readonly ReportEntities _dc=new ReportEntities();


        public static IEnumerable GetCategories()
        {
            var query = from material in _dc.Material
                        select new
                        {
                            Material_Id = material.Material_id,
                            CategoryName = material.name,

                        };
            return query.ToList();
        } 
    }
}