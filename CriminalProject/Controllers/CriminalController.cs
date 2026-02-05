using CriminalProject.Data;
using CriminalProject.Models;
using CriminalProject.UserActivityClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace CriminalProject.Controllers
{
    public class CriminalController : Controller
    {
        //User Logger
        private readonly IUserActivityLogger _userActivityLogger;
        private readonly CriminalAppContext _context;
        //private Suspects suspect;

        public CriminalController(CriminalAppContext context, IUserActivityLogger userActivityLogger)
        {
            _context = context;
            _userActivityLogger = userActivityLogger;
        }


        //Dashboard View
        public IActionResult DashboardView(string availableManagers, string successMessage)
        {
            if (availableManagers != null)
            {
                TempData["Error"] = availableManagers;
            }
            

            if (successMessage == "No Suspect")
            {
                TempData["Error"] = "No Suspect found";
            }
            else
            {
                TempData["Success"] = successMessage;
            }
                return View();
        }


        //Dashboard
        //Search
        [HttpPost]
        [ActionName("DashboardView")]
        public IActionResult DashboardView2(string SusID )
        {

            var suspects = _context.Suspects.ToList();
            var singleValue = 0;
            var message = "";



            foreach (var sus in suspects)
            {
                if (SusID != null)
                {
                    if (sus.SuspectID.Contains(SusID))
                    {
                        singleValue = sus.SuspectNo;
                    }
                }
                
                
            }

            
                var foundID = _context.Suspects.Find(singleValue);
            if (foundID != null)
            {
                var criminals = _context.CriminalRecord.ToList();

                List<CriminalRecords> crimLis = new List<CriminalRecords>();

                foreach (var obj in criminals)
                {
                    if (obj.SuspectNo == singleValue)
                    {
                        crimLis.Add(obj);
                    }
                }
                // TempData["SusIDValue"] = SusID;

                TempData["FoundSusNo"] = foundID.SuspectNo;
                TempData["IDNumber"] = foundID.SuspectID;
                var combinedModel = new SuspectsNCrimininal
                {
                    Suspects = foundID,
                    CriminalRecords = crimLis
                };


                _userActivityLogger.LogUserActivity(User.Identity.Name, "Searched For Suspect whose ID No Is "+SusID.ToString());

                return View(combinedModel);

                
            }
            else
            {
                 message = "No Suspect";
                return RedirectToAction("DashboardView",new { successMessage =message});
            }
            
            
            //return View();
        }



        //Suspects Action View
        public IActionResult SuspectsView()
        {
            return View(new Suspects());
        }

        //Action for adding suspects 
        [HttpPost]
        public IActionResult SuspectsView(Suspects suspects)
        {
          
            var suspObject = new Suspects
            {
                SuspectID = suspects.SuspectID,
                FirstName = suspects.FirstName,
                LastName = suspects.LastName,
            };

             _context.Suspects.Add(suspObject);
                _context.SaveChanges();
            // TempData["SuspectNo"] = suspObject.SuspectNo;
            //TempData["IDNumber"]= suspObject.SuspectID;

            //return RedirectToAction("CriminalRecordView");

            _userActivityLogger.LogUserActivity(User.Identity.Name, "Added a Suspect whose ID Number is:  " + suspObject.SuspectID + 
                "  and Name is:  " + suspObject.FirstName);
            var message = "A Suspect whose ID Number is:  " + suspObject.SuspectID +
                "  and Name is:  " + suspObject.FirstName+" was added successfully!!!";

            return RedirectToAction("DashboardView", new { successMessage =message});

          //  return View();
        }

        //Criminal Record view
        [HttpGet]
        public IActionResult CriminalRecordView(int suspectNo, string viewName)
        {
            // suspectNo =(int) TempData["SuspectNo"];

            //suspectNo =(int)TempData["FoundSusNo"];

            string Id = "";

            var cases = _context.Managers.ToList();
            if(cases.Count()<=0 && viewName=="DashboardView")
            {
                return RedirectToAction(""+viewName, new { availableManagers = "No Managers Available to create a case" });
            }
            else if(cases.Count()<=0 && viewName== "ShowSuspects")
            {
                return RedirectToAction(viewName, new { availableManagers ="No managers available" });
            }


                foreach (var sus in _context.Suspects.ToList())
                {
                    if (sus.SuspectNo == suspectNo)
                    {
                        Id = sus.SuspectID;

                    }
                }


            TempData["IDNumber"]= Id;
            TempData["ManagerForeignKey"] = ManagerNoMeth();

          var crimRec = new CriminalRecords { SuspectNo = suspectNo, ManagerNoForeign=ManagerNoMeth()};

            return View();
        }

        // Criminal Adding Action
        [HttpPost]
        public IActionResult CriminalRecordView(CriminalRecords criminalRecords)
        {
            var suspect = _context.Suspects
                .Include(c=> c.CriminalRecords)
                .FirstOrDefault(s=>s.SuspectNo==criminalRecords.SuspectNo);
            
         

            if (suspect != null)
            {
                criminalRecords.Suspects = suspect;
            }

            //criminalRecords = new CriminalRecords
            //{
            //    CriminalRecordId= criminalRecords.CriminalRecordId,


            //    ManagerNoForeign = Managers()
            //};

           _context.Add(criminalRecords);
                      
            _context.SaveChanges();

            _userActivityLogger.LogUserActivity(User.Identity.Name, "Added a Criminal record :  "+ criminalRecords.Offences +
              " for a suspect whose ID Number Is:  " + suspect.SuspectID+ " Suspect Name is: "+suspect.FirstName);

            var crimSuccessMessage = "Criminal Reccord: " + criminalRecords.Offences +
                " Added Successfully for Suspect: " + suspect.FirstName;
            //AutoAllocation();
            return RedirectToAction("ShowSuspects", new { addedCriminalRec =crimSuccessMessage});
           // return View();
        }


        //update Suspect View Action
        [HttpGet]
        public IActionResult UpdateSuspect(int id)
        {
            var suspect = _context.Suspects.Find(id);
            return View(suspect);
        }

        //update Suspect View Action
        //get
        [HttpPost]
        public IActionResult UpdateSuspect(Suspects suspecs)
        {
            _context.Suspects.Update(suspecs);
            _context.SaveChanges();

            if (User.Identity != null)
            {
                if(User.Identity.Name!=null)
                { 
                _userActivityLogger.LogUserActivity(User.Identity.Name, "Updated Suspect Details whose name is:  "
                    + suspecs.FirstName +
                " and whose ID Number Is:  " + suspecs.SuspectID);
            } }



            TempData["Success"] = "Suspect Details whose name is: " + suspecs.FirstName + 
                " and whose ID Number Is:  " + suspecs.SuspectID
                + " has been updated successfully";

            return RedirectToAction("DashboardView");
            return View(suspecs);
        }

        



        //update Criminal Reord View Action
        //get
        [HttpGet]
        public IActionResult UpdateCriminal(int id)
        {
            var criminal = _context.CriminalRecord.Find(id);

            return View(criminal);
        }

        //update Criminal Record View Action
        [HttpPost]
        public IActionResult UpdateCriminal(CriminalRecords recs)
        {
            var suspect = _context.Suspects
                .Include(c => c.CriminalRecords)
                .FirstOrDefault(s => s.SuspectNo == recs.SuspectNo);

            _context.CriminalRecord.Update(recs);
            _context.SaveChanges();

            var message = "Criminal record for Suspect: " + suspect.FirstName + " has been updated";



            return RedirectToAction("DashboardView", new { successMessage =message});
            

       
        }

        //Show Suspects
        [HttpGet]
        public IActionResult ShowSuspects(string availableManagers,string addedCriminalRec)
        {
            List<Suspects> suspects = _context.Suspects.ToList();
            List <CriminalRecords> criminals = _context.CriminalRecord.ToList();

            if (availableManagers != null)
            {
                TempData["Error"] = "No Managers Available to create a case";
            }

            foreach (var sus in suspects)
            {
                TempData["IDNumber"] = sus.SuspectID;
                foreach (var record in criminals) 
                {
                   
                    if (sus.SuspectNo == record.SuspectNo)
                    {
                        sus.CriminalRecords.Add(record);
                    }
                   
                }

            }

            TempData["Success"] = addedCriminalRec;
            _userActivityLogger.LogUserActivity(User.Identity.Name, "Viewed All Suspects");

            return View(suspects);
        }


        //Add Managers

        [HttpGet]
        public IActionResult AddManagers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddManagers(Manager manager)
        {

            _context.Managers.Add(manager);
            _context.SaveChanges();


            _userActivityLogger.LogUserActivity(User.Identity.Name, "Added a Manager whose ID Number Is:  " 
                + manager.ManagerID + " Whose Name is: " + manager.Name);

            TempData["Success"] = "A Manager whose ID Number Is: " + manager.ManagerID +
                " Whose Name is: " + manager.Name + " has been added Successfully!!!";
            
                ModelState.Clear();
            return View();
        }


        public IActionResult viewCases() 
        {



            List<Suspects> suspects = _context.Suspects.ToList();
            List<Manager> managerList = _context.Managers.ToList();
            List<CriminalRecords> criminals = _context.CriminalRecord.ToList();

            List<CriminalRecords> criminalCase= new List<CriminalRecords>();

            foreach (var man in managerList)
            {
                foreach (var sus in suspects)
                {
                    TempData["IDNumber"] = sus.SuspectID;
                    foreach (var record in criminals)
                    {

                        if (sus.SuspectNo == record.SuspectNo  && man.ManagerNo==record.ManagerNoForeign)
                        {
                            sus.CriminalRecords.Add(record);
                            man.Criminals.Add(record);
                            criminalCase.Add(record);   
                        }

                    }

                }
            }


            List<Cases> cases = new List<Cases>();

            cases.Add(new Cases { Suspects = suspects,
                                   ManagerList=managerList,
                                   CriminalRecords=criminalCase});

            _userActivityLogger.LogUserActivity(User.Identity.Name, "Viewed Cases (Suspects And Criminal Records and Managers");



            return View(cases);  
        }





        //Returning Manager Number
        public int ManagerNoMeth()
        {
            var managers = _context.Managers.ToList();
            var criminalList = _context.CriminalRecord.ToList();
            Manager matchingManager = new Manager();

            int ManagerNo = 0;


            foreach (var man in managers)
            {

                foreach (var crim in criminalList)
                {

                    if (man.ManagerNo == crim.ManagerNoForeign)
                    {
                        man.Criminals.Add(crim);
                    }

                }

            }

                   
           matchingManager = managers.OrderBy(manager => manager.Criminals == null ? 0 : manager.Criminals.Count()).FirstOrDefault();
       

            if (matchingManager == null)
            {
                TempData["NoManagerWarning"] = "No Manager Exisits in the database";
            }
            else
            {
                ManagerNo = matchingManager.ManagerNo;
            }
            _userActivityLogger.LogUserActivity(User.Identity.Name, "Automated A Manager");

            return ManagerNo;

        }//end of method 














    }
    
}
