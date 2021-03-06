﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;

namespace RegionR.addedit
{
    public partial class AddEditMarkAct : Form
    {
        int index, db;
        private bool save;
        public bool edit;

        public AddEditMarkAct(int flag)
        {
            InitializeComponent();

            index = 0;
            save = false;
            edit = false;

            if (flag == 1)
                loadData();
            else if (flag == 2)
                loadData2();
        }

        public AddEditMarkAct(int i, int d)
        {
            InitializeComponent();

            index = i;
            db = d;

            save = false;
            edit = true;
            loadData();
        }

        public AddEditMarkAct(int i, int d, int f)
        {
            InitializeComponent();

            index = i;
            db = d;

            save = false;
            edit = true;
            loadData2();
        }

        private void loadData2()
        {
            sql sql1 = new sql();
            DataTable dt1 = sql1.GetRecords("exec SelUserByID @p1", globalData.UserID2);

            lbUserName.Text = dt1.Rows[0].ItemArray[1].ToString();


            label3.Text = "Регион";

            cbLPU.DataSource = sql1.GetRecords("exec SelRegPM @p1", globalData.UserID2);
            cbLPU.DisplayMember = "reg_nameRus";
            cbLPU.ValueMember = "reg_id";

            label4.Visible = false;
            tbRegion.Visible = false;

            tbPlan1.Text = String.Empty;
            tbPlan2.Text = String.Empty;
            tbPlan3.Text = String.Empty;
            tbPlan4.Text = String.Empty;
            tbFact1.Text = String.Empty;
            tbFact2.Text = String.Empty;
            tbFact3.Text = String.Empty;
            tbFact4.Text = String.Empty;

            if (index != 0)
            {
                dt1 = sql1.GetRecords("exec SelMarkActByID @p1, @p2", index, db);

                tbName.Text = dt1.Rows[0].ItemArray[1].ToString();

                cbLPU.SelectedValue = Convert.ToInt32(dt1.Rows[0].ItemArray[4]);

                if (dt1.Rows[0].ItemArray[15].ToString() == "1")
                {
                    tbPlan1.Enabled = true;
                    tbPlan2.Enabled = true;
                    tbPlan3.Enabled = true;
                    tbPlan4.Enabled = true;
                    cbLPU.Enabled = true;
                }
                else
                {
                    tbPlan1.Enabled = false;
                    tbPlan2.Enabled = false;
                    tbPlan3.Enabled = false;
                    tbPlan4.Enabled = false;
                    cbLPU.Enabled = false;
                }
                if (dt1.Rows[0].ItemArray[17].ToString() == "1")
                {
                    tbFact1.Enabled = true;
                    tbFact2.Enabled = true;
                    tbFact3.Enabled = true;
                    tbFact4.Enabled = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    tbFact1.Enabled = false;
                    tbFact2.Enabled = false;
                    tbFact3.Enabled = false;
                    tbFact4.Enabled = false;
                    btnSave.Enabled = false;
                }

                if (dt1.Rows[0].ItemArray[7].ToString() != "0")
                    tbPlan1.Text = dt1.Rows[0].ItemArray[7].ToString();

                if (dt1.Rows[0].ItemArray[8].ToString() != "0")
                    tbPlan2.Text = dt1.Rows[0].ItemArray[8].ToString();

                if (dt1.Rows[0].ItemArray[9].ToString() != "0")
                    tbPlan3.Text = dt1.Rows[0].ItemArray[9].ToString();

                if (dt1.Rows[0].ItemArray[10].ToString() != "0")
                    tbPlan4.Text = dt1.Rows[0].ItemArray[10].ToString();

                if (dt1.Rows[0].ItemArray[11].ToString() != "0")
                    tbFact1.Text = dt1.Rows[0].ItemArray[11].ToString();

                if (dt1.Rows[0].ItemArray[12].ToString() != "0")
                    tbFact2.Text = dt1.Rows[0].ItemArray[12].ToString();

                if (dt1.Rows[0].ItemArray[13].ToString() != "0")
                    tbFact3.Text = dt1.Rows[0].ItemArray[13].ToString();

                if (dt1.Rows[0].ItemArray[14].ToString() != "0")
                    tbFact4.Text = dt1.Rows[0].ItemArray[14].ToString();

                //tbRegion.Text = sql1.GetRecordsOne("exec SelRegByLPUid @p1", cbLPU.SelectedValue);
            }
            else
            {
                tbName.Text = String.Empty;

                //tbRegion.Text = sql1.GetRecordsOne("exec SelRegByLPUid @p1", cbLPU.SelectedValue);

                cbLPU.Enabled = true;
            }
        }


        private void loadData()
        {
            sql sql1 = new sql();
            DataTable dt1 = sql1.GetRecords("exec SelUserByID @p1", globalData.UserID2);

            lbUserName.Text = dt1.Rows[0].ItemArray[1].ToString();

            cbLPU.DataSource = sql1.GetRecords("exec SelLPU_MA @p1, @p2, @p3, @p4", globalData.UserID2, globalData.Region, globalData.Div, globalData.CurDate.Year);
            cbLPU.DisplayMember = "lpu_sname";
            cbLPU.ValueMember = "ulpu_id";

            tbPlan1.Text = String.Empty;
            tbPlan2.Text = String.Empty;
            tbPlan3.Text = String.Empty;
            tbPlan4.Text = String.Empty;
            tbFact1.Text = String.Empty;
            tbFact2.Text = String.Empty;
            tbFact3.Text = String.Empty;
            tbFact4.Text = String.Empty;

            if (index != 0)
            {
                dt1 = sql1.GetRecords("exec SelMarkActByID @p1, @p2", index, db);

                tbName.Text = dt1.Rows[0].ItemArray[1].ToString();

                cbLPU.SelectedValue = Convert.ToInt32(dt1.Rows[0].ItemArray[5]);

                if (dt1.Rows[0].ItemArray[15].ToString() == "1")
                {
                    tbPlan1.Enabled = true;
                    tbPlan2.Enabled = true;
                    tbPlan3.Enabled = true;
                    tbPlan4.Enabled = true;
                    cbLPU.Enabled = true;
                }
                else
                {
                    tbPlan1.Enabled = false;
                    tbPlan2.Enabled = false;
                    tbPlan3.Enabled = false;
                    tbPlan4.Enabled = false;
                    cbLPU.Enabled = false;
                }
                if (dt1.Rows[0].ItemArray[17].ToString() == "1")
                {
                    tbFact1.Enabled = true;
                    tbFact2.Enabled = true;
                    tbFact3.Enabled = true;
                    tbFact4.Enabled = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    tbFact1.Enabled = false;
                    tbFact2.Enabled = false;
                    tbFact3.Enabled = false;
                    tbFact4.Enabled = false;
                    btnSave.Enabled = false;
                }

                if (dt1.Rows[0].ItemArray[7].ToString() != "0")
                    tbPlan1.Text = dt1.Rows[0].ItemArray[7].ToString();

                if (dt1.Rows[0].ItemArray[8].ToString() != "0")
                    tbPlan2.Text = dt1.Rows[0].ItemArray[8].ToString();

                if (dt1.Rows[0].ItemArray[9].ToString() != "0")
                    tbPlan3.Text = dt1.Rows[0].ItemArray[9].ToString();

                if (dt1.Rows[0].ItemArray[10].ToString() != "0")
                    tbPlan4.Text = dt1.Rows[0].ItemArray[10].ToString();

                if (dt1.Rows[0].ItemArray[11].ToString() != "0")
                    tbFact1.Text = dt1.Rows[0].ItemArray[11].ToString();

                if (dt1.Rows[0].ItemArray[12].ToString() != "0")
                    tbFact2.Text = dt1.Rows[0].ItemArray[12].ToString();

                if (dt1.Rows[0].ItemArray[13].ToString() != "0")
                    tbFact3.Text = dt1.Rows[0].ItemArray[13].ToString();

                if (dt1.Rows[0].ItemArray[14].ToString() != "0")
                    tbFact4.Text = dt1.Rows[0].ItemArray[14].ToString();

                tbRegion.Text = sql1.GetRecordsOne("exec SelRegByLPUid @p1", cbLPU.SelectedValue);
            }
            else
            {
                tbName.Text = String.Empty;

                tbRegion.Text = sql1.GetRecordsOne("exec SelRegByLPUid @p1", cbLPU.SelectedValue);

                cbLPU.Enabled = true;
            }
        }

        private void cbLPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql sql1 = new sql();

            tbRegion.Text = sql1.GetRecordsOne("exec SelRegByLPUid @p1", cbLPU.SelectedValue);

            if (tbRegion.Text == String.Empty)
                tbRegion.Text = globalData.Region;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validation(KeyPressEventArgs e)
        {
            if ((!(Char.IsDigit(e.KeyChar))) && (e.KeyChar != ','))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }


        private void SaveMA()
        {
            sql sql1 = new sql();

            globalData.load = true;

            DataTable dt1 = new DataTable();

            string lpu = String.Empty;
            string reg = String.Empty;

            if (tbRegion.Visible == false)
            {
                lpu = "-3";
                reg = cbLPU.SelectedValue.ToString();
            }
            else
            {
                lpu = cbLPU.SelectedValue.ToString();
                reg = tbRegion.Text;
            }

            if (index == 0)
            {
                dt1 = sql1.GetRecords("exec InsMarkAct 0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13",
                    tbName.Text, globalData.UserID2, globalData.Div, reg, lpu, 
                    tbPlan1.Text.Replace(",", "."), tbPlan2.Text.Replace(",", "."), tbPlan3.Text.Replace(",", "."), tbPlan4.Text.Replace(",", "."),
                    tbFact1.Text.Replace(",", "."), tbFact2.Text.Replace(",", "."), tbFact3.Text.Replace(",", "."), tbFact4.Text.Replace(",", "."));

                if (dt1 == null)
                {
                    MessageBox.Show("Не удалось добавить маркетинговое мероприятие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    save = false;
                }
                else
                {
                    MessageBox.Show("Маркетинговое мероприятие добавлено.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    save = true;
                    index = Convert.ToInt32(dt1.Rows[0].ItemArray[0]);
                    db = Convert.ToInt32(dt1.Rows[0].ItemArray[1]);
                }
                
            }
            else
            {
                dt1 = sql1.GetRecords("exec UpdMarkAct @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14", index, db, globalData.UserID2, tbName.Text, lpu, reg,
                   tbPlan1.Text.Replace(",", "."), tbPlan2.Text.Replace(",", "."), tbPlan3.Text.Replace(",", "."), tbPlan4.Text.Replace(",", "."),
                    tbFact1.Text.Replace(",", "."), tbFact2.Text.Replace(",", "."), tbFact3.Text.Replace(",", "."), tbFact4.Text.Replace(",", "."));

                if (dt1 == null)
                    MessageBox.Show("Не удалось отредактировать маркетинговое мероприятие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Маркетинговое мероприятие обновлено.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sql sql1 = new sql();

            globalData.load = true;

            DataTable dt1 = new DataTable();

            string lpu = String.Empty;
            string reg = String.Empty;

            if (tbRegion.Visible == false)
            {
                lpu = "-3";
                reg = cbLPU.SelectedValue.ToString();
            }
            else
            {
                lpu = cbLPU.SelectedValue.ToString();
                reg = tbRegion.Text;
            }

            if (index == 0)
            {
                dt1 = sql1.GetRecords("exec InsMarkAct 0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13",
                    tbName.Text, globalData.UserID2, globalData.Div, reg, lpu, tbPlan1.Text.Replace(",", "."), tbPlan2.Text.Replace(",", "."), tbPlan3.Text.Replace(",", "."), tbPlan4.Text.Replace(",", "."),
                    tbFact1.Text.Replace(",", "."), tbFact2.Text.Replace(",", "."), tbFact3.Text.Replace(",", "."), tbFact4.Text.Replace(",", "."));

                if (dt1 == null)
                    MessageBox.Show("Не удалось добавить маркетинговое мероприятие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Маркетинговое мероприятие добавлено.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                dt1 = sql1.GetRecords("exec UpdMarkAct @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14", 
                    index, 
                    db, 
                    globalData.UserID2, 
                    tbName.Text, 
                    lpu, 
                    reg,
                    tbPlan1.Text.Replace(",", "."), 
                    tbPlan2.Text.Replace(",", "."), 
                    tbPlan3.Text.Replace(",", "."), 
                    tbPlan4.Text.Replace(",", "."), 
                    tbFact1.Text.Replace(",", "."), 
                    tbFact2.Text.Replace(",", "."), 
                    tbFact3.Text.Replace(",", "."),
                    tbFact4.Text.Replace(",", "."));

                if (dt1 == null)
                    MessageBox.Show("Не удалось отредактировать маркетинговое мероприятие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Маркетинговое мероприятие обновлено.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

       
        private void tbPlan1_MouseClick(object sender, MouseEventArgs e)
        {
            InputAlloc(tbPlan1, 1);
        }

        private void tbPlan2_MouseClick(object sender, MouseEventArgs e)
        {
            InputAlloc(tbPlan2, 2);
        }

        private void tbPlan3_MouseClick(object sender, MouseEventArgs e)
        {
            InputAlloc(tbPlan3, 3);
        }

        private void tbPlan4_MouseClick(object sender, MouseEventArgs e)
        {
            InputAlloc(tbPlan4, 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputAlloc(tbPlan1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InputAlloc(tbPlan2, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InputAlloc(tbPlan3, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InputAlloc(tbPlan4, 4);
        }

        void InputAlloc (TextBox tb, int num)
        {
            if (!save)
                SaveMA();

            AllocCosts ac;
            //if (index == 0)
            //    ac = new AllocCosts(num);
            //else
            ac = new AllocCosts(index, db, num, tb.Text.Trim());
                if (tb.Text.Trim() != String.Empty)
                    ac.price = tb.Text;
                else
                    ac.price = String.Empty;
            ac.ShowDialog();
            if (ac.price != null || ac.price != "")
                tb.Text = ac.price.ToString();
        }
    }
}
