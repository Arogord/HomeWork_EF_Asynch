using HomeWorCore_MVC_DataBase.Models;
using HomeWork_EF_Asynch.Context;
using HomeWork_EF_Asynch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Text;

namespace HomeWork_EF_Synch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<string> GetSensorReadings()
        {
            StringBuilder result = new StringBuilder();
            using (ApplicationContext db = new ApplicationContext())
            {
                var sensor = await db.sensors.ToListAsync();
                
                foreach (var val in sensor)
                {
                    result.Append($"{val.ID} \t{val.Temp_Sensor} \t\t{val.Humid_Sensor} \t\t{val.Motion_Sensor} \t\t{val.Light_Sensor} \t\t{val.CO_Sensor} \t\t{val.Data_Time}\n");
                }
            }
            return result.ToString();
        }

        [HttpGet]
        public IActionResult AddSensorData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSensorData(Sensors data)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.sensors.Add(data);
                await db.SaveChangesAsync();
            }

            return View();

        }

        public async Task <string> UpdateFirstSensorData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Sensors? sens = await db.sensors.FirstOrDefaultAsync();
                if (sens != null)
                {
                    sens.Temp_Sensor = 33;
                    sens.Humid_Sensor = 33;
                    sens.Motion_Sensor = Convert.ToBoolean(1);
                    sens.CO_Sensor = 33;
                    sens.Light_Sensor = 33;
                    sens.Data_Time = new DateTime(2022, 11, 11, 0, 0, 0);
                    await db.SaveChangesAsync();
                }
            }

            return "Ready";
        }
        public async Task<string> DeleteFirstSensorData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Sensors? sens = await db.sensors.FirstOrDefaultAsync();
                //Sensors? sens2 = db.sensors.FirstOrDefaultAsync();

                if (sens != null)
                {
                    db.sensors.Remove(sens);
                    await db.SaveChangesAsync();
                }
            }

            return "Deleted";
        }

    }
}