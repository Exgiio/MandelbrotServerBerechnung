using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MandelbrotBerechnung.Klassen;
using System.IO;
using System.Text;

namespace Mandelbrot.Controllers
{
    [Route("")]
    public class MandelbrotController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post()
        {
            string value = string.Empty;
            List<int> iterationen = new List<int>();

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                value = await reader.ReadToEndAsync();
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                JsonObject jsonObject = new JsonObject(value);

                if (jsonObject != null)
                {
                    int width = Convert.ToInt32(jsonObject.RealTo);
                    int height = Convert.ToInt32(jsonObject.ImaginaryTo);

                    for (decimal x = jsonObject.RealFrom; x < width; x = x + jsonObject.Intervall)
                    {
                        for (decimal y = jsonObject.ImaginaryFrom; y < height; y = y + jsonObject.Intervall)
                        {
                            Complex c = new Complex((double)x, (double)y);
                            Complex z = new Complex(0, 0);

                            int durchgänge = 0;
                            do
                            {
                                Complex.Square(ref z);
                                Complex.AddCtoZ(c, ref z);
                                if (Complex.Magnitude(z) > 2.0) break;
                                durchgänge++;
                            }
                            while (durchgänge < jsonObject.MaxIteration);

                            iterationen.Add(durchgänge);
                        }
                    }

                    if (iterationen.Count > 0)
                    {
                        return new JsonResult(iterationen);
                    }
                }
            }

            return new JsonResult(BadRequest());
        }
    }
}
