using System.Data;
using System.Data.OleDb;

namespace KYIV_CATALOG.KinderGarden
{
    public partial class AddKinderGardenForm : Form
    {
        public KinderGardenForm kinderGarden;
        public AddKinderGardenForm(KinderGardenForm kinderGarden)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.kinderGarden = kinderGarden;
            this.Text = "Додати/змінити дані у каталозі \"ПРИВАТНИЙ ДИТСАДОК\"";

            //Підказки
            toolTip1.SetToolTip(btnOK, "Ок");
            toolTip1.SetToolTip(btnCancel, "Відмінити");
            toolTip1.SetToolTip(txtName, "Назва приватного дитсадка");
            toolTip1.SetToolTip(txtDirector, "ПІП директора дитсадка");
            toolTip1.SetToolTip(txtAddress, "Введіть адресу дитсадка");
            toolTip1.SetToolTip(cmbStatus, "Оберіть статус дитсадка");
            toolTip1.SetToolTip(txtCost, "Вартість відвідування за місяць");

            //Роблю comboBox лише за читанням
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            if (kinderGarden.AddOrChangeKinder == 2)
            {
                SelectData(kinderGarden.KEY);
            }
        }

        //Заповнення об`єктів форми змінюванними даними 
        public void SelectData(int key)
        {
            OleDbConnection connection = new("Provider=Microsoft.Jet.OLEDB.4.0; " +
                "Data Source=Directory.mdb");
            OleDbDataAdapter adapter = new("SELECT * FROM KinderGarden WHERE ID=" + key + "", connection);

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

            GroupsNumber.Value = Convert.ToInt32(T.Rows[0].ItemArray[9].ToString());
            txtCost.Text = T.Rows[0].ItemArray[10].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-----Створення підказок-----//
        private void txtPhone_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть телефон автошколи";
            //приклад: \"+38 (067) 555 5555\"";
        }

        private void txtPhone_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть email, приклад: ім`я_користувача@ім`я_домена.urk";
            //пример: \"имя_пользователя@имя_домена.ru\"";
        }

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void txtSite_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Введіть website, приклад: www.ім`я_сайту.хост";
        }

        private void txtSite_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtDirector.Text == "" || txtAddress.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Введено не всі дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Створюю екземпляр класу AutoSchool і надаю значення його полям
                KinderGarden KinderGrdn = new KinderGarden(NewID(), cmbpropForm.Text, txtName.Text, 
                    txtDirector.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtSite.Text,
                    cmbStatus.SelectedItem.ToString(), Convert.ToInt32(GroupsNumber.Value),
                    Convert.ToSingle(txtCost.Text));

                //Якщо AddOrChangeAuto == 1, то додавання даних
                if (kinderGarden.AddOrChangeKinder == 1)
                {
                    KinderGrdn.AddKinderGarden();
                    MessageBox.Show("Дані успішно додано", "ПОВІДОМЛЕННЯ", MessageBoxButtons.OK);
                    this.Close();
                }

                else
                {
                    if (kinderGarden.AddOrChangeKinder == 2)
                    {
                        KinderGrdn.EditKinderGarden(kinderGarden.KEY);
                        MessageBox.Show("Дані успішно змінено", "ПОВІДОМЛЕННЯ", MessageBoxButtons.OK);
                        this.Close();
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
            OleDbDataAdapter con2 = new("SELECT MAX (ID) FROM KinderGarden", con1);
            con1.Open();
            newID = Convert.ToInt32(con2.SelectCommand.ExecuteScalar());
            newID++;
            con1.Close();
            return newID;
        }
    }
    
}
