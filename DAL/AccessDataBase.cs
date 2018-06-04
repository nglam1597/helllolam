using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 
namespace DAL
{
    public class AccessDataBase
    {
        protected SqlConnection sqlConnection = null; 
        protected string strConection = "Data Source=DESKTOP-APPIPM7;Initial Catalog=HeThongQuanLyBanHang;Integrated Security=True"; 
        public void OpenDataBase()
        {
            if(sqlConnection == null)
            {
                sqlConnection = new SqlConnection(strConection); 
            }
            if(sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open(); 
            }
        }
        public void CloseDataBase()
        {
            if(sqlConnection!=null && sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Close(); 
            }
        }
            
    }
}
