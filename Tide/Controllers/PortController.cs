using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortController : ControllerBase
    {

        [HttpGet]
        public async Task<List<String>> GetAsync()
        {
            string tmps;

            string cs = @"server=my03.winhost.com;userid=mehrzad;password=UMDGMSZG9D;database=mysql_47511_wp";
            List<string> Ports = new List<string>();
            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                string sql = string.Format("SELECT port FROM mysql_47511_wp.irantide order by port;");
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = await cmd.ExecuteReaderAsync())
                    {
                        while (rdr.Read())
                        {
                            Ports.Add(rdr["port"].ToString() ?? "");
                            //var aa = rdr[0].ToString() ?? "";
                            //var b = 2;
                            //tmps = rdr["longitude"].ToString() ?? "";
                            //myPort.longitude = Double.Parse(tmps.Substring(0, 2))
                            //                + Double.Parse(tmps.Substring(2, 2)) / 60.0
                            //                + Double.Parse(tmps.Substring(4, 2)) / 3600.0;

                            //tmps = rdr["latitude"].ToString() ?? "";
                            //myPort.latitude = Double.Parse(tmps.Substring(0, 2))
                            //        + Double.Parse(tmps.Substring(2, 2)) / 60.0
                            //        + Double.Parse(tmps.Substring(4, 2)) / 3600.0;

                            //myPort.z0 = 100 * double.Parse(rdr["z0"].ToString());
                            //////string scanLine = "";
                            //string fileName = rdr["DataFile"].ToString();
                            //myPort.setIranPort(fileName);

                            //StreamReader sr = new StreamReader(Application.StartupPath + "\\App_Data\\" + fileName);
                            //string scanLine = "";
                            //int freqIndex = 0;
                            //do
                            //{
                            //    scanLine = sr.ReadLine();
                            //} while ((freqIndex = scanLine.IndexOf("FREQUENCY")) == -1);
                            //do
                            //{

                            //    if ((scanLine = sr.ReadLine()) != null)
                            //    {
                            //        tmps = scanLine.Substring(freqIndex - 8, 5).ToUpper();
                            //        if (tmps != "")
                            //        {
                            //            double amplitude = 100.0 * Convert.ToDouble(scanLine.Substring(freqIndex + 27, 6));
                            //            double phase = Convert.ToDouble(scanLine.Substring(freqIndex + 34, 6));
                            //            myPort.portData.Add(tmps, new Port.portDataClass(amplitude, phase));
                            //        }
                            //    }
                            //} while (scanLine != null);


                        }
                    }
                }
            }
            return Ports.ToList();
        }
    }
   
}
