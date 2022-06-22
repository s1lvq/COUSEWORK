using System.Data;


namespace KYIV_CATALOG.KinderGarden
{
    public partial class KinderGardenForm : Form
    {
        KinderGarden kindergarden = new KinderGarden();

        public DataTable Table;
        public int AddOrChangeKinder = 0;
        public int KEY = 0;
        public KinderGardenForm()
        {
            InitializeComponent();
            KinderGridView.ContextMenuStrip = KinderGardenMenu;
            Table = kindergarden.SelectData("KinderGarden");
            //заповнюємо KinderGridView
            TableUpdate();
        }

        //--МЕТОД ДЛЯ ЗАПОВНЕННЯ KinderGridView --//
        public void TableUpdate()
        {
            KinderGridView.DataSource = Table;
            KinderGridView.Columns[0].Visible = false;
            KinderGridView.Columns[0].Width = 6;
            KinderGridView.Columns[1].Visible = false;
            KinderGridView.Columns[2].HeaderText = "Назва";
            KinderGridView.Columns[2].Width = 300;
            KinderGridView.Columns[3].Visible = false;
            KinderGridView.Columns[4].HeaderText = "Адреса";
            KinderGridView.Columns[4].Width = 643;
            KinderGridView.Columns[5].Visible = false;
            KinderGridView.Columns[6].Visible = false;
            KinderGridView.Columns[7].Visible = false;
            KinderGridView.Columns[8].Visible = false;
            KinderGridView.Columns[9].Visible = false;
            KinderGridView.Columns[10].Visible = false;
        }

        //Підказки
        private void KinderGridView_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Для будь-якої дії оберіть" +
                " комірку та натисніть на неї правою кнопкою миші";
        }

        private void KinderGridView_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        //Вивід детальної інформації про Приватні Дитсадки Києва
        private void KinderGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (KinderGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(KinderGridView.CurrentRow.Cells[0].Value);   //ID виділеного рядка
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
                        lblStatus.Text = Convert.ToString(Table.Rows[i].ItemArray[8]);
                        lblGroupsNumber.Text = Convert.ToString(Table.Rows[i].ItemArray[9]);
                        lblCost.Text = Convert.ToString(Table.Rows[i].ItemArray[10]);  
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void AddKinderGarden_Click(object sender, EventArgs e)
        {
            AddOrChangeKinder = 1;
            AddKinderGardenForm add = new AddKinderGardenForm(this);
            add.ShowDialog();
            //Оновлення KinderGridView
            TableUpdate();  
        }

        private void ChangeKinderGarden_Click(object sender, EventArgs e)
        {
            if (KinderGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            else
            {
                //ID зміненного запису 
                KEY = Convert.ToInt32(KinderGridView.CurrentRow.Cells[0].Value);
                AddOrChangeKinder = 2;
                AddKinderGardenForm ch = new AddKinderGardenForm(this);
                ch.ShowDialog();
                TableUpdate(); //Оновлення KinderGridView
            }
        }
        private void DeleteKinderGarden_Click(object sender, EventArgs e)
        {
            //Якщо рядок пустий, отримаємо сповіщення про помилку
            if (KinderGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                KinderGarden as2 = new KinderGarden();
                //Перевірка статуса: якщо "Працює" - відмова, інакше підтвердження
                bool work = as2.CheckStatus(Convert.ToInt32(KinderGridView.CurrentRow.Cells[0].Value), "KinderGarden");
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
                        as2.DeleteData(Convert.ToInt32(KinderGridView.CurrentRow.Cells[0].Value), "KinderGarden");
                        if (KinderGridView.CurrentRow.Index != 0)
                        {
                            //Виділення 1 комірки 1 рядка KinderGridView
                            KinderGridView.CurrentCell = KinderGridView.Rows[0].Cells[2];
                        }
                        else
                        {
                            //Виділення 1 комірки 2 рядка KinderGridView
                            KinderGridView.CurrentCell = KinderGridView.Rows[1].Cells[2];
                        }
                        //Оновлення KinderGridView
                        TableUpdate();
                        MessageBox.Show("Дані успішно видалено!", "СПОВІЩЕННЯ",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //---ПОШУК ДИТСАДКА ЗА ВАРТІСТЮ НАВЧАННЯ---//
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

                KinderGarden KG = new KinderGarden();
                SearchGridView.DataSource = KG.CostSearching(min, max);
            }

        }

        //---ПОШУК ШКОЛИ ЗА НАЗВОЮ---//
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            KinderGarden KG = new KinderGarden();
            SearchGridView.DataSource = KG.FindName("KinderGarden", txtName.Text);

            txtPrice_From.Text = "";
            txtPrice_To.Text = "";
        }
    }
}
