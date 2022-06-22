using System.Data;
using System.Data.OleDb;

namespace KYIV_CATALOG.AutoSchools
{
    public partial class AddAutoSchoolForm : Form
    {
        public AutoSchoolForm autoSchool;
        public AddAutoSchoolForm(AutoSchoolForm autoSchool)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.autoSchool = autoSchool;
            this.Text = "Додати/змінити дані у каталозі \"АВТОШКОЛИ\"";

            //Підказки
            toolTip1.SetToolTip(btnOK, "Ок");
            toolTip1.SetToolTip(btnCancel, "Відмінити");
            toolTip1.SetToolTip(cmbpropForm, "Оберіть форму власності автошколи");
            toolTip1.SetToolTip(txtName, "Введіть назву автошколи");
            toolTip1.SetToolTip(txtDirector, "Введіть ПІП директора автошколи");
            toolTip1.SetToolTip(txtAddress, "Введіть адресу автошколи");
            toolTip1.SetToolTip(cmbStatus, "Оберіть статус автошколи");
            toolTip1.SetToolTip(txtCost, "Введіть вартість навчання");

            //comboBox лише за читанням
            cmbpropForm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            if (autoSchool.AddOrChangeAuto == 2)
            {
                SelectData(autoSchool.KEY);
            }
        }

        //---МЕТОД ЗАПОВНЕННЯ ФОРМИ ЗМІНЮВАННИМИ ДАНИМИ---// 
        public void SelectData(int key)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM AutoSchools WHERE ID=" 
                + key + "", connection);
           
            connection.Open(); 
            adapter.SelectCommand.ExecuteNonQuery(); 
            connection.Close();

            DataTable T = new DataTable();
            adapter.Fill(T);

            cmbpropForm.Text = T.Rows[0].ItemArray[1].ToString();
            txtName.Text = T.Rows[0].ItemArray[2].ToString();
            txtDirector.Text = T.Rows[0].ItemArray[3].ToString();
            txtAddress.Text = T.Rows[0].ItemArray[4].ToString();

            txtPhone.Text = T.Rows[0].ItemArray[5].ToString();
            txtEmail.Text = T.Rows[0].ItemArray[6].ToString();
            txtSite.Text = T.Rows[0].ItemArray[7].ToString();
            cmbStatus.Text = T.Rows[0].ItemArray[8].ToString();

            //-----Відображення обраних категорій------//

            //Розбиваємо рядок із категоріями за символом ','
            string[] categories = T.Rows[0].ItemArray[9].ToString().Split(',');

            //Видаляємо зайві пробіли
            string[] NewCateg = new string[categories.Length]; 
            for (int i = 0; i < categories.Length; i++)
            {
                NewCateg[i] = categories[i].Trim();
            }
           
            NewCateg.CopyTo(categories, 0);  //Копіюємо масив

            //Обираємо необхідні checkBox
            for (int i = 0; i < categories.Length; i++)
            {
                if (categories[i] == "A") { check_A.Checked = true; }
                else
                {
                    if (categories[i] == "B") { check_B.Checked = true; }
                    else
                    {
                        if (categories[i] == "C") { check_C.Checked = true; }
                        else
                        {
                            if (categories[i] == "D") { check_D.Checked = true; }
                            else
                            {
                                if (categories[i] == "E") { check_E.Checked = true; }
                                else
                                {
                                    if (categories[i] == "T") { check_T.Checked = true; }
                                }
                            }
                        }
                    }
                }
            }

            EdTime.Value = Convert.ToInt32(T.Rows[0].ItemArray[10].ToString());
            DayGroups.Value = Convert.ToInt32(T.Rows[0].ItemArray[11].ToString());
            EvGroups.Value = Convert.ToInt32(T.Rows[0].ItemArray[12].ToString());
            txtCost.Text = T.Rows[0].ItemArray[13].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-----СТВОРЕННЯ ПІДКАЗОК-----//
        private void txtPhone_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть телефон автошколи, приклад:" +
                " \"+38 (067) 343 5658\"";
        }

        private void txtPhone_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть email, приклад: " +
                "\"ім`я_користувача@ім`я_домена.urk\"";
        }

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void txtSite_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть website, приклад: " +
                "\"www.ім`я_сайту.хост\"";
        }

        private void txtSite_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Для формування рядка категорій
            string categories = "";
            if (txtName.Text == "" || txtDirector.Text == "" || txtAddress.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Введено не всі дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (check_A.Checked == true) { categories += "A "; }
                if (check_B.Checked == true) { categories += "B "; }
                if (check_C.Checked == true) { categories += "C "; }
                if (check_D.Checked == true) { categories += "D "; }
                if (check_E.Checked == true) { categories += "E "; }
                if (check_T.Checked == true) { categories += "T "; }
                if (categories == "") { MessageBox.Show("Не обрано категорію!", "ПОМИЛКА",
                    MessageBoxButtons.OK); }

                else
                {
                    // Заміна пробілу на кому з пробілом у рядку
                    string k1 = categories.Replace(" ", ", ");
                    //Вирізаємо останню кому
                    string k2 = k1.Remove(k1.Length - 2, 1);
                    //Рядок categories містить обрані користувачем категорії
                    categories = k2;  

                    //Створюємо екземпляр класу AutoSchool і надаємо значення його полям
                    AutoSchool AutoSch = new(NewID(), cmbpropForm.SelectedItem.ToString(),
                        txtName.Text, txtDirector.Text, txtAddress.Text,
                        txtPhone.Text, txtEmail.Text, txtSite.Text,
                        cmbStatus.SelectedItem.ToString(), categories,
                        Convert.ToInt32(EdTime.Value), Convert.ToInt32(DayGroups.Value),
                        Convert.ToInt32(EvGroups.Value), Convert.ToSingle(txtCost.Text));

                    //Якщо AddOrChangeAuto == 1, то дані додаються
                    if (autoSchool.AddOrChangeAuto == 1)
                    {
                        AutoSch.AddAutoSchool();
                        MessageBox.Show("Вітаємо! Дані успішно додано", "ПОВІДОМЛЕННЯ", 
                            MessageBoxButtons.OK);
                        this.Close();
                    }

                    else
                    {
                        // Якщо AddOrChangeAuto == 2, то дані змінюються
                        if (autoSchool.AddOrChangeAuto == 2)
                        {
                            AutoSch.EditAutoSchool(autoSchool.KEY);
                            MessageBox.Show("Вітаємо! Дані успішно змінено!", "ПОВІДОМЛЕННЯ", 
                                MessageBoxButtons.OK);
                            this.Close();
                        }
                    }
                }
            }

        }

        //Пошук нового ID
        public int NewID()
        {
            int newID = 0;
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter con2 = new OleDbDataAdapter("SELECT MAX (ID) FROM AutoSchools", con1);

            con1.Open();  
            newID = Convert.ToInt32(con2.SelectCommand.ExecuteScalar());   
            newID++;
            con1.Close();

            return newID;
        }
    }
}

