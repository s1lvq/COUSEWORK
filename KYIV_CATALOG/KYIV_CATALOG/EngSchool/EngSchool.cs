using System.Data;
using System.Data.OleDb;


namespace KYIV_CATALOG.EngSchool
{
    class EngSchool : BaseClass
    {
        //Поля класа EngSchool
        public string Levels { get; set; }
        public int EducationTime { get; set; }
        public int DayGroups { get; set; }
        public int EveningGroups { get; set; }
        public float Cost { get; set; }

        //Конструктори
        public EngSchool() { }
        public EngSchool(int b, string b1, string b2, string b3,
            string b4, string b5, string b6, string b7, string b8,
            string levels, int edtime, int daygroups, int evgroups, float cost)
            : base(b, b1, b2, b3, b4, b5, b6, b7, b8)
        {
            this.Levels = levels;
            this.EducationTime = edtime;
            this.DayGroups = daygroups;
            this.EveningGroups = evgroups;
            this.Cost = cost;
        }

        //--МЕТОД ДЛЯ ДОДАВАННЯ ШКОЛИ--//
        public void AddEngSchool()
        {
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Directory.mdb");
            OleDbDataAdapter adapter = new("INSERT INTO EngSchools VALUES(" + this.Id + ",'" + this.PropertyForm 
                             + "','" + this.Name + "','" + this.Director + "','" + this.Address + "','" + this.PhoneNumber
                             + "','" + this.Email + "','" + this.WebSite + "','" + this.Status  + "','" + this.Levels + "'," 
                             + this.EducationTime +  "," + this.DayGroups + "," + this.EveningGroups + "," + this.Cost + ")", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        //--МЕТОД ДЛЯ РЕДАГУВАННЯ ДАНИХ ШКОЛИ--//
        public void EditEngSchool(int key)
        {
            OleDbConnection connection = new("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Directory.mdb");

            OleDbDataAdapter adapter = new OleDbDataAdapter("UPDATE EngSchools SET PropertyForm='" + this.PropertyForm + "',Name='"
                            + this.Name + "',Director='" + this.Director + "',Address='" + this.Address + "',PhoneNumber='" + this.PhoneNumber + "',Email='" 
                            + this.Email + "',WebSite='" + this.WebSite + "',Status='" + this.Status + "',Levels='" + this.Levels + "',EducationTime=" 
                            + this.EducationTime + ",DayGroups=" + this.DayGroups + ",EveningGroups=" + this.EveningGroups + ",Cost=" + this.Cost 
                            + " WHERE ID=" + key + "", connection);

            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }


        //--МЕТОД ДЛЯ ПОШУКУ ШКОЛИ ПО ВАРТОСТІ НАВЧАННЯ--//
        public DataTable CostSearching(float min, float max)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Name,Director," +
                "Address,PhoneNumber,Cost,Status FROM EngSchools where Cost >= " + min + " and Cost <= "
                + max + "", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }


        //--МЕТОД ДЛЯ ПОШУКУ ШКОЛИ ПО РАЙОНУ--//
        public List<int> FindRegion(string search)
        {
            List<int> Rez = new();
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT ID,Address FROM EngSchools", connection);

            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string A = dataTable.Rows[i].ItemArray[1].ToString();
                string[] B = A.Split(',');
                string C = B[0];
                string D = C.Remove(0, 3);

                D = D.ToLower();
                search = search.ToLower();
                int index = D.IndexOf(search); if (index != -1)
                {
                    Rez.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
                }
            }

            return Rez;
        }

        //--МЕТОД ВИБОРУ РЯДКІВ ЗА ID--//
        public DataTable SelectFromID(List<int> search)
        {
            DataTable T = new DataTable();
            for (int i = 0; i < search.Count; i++)
            {
                OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Directory.mdb");
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Name,Director,Address,PhoneNumber," +
                    "Cost,Status FROM EngSchools WHERE ID = " + search[i] + "", connection);
                connection.Open(); adapter.SelectCommand.ExecuteNonQuery(); connection.Close(); adapter.Fill(T);
            }
            return T;
        }

    }
}
