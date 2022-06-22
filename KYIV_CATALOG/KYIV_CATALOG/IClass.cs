using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KYIV_CATALOG
{
    public interface IClass
    {
        DataTable SelectData(string NameTable);
        bool CheckStatus(int id, string NameTable);
        void DeleteData(int id, string NameTable);
        DataTable FindName(string TableName, string search);
    }
}
