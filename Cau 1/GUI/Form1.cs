using Cau_1.BAL;
using Cau_1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau_1
{
    public partial class Form1 : Form
    {
        EmployeeBAL cnBAL = new EmployeeBAL();
       DepartmentBAL depBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeDTO> lstCongNo = cnBAL.ReadDepartment();
            foreach (EmployeeDTO cn in lstCongNo)
            {
                dgvDepartment.Rows.Add(cn.IdEmployee, cn.Name, cn.DateBirth, cn.Gender, cn.PlaceBirth, cn.NameDepartment);

            }
            List < DepartmentDTO > lstPhong = depBAL.ReadAreaList();
            foreach (DepartmentDTO dep in lstPhong)
            {
                cbdonvi.Items.Add(dep);
            }
            cbdonvi.DisplayMember = "Name";
        }

        private void dgvDepartment_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            if (idx >= 0)
            {
                tbId.Text = dgvDepartment.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvDepartment.Rows[idx].Cells[1].Value.ToString();
                dtngaysinh.Text = dgvDepartment.Rows[idx].Cells[2].Value.ToString();
                if(dgvDepartment.Rows[idx].Cells[3].Value.ToString().Length < 3)
                {
                    cbGt.Checked = false;
                }
                else
                {
                    cbGt.Checked = true;
                }    
                //cbGt.Text = dgvDepartment.Rows[idx].Cells[3].Value.ToString();
                tbnoisinh.Text = dgvDepartment.Rows[idx].Cells[4].Value.ToString();
                cbdonvi.Text = dgvDepartment.Rows[idx].Cells[5].Value.ToString();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EmployeeDTO cn = new EmployeeDTO();
            cn.IdEmployee = int.Parse(tbId.Text);
            cn.Name = tbName.Text;
            cn.DateBirth = DateTime.Parse(dtngaysinh.Value.Date.ToString());
            if (cbGt.Checked)
            {
                cn.Gender = "Nam";
            }
            else
            {
                cn.Gender = "Nữ";
            }
            cn.PlaceBirth = tbnoisinh.Text;
            cn.Department = (DepartmentDTO)cbdonvi.SelectedItem;
            if (String.IsNullOrEmpty(tbId.Text) || String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnBAL.ThemDepartment(cn);
                dgvDepartment.Rows.Add(cn.IdEmployee, cn.Name, cn.DateBirth, cn.Gender, cn.PlaceBirth, cn.NameDepartment);
            }
            //
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeeDTO cn = new EmployeeDTO();
            cn.IdEmployee = int.Parse(tbId.Text);
            cn.Name = tbName.Text;
            cn.DateBirth = DateTime.Parse(dtngaysinh.Value.Date.ToString());
            if (cbGt.Checked)
            {
                cn.Gender = "Nam";
            }
            else
            {
                cn.Gender = "Nữ";
            }
            cn.PlaceBirth = tbnoisinh.Text;
            cn.Department = (DepartmentDTO)cbdonvi.SelectedItem;
            int idx = dgvDepartment.CurrentCell.RowIndex;
            cnBAL.XoaDepartment(cn);
            dgvDepartment.Rows.RemoveAt(idx);
            try
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EmployeeDTO cn = new EmployeeDTO();
            cn.IdEmployee = int.Parse(tbId.Text);
            cn.Name = tbName.Text;
            cn.DateBirth = DateTime.Parse(dtngaysinh.Value.Date.ToString());
            if (cbGt.Checked)
            {
                cn.Gender = "Nam";
            }
            else
            {
                cn.Gender = "Nữ";
            }
            cn.PlaceBirth = tbnoisinh.Text;
            cn.Department = (DepartmentDTO)cbdonvi.SelectedItem;
            if (String.IsNullOrEmpty(tbId.Text) || String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnBAL.SuaDepartment(cn);
                DataGridViewRow row = dgvDepartment.CurrentRow;
                row.Cells[0].Value = cn.IdEmployee;
                row.Cells[1].Value = cn.Name;
                row.Cells[2].Value = cn.DateBirth;
                row.Cells[3].Value = cn.Gender;
                row.Cells[4].Value = cn.PlaceBirth;
                row.Cells[5].Value = cn.NameDepartment;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbId.Text = ""; tbName.Text = ""; tbnoisinh.Text = "";dtngaysinh.Value = DateTime.Now;cbGt.Checked = false;cbdonvi.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
