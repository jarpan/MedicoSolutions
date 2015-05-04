using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MedicoSolutions.Entity;

using Twilio;
using System.Configuration;

namespace MedicoSolutions.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Feedbackform()
        {
            return View();
        }
        public ActionResult Savefeedback1data(string message, string email, string question1, string question2, string question3)
        {
            feedback1 v = new feedback1();

            bool b = v.insertfeedback1(message, email, question1, question2, question3);


            string msg = "";
            if (b == true)
            {
                msg = "Thank You For Your Feedback";
            }
            else
            {
                msg = "Error.Please check the data you have inserted";
            }
            // v.close();
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contactus()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }
        public ActionResult GetCustomers()
        {
            user u = new user();
            List<user> m1 = u.GetCustomers();

            return Json(m1, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Admin_customer()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Login");
                }
            }
        }
        public ActionResult Search_medicine()
        {
            return View();
        }

        public ActionResult Searchmedicine(string medicine)
        {
            Searchmedicine a = new Searchmedicine();
            List<SearchmedicineDetails> m1 = a.search(medicine);
            return Json(m1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Main_home()
        {
            return View();
        }
        public ActionResult Main_page()
        {
            return View();
        }
        public ActionResult Store_email_id(string email)
        {
            user u = new user();
            bool b = u.login_email(email);
            return Json(b);
        }
        public ActionResult logout()
        {

            if (HttpContext.Session["UserSession"] != null)
            {
                Session.Abandon();
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Login(string email, string password)
        {
            return View();
        }
        public ActionResult Admin_login(string email, string password)
        {
            return View();
        }
        public ActionResult DoLogin(string email, string password)
        {
            user u = new user();
            int result = u.userAuthenticAte(email, password);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult sms(string phoneno, string name)
        {
            
            sms s = new sms();

          bool status = s.message(phoneno,name);
          return Json(status);
        }
  

   public ActionResult Customerhome()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 1)
                {
                    return View();
                }
                else
                {
                    return View("Login");
                }
            }
        }
        //
        // GET: /Admin/

        public ActionResult accounting()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Login");
                }
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Admin_login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Admin_login");
                }
            }
        }
        public ActionResult Vendor()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Admin_login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Admin_login");
                }
            }
        }
        public ActionResult Medicine()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Admin_login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Admin_login");
                }
            }
        }
        public ActionResult MedicineList()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Admin_login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Admin_login");
                }
            }
        }
        public ActionResult Maps()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 1)
                {
                    return View();
                }
                else
                {
                    return View("Login");
                }
            }
        }
     
        public ActionResult VendorList()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Admin_login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Admin_login");
                }
            }
        }

        public ActionResult SaveVendordata(string name, string phno, string company, string email, DateTime date, string status, string Address)
        {
            vendor v = new vendor();

            bool b = v.insertvendor(name, phno, company, email, date, status, Address);

          
            string msg = "";
            if (b == true)
            {
                msg = "Data Inserted Successfully";
            }
            else
            {
                msg = "Error.Please check the data you have inserted";
            }
            v.close();
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateVendordata(string name, string phno, string company, string email, DateTime date, string status, string Address, string vendorid)
        {
            vendor v = new vendor();
            bool b=v.UpdateVendordata(name,  phno,  company,  email,  date,  status,  Address,  vendorid);
            string msg = "";
            if (b == true)
            {
                msg = "Data Updated Successfully";
            }
            else
            {
                msg = "Error.Please check the data you want to edit ";
            }
            v.close();
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

      
        public ActionResult SaveMedicinedata(string name, string vendor, int MedicineType, decimal mrp, decimal cp, string qty, DateTime ExpDate)
        {
            medicine m = new medicine();

            bool b = m.insertmed(name, vendor, MedicineType, mrp, cp, qty, ExpDate);
            string msg = "";
            if (b == true)
            {
                msg = "Data Inserted Successfully";
            }
            else
            {
                msg = "Error.Please check the data you have inserted";
            }
            m.close();
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Updatequantity(string batch,string quantity)
        {
            medicine m = new medicine();
            bool mm = m.updatequantity(batch,quantity);
            return Json(mm, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Updatequantity(string medicinename)
        //{
        //    medicine m = new medicine();

        //    bool b = m.updatequantity(medicinename);
           
        //    return Json(msg, JsonRequestBehavior.AllowGet);
        //}
      
        
        public ActionResult UpdateMedicinedata(string name, string vendor, int MedicineType, decimal mrp, decimal cp, string mid, string qty)
        {

            ///Update Medicine Code
            medicine m = new medicine();
            bool b = m.UpdateMedicinedata(name, vendor, MedicineType, mrp, cp, mid,qty);
            string msg = "";
            if (b == true)
            {
                msg = "Data Updated Successfully";
            }
            else
            {
                msg = "Error.Please check the data you want to edit ";
            }
            m.close();
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVendorName()
        {
            vendor v = new vendor();
            List<Vendor1> vendor = v.getvendor();
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetVendorNameForMedicine(string vendorid)
        {
            vendor v = new vendor();
            List<Vendor1> vv = v.GetVendorNameForMedicine(vendorid);
            return Json (vv, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMedicineName()
        {
            medicine m = new medicine();
            List<MedicineDetails> m1 = m.getMedicine();
            return Json(m1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMedicineAdmin()
        {
            medicine m = new medicine();
            List<MedicineDetails> m1 = m.getMedicine1();
            return Json(m1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMedicine()
        {
            Searchmedicine m = new Searchmedicine();
            List<search_medicinedetails> m1 = m.gets();
            return Json(m1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAccountDetails()
        {
            Accounting a = new Accounting();
            List<AccountingDetails> m1 = a.getAccount();
            return Json(m1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetInvoiceDetails()
        {
            invoice i = new invoice();
            List<InvoiceCustomer> m1 = i.getInvoice();
            return Json(m1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Del_Email_row()
        {
            user m = new user();
            m.Del_Email_row();
            return Json(null);


        }
        public ActionResult getmedtype()
        {
            medicine m = new medicine();
            List<medicinetypemaster> m1 = m.getmedtype();
            return Json(m1);
        }

        public ActionResult getcompname()
        {
            company c = new company();
            List<companydata> c1 = c.getcompname();
            return Json(c1);
        }

        public ActionResult Invoice_Print(string invoiceid)
        {
            invoice v = new invoice();
            List<InvoicePrint> b = v.getInvoice(invoiceid);
            return Json(b, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteVendor(string vendorid)
        {
            vendor v = new vendor();
            bool b = v.delvendor(vendorid);
            return Json(b, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteMedicine(string medicineid)
        {
            medicine m = new medicine();
            bool b = m.DeleteMedicine(medicineid);
            
          
            return Json(b);
        }

        public ActionResult Invoice()
        {
            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Admin_login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 2)
                {
                    return View();
                }
                else
                {
                    return View("Admin_login");
                }
            }

        }

        public ActionResult ShowVendorDetails(string vendorid)
        {
            vendor v = new vendor();
            List<Vendor1> v2 = v.showvendordetails(vendorid);
            return Json(v2, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMedicineDetails(string batch)
        {
            medicine m = new medicine();
            List<MedicineDetails> mm = m.getmedicinedetails(batch);
            return Json(mm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowVendorCompanies(string vendorid)
        {
            vendor v = new vendor();
            List<map_vendor_company> v1 = v.showvendorcompanies(vendorid);
            return Json(v1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveUserdata(string name, string email, string phoneno)
        {
            user u = new user();
            bool b = u.insertuser(name, email, phoneno);
            string msg = "";
            if (b == true)
            {
                msg = "User Created Successfully";
            }
            else
            {
                msg = "Error.Please check the details ";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult GetUserDetails()
        {
            user u = new user();
            List<user> ud = u.GetUserDetails();
            return Json(ud, JsonRequestBehavior.AllowGet) ;
        }

        public ActionResult getMrp(string medid)
        {
            medicine m = new medicine();
            decimal mrp = m.getmrp(medid);
            return Json(mrp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getdetailsfromemail(string emailid)
        {
            user u=new user();
            List<user> l=u.getdetails(emailid);
            return Json(l,JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Login()
        //{
        //    return View();
            
        //}

     
        public ActionResult getbatchno(string medname)
        {

            medicine m = new medicine();
            List<MedicineDetails> m1 = m.batchno(medname);
            return Json(m1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Customershowinvoice()
        {

            DataSet ds = new DataSet();
            if (HttpContext.Session["UserSession"] == null)
            {
                return View("Login");
            }
            else
            {
                ds = (DataSet)HttpContext.Session["UserSession"];
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 1)
                {
                    return View();
                }
                else
                {
                    return View("Login");
                }
            }
        }

        public ActionResult SaveInvoiceInfo(string emailid, decimal totalamount, decimal discount, decimal amountafterDisountFinal,decimal profit_per_bill, string medDetails)
        {
            invoice i = new invoice();
            bool b = i.insertinvoice(emailid, totalamount, discount, amountafterDisountFinal,profit_per_bill, medDetails);
            string msg = "";
            if (b == true)
            {
                msg = "Invoice saved";
            }
            else
            {
                msg = "Error.Please check!";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);


        }
    }
}
