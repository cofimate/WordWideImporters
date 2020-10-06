using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WordWideImporters.Services
{
    public interface IWorldWideImporterTables 
    {
        //retrieve all data from the tables
        IListSource GetTableData(string tableName);
        //check if table exists
        bool TableExists(string tableName);
    }
}
