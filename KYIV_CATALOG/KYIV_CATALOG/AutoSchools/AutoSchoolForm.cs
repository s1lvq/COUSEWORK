using System.Data;

namespace KYIV_CATALOG.AutoSchools
{
    public partial class AutoSchoolForm : Form
    {
        AutoSchool autoschool = new AutoSchool();

        public DataTable Table;
        public int AddOrChangeAuto = 0;
        public int KEY = 0;

        public AutoSchoolForm()
        {
            InitializeComponent();
            //Зв'язування контексного меню з AutoGridView
            AutoGridView.ContextMenuStrip = AutoSchoolMenu;
            Table = autoschool.SelectData("AutoSchools");
            TableUpdate(); //заповнюємо AutoGridView
        }

        //--МЕТОД ДЛЯ ЗАПОВНЕННЯ ДАНИМИ AutoGridView--//
        public void TableUpdate()
        {
            AutoGridView.DataSource = Table;
            AutoGridView.Columns[0].Visible = false;
            AutoGridView.Columns[0].Width = 6;
            AutoGridView.Columns[1].Visible = false;
            AutoGridView.Columns[2].HeaderText = "Назва";
            AutoGridView.Columns[2].Width = 300;
            AutoGridView.Columns[3].Visible = false;
            AutoGridView.Columns[4].HeaderText = "Адреса";
            AutoGridView.Columns[4].Width = 585;
            AutoGridView.Columns[5].Visible = false;
            AutoGridView.Columns[6].Visible = false;
            AutoGridView.Columns[7].Visible = false;
            AutoGridView.Columns[8].Visible = false;
            AutoGridView.Columns[9].Visible = false;
            AutoGridView.Columns[10].Visible = false;
            AutoGridView.Columns[11].Visible = false;
            AutoGridView.Columns[12].Visible = false;
            AutoGridView.Columns[13].Visible = false;
        }

        //---Створення підказок--//
        private void AutoGridView_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Для будь-якої дії оберіть" +
                " комірку та натисніть на неї правою кнопкою миші";
        }

        private void AutoGridView_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        //---Вивід детальної інформації про виділену автошколу---//
        private void AutoGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (AutoGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(AutoGridView.CurrentRow.Cells[0].Value);   //ID виділеного рядка
                bool flag = true; //true, поки не знайдено шуканий рядок 
                int i = 0; //змінна лічильника

                //Пошук данних по ID
                while (flag)
                {
                    if (Convert.ToInt32(Table.Rows[i].ItemArray[0]) == id)
                    {
                        flag = false;

                        //Обираємо дані для виведення їх у labels
                        lblPropertyForm.Text = Convert.ToString(Table.Rows[i].ItemArray[1]);
                        lblName.Text = Convert.ToString(Table.Rows[i].ItemArray[2]);
                        lblDirector.Text = Convert.ToString(Table.Rows[i].ItemArray[3]);
                        lblAddress.Text = Convert.ToString(Table.Rows[i].ItemArray[4]);
                        lblPhone.Text = Convert.ToString(Table.Rows[i].ItemArray[5]);
                        lblEmail.Text = Convert.ToString(Table.Rows[i].ItemArray[6]);
                        lblWebSite.Text = Convert.ToString(Table.Rows[i].ItemArray[7]);
                        lblStatus.Text = Convert.ToString(Table.Rows[i].ItemArray[8]);
                        lblCategories.Text = Convert.ToString(Table.Rows[i].ItemArray[9]);
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

        //--МЕТОД ДЛЯ ДОДАВАННЯ АВТОШКОЛИ---//
        private void AddAutoSchool_Click(object sender, EventArgs e)
        {
            AddOrChangeAuto = 1;

            AddAutoSchoolForm addAS = new AddAutoSchoolForm(this);
            addAS.ShowDialog();

            //Оновлення AutoGridView
            TableUpdate(); 
        }


        //--МЕТОД ДЛЯ РЕДАГУВАННЯ АВТОШКОЛИ---//
        private void ChangeAutoSchool_Click(object sender, EventArgs e)
        {
            //Обробка помилки
            if (AutoGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            else
            {
                //ID зміненного запису 
                KEY = Convert.ToInt32(AutoGridView.CurrentRow.Cells[0].Value);

                AddOrChangeAuto = 2;
                AddAutoSchoolForm chAS = new(this);
                chAS.ShowDialog();

                //Оновлення AutoGridView
                TableUpdate(); 
            }
        }

        //--МЕТОД ДЛЯ ВИДАЛЕННЯ АВТОШКОЛИ---//
        private void DeleteAutoSchool_Click(object sender, EventArgs e)
        {
            //Якщо рядок пустий, отримуємо сповіщення про помилку
            if (AutoGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                AutoSchool as2 = new AutoSchool();

                //Перевірка статуса: якщо підприємство "Працює" - відмова, інакше підтвердження
                bool work = as2.CheckStatus(Convert.ToInt32(AutoGridView.CurrentRow.Cells[0].Value), 
                    "AutoSchools");

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
                        as2.DeleteData(Convert.ToInt32(AutoGridView.CurrentRow.Cells[0].Value), "AutoSchools");
                        if (AutoGridView.CurrentRow.Index != 0)
                        {
                            //Виділення 1 клітинки 1 рядка AutoGridView
                            AutoGridView.CurrentCell = AutoGridView.Rows[0].Cells[2];
                        }
                        else
                        {
                            //Виділення 1 клітинки 2 рядки AutoGridView
                            AutoGridView.CurrentCell = AutoGridView.Rows[1].Cells[2];
                        }

                        //Онолвення AutoGridView
                        TableUpdate();
                        MessageBox.Show("Вітаємо!Дані успішно видалено!", "СПОВІЩЕННЯ",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //---ПОШУК АВТОШКОЛИ ЗА ВАРТІСТЮ НАВЧАННЯ---//
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

                AutoSchool AS = new AutoSchool();
                SearchGridView.DataSource = AS.CostSearching(min, max);
            }

        }


        //---ПОШУК АВТОШКОЛИ ЗА НАЗВОЮ---//
        private void txtName_TextChanged(object sender, EventArgs e)
        {
                AutoSchool autosch = new AutoSchool();
                SearchGridView.DataSource = autosch.FindName("AutoSchools", txtName.Text);
                
                txtPrice_From.Text = ""; 
                txtPrice_To.Text = "";
        }
    }
}

