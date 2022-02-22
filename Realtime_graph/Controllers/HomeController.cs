using Newtonsoft.Json;
using Realtime_graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Realtime_graph.Controllers
{
    public class HomeController : Controller
    {
        private IE_COMMONEntities _db = new IE_COMMONEntities();

        public ActionResult Index()
        {

            ViewBag.DataPoints = JsonConvert.SerializeObject(_db.sp_sum_boot_vote().ToList());

            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            //List<DataPoint> dataPoints = new List<DataPoint>();

            //dataPoints.Add(new DataPoint("NO2", 64));
            //dataPoints.Add(new DataPoint("PM10", 80));
            //dataPoints.Add(new DataPoint("O3", 32));
            //dataPoints.Add(new DataPoint("NH3", 3));
            //dataPoints.Add(new DataPoint("SO2", 8));
            //dataPoints.Add(new DataPoint("CO", 22));
            //dataPoints.Add(new DataPoint("PM2.5", 79));

            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
        [HttpPost]
        public ActionResult test()
        {
            var data = _db.sp_sum_boot_vote().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChartJs()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> iData = new List<object>();
            var results = _db.sp_sum_boot_vote().ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Employee", System.Type.GetType("System.String"));
            dt.Columns.Add("Credit", System.Type.GetType("System.Int32"));
            foreach (sp_sum_boot_vote_Result ss in results)
            {
                DataRow dr = dt.NewRow();
                dr["Employee"] = ss.NameBoot;
                dr["Credit"] = ss.Total;
                dt.Rows.Add(dr);
                //Mvote homeVm = new Mvote();
                //homeVm.Poll = ss.Poll;
                //homeVm.Total = ss.Total;
                //iData.Add(homeVm);
            }
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            return Json(iData, JsonRequestBehavior.AllowGet);


            //List<object> iData = new List<object>();
            ////Creating sample data  
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Employee", System.Type.GetType("System.String"));
            //dt.Columns.Add("Credit", System.Type.GetType("System.Int32"));

            //DataRow dr = dt.NewRow();
            //dr["Employee"] = "Sam";
            //dr["Credit"] = 123;
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["Employee"] = "Alex";
            //dr["Credit"] = 456;
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["Employee"] = "Michael";
            //dr["Credit"] = 587;
            //dt.Rows.Add(dr);
            ////Looping and extracting each DataColumn to List<Object>  
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    List<object> x = new List<object>();
            //    x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
            //    iData.Add(x);
            //}
            //return Json(iData, JsonRequestBehavior.AllowGet);
            //Source data returned as JSON  
        }


        public ActionResult get_results()
        {
            var data = _db.sp_sum_boot_vote().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

    }
}