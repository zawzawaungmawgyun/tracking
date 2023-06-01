using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tracking.Data;
using Tracking.Models;
using Tracking.Models.TrackingViewModels;

namespace Tracking.Controllers
{
    [Authorize]
    public class TrackingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TrackingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Division> DivisionList = _dbContext.Division.OrderBy(d => d.DivisionID).ToList();
            List<LoginUser> LoginUserList = _dbContext.LoginUser.ToList();
            List<Models.ServiceProvider> ServiceProviderList = _dbContext.ServiceProvider.ToList();

            TrackingViewModel tvm = new TrackingViewModel()
            {
                Divisions = DivisionList,
                LoginUsers = LoginUserList,
                ServiceProviders = ServiceProviderList
            };
            return View(tvm);
        }
        public IActionResult GetDivisions()
        {
            var divisions = _dbContext.Division.OrderBy(x => x.DivisionID).ToList();
            return Json(divisions);
        }
        public IActionResult GetDistricts(string selectDivision ="")
        {
            var districts = _dbContext.District.Where(x => x.DivisionID == selectDivision).OrderBy(x => x.DistrictID).ToList();
            return Json(districts);
        }

        public IActionResult GetBranches(string selectDivision = "", string selectDistrict = "")
        {
            var branchwisedistrict = _dbContext.BranchWiseDistrict.Where(x => x.DivisionID == selectDivision && x.DistrictID == selectDistrict).Distinct().ToList();
            var branches = new List<Branch>();
            foreach (var item in branchwisedistrict)
            {
                var branch = _dbContext.Branch.Where(x => x.BranchCode == item.BranchCode).SingleOrDefault();
                branches.Add(branch);
            }            
            return Json(branches);
        }

        public IActionResult GetLoginUsers()
        {
            var loginusers = _dbContext.LoginUser.OrderBy(x => x.FirstName).ToList();
            return Json(loginusers);
        }

        public IActionResult GetDeviceNames()
        {
            var devicenames = _dbContext.Device.OrderBy(x => x.DeviceName).ToList();
            return Json(devicenames);
        }

        public IActionResult GetServiceProviders()
        {
            var serviceproviders = _dbContext.ServiceProvider.OrderBy(x => x.Name).ToList();
            return Json(serviceproviders);
        }
        public IActionResult GetTransactionbyDivision(string DivisionID)
        {
            var transactions = _dbContext.Transaction.Where(x => x.DivisionID == DivisionID).ToList() ;
            return Json(transactions);
        }
        
        public IActionResult GetTransactionbyDivDis(string DivisionID, string DistrictID)
        {
            var transactions = _dbContext.Transaction.Where(x => x.DivisionID == DivisionID && x.DistrictID == DistrictID).ToList();
            return Json(transactions);
        }

        public IActionResult GetTransactionbyDivDisUnit(string DivisionID, string DistrictID, string BranchCode)
        {
            var transactions = _dbContext.Transaction.Where(x => x.DivisionID == DivisionID && x.DistrictID == DistrictID && x.BranchCode == BranchCode).ToList();
            return Json(transactions);
        }
        public IActionResult GetTransactionbySerialNumber(string serialnumber)
        {
            var transactions = _dbContext.Transaction.Where(x => x.SerialNumber == serialnumber).ToList();
            return Json(transactions);
        }  

        public IActionResult GetTransactionbyDeviceName(string devicename)
        {
            var transactions = _dbContext.Transaction.Where(x => x.DeviceName == devicename).ToList();
            return Json(transactions);
        }
        public IActionResult GetTransactionbyBrandName(string brandname)
        {
            var transactions = _dbContext.Transaction.Where(x => x.BrandName == brandname).ToList();
            return Json(transactions);
        }
        public IActionResult GetTransactionbyIssue(string issue)
        {
            var transactions = _dbContext.Transaction.Where(x => x.TypeOfIssue.Contains(issue)).ToList();
            return Json(transactions);
        }
        public IActionResult GetTransactionbyIssueDate(DateTime fromdate, DateTime todate)
        {
            var transactions = _dbContext.Transaction.Where(x => x.IssueDate >= fromdate && x.IssueDate <= todate).ToList();
            return Json(transactions);
        }

        //[HttpPost]
        public IActionResult Save (Transaction ts)
        {
            try
            {
                int msg = 0;
                if (ModelState.IsValid)
                {
                    _dbContext.Transaction.Add(ts);
                    _dbContext.SaveChanges();
                    msg = 1;
                    return Ok(new
                    {
                        data = msg
                    });
                }
                else
                {
                    return Ok(new
                    {
                        data = msg
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

        }
        public IActionResult NewSave(Transaction ts)
        {
            try
            {
                int msg = 0;
                if (ModelState.IsValid)
                {
                    _dbContext.Transaction.Update(ts);
                    _dbContext.SaveChanges();
                    msg = 1;
                    return Ok(new
                    {
                        data = msg
                    });
                }
                else
                {
                    return Ok(new
                    {
                        data = msg
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

        }

        public IActionResult SearchbyDivDis()
        {
            return View();
        }

        public IActionResult SearchbySerialNumber()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            Transaction ts = new Transaction();
            ts = _dbContext.Transaction.Where(x => x.Id == id).FirstOrDefault();
            return View(ts);
        }
        
        public IActionResult SDetails(int id)
        {
            Transaction ts = new Transaction();
            ts = _dbContext.Transaction.Where(x => x.Id == id).FirstOrDefault();
            return View(ts);
        }
        public IActionResult Edit(int id)
        {
            Transaction ts = new Transaction();
            ts = _dbContext.Transaction.Where(x => x.Id == id).FirstOrDefault();
            return View(ts);
        }

    }
}
