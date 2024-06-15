using CRUDApp.Models;
using CRUDApp.Models.Address;
using CRUDApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace CRUDApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context;

        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;

        }
        public JsonResult Province()
        {
            var provinces = context.Provinces
               .Select(p => new { p.ProvinceId, p.ProvinceName })
               .ToList();
            return new JsonResult(provinces);
        }

        public JsonResult District(int id)
        {
            var districts = context.Districts
                .Where(d => d.Province.ProvinceId == id)
                .Select(d => new { d.DistrictId, d.DistrictName })
                .ToList();
            return new JsonResult(districts);
        }

        public JsonResult Municipality(int id)
        {
            var municipalities = context.Municipalities
                .Where(m => m.District.DistrictId == id)
                .Select(m => new { m.MunId, m.MunName })
                .ToList();
            return new JsonResult(municipalities);
        }

        public IActionResult Index()
        {
            var customers = context.Customers.ToList();
    

            return View(customers);


        }

        public IActionResult Create()
        {
            var customerDTO = new CustomerDTO();
            return View(customerDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Map CustomerDTO to Customer entity and save to database
                    var customer = new Customer
                    {
                        Name = customerDTO.Name,
                        Email = customerDTO.Email,
                        Phone = customerDTO.Phone,
                        Province = customerDTO.Province,
                        District = customerDTO.District,
                        Municipality = customerDTO.Municipality,
                        WardNo = customerDTO.WardNo
                    };

                    context.Customers.Add(customer);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"An error occurred: {ex.Message}";

                }
            }


            return View(customerDTO);
        }

        public IActionResult Edit(int Id)
        {
            var customer = context.Customers.Find(Id);

            if (customer == null)
            {
                return RedirectToAction("Index", "Parameter");
            }

            var customerDTO = new CustomerDTO()
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Province = customer.Province,
                District = customer.District,
                Municipality = customer.Municipality,
                WardNo = customer.WardNo,

            };

            ViewData["CustomerId"] = customer.Id;
            return View(customerDTO);


        }
        [HttpPost]
        public IActionResult Edit(int Id, CustomerDTO customerDTO)
        {
            var customer = context.Customers.Find(Id);
            if (customer == null)
            {
                return RedirectToAction("Index", "Parameter");
            }
            if (!ModelState.IsValid)
            {
                ViewData["CustomerId"] = customer.Id;
                return View(customerDTO);
            }
            // Update customer entity with data from customerDTO
            customer.Name = customerDTO.Name;
            customer.Email = customerDTO.Email;
            customer.Phone = customerDTO.Phone; 
            customer.Province = customerDTO.Province;
            customer.District = customerDTO.District;
            customer.Municipality = customerDTO.Municipality;
            customer.WardNo = customerDTO.WardNo;
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }
        public IActionResult Delete(int Id)
        {
            var customer = context.Customers.Find(Id);
            if (customer == null)
            {
                return RedirectToAction("Index", "Parameter");
            }


            context.Customers.Remove(customer);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Customer");
        }



    }
}