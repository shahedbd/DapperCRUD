using Dapper;
using DapperMicroORM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;



namespace DapperMicroORM.Controllers
{
    public class PersonalInfoController : Controller
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString);
        // GET: PersonalInfo
        public ActionResult Index()
        {
            List<PersonalInfo> PersonalInfoList = new List<PersonalInfo>();
            PersonalInfoList = db.Query<PersonalInfo>("Select * From PersonalInfo").ToList();
            return View(PersonalInfoList);
        }

        // GET: PersonalInfo/Details/5
        public ActionResult Details(int id)
        {
            PersonalInfo _PersonalInfo = new PersonalInfo();
            _PersonalInfo = db.Query<PersonalInfo>("Select * From PersonalInfo " +
                                       "WHERE PersonalInfoID =" + id, new { id }).SingleOrDefault();
            return View(_PersonalInfo);
        }

        // GET: PersonalInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfo/Create
        [HttpPost]
        public ActionResult Create(PersonalInfo _PersonalInfo)
        {
            try
            {
                // TODO: Add insert logic here
                string sqlQuery = "Insert into PersonalInfo (FirstName,LastName,DateOfBirth,City,Country,MobileNo,NID,Email,Status) Values('" + _PersonalInfo.FirstName + "','" + _PersonalInfo.LastName + "','" + _PersonalInfo.DateOfBirth + "','" + _PersonalInfo.City + "','" + _PersonalInfo.Country + "','" + _PersonalInfo.MobileNo + "','" + _PersonalInfo.NID + "','" + _PersonalInfo.Email + "','" + _PersonalInfo.Status + "')";
                int rowsAffected = db.Execute(sqlQuery);

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {

                throw ex;
                return View();
            }
        }

        // GET: PersonalInfo/Edit/5
        public ActionResult Edit(int id)
        {
            PersonalInfo _PersonalInfo = new PersonalInfo();
            _PersonalInfo = db.Query<PersonalInfo>("Select * From PersonalInfo " +
                                       "WHERE PersonalInfoID =" + id, new { id }).SingleOrDefault();
            return View(_PersonalInfo);
        }

        // POST: PersonalInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonalInfo _PersonalInfo)
        {
            try
            {
                // TODO: Add update logic here
                string sqlQuery = @"update PersonalInfo set FirstName='" + _PersonalInfo.FirstName + "',LastName='" + _PersonalInfo.LastName + "',DateOfBirth='" + _PersonalInfo.DateOfBirth + "', City='" + _PersonalInfo.City + "', Country = '" + _PersonalInfo.Country + "', MobileNo = '" + _PersonalInfo.MobileNo + "', NID = '" + _PersonalInfo.NID + "',Email = '" + _PersonalInfo.Email + "',Status = '" + _PersonalInfo.Status + "' where PersonalInfoID=" + _PersonalInfo.PersonalInfoID;
                int rowsAffected = db.Execute(sqlQuery);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
                return View();
            }
        }

        // GET: PersonalInfo/Delete/5
        public ActionResult Delete(int id)
        {
            PersonalInfo _PersonalInfo = new PersonalInfo();
            _PersonalInfo = db.Query<PersonalInfo>("Select * From PersonalInfo " +
                                     "WHERE PersonalInfoID =" + id, new { id }).SingleOrDefault();
            return View();
        }

        // POST: PersonalInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                string sqlQuery = "Delete From PersonalInfo WHERE PersonalInfoID = " + id;

                int rowsAffected = db.Execute(sqlQuery);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
