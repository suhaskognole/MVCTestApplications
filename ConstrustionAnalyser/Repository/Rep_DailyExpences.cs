using ConstrustionAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConstrustionAnalyser.Repository
{
    public class Rep_DailyExpences
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }


        /// <summary>
        ///To view expences details with generic list  
        /// </summary>
        /// <returns></returns>
        public List<DailyExpences> GetAllExpences()
        {
            connection();
            List<DailyExpences> ExpencesList = new List<DailyExpences>();
            SqlCommand com = new SqlCommand("GetDailyExpences", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind expences generic list using LINQ 
            ExpencesList = (from DataRow dr in dt.Rows
                            select new DailyExpences()
                       {
                           DailyExpencesId = Convert.ToInt32(dr["DailyExpencesId"]),
                           expencesAmount = Convert.ToDouble(dr["ExpencesAmount"]),
                           expenceDescription = Convert.ToString(dr["ExpenceDescription"]),
                           expenceDate = Convert.ToDateTime(dr["ExpenceDate"]),
                           remark = Convert.ToString(dr["Remark"])
                       }).ToList();

            return ExpencesList;
        }


        //To Add Daily Expences Details.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddDailyExpences(DailyExpences obj)
        {
            connection();
            SqlCommand com = new SqlCommand("USP_InsertDailyExpenceDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Amount", obj.expencesAmount);
            com.Parameters.AddWithValue("@Description", obj.expenceDescription);
            com.Parameters.AddWithValue("@Date", obj.expenceDate);
            com.Parameters.AddWithValue("@Remark", obj.remark);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //To Update Daily Expences details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateExpence(DailyExpences obj)
        {
            connection();
            SqlCommand com = new SqlCommand("USP_UpdateDailyExpenceDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Amount", obj.expencesAmount);
            com.Parameters.AddWithValue("@Description", obj.expenceDescription);
            com.Parameters.AddWithValue("@Date", obj.expenceDate);
            com.Parameters.AddWithValue("@Remark", obj.remark);
            com.Parameters.AddWithValue("@ExpenceId", obj.DailyExpencesId);
            com.Parameters.AddWithValue("@UpdateCondition", "1=1");

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //To delete Daily Expences details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExpenceId"></param>
        /// <returns></returns>
        public bool DeleteExpence(int ExpenceId)
        {
            connection();
            SqlCommand com = new SqlCommand("USP_DelTblDailyExpences", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExpencesId", ExpenceId);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //To Get specific Daily Expences details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenceId"></param>
        /// <returns></returns>
        public DailyExpences GetExpence(int expenceId)
        {
            connection();
            DailyExpences expences = new DailyExpences();
            SqlCommand com = new SqlCommand("GetDailyExpencesById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", expenceId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                //Bind expences generic list using LINQ 
                expences.DailyExpencesId = Convert.ToInt32(dt.Rows[0]["DailyExpencesId"]);
                expences.expencesAmount = Convert.ToDouble(dt.Rows[0]["ExpencesAmount"]);
                expences.expenceDescription = Convert.ToString(dt.Rows[0]["ExpenceDescription"]);
                expences.expenceDate = Convert.ToDateTime(dt.Rows[0]["ExpenceDate"]);
                expences.remark = Convert.ToString(dt.Rows[0]["Remark"]);
            }

            return expences;
        }

    }
}