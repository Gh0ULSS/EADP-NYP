using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using System.Linq;
using System.Web;
using Project.Entity_Layer;

namespace Project.Data_Access_Layer
{
    public class JobDAO
    {

        public Details RetrieveDataBySelectedDate(DateTime selectedDate)  //should be done by date selected 
        {
            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType, Job_StartDate, Job_EndDate");
            sqlCommand.AppendLine("From JobsDB");
            sqlCommand.AppendLine("Where Job_StartDate = @paraStartDate AND user_Id = " + HttpContext.Current.Session["Id"]);
            // test with session variable (PASS)

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraStartDate", selectedDate);
            da.Fill(ds, "Job");
         
            // Instantiate a detail object
            Details detail = new Details();

            try
            {
                DataRow row = ds.Tables["Job"].Rows[0]; // get first row (error)

                // store database data into object
                detail.Job_Name = row["Job_Name"].ToString();
                detail.Job_Type = row["Job_Categ"].ToString();
                detail.Payment_Amount = (decimal)row["Job_PayRate"];
                detail.Pay_Type = row["Job_PayType"].ToString();
                detail.Start_Date = (DateTime)row["Job_StartDate"];
                detail.End_Date = (DateTime)row["Job_EndDate"];
            }
            catch
            {
                detail = null;
            }

            // close the connection
            myConn.Close();

            return detail;

        } 

        public List<jobhistory> RetrieveJobHistory()
        {
            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND user_Id = " +HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {
                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory();

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;


        }

        public List<Payments> GetDuePayments()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_PayRate, Job_EndDate ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_EndDate < GETDATE() AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<Payments> payments = new List<Payments>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a Payments object
                    Payments pay = new Payments(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    pay.Job_Name = row["Job_Name"].ToString();
                    pay.Payment_Amount = (decimal)row["Job_PayRate"]; 
                    pay.End_Date = (DateTime)row["Job_EndDate"];
                    payments.Add(pay);

                }

            }
            catch
            {
               payments = null;
            }

            // close the connection
            myConn.Close();

            return payments ;

        }

        public List<date> getDate()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_StartDate ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<date> dates = new List<date>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {
                    // Instantiate the date object
                    date d = new date();

                    d.Start_Date = (DateTime)row["Job_StartDate"];
                    dates.Add(d);
                   

                }

            }
            catch
            {
                dates = null;
            }

            myConn.Close();

            return dates ;

        }

        public List<Payments> GetDuePaymentsHourly()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_PayRate, Job_EndDate ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_EndDate < GETDATE() AND user_Id = " + HttpContext.Current.Session["Id"] + " AND Job_PayType LIKE 'Per Hour' ");

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<Payments> payments = new List<Payments>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a Payments object
                    Payments pay = new Payments(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    pay.Job_Name = row["Job_Name"].ToString();
                    pay.Payment_Amount = (decimal)row["Job_PayRate"];
                    pay.End_Date = (DateTime)row["Job_EndDate"];
                    payments.Add(pay);

                }

            }
            catch
            {
                payments = null;
            }

            // close the connection
            myConn.Close();

            return payments;

        }

        public List<Payments> GetDuePaymentsMonthly()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_PayRate, Job_EndDate ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_EndDate < GETDATE() AND user_Id = " + HttpContext.Current.Session["Id"] + " AND Job_PayType LIKE 'Per Month' ");

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<Payments> payments = new List<Payments>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a Payments object
                    Payments pay = new Payments(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    pay.Job_Name = row["Job_Name"].ToString();
                    pay.Payment_Amount = (decimal)row["Job_PayRate"];
                    pay.End_Date = (DateTime)row["Job_EndDate"];
                    payments.Add(pay);

                }

            }
            catch
            {
                payments = null;
            }

            // close the connection
            myConn.Close();

            return payments;

        }


        public List<jobhistory> RetrieveJobHistoryHourly()
        {
            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_PayType LIKE 'Per Hour' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {
                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;
        }

        public List<jobhistory> RetrieveJobHistoryMonthly()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_PayType LIKE 'Per Month' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {
                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryRetail()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Retail' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {
                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;
        }

        public List<jobhistory> RetrieveJobHistoryLogistics()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Logistics' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {
                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryMarketing()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Marketing' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryService()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Service' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryFoodandBeverage()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Food & Beverage' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryEngineering()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Engineering' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryMedicine()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Medicine' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryIT()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'IT' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

        public List<jobhistory> RetrieveJobHistoryOther()
        {

            //Get connection string from web.config
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Create connection to database
            SqlConnection myConn = new SqlConnection(DBConnect);

            // open the connection
            myConn.Open();

            // Create DataAdapter and DataSet
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Define Sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("Select Job_Name, Job_Categ, Job_PayRate, Job_PayType , Job_StartDate, Job_EndDate, Job_Status ");
            sqlCommand.Append("From JobsDB ");
            sqlCommand.Append("Where Job_Status LIKE 'Ended' AND Job_Categ LIKE 'Other' AND user_Id = " + HttpContext.Current.Session["Id"]);

            // Execute Sql statement and fill data set 
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "Job");

            // Instantiate a List to store the object
            List<jobhistory> historylist = new List<jobhistory>();

            try
            {

                foreach (DataRow row in ds.Tables["Job"].Rows)
                {

                    // Instantiate a jobhistory object
                    jobhistory History = new jobhistory(); // place here as object needs to be created for every row of data in database

                    // store database data into object
                    History.Job_Name = row["Job_Name"].ToString();
                    History.Job_Type = row["Job_Categ"].ToString();
                    History.Payment_Amount = (decimal)row["Job_PayRate"];
                    History.Pay_Type = row["Job_PayType"].ToString();
                    History.Start_Date = (DateTime)row["Job_StartDate"];
                    History.End_Date = (DateTime)row["Job_EndDate"];
                    History.Active_Status = row["Job_Status"].ToString();
                    historylist.Add(History);

                }

            }
            catch
            {
                historylist = null;
            }

            // close the connection
            myConn.Close();

            return historylist;

        }

    }
}