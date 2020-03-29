using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System;
//using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MVC_Dapper_DEMO.Models;
using Dapper;
//using System.Linq;

namespace MVC_Dapper_DEMO.Repository
{
    public class EmpRepository
    {

        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            //string StringConnex = @"Data Source=CROSAS2\SQLEXPRESS;Initial Catalog=crosas2016;Integrated Security=SSPI;";
            //string StringConnex = @"Data Source=DESKTOP-BVN4UMD\SQLEXPRESS;Initial Catalog=crosas2016;Integrated Security=SSPI;";
            string StringConnex = @"Data Source=DESKTOP-BVN4UMD\SQLEXPRESS;Initial Catalog=crosas2016;User ID=user;Password=user";
            con = new SqlConnection(StringConnex);
        }
        //To Add Employee details
        public void AddEmployee(EmpModel objEmp)
        {
            //Additing the employess
            try
            {
                connection();
                con.Open();
                con.Execute("AddNewEmpDetails", objEmp, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To view employee details with generic list 
        public List<EmpModel> GetAllEmployees()
        {
            try
            {
                connection();
                con.Open();
                IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(
                                  con, "GetEmployees").ToList();
                con.Close();
                return EmpList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To Update Employee details
        public void UpdateEmployee(EmpModel objUpdate)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateEmpDetails", objUpdate, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To delete Employee details
        public bool DeleteEmployee(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", Id);
                connection();
                con.Open();
                con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need 
                throw ex;
            }
        }
    }
}