using System.Data;

namespace KYIV_CATALOG.EngSchool
{
    public partial class EngSchoolForm : Form
    {
        EngSchool engschool = new();
        public DataTable Table;
        public int AddOrChangeEng = 0;
        public int KEY = 0;
        public EngSchoolForm()
        {
            InitializeComponent();
            EngGridView.ContextMenuStrip = EngSchoolMenu;
            Table = engschool.SelectData("EngSchools");
            TableUpdate();  //заповнюємо EngGridView
        }
        public void TableUpdate()
        {
            EngGridView.DataSource = Table;
            EngGridView.Columns[0].Visible = false;
            EngGridView.Columns[0].Width = 6;
            EngGridView.Columns[1].Visible = false;
            EngGridView.Columns[2].HeaderText = "Назва";
            EngGridView.Columns[2].Width = 300;
            EngGridView.Columns[3].Visible = false;
            EngGridView.Columns[4].HeaderText = "Адреса";
            EngGridView.Columns[4].Width = 585;
            EngGridView.Columns[5].Visible = false;
            EngGridView.Columns[6].Visible = false;
            EngGridView.Columns[7].Visible = false;
            EngGridView.Columns[8].Visible = false;
            EngGridView.Columns[9].Visible = false;
            EngGridView.Columns[10].Visible = false;
            EngGridView.Columns[11].Visible = false;
            EngGridView.Columns[12].Visible = false;
            EngGridView.Columns[13].Visible = false;
        }

        private void EngGridView_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Для будь-якої дії оберіть" +
                " комірку та натисніть на неї правою кнопкою миші";
        }

        private void EngGridView_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void EngGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (EngGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(EngGridView.CurrentRow.Cells[0].Value);   //ID виділеного рядка
                bool flag = true; //true, поки не знайдено шуканий рядок 
                int i = 0; //змінна лічильника

                //Пошук данних по ID
                while (flag)
                {
                    if (Convert.ToInt32(Table.Rows[i].ItemArray[0]) == id)
                    {
                        flag = false;
                        //Обираємо дані у labels
                        lblPropertyForm.Text = Convert.ToString(Table.Rows[i].ItemArray[1]);
                        lblName.Text = Convert.ToString(Table.Rows[i].ItemArray[2]);
                        lblDirector.Text = Convert.ToString(Table.Rows[i].ItemArray[3]);
                        lblAddress.Text = Convert.ToString(Table.Rows[i].ItemArray[4]);
                        lblPhone.Text = Convert.ToString(Table.Rows[i].ItemArray[5]);
                        lblEmail.Text = Convert.ToString(Table.Rows[i].ItemArray[6]);
                        lblWebSite.Text = Convert.ToString(Table.Rows[i].ItemArray[7]);
                        lblLevels.Text = Convert.ToString(Table.Rows[i].ItemArray[8]);
                        lblLevels.Text = Convert.ToString(Table.Rows[i].ItemArray[9]);
                        lblEducationTime.Text = Convert.ToString(Table.Rows[i].ItemArray[10]);
                        lblDayGroups.Text = Convert.ToString(Table.Rows[i].ItemArray[11]);
                        lblEvGroups.Text = Convert.ToString(Table.Rows[i].ItemArray[12]);
                        lblCost.Text = Convert.ToString(Table.Rows[i].ItemArray[13]);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void AddEngSchool_Click(object sender, EventArgs e)
        {
            AddOrChangeEng = 1;
            AddEngSchoolForm add = new(this);
            add.ShowDialog();
            TableUpdate();  //оновлення EngGridView
        }

        private void ChangeEngSchool_Click(object sender, EventArgs e)
        {
            if (EngGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            else
            {
                //ID зміненного запису 
                KEY = Convert.ToInt32(EngGridView.CurrentRow.Cells[0].Value);
                AddOrChangeEng = 2;
                AddEngSchoolForm ch = new(this);
                ch.ShowDialog();
                TableUpdate(); //Оновлення EngGridView
            }
        }
        private void DeleteEngSchool_Click(object sender, EventArgs e)
        {
            //Якщо рядок пустий, отримаємо сповіщення про помилку
            if (EngGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                EngSchool es2 = new EngSchool();
                //Перевірка статуса: якщо "Працює" - відмова, інакше підтвердження
                bool work = es2.CheckStatus(Convert.ToInt32(EngGridView.CurrentRow.Cells[0].Value), "EngSchools");
                if (work)
                {
                    MessageBox.Show("У цієї автошколи статус - \"ПРАЦЮЄ\"", "ВІДМОВА У ВИДАЛЕННІ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult DR = MessageBox.Show("Ви впевненні, що хочете видалити запис?", "ПІДТВЕРДЖЕННЯ",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DR.ToString() == "OK")
                    {
                        //Видалення з БД
                        es2.DeleteData(Convert.ToInt32(EngGridView.CurrentRow.Cells[0].Value), "EngSchools");
                        if (EngGridView.CurrentRow.Index != 0)
                        {
                            //Выделение 1 ячейки 1 строки EngGridView
                            EngGridView.CurrentCell = EngGridView.Rows[0].Cells[2];
                        }
                        else
                        {
                            //Выделение 1 ячейки 2 строки EngGridView
                            EngGridView.CurrentCell = EngGridView.Rows[1].Cells[2];
                        }
                        //Обновление EngGridView
                        TableUpdate();
                        MessageBox.Show("Дані успішно видалено!", "СПОВІЩЕННЯ",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //---ПОШУК ШКОЛИ ЗА ВАРТІСТЮ НАВЧАННЯ---//
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Комірки діапазону пусті
            if (txtPrice_From.Text == "" && txtPrice_To.Text == "")
            {
                MessageBox.Show("Діапазон пошуку не задано", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                float min, max;
                if (txtPrice_From.Text == "")
                {
                    min = 0;
                }
                else
                {
                    min = Convert.ToSingle(txtPrice_From.Text);
                }

                if (txtPrice_To.Text == "")
                {
                    max = 100000;
                }
                else
                {
                    max = Convert.ToSingle(txtPrice_To.Text);
                }

                EngSchool ES = new EngSchool();
                SearchGridView.DataSource = ES.CostSearching(min, max);
            }

        }

        //---ПОШУК ШКОЛИ ЗА НАЗВОЮ---//
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            EngSchool ES = new EngSchool();
            SearchGridView.DataSource = ES.FindName("EngSchools", txtName.Text);

            txtPrice_From.Text = "";
            txtPrice_To.Text = "";
        }
    }
}
