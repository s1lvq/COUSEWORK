using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace KYIV_CATALOG
{
    class BaseClass: IClass
    {
        //з`єднання з базою даних
        public string AccessConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; " +
            "Data Source = Directory.mdb";

        //--Поля базового класy--//
        public int Id { get; set; } //ключ сутностей
        public string PropertyForm { get; set; } 
        public string Name { get; set; }
        public string Director { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Status { get; set; }


        //--Конструктори--//
        public BaseClass(int id, string propForm, string name, 
            string director, string address, string phoneNum,
            string email, string webSite, string status)
        {
            this.Id = id;
            this.PropertyForm = propForm;
            this.Name = name;
            this.Director = director;
            this.Address = address;
            this.PhoneNumber = phoneNum;
            this.Email = email;
            this.WebSite = webSite;
            this.Status = status;
        }

        public BaseClass() { }

        //--МЕТОД ДЛЯ ВИБОРУ ДАНИХ ІЗ БД--//
        public DataTable SelectData(string NameTable)
        {
            OleDbConnection Connection = new OleDbConnection(AccessConnectionString);
            OleDbDataAdapter Adapter = new OleDbDataAdapter("SELECT * FROM " + NameTable + "", Connection);
            Connection.Open();
            Adapter.SelectCommand.ExecuteNonQuery();
            Connection.Close();
            DataTable T = new DataTable();
            Adapter.Fill(T);
            return T;
        }


        //--МЕТОД ПЕРЕВІРКИ СТАТУСА ПІДПРИЄМСТВА--//
        public bool CheckStatus(int id, string NameTable)
        {
            OleDbConnection con = new OleDbConnection(AccessConnectionString);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Status FROM " + NameTable
                + " WHERE ID=" + id + "", con);
            con.Open();
            string Tekushiystatus = adapter.SelectCommand.ExecuteScalar().ToString();
            con.Close();
            if (Tekushiystatus == "Працює") { return true; }
            else { return false; }
        }

        //Метод для перевірки номера телефону
        public bool CheckPhoneNumber(string phoneNum)
        {
            Regex TempRegex = new Regex(@"^+38 [(][0-9][0-9][0-9][)] [0-9][0-9][0-9] [0-9][0-9][0-9][0-9]$");
            if (TempRegex.IsMatch(phoneNum) == false)
            {
                //IncorrectValue(Fields.PhoneNumber);
                return false;
            }
            else { return true; }
        }


        //--МЕТОД ВИДАЛЕННЯ ДАНИХ ІЗ БД--//
        public void DeleteData(int id, string NameTable)
        {
            OleDbConnection connection = new(AccessConnectionString);
            OleDbDataAdapter adapter = new("DELETE * FROM " + NameTable + " WHERE ID=" + id + "", connection);
            connection.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }


        //--МЕТОД ПОШУКУ ПІДПРИЄМСТВА ПО НАЗВІ--//
        public DataTable FindName(string TableName, string search)
        {
            OleDbConnection connection = new OleDbConnection(AccessConnectionString);
            OleDbDataAdapter adapter;

            if (TableName == "AutoSchools")
            {
                adapter = new OleDbDataAdapter("SELECT Name,Director,Categories," +
                    "Address,PhoneNumber,Cost,Status FROM AutoSchools WHERE Name Like'%" + search + "%'", connection);
            }
            else if(TableName == "EngSchools")
            {
                adapter = new OleDbDataAdapter("SELECT Name,Director,Levels," +
                    "Address,PhoneNumber,Cost,Status FROM EngSchools WHERE Name Like'%" + search + "%'", connection);
            }
            else if (TableName == "Printery")
            {
                adapter = new OleDbDataAdapter("SELECT Name,Director,Production," +
                   "Address,PhoneNumber,Cost,Status FROM Printery WHERE Name Like'%" + search + "%'", connection);
            }
            else 
            {
                adapter = new OleDbDataAdapter("SELECT Name,Director," +
                  "Address,PhoneNumber,Status,Cost FROM KinderGarden WHERE Name Like'%" + search + "%'", connection);
            }

            connection.Open(); 
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();

            DataTable dataTable = new DataTable(); 
            adapter.Fill(dataTable);

            return dataTable;
        }

    
    
        
    
    
    }  
}

/*//Метод для перевірки номера телефону
         public bool CheckPhoneNumber(string phoneNum)
         {
             Regex TempRegex = new Regex(@"^+38 [(]0-9[)] [0-9][0-9][0-9] [0-9][0-9][0-9][0-9]$");
             if (TempRegex.IsMatch(phoneNum) == false)
             {
                 //IncorrectValue(Fields.PhoneNumber);
                 return false;
             }
             else { return true; }
         }

         //Метод для перевірки Email
         public bool CheckEmail(string email)
         {
             Regex TempRegex = new Regex(@"[A-Za-z0-9_-]+[@][A-Za-z0-9_-]+[.][a-z]+");
             if (TempRegex.IsMatch(email) == false && email!="" && email!="null")
             {
                 //IncorrectValue(Fields.Email);
                 return false;
             }
             else { return true;}
         }

         //Метод для перевірки сайта
         public bool CheckSite(string site)
         {
             Regex TempRegex = new Regex(@"www.[a-zA-Z0-9_-]+[.][a-z]+");
             if ((TempRegex.IsMatch(site)) == false && (site != "") && (site != "null"))
             {
                 //IncorrectValue(Fields.WebSite);
                 return false;
             }
             else { return true; }
         }*/




//Метод для перевірки адреса
/*public bool CheckAddress(string address)
 {
     Regex TempRegex = new Regex(@"[А-Яа-я] ^p-н. +, [А-Яа-я 0-9]+ д. [1-9][0-9]*, кв. [1-9][0-9]*$");
     if (TempRegex.IsMatch(address) == false)
     {
         //IncorrectValue(Fields.Address);
         return false;
     }
     else { return true; }
 }*/

