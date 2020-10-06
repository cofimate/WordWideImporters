using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace WordWideImporters.Services
{
    public class WordWideImporterTableRepo : IWorldWideImporterTables
    {
        private WordWideImporterAdoContext _wwwAdoContext;

        public WordWideImporterTableRepo(WordWideImporterAdoContext wwwAdoContext)
        {
            _wwwAdoContext = wwwAdoContext;
        }
        public IListSource GetTableData(string tableName)
        {
            DataTable dt = new DataTable();


            using (SqlConnection conn = new SqlConnection(_wwwAdoContext.connectionString))
            {
                string sql = string.Format("select * from {0}", tableName);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
                dataAdapter.Fill(dt);

            }
            var Data = new List<DataTable>();

            return dt;
        }

        public IListSource GetTableDataPaginated(string tableName,int limit, int offset)
        {
            DataSet dt = new DataSet();

            using (SqlConnection conn = new SqlConnection(_wwwAdoContext.connectionString))
            {
                string sql = string.Format("select * from {0}", tableName);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
                dataAdapter.Fill(dt, offset, limit, tableName);

            }
       
            return dt;
        }

        public bool TableExists(string tableName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_wwwAdoContext.connectionString))
            {
                string sql = string.Format("select top 1 from {0}", tableName);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
                dataAdapter.Fill(dt);
            }

            var tableExists = (!dt.HasErrors) ? true : false;
            return tableExists;
        }
    }
}
