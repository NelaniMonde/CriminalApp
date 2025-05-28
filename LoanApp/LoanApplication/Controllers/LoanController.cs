using LoanApplication.Data;
using LoanApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplication.Controllers
{
    public class LoanController : Controller
    {
        private readonly AppDataBaseContext _dataBase;

        public LoanController (AppDataBaseContext _dataBase)
        {
            this._dataBase = _dataBase;
        }



        public IActionResult LoanView()
        {
          var loanObjList = _dataBase.Loans.ToList();

            
            return View(loanObjList);
        }

        //To return the view 
        public IActionResult GetLoaner()
        {

            return View();   

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetLoaner(LoanModel loanObj)
        {



        


                loanObj = UtilityMethod(loanObj);

            _dataBase.Loans.Add(loanObj);
            _dataBase.SaveChanges();

            return RedirectToAction("LoanView");
            

            return View(loanObj);
            
        }



        public IActionResult Update(int? id)
        {
            if(id == null && id==0)
            {
                return NotFound();
            }
            var loanObj = _dataBase.Loans.Find(id);
            
            
            
            return View(loanObj);

        }

        [HttpPost]
        public IActionResult Update(LoanModel loanObj)
        {

            loanObj = UtilityMethod(loanObj);
          _dataBase.Loans.Update(loanObj);
            _dataBase.SaveChanges();
            return RedirectToAction("LoanView");

            return View(loanObj);
        }


        //Get method for delete
        public IActionResult Delete(int? id) 
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var loanObj = _dataBase.Loans.Find(id);
            return View(loanObj);
        }

        [HttpPost]
        public IActionResult Delete(LoanModel loanObj)
        {
            loanObj = UtilityMethod(loanObj);
            _dataBase.Loans.Remove(loanObj);
            _dataBase.SaveChanges();
            return RedirectToAction("LoanView");

            return View(loanObj);
        }

        public IActionResult Details(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var loanObj = _dataBase.Loans.Find(id);
            return View(loanObj);
        }


        public static void Hide()
        {

        }


       // Utility method
        public LoanModel UtilityMethod(LoanModel loanObj)
        {
            float maximumInst = 0;
            float loanGranted = 0;
            float deposite = 0;
            float monthlyInstall = 0;
            
            

            //100% loan
            if (loanObj.CreditScore >= 800)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(100);
                deposite = DepositeReqCal(loanObj.PriceOfProperty,loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);
            }
            //97.5 loan
            else if (loanObj.CreditScore >= 750 && loanObj.CreditScore <= 799)
            {
                
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(97.5);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);
            }
            //95% loan
            else if (loanObj.CreditScore >= 700 && loanObj.CreditScore <= 749)
            {

                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(95);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);
            }

            //90% loan
            else if (loanObj.CreditScore >= 650 && loanObj.CreditScore <= 699)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted =loanGrantedCal(90);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);
            }
            //85% loan
            else if (loanObj.CreditScore >= 600 && loanObj.CreditScore <= 649)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(85);
                deposite = DepositeReqCal(loanObj.PriceOfProperty,  loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);
            }
            //80% loan
            else if (loanObj.CreditScore >= 550 && loanObj.CreditScore <= 599)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(80);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);
            }
            //No loan
            else if (loanObj.CreditScore <= 549)
            {
                maximumInst = 0;
                loanObj.LoanStatus = "Rejected";
                loanGranted = 0;
                deposite = 0;
                monthlyInstall = 0;
            }

            loanObj = new LoanModel
            {
                ID = loanObj.ID,
                Name = loanObj.Name,
                Surname = loanObj.Surname,
                GrossSalary = loanObj.GrossSalary,
                CreditScore = loanObj.CreditScore,
                PriceOfProperty = loanObj.PriceOfProperty,
                LoanStatus = loanObj.LoanStatus,
                MaximumInstalment = maximumInst,
                LoanGranted = loanGranted,
                DepositeRequired = deposite,
                MonthlyInstalment = monthlyInstall


            };

            return loanObj;

        }

        public float MaximumInstalCal(float grossSalary)
        {
            float maxInstal = grossSalary * 30 / 100;

            return maxInstal;
        }

        public float loanGrantedCal(double loangrant)
        {
            float loanGranted = (float)(loangrant);
            return loanGranted;
        }
    

        public float DepositeReqCal(float priceOfPropery,float loanGranted)
        {
            float deposite = priceOfPropery - (priceOfPropery * loanGranted/100);

            return deposite;
        }
        public float MonthlyInstalCal(float priceOfproperty, float deposite)
        {
            float monthlyInstall = (float)((priceOfproperty - deposite) * ((double)0.00785));

            return monthlyInstall;
        }
    }
}
