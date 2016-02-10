using DrivingLicense.DataAccessLayer;
using DrivingLicense.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace DrivingLicense.Controllers
{
    [Authorize(Roles = "Manager, Employee")]
    public class DLController : Controller
    {
        private DLContext _dbContext = new DLContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            //int storeIDVal = Convert.ToInt32(storeID);
            if (_dbContext.DLDetailss != null)
            {
                return View(_dbContext.DLDetailss.ToList());
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult ViewDrivingLicense(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLDetails inventory = _dbContext.DLDetailss.Find(id);
            generateXML(inventory);
            XslTransform xslt = new XslTransform();
            String path = HostingEnvironment.MapPath("~/XMLClasses/DrivingLicense.xsl");
            xslt.Load(path);
            path = HostingEnvironment.MapPath("~/XMLClasses/DrivingLicense.xml");
            XPathDocument xpathdocument = new
            XPathDocument(path);
            path = HostingEnvironment.MapPath("~/XMLClasses/MyDrivingLicense.html");
            XmlTextWriter writer = new XmlTextWriter(path, UTF8Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            xslt.Transform(xpathdocument, null, writer, null);
            writer.Flush();
            writer.Close();
            writer.Dispose();
            return new FilePathResult(path, "text/html");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLDetails inventory = _dbContext.DLDetailss.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DLNumber,Name,FathersName,Address,Pin,BloodGroup,DOB,DeptName,State,IssuingID,DateOfIssue,ValidTill,COV1,COV2")] DLDetails inventory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.DLDetailss.Add(inventory);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        private void generateXML(DLDetails newDL)
        {
            drivingLicense dL = new drivingLicense();
            dL.DLNumber = newDL.DLNumber;
            dL.Address = newDL.Address;
            dL.BG = newDL.BloodGroup;
            dL.CountryName = newDL.DeptName;
            dL.COV1 = newDL.COV1;
            dL.COV2 = newDL.COV2;
            dL.DOB = newDL.DOB.Date.ToString();
            dL.DOI = newDL.DateOfIssue.Date.ToString();
            dL.FatherName = newDL.FathersName;
            dL.IssuingId = newDL.IssuingID;
            dL.Name = newDL.Name;
            dL.Pin = newDL.Pin;
            dL.StateName = newDL.State;
            dL.ValidTill = newDL.ValidTill.Date.ToString();
            var serializer = new XmlSerializer(typeof(drivingLicense));
            String path = HostingEnvironment.MapPath("~/XMLClasses/DrivingLicense.xml");
            using (var stream = new StreamWriter(path))
                serializer.Serialize(stream, dL);
  
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLDetails inventory = _dbContext.DLDetailss.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DLNumber,Name,FathersName,Address,Pin,BloodGroup,DOB,DeptName,State,IssuingID,DateOfIssue,ValidTill,COV1,COV2")] DLDetails inventory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(inventory).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLDetails inventory = _dbContext.DLDetailss.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DLDetails inventory = _dbContext.DLDetailss.Find(id);
            _dbContext.DLDetailss.Remove(inventory);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DL()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void createxsd()
        {
            XmlReader reader = XmlReader.Create("D:/DrivingLicense.xml");
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchemaInference schema = new XmlSchemaInference();
            System.IO.StreamWriter stringWriter = new System.IO.StreamWriter("D:/test.txt");
            schemaSet = schema.InferSchema(reader);
            var settings = new XmlWriterSettings();
            settings.Indent = true;

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                    using (var writer = XmlWriter.Create(stringWriter, settings))
                    {
                        s.Write(writer);
                    }

                    stringWriter.Write(s);        
            }
        }
    }
}