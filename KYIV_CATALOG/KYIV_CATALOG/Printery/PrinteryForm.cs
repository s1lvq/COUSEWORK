using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYIV_CATALOG.Printery
{
    public partial class PrinteryForm : Form
    {
        Printery printery = new Printery();
        public DataTable Table;
        public int AddOrChangePrint = 0;
        public int KEY = 0;
        public PrinteryForm()
        {
            InitializeComponent();
            PrinteryGridView.ContextMenuStrip = PrinteryMenu;
            Table = printery.SelectData("Printery");
            //заповнюємо PrinteryGridView
            TableUpdate();
        }

        public void TableUpdate()
        {
            PrinteryGridView.DataSource = Table;
            PrinteryGridView.Columns[0].Visible = false;
            PrinteryGridView.Columns[0].Width = 6;
            PrinteryGridView.Columns[1].Visible = false;
            PrinteryGridView.Columns[2].HeaderText = "Назва";
            PrinteryGridView.Columns[2].Width = 300;
            PrinteryGridView.Columns[3].Visible = false;
            PrinteryGridView.Columns[4].HeaderText = "Адреса";
            PrinteryGridView.Columns[4].Width = 585;
            PrinteryGridView.Columns[5].Visible = false;
            PrinteryGridView.Columns[6].Visible = false;
            PrinteryGridView.Columns[7].Visible = false;
            PrinteryGridView.Columns[8].Visible = false;
            PrinteryGridView.Columns[9].Visible = false;
            PrinteryGridView.Columns[10].Visible = false;
        }

        private void PrinteryGridView_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = " Для будь-якої дії оберіть" +
                " комірку та натисніть на неї правою кнопкою миші";
        }

        private void PrinteryGridView_MouseLeave(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
        }

        private void PrinteryGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (PrinteryGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(PrinteryGridView.CurrentRow.Cells[0].Value);   //ID виділеного рядка
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
                        lblProduction.Text = Convert.ToString(Table.Rows[i].ItemArray[9]);
                        lblCost.Text = Convert.ToString(Table.Rows[i].ItemArray[10]);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void AddPrintery_Click(object sender, EventArgs e)
        {
            AddOrChangePrint = 1;
            AddPrinteryForm addPr = new(this);
            addPr.ShowDialog();
            TableUpdate();  //оновлення PrinteryGridView
        }

        private void ChangePrintery_Click(object sender, EventArgs e)
        {
            if (PrinteryGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані!", "ПОМИЛКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            else
            {
                //ID зміненного запису 
                KEY = Convert.ToInt32(PrinteryGridView.CurrentRow.Cells[0].Value);
                AddOrChangePrint = 2;
                AddPrinteryForm chPr = new(this);
                chPr.ShowDialog();
                TableUpdate(); //Оновлення PrinteryGridView
            }
        }

        private void DeletePrintery_Click(object sender, EventArgs e)
        {
            //Якщо рядок пустий, отримаємо сповіщення про помилку
            if (PrinteryGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("У цьому рядку відсутні дані", "ПОМИЛКА",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Printery pr = new Printery();

                //Перевірка статуса: якщо "Працює" - відмова, інакше підтвердження
                bool work = pr.CheckStatus(Convert.ToInt32(PrinteryGridView.CurrentRow.Cells[0].Value), "Printery");
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
                        pr.DeleteData(Convert.ToInt32(PrinteryGridView.CurrentRow.Cells[0].Value), "Printery");
                        if (PrinteryGridView.CurrentRow.Index != 0)
                        {
                            //Выделение 1 ячейки 1 строки PrinteryGridView
                            PrinteryGridView.CurrentCell = PrinteryGridView.Rows[0].Cells[2];
                        }
                        else
                        {
                            //Выделение 1 ячейки 2 строки PrinteryGridView
                            PrinteryGridView.CurrentCell = PrinteryGridView.Rows[1].Cells[2];
                        }
                        //Обновление dataGridView1
                        TableUpdate();
                        MessageBox.Show("Дані успішно видалено!", "СПОВІЩЕННЯ",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        //---ПОШУК ДРУКАРНІ ЗА ВАРТІСТЮ НАВЧАННЯ---//
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

                Printery PR = new Printery();
                SearchGridView.DataSource = PR.CostSearching(min, max);
            }

        }

        //---ПОШУК ДРУКАРНІ ЗА НАЗВОЮ---//
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Printery PR = new Printery();
            SearchGridView.DataSource = PR.FindName("Printery", txtName.Text);

            txtPrice_From.Text = "";
            txtPrice_To.Text = "";
        }
    }
}
