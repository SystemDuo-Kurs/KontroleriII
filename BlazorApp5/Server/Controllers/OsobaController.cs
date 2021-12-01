using BlazorApp5.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlazorApp5.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OsobaController : ControllerBase
    {
        private readonly ILogger _logger;

        public OsobaController(ILogger<OsobaController> log)
        {
            _logger = log; 
        }
        [HttpPost]
        public void Dodaj(Osoba o)
        {
            _logger.LogInformation($"{o.Ime} {o.Prezime}");
            System.IO.File.AppendAllText("osobe.txt",
                $"{o.Ime} {o.Prezime}" 
                + Environment.NewLine);
        }

        [HttpGet]
        public List<Osoba> Dohvati()
        {
            List<Osoba> o = new();
            foreach(string red in System.IO.File.ReadLines("osobe.txt"))
            {
                string[] ip = red.Split(' ');
                o.Add(new Osoba { Ime = ip[0], Prezime = ip[1] });
            }
            return o;
        }
    }
}
