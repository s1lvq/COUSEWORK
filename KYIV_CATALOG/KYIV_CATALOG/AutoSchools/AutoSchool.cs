using System.Data;
using System.Data.OleDb;

namespace KYIV_CATALOG
{
    class AutoSchool : BaseClass
    {
        //Поля класа AutoSchool
        public string Categories { get; set; }
        public int EducationTime { get; set; }
        public int DayGroups { get; set; }
        public int EveningGroups { get; set; }
        public float Cost { get; set; }

        //Конструктори
        public AutoSchool() {}
        public AutoSchool(int b, string b1, string b2, string b3,
               string b4, string b5, string b6, string b7, string b8,
               string categories, int edTime, int dayGroups, int evGroups, float cost)
               : base(b, b1, b2, b3, b4, b5, b6, b7, b8)
        {
            this.Categories = categories;
            this.EducationTime = edTime;
            this.DayGroups = dayGroups;
            this.EveningGroups = evGroups;
            this.Cost = cost;
        }

        //--МЕТОД ДЛЯ ДОДАВАННЯ АВТОШКОЛИ--//
        public void AddAutoSchool()
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Directory.mdb");
            OleDbDataAdapter adapter = new("INSERT INTO AutoSchools VALUES(" + this.Id + ",'" + this.PropertyForm +
                             "','" + this.Name + "','" + this.Director + "','" + this.Address + "','" + this.PhoneNumber
                             + "','" + this.Email + "','" + this.WebSite + "','" + this.Status + "','" + this.Categories
                             + "'," + this.EducationTime + "," + this.DayGroups + "," + this.EveningGroups + "," + this.Cost + ")", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        //--МЕТОД ДЛЯ РЕДАГУВАННЯ ДАНИХ АВТОШКОЛИ--//
        public void EditAutoSchool(int key)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            
            OleDbDataAdapter adapter = new OleDbDataAdapter("UPDATE AutoSchools SET PropertyForm='" + this.PropertyForm + "',Name='"
                           + this.Name + "',Director='" + this.Director + "',Address='" + this.Address + "',PhoneNumber='" + this.PhoneNumber + "',Email='" 
                           + this.Email + "',WebSite='" + this.WebSite + "',Status='" + this.Status + "',Categories='" + this.Categories + "',EducationTime="
                           + this.EducationTime + ",DayGroups=" + this.DayGroups + ",EveningGroups=" + this.EveningGroups + ",Cost=" + this.Cost +
                           " WHERE ID=" + key + "", connection);
            
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }


        //--МЕТОД ПОШУКА АВТОШКОЛИ ПО ЦІНІ --//
        public DataTable CostSearching(float min, float max)
        {
            OleDbConnection connection = new ("Provider = Microsoft.Jet.OLEDB.4.0; Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new ("SELECT Name,Director,Categories," +
                "Address,PhoneNumber,Cost,Status FROM AutoSchools where Cost >= " + min + " and Cost <= "
                + max + "", connection);

            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();

            DataTable dataTable = new ();
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
