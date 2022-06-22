using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYIV_CATALOG.KinderGarden
{
    class KinderGarden : BaseClass
    {
        //Поля класа KinderGarden
        public int GroupsNumber { get; set; }
        public float Cost { get; set; }

        //Конструктори
        public KinderGarden() { }
        public KinderGarden(int b, string b1, string b2, string b3,
            string b4, string b5,  string b6, string b7, string b8,
            int groupsNumber, float cost)
            : base(b, b1, b2, b3, b4, b5, b6, b7, b8)
        {
            this.GroupsNumber = groupsNumber;
            this.Cost = cost;
        }

        //--МЕТОД ДЛЯ ДОДАВАННЯ ДИТСАДКА--//
        public void AddKinderGarden()
        {
            OleDbConnection connection = new ("Provider = Microsoft.Jet.OLEDB.4.0;" + 
                "Data Source = Directory.mdb");
            OleDbDataAdapter adapter = new("INSERT INTO KinderGarden VALUES(" + this.Id + ",'" + this.PropertyForm +
                             "','" + this.Name + "','" + this.Director + "','" + this.Address + "','" + this.PhoneNumber
                             + "','" + this.Email + "','" + this.WebSite + "','" + this.Status + "'," + this.GroupsNumber + "," + this.Cost + ")", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        //--МЕТОД ДЛЯ РЕДАГУВАННЯ ДАНИХ ДИТСАДКА--//
        public void EditKinderGarden(int key)
        {
            OleDbConnection connection = new("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new ("UPDATE KinderGarden SET PropertyForm='" + this.PropertyForm + "',Name='"
                            + this.Name + "',Director='" + this.Director + "',Address='" + this.Address + "',PhoneNumber='" + this.PhoneNumber + "',Email='" + this.Email + "',WebSite='"
                            + this.WebSite + "',Status='" + this.Status + "',GroupNumber=" + this.GroupsNumber + ",Cost=" + this.Cost + " WHERE ID=" + key + "", connection);

            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }


        //--МЕТОД ДЛЯ ПОШУКУ ДИТСАДКА ПО ВАРТОСТІ ВІДВІДУВАННЯ--//
        public DataTable CostSearching(float min, float max)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Name,Director," +
                "Address,PhoneNumber,Status,Cost FROM KinderGarden where Cost >= " + min + " and Cost <= " + max + "", connection);
            
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

    }
}
