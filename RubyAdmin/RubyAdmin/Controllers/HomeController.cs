using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RubyAdmin.Models;
using System.Diagnostics;

namespace RubyAdmin.Controllers
{
    public class HomeController : Controller
    {
        private RubyHome_DatabaseContext db;
        public HomeController(RubyHome_DatabaseContext context)
        {
            db = context;
        }

        public async Task<IActionResult> IndexPropertyAsync()
        {
            return View(await db.Properties.ToListAsync());
        }

        public async Task<IActionResult> IndexTypePropertyAsync()
        {
            return View(await db.TypeProperties.ToListAsync());
        }

        public async Task<IActionResult> IndexUserAsync()
        {
            return View(await db.Users.ToListAsync());
        }

        public async Task<IActionResult> IndexUserCardAsync()
        {
            return View(await db.UserCards.ToListAsync());
        }
        public async Task<IActionResult> IndexEmployeeAsync()
        {
            return View(await db.Employees.ToListAsync());
        }
        public async Task<IActionResult> IndexCurrentPositionAsync()
        {
            return View(await db.CurrentPositions.ToListAsync());
        }

        public async Task<IActionResult> IndexStructureOfUserPropertyAsync()
        {
            return View(await db.StructureOfUserProperties.ToListAsync());
        }
        public async Task<IActionResult> IndexStructureOfEmployeeAsync()
        {
            return View(await db.StructureOfEmployees.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        ///////////////////////////////Property//////////////////////////////////////
        public IActionResult CreateProperty()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProperty(Property property)
        {
            db.Properties.Add(property);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexProperty");
        }

        public async Task<IActionResult> EditProperty(int? id)
        {
            if (id != null)
            {
                Property property = await db.Properties.FirstOrDefaultAsync(p => p.IdProperty == id);
                if (property != null)
                    return View(property);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditProperty(Property property)
        {
            db.Properties.Update(property);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexProperty");
        }

        [HttpGet]
        [ActionName("DeleteProperty")]
        public async Task<IActionResult> ConfirmDeleteProperty(int? id)
        {
            if (id != null)
            {
                Property property = await db.Properties.FirstOrDefaultAsync(p => p.IdProperty == id);
                if (property != null)
                    return View(property);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProperty(int? id)
        {
            if (id != null)
            {
                Property property = await db.Properties.FirstOrDefaultAsync(p => p.IdProperty == id);
                if (property != null)
                {
                    db.Properties.Remove(property);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexProperty");
                }
            }
            return NotFound();
        }
        //////////////////////////////////Type Property//////////////////////////////////////
        public IActionResult CreateTypeProperty()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTypeProperty(TypeProperty typeProperty)
        {
            db.TypeProperties.Add(typeProperty);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexTypeProperty");
        }

        public async Task<IActionResult> EditTypeProperty(int? id)
        {
            if (id != null)
            {
                TypeProperty typeProperty = await db.TypeProperties.FirstOrDefaultAsync(p => p.IdTypeProperty == id);
                if (typeProperty != null)
                    return View(typeProperty);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditTypeProperty(TypeProperty typeProperty)
        {
            db.TypeProperties.Update(typeProperty);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexTypeProperty");
        }

        [HttpGet]
        [ActionName("DeleteTypeProperty")]
        public async Task<IActionResult> ConfirmDeleteTypeProperty(int? id)
        {
            if (id != null)
            {
                TypeProperty typeProperty = await db.TypeProperties.FirstOrDefaultAsync(p => p.IdTypeProperty == id);
                if (typeProperty != null)
                    return View(typeProperty);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTypeProperty(int? id)
        {
            if (id != null)
            {
                TypeProperty typeProperty = await db.TypeProperties.FirstOrDefaultAsync(p => p.IdTypeProperty == id);
                if (typeProperty != null)
                {
                    db.TypeProperties.Remove(typeProperty);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexTypeProperty");
                }
            }
            return NotFound();
        }
        /////////////////////////////////////User////////////////////////////////////////
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexUser");
        }

        public async Task<IActionResult> EditUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexUser");
        }

        [HttpGet]
        [ActionName("DeleteUser")]
        public async Task<IActionResult> ConfirmDeleteUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexUser");
                }
            }
            return NotFound();
        }
        ///////////////////////////////////UserCard////////////////////////////////////////////////
        public IActionResult CreateUserCard()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserCard(UserCard userCard)
        {
            db.UserCards.Add(userCard);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexUserCard");
        }

        public async Task<IActionResult> EditUserCard(int? id)
        {
            if (id != null)
            {
                UserCard userCard = await db.UserCards.FirstOrDefaultAsync(p => p.IdUserCard == id);
                if (userCard != null)
                    return View(userCard);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditUserCard(UserCard userCard)
        {
            db.UserCards.Update(userCard);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexUserCard");
        }

        [HttpGet]
        [ActionName("DeleteUserCard")]
        public async Task<IActionResult> ConfirmDeleteUserCard(int? id)
        {
            if (id != null)
            {
                UserCard userCard = await db.UserCards.FirstOrDefaultAsync(p => p.IdUserCard == id);
                if (userCard != null)
                    return View(userCard);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserCard(int? id)
        {
            if (id != null)
            {
                UserCard userCard = await db.UserCards.FirstOrDefaultAsync(p => p.IdUserCard == id);
                if (userCard != null)
                {
                    db.UserCards.Remove(userCard);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexUserCard");
                }
            }
            return NotFound();
        }
        ////////////////////////////////////////Employee////////////////////////////////////////
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexEmployee");
        }

        public async Task<IActionResult> EditEmployee(int? id)
        {
            if (id != null)
            {
                Employee employee = await db.Employees.FirstOrDefaultAsync(p => p.IdEmployee == id);
                if (employee != null)
                    return View(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            db.Employees.Update(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexEmployee");
        }

        [HttpGet]
        [ActionName("DeleteEmployee")]
        public async Task<IActionResult> ConfirmDeleteEmployee(int? id)
        {
            if (id != null)
            {
                Employee employee = await db.Employees.FirstOrDefaultAsync(p => p.IdEmployee == id);
                if (employee != null)
                    return View(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            if (id != null)
            {
                Employee employee = await db.Employees.FirstOrDefaultAsync(p => p.IdEmployee == id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexEmployee");
                }
            }
            return NotFound();
        }
        //////////////////////////////////////////CurrentPosition///////////////////////////////////
        public IActionResult CreateCurrentPosition()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCurrentPosition(CurrentPosition currentPosition)
        {
            db.CurrentPositions.Add(currentPosition);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexCurrentPosition");
        }

        public async Task<IActionResult> EditCurrentPosition(int? id)
        {
            if (id != null)
            {
                CurrentPosition currentPosition = await db.CurrentPositions.FirstOrDefaultAsync(p => p.IdCurrentPosition == id);
                if (currentPosition != null)
                    return View(currentPosition);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCurrentPosition(CurrentPosition currentPosition)
        {
            db.CurrentPositions.Update(currentPosition);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexCurrentPosition");
        }

        [HttpGet]
        [ActionName("DeleteCurrentPosition")]
        public async Task<IActionResult> ConfirmCurrentPosition(int? id)
        {
            if (id != null)
            {
                CurrentPosition currentPosition = await db.CurrentPositions.FirstOrDefaultAsync(p => p.IdCurrentPosition == id);
                if (currentPosition != null)
                    return View(currentPosition);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCurrentPosition(int? id)
        {
            if (id != null)
            {
                CurrentPosition currentPosition = await db.CurrentPositions.FirstOrDefaultAsync(p => p.IdCurrentPosition == id);
                if (currentPosition != null)
                {
                    db.CurrentPositions.Remove(currentPosition);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexCurrentPosition");
                }
            }
            return NotFound();
        }
        ////////////////////////////StructureOfUserProperty//////////////////
        public IActionResult CreateStructureOfUserProperty()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStructureOfUserProperty(StructureOfUserProperty structureOfUserProperty)
        {
            db.StructureOfUserProperties.Add(structureOfUserProperty);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexStructureOfUserProperty");
        }

        public async Task<IActionResult> EditStructureOfUserProperty(int? id)
        {
            if (id != null)
            {
                StructureOfUserProperty structureOfUserProperty = await db.StructureOfUserProperties.FirstOrDefaultAsync(p => p.IdStructureOfUserProperty == id);
                if (structureOfUserProperty != null)
                    return View(structureOfUserProperty);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditStructureOfUserProperty(StructureOfUserProperty structureOfUserProperty)
        {
            db.StructureOfUserProperties.Update(structureOfUserProperty);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexStructureOfUserProperty");
        }

        [HttpGet]
        [ActionName("DeleteStructureOfUserProperty")]
        public async Task<IActionResult> ConfirmDeleteStructureOfUserProperty(int? id)
        {
            if (id != null)
            {
                StructureOfUserProperty structureOfUserProperty = await db.StructureOfUserProperties.FirstOrDefaultAsync(p => p.IdStructureOfUserProperty == id);
                if (structureOfUserProperty != null)
                    return View(structureOfUserProperty);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStructureOfUserProperty(int? id)
        {
            if (id != null)
            {
                StructureOfUserProperty structureOfUserProperty = await db.StructureOfUserProperties.FirstOrDefaultAsync(p => p.IdStructureOfUserProperty == id);
                if (structureOfUserProperty != null)
                {
                    db.StructureOfUserProperties.Remove(structureOfUserProperty);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexStructureOfUserProperty");
                }
            }
            return NotFound();
        }
        ///////////////////////////////////////////////////////////////////////////////////
        public IActionResult CreateStructureOfEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStructureOfEmployee(StructureOfEmployee structureOfEmployee)
        {
            db.StructureOfEmployees.Add(structureOfEmployee);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexStructureOfEmployee");
        }

        public async Task<IActionResult> EditStructureOfEmployee(int? id)
        {
            if (id != null)
            {
                StructureOfEmployee structureOfEmployee = await db.StructureOfEmployees.FirstOrDefaultAsync(p => p.IdStructureOfEmployee == id);
                if (structureOfEmployee != null)
                    return View(structureOfEmployee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditStructureOfEmployee(StructureOfEmployee structureOfEmployee)
        {
            db.StructureOfEmployees.Update(structureOfEmployee);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexStructureOfEmployee");
        }

        [HttpGet]
        [ActionName("DeleteStructureOfEmployee")]
        public async Task<IActionResult> ConfirmDeleteStructureOfEmployee(int? id)
        {
            if (id != null)
            {
                StructureOfEmployee structureOfEmployee = await db.StructureOfEmployees.FirstOrDefaultAsync(p => p.IdStructureOfEmployee == id);
                if (structureOfEmployee != null)
                    return View(structureOfEmployee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStructureOfEmployee(int? id)
        {
            if (id != null)
            {
                StructureOfEmployee structureOfEmployee = await db.StructureOfEmployees.FirstOrDefaultAsync(p => p.IdStructureOfEmployee == id);
                if (structureOfEmployee != null)
                {
                    db.StructureOfEmployees.Remove(structureOfEmployee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexStructureOfEmployee");
                }
            }
            return NotFound();
        }
        /////////////////////////////////////////////////////////////////////////////////
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}