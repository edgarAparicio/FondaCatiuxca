﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using EdgarAparicio.FondaCatiuxca.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FondaCatiuxcaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenu menuRepositorio;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Menu Menu { get; set; }
        public IEnumerable<SelectListItem> TipoComidaSelectList { get; set; }
        

        public HomeController(IMenu menu, IHtmlHelper htmlH)
        {
            menuRepositorio = menu;
            htmlHelper = htmlH;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var listaMenus = menuRepositorio.ObtenerListaMenus().OrderBy(m => m.Nombre);
            return View(listaMenus);
        }

        public ActionResult Detalle(int idMenu)
        {
            var menu = menuRepositorio.ObtenerMenuPorId(idMenu);
            if(menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        public ActionResult Crear()
        {
            TipoComidaSelectList = htmlHelper.GetEnumSelectList<TipoComida>();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                TipoComidaSelectList = htmlHelper.GetEnumSelectList<TipoComida>();
                return View();
            }

            menuRepositorio.AgregarMenu(menu);
            menuRepositorio.Commit();
            return RedirectToAction("Index");

        }

        public ActionResult Editar(int? idMenu)
        {
            TipoComidaSelectList = htmlHelper.GetEnumSelectList<TipoComida>();
            
            if (idMenu.HasValue)
            {
                Menu = menuRepositorio.ObtenerMenuPorId(idMenu.Value);
            }
            else
            {
                Menu = new Menu();
            }
            if(Menu == null)
            {
                return RedirectToPage("./NoSeEncontro");
            }
            return View(Menu);
        }

        [HttpPost]
        public ActionResult Editar()
        {
            if (!ModelState.IsValid)
            {
                TipoComidaSelectList = htmlHelper.GetEnumSelectList<TipoComida>();
                return View();
            }

            menuRepositorio.EditarMenu(Menu);
            menuRepositorio.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int? idMenu)
        {
            if (idMenu.HasValue)
            {
                Menu = menuRepositorio.ObtenerMenuPorId(idMenu.Value);
            }
            else
            {
                Menu = new Menu();
            }
            if(Menu == null)
            {
                return RedirectToPage("./NoSeEncontro");
            }
            return View(Menu);
        }

        [HttpPost]
        public ActionResult Eliminar(int idMenu)
        {
            Menu = menuRepositorio.ElimnarMenu(idMenu);
            menuRepositorio.Commit();
            if(Menu == null)
            {
                return RedirectToPage("./NoSeEncontro");
            }

            return RedirectToAction("Index");
        }

    }
}
