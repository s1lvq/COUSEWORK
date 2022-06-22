using System.Data;
using System.Data.OleDb;

namespace KYIV_CATALOG.Printery
{
    public partial class AddPrinteryForm : Form
    {
        public PrinteryForm print;
        public AddPrinteryForm(PrinteryForm print)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.print = print;
            this.Text = "Додати/змінити дані в каталозі \"ДРУКАРНІ\"";

            //Підказки
            toolTip1.SetToolTip(btnOK, "Ок");
            toolTip1.SetToolTip(btnCancel, "Відмінити");
            toolTip1.SetToolTip(cmbpropForm, "Оберіть форму власності друкарні");
            toolTip1.SetToolTip(txtName, "Назва друкарні");
            toolTip1.SetToolTip(txtDirector, "ПІП директора друкарні");
            toolTip1.SetToolTip(txtAddress, "Введіть адресу друкарні");
            toolTip1.SetToolTip(cmbStatus, "Оберіть статус друкарні");
            toolTip1.SetToolTip(txtCost, "Ціна за 1 лист А4");

            //ComboBox лише за читанням
            cmbpropForm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            if (print.AddOrChangePrint == 2)
            {
                SelectData(print.KEY);
            }
        }

        //--МЕТОД ДЛЯ ЗАПОВНЕННЯ ОБ`ЄКТІВ ЗМІНЮВАННИМИ ДАНИМИ--//
        public void SelectData(int key)
        {
            OleDbConnection connection = new("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new("SELECT * FROM Printery WHERE ID=" + key + "", connection);

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


            //Розбиваємо рядок із продукцією за символом ','
            string[] production = T.Rows[0].ItemArray[9].ToString().Split(',');

            //Видаляємо зайві пробіли
            string[] NewCateg = new string[production.Length];
            for (int i = 0; i < production.Length; i++)
            {
                NewCateg[i] = production[i].Trim();
            }

            //Копіюємо масив
            NewCateg.CopyTo(production, 0);

            //Обираємо необхідні checkBox
            for (int i = 0; i < production.Length; i++)
            {
                if (production[i] == "Візитки") { check_1.Checked = true; }
                else
                {
                    if (production[i] == "Флаєри") { check_2.Checked = true; }
                    else
                    {
                        if (production[i] == "Листівки") { check_3.Checked = true; }
                        else
                        {
                            if (production[i] == "Буклети") { check_4.Checked = true; }
                            else
                            {
                                if (production[i] == "Наліпки") { check_5.Checked = true; }
                                else
                                {
                                    if (production[i] == "Сертифікати") { check_6.Checked = true; }
                                }
                            }
                        }
                    }
                }
            }

            txtCost.Text = T.Rows[0].ItemArray[10].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Створення підказок
        private void txtPhone_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть телефон автошколи, приклад: \"+38 (067) 555 5555\"";
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
            //Для формування рядка продукції
            string production = "";
            if (txtName.Text == "" || txtDirector.Text == "" || txtAddress.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Введено не всі дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (check_1.Checked == true) { production += "Візитки "; }
                if (check_2.Checked == true) { production += "Флаєри "; }
                if (check_3.Checked == true) { production += "Листівки "; }
                if (check_4.Checked == true) { production += "Буклети "; }
                if (check_5.Checked == true) { production += "Наліпки "; }
                if (check_6.Checked == true) { production += "Сертифікати "; }
                if (production == "") { MessageBox.Show("Не обрано категорію", "ПОМИЛКА", MessageBoxButtons.OK); }

                else
                {
                    string k1 = production.Replace(" ", ", "); // Заміна в рядку пробіл на кому з пробілом
                    string k2 = k1.Remove(k1.Length - 2, 1); //Вирізаємо останню кому
                    production = k2;  //Рядок production містить вибрані користувачем категорії

                    //Створюємо екземпляр класу Printery і надаємо значення його полям
                    Printery Print = new(NewID(), cmbpropForm.SelectedItem.ToString(),
                        txtName.Text, txtDirector.Text, txtAddress.Text,
                        txtPhone.Text, txtEmail.Text, txtSite.Text,
                        cmbStatus.SelectedItem.ToString(), production,
                        Convert.ToSingle(txtCost.Text));

                    //Якщо AddOrChangePrint == 1, то додавання даних
                    if (print.AddOrChangePrint == 1)
                    {
                        Print.AddPrintery();
                        MessageBox.Show("Дані успішно додано", "ПОВІДОМЛЕННЯ", 
                            MessageBoxButtons.OK);
                        this.Close();
                    }

                    else
                    {
                        if (print.AddOrChangePrint == 2)
                        {
                            Print.EditPrintery(print.KEY);
                            MessageBox.Show("Дані успішно змінено", "ПОВІДОМЛЕННЯ", 
                                MessageBoxButtons.OK);
                            this.Close();
                        }
                    }         
                }
            }

        }

        //---МЕТОД ДЛЯ ПОШУКУ НОВОГО ID---//
        public int NewID()
        {
            int newID = 0;
            OleDbConnection con1 = new("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter con2 = new("SELECT MAX (ID) FROM Printery", con1);
            con1.Open();
            newID = Convert.ToInt32(con2.SelectCommand.ExecuteScalar());
            newID++;
            con1.Close();
            return newID;
        }
    }
}
