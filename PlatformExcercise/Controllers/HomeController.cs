using Newtonsoft.Json.Linq;
using PlatformExcercise.Data;
using PlatformExcercise.Dtos;
using PlatformExcercise.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PlatformExcercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOpomba(OpombaDto dto)
        {
            var model = new OpombaModel
            {
                Id = dto.Id,
                Opomba = dto.Opomba
            };

            List<OpombaModel> getOpombaById = DataRepository.LoadOpombaById(model);
            if (getOpombaById.Count > 0)
            {
                DataRepository.UpdateOpomba(model);
            }
            else 
            {
                DataRepository.CreateOpomba(model);
            }

            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult GetProdukti()
        {

            var opombe = DataRepository.LoadOpombe();

            List<ProduktOpombaDto> po = new List<ProduktOpombaDto>();

            JObject products = ServicesDataRepository.GetProducts();

            foreach (var produkt in products["data"]["items"])
            {
                bool flag = false;
                foreach (var op in opombe)
                {
                    if (op.Id == (int)produkt[1])
                    {
                        flag = true;
                        po.Add(new ProduktOpombaDto
                        {
                            Id = (int)produkt[1],
                            Produkt = (string)produkt[2],
                            Stranka = (string)produkt[4],
                            Cena = (string)produkt[5],
                            Opomba = op.Opomba,
                            DatumOpombe = op.DatumOpombe.ToString("dd.MM.yyyy HH:mm")
                        });
                        break;
                    }
                }
                if (flag) continue;
                po.Add(new ProduktOpombaDto
                {
                    Id = (int)produkt[1],
                    Produkt = (string)produkt[2],
                    Stranka = (string)produkt[4],
                    Cena = (string)produkt[5]
                });
            }

            return Json(po, JsonRequestBehavior.AllowGet);
        }
    }
}