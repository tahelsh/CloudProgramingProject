using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderContext _context;
        private readonly FlavorsContext _context2;

        public OrdersController(OrderContext context, FlavorsContext context2 )
        {
            _context = context;
            _context2 = context2;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.Message = _context2.Flavors.ToList();//for combo box of flavors in the window
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,Email,Street,City,HouseNumber,IceCream,Date,FeelsLike,Humidity,Pressure")] Order order)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(order);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            if (ModelState.IsValid)
            {
                bool flag = checkStreet(order.City, order.Street);
                if (flag)
                {
                    //enter weather details
                    Main weather = findWeather(order.City);
                    order.FeelsLike = weather.feels_like;
                    order.Pressure = weather.pressure;
                    order.Humidity = weather.humidity;
                    //enter date and hour
                    DateTime date = DateTime.Now;
                    order.Date = date;
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //else -להודיע על שגיאה
            }
            // return View(order);

            //return View(order);
            ViewBag.Message = _context2.Flavors.ToList();//for combo box of flavors in the window
            return View(order);
        }
        public bool checkStreet(string City, string Street)
        {
            AddressChecking addressChecking = new AddressChecking();
            Boolean result = addressChecking.CheckAddress(City, Street);
            if (result)
                return true;
            else
                return false;
        }
        public Main findWeather(string city)
        {
            WeatherClass weather = new WeatherClass();
            Main result = weather.CheckWeather(city);
            return result;
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Email,Street,City,HouseNumber,IceCream,Date,FeelsLike,Humidity,Pressure")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
