using System.Data;
using System.Data.OleDb;

namespace KYIV_CATALOG.EngSchool
{
    public partial class AddEngSchoolForm : Form
    {
        public EngSchoolForm engSchool;
        public AddEngSchoolForm(EngSchoolForm engSchool)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.engSchool = engSchool;
            this.Text = "Додати/змінити дані у каталозі \"ШКОЛА АНГЛІЙСЬКОЇ МОВИ\"";

            //Підказки
            toolTip1.SetToolTip(btnOK, "Ок");
            toolTip1.SetToolTip(btnCancel, "Відмінити");
            toolTip1.SetToolTip(cmbpropForm, "Оберіть форму власності школи");
            toolTip1.SetToolTip(txtName, "Назва школи");
            toolTip1.SetToolTip(txtDirector, "ПІП директора школи");
            toolTip1.SetToolTip(txtAddress, "Введіть адресу школи");
            toolTip1.SetToolTip(cmbStatus, "Оберіть статус школи");
            toolTip1.SetToolTip(txtCost, "Вартість навчання за місяць");

            //ComboBox лише за читанням
            cmbpropForm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            if (engSchool.AddOrChangeEng == 2)
            {
                SelectData(engSchool.KEY);
            }
        }

        //--МЕТОД ДЛЯ ЗАПОВНЕННЯ ОБ'ЄКТІВ ЗМІНЮВАННИМИ ДАНИМИ--//
        public void SelectData(int key)
        {
            OleDbConnection connection = new("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new("SELECT * FROM EngSchools WHERE ID=" + key + "", connection);

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

            //Відображення обраних рівнів

            //Розбиваємо рядок із рівнями за символом ','
            string[] levels = T.Rows[0].ItemArray[9].ToString().Split(',');

            //Видаляємо зайві пробіли
            string[] NewLevel = new string[levels.Length];
            for (int i = 0; i < levels.Length; i++)
            {
                NewLevel[i] = levels[i].Trim();
            }

            //Копіюємо масив
            NewLevel.CopyTo(levels, 0);

            //Обираємо необхідні checkBox
            for (int i = 0; i < levels.Length; i++)
            {
                if (levels[i] == "A1") { check_A1.Checked = true; }
                else
                {
                    if (levels[i] == "A2") { check_A2.Checked = true; }
                    else
                    {
                        if (levels[i] == "B1") { check_B1.Checked = true; }
                        else
                        {
                            if (levels[i] == "B2") { check_B2.Checked = true; }
                            else
                            {
                                if (levels[i] == "C1") { check_C1.Checked = true; }
                                else
                                {
                                    if (levels[i] == "C2") { check_C2.Checked = true; }
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

        //-----Створення підказок-----//
        private void txtPhone_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть телефон автошколи, приклад: \"+38 (067) 575 5995\"";
        }

        private void txtPhone_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть email, приклад: \"ім`я_користувача@ім`я_домена.urk\"";
        }

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void txtSite_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть website, приклад: \"www.ім`я_сайту.хост\"";
        }

        private void txtSite_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Для формування рядка рівнів мови
            string levels = "";
            if (txtName.Text == "" || txtDirector.Text == "" || txtAddress.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Введено не всі дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (check_A1.Checked == true) { levels += "A1 "; }
                if (check_A2.Checked == true) { levels += "A2 "; }
                if (check_B1.Checked == true) { levels += "B1 "; }
                if (check_B2.Checked == true) { levels += "B2 "; }
                if (check_C1.Checked == true) { levels += "C1 "; }
                if (check_C2.Checked == true) { levels += "C2 "; }
                if (levels == "") { MessageBox.Show("Не обрано категорію", "ПОМИЛКА", MessageBoxButtons.OK); }

                else
                {
                    string k1 = levels.Replace(" ", ", "); // Заміна в рядку пробіл на кому з пробілом
                    string k2 = k1.Remove(k1.Length - 2, 1);  //Вирізаємо останню кому
                    levels = k2;  //Рядок levels містить вибрані користувачем рівні

                    //Створюємо екземпляр класу AutoSchool і надаю значення його полям
                    EngSchool EngSch = new(NewID(), cmbpropForm.SelectedItem.ToString(),
                        txtName.Text, txtDirector.Text, txtAddress.Text,
                        txtPhone.Text, txtEmail.Text, txtSite.Text,
                        cmbStatus.SelectedItem.ToString(), levels,
                        Convert.ToInt32(EdTime.Value), Convert.ToInt32(DayGroups.Value),
                        Convert.ToInt32(EvGroups.Value), Convert.ToSingle(txtCost.Text));

                    //Якщо AddOrChangeAuto == 1, то дані додаються
                    if (engSchool.AddOrChangeEng == 1)
                    {
                        EngSch.AddEngSchool();
                        MessageBox.Show("Дані успішно додано", "ПОВІДОМЛЕННЯ", 
                            MessageBoxButtons.OK);
                        this.Close();
                    }

                    else
                    {
                        if (engSchool.AddOrChangeEng == 2)
                        {
                            EngSch.EditEngSchool(engSchool.KEY);
                            MessageBox.Show("Дані успішно змінено", "ПОВІДОМЛЕННЯ", 
                                MessageBoxButtons.OK);
                            this.Close();
                        }
                    }
                }
            }      
        }

        //Знаходимо новий ID
        public int NewID()
        {
            int newID = 0;
            OleDbConnection con1 = new("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter con2 = new("SELECT MAX (ID) FROM EngSchools", con1);
            con1.Open();
            newID = Convert.ToInt32(con2.SelectCommand.ExecuteScalar());
            newID++;
            con1.Close();
            return newID;
        }


    }
}
