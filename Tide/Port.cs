using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tide
{
    public class Port
    {
        private double _longitude, _latitude;
        public double latitude;
        public double longitude;
        public double z0;
        public double msl, hast;
        private string _ename, _fname;
        public string Name;
        public Dictionary<string, portDataClass> portData;

        public class portDataClass
        {
            public double amplitude;
            public double phase;
            public portDataClass(double _amplitude, double _phase)
            {
                amplitude = _amplitude;
                phase = _phase;
            }
        }
        public Port()
        {
            this.longitude = 0.0;
            this.latitude = 45.0;
            portData = new Dictionary<string, portDataClass>();
        }
        public Port(double latitute, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }
        public void setIranPort(string fileName)
        {
            //Port p = new Port();
            Assembly a = Assembly.GetExecutingAssembly();
            string[] resnames = a.GetManifestResourceNames();
            StreamReader sr = new StreamReader(a.GetManifestResourceStream(@"OceanTide.data." + fileName));
            //StreamReader sr = new StreamReader(Application.StartupPath + "\\App_Data\\" + fileName);
            string scanLine = "", tmps = "";

            int freqIndex = 0;
            do
            {
                scanLine = sr.ReadLine();
            } while ((freqIndex = scanLine.IndexOf("FREQUENCY")) == -1);
            do
            {

                if ((scanLine = sr.ReadLine()) != null)
                {
                    tmps = scanLine.Substring(freqIndex - 8, 5).ToUpper();
                    if (tmps != "")
                    {
                        double amplitude = 100.0 * double.Parse(scanLine.Substring(freqIndex + 27, 6));
                        double phase = double.Parse(scanLine.Substring(freqIndex + 34, 6));
                        this.portData.Add(tmps, new Port.portDataClass(amplitude, phase));
                    }
                }
            } while (scanLine != null);

        }

    }
}
