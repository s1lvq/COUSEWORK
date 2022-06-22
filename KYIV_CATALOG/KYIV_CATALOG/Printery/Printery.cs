using System.Data;
using System.Data.OleDb;

namespace KYIV_CATALOG.Printery
{
    class Printery : BaseClass
    {
        //Поля класа Printery
        public string Production { get; set; }
        public float Cost { get; set; }


        //Конструктори
        public Printery() { }
        public Printery(int b, string b1, string b2, string b3,
            string b4, string b5, string b6, string b7, string b8,
            string production, float cost)
            : base(b, b1, b2, b3, b4, b5, b6, b7, b8)
        {
            this.Production = production;
            this.Cost = cost;
        }

        //--МЕТОД ДЛЯ ДОДАВАННЯ ДРУКАРНІ--//

        public void AddPrintery()
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = Directory.mdb");
            OleDbDataAdapter adapter = new("INSERT INTO Printery VALUES(" + this.Id + ",'" + this.PropertyForm +
                             "','" + this.Name + "','" + this.Director + "','" + this.Address + "','" + this.PhoneNumber
                             + "','" + this.Email + "','" + this.WebSite + "','" + this.Status + "','" + this.Production + "'," + this.Cost + ")", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        //--МЕТОД ДЛЯ РЕДАГУВАННЯ ДРУКАРНІ--//

        public void EditPrintery(int key)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");

            OleDbDataAdapter adapter = new OleDbDataAdapter("UPDATE Printery SET PropertyForm='" + this.PropertyForm + "',Name='"
                           + this.Name + "',Director='" + this.Director + "',Address='" + this.Address + "',PhoneNumber='" + this.PhoneNumber + "',Email='"
                           + this.Email + "',WebSite='" + this.WebSite + "',Status='" + this.Status + "',Production='" + this.Production + "',Cost=" + this.Cost +
                           " WHERE ID=" + key + "", connection);

            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }


        //--МЕТОД ДЛЯ ПОШУКУ ДРУКАРНІ ПО ЦІНІ ПРОДУКЦІЇ--//
        public DataTable CostSearching(float min, float max)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Name,Director,Production," +
                "Address,PhoneNumber,Cost,Status FROM Printery where Cost >= " + min + " and Cost <= "
                + max + "", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
