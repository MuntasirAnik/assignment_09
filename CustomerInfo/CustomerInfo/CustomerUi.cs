using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerInfo.Manager;
using CustomerInfo.Model;

namespace CustomerInfo
{
    public partial class CustomerUi : Form
    {
       
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void CustomerUi_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _customerManager.LoadCustomerCombo();
            //int num = new Random().Next(1000, 9999);
            // codeTextBox.Text = num.ToString();
            customerComboBox.Text = "select";
        }

       

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
           
            CustomerDistrict customerDistrict = new CustomerDistrict();
            if(saveButton.Text =="Save")
            {
                int i;
                if (String.IsNullOrEmpty(codeTextBox.Text) ||!int.TryParse(codeTextBox.Text, out i) || String.IsNullOrEmpty(nameTextBox.Text) || String.IsNullOrEmpty(addressTextBox.Text) || String.IsNullOrEmpty(contactTextBox.Text) || String.IsNullOrEmpty(customerComboBox.Text))
                {
                    MessageBox.Show("Fill the empty box");
                }
                else
                {
                    customerDistrict.Code = Convert.ToInt32(codeTextBox.Text);
                    if (_customerManager.IsCodeExists(customerDistrict))
                    {
                        MessageBox.Show("Code " + codeTextBox.Text + " is Already exist");
                    }
                    else
                    {
                        customerDistrict.Contact = contactTextBox.Text;
                        if (_customerManager.IsContactExists(customerDistrict))
                        {
                            MessageBox.Show("Contact no " + contactTextBox.Text + " is Already exist");
                        }
                        else
                        {
                            customerDistrict.Name = nameTextBox.Text;
                            customerDistrict.Address = addressTextBox.Text;
                            customerDistrict.District = customerComboBox.Text;

                            bool isAdded = _customerManager.AddCustomer(customerDistrict);

                            if (isAdded)
                            {
                                MessageBox.Show("Data Saved Successfully");
                                customerDataGridView.DataSource = _customerManager.DisplayData();
                                codeTextBox.Text = "";
                                nameTextBox.Text = "";
                                addressTextBox.Text = "";
                                contactTextBox.Text = "";
                                customerComboBox.Text = "select";
                            }
                            else
                            {
                                MessageBox.Show("not Saved");
                            }
                        }
                    }
                }
            }
            else if(saveButton.Text=="Update")
            {
                int i;
                if(String.IsNullOrEmpty(codeTextBox.Text)|| !int.TryParse(codeTextBox.Text, out i))
                {
                    MessageBox.Show("code must be an integer");
                    return;
                }
                if (nameTextBox.Text == "")
                {
                    MessageBox.Show("Name can't be empty");
                    return;
                }
                if (addressTextBox.Text == "")
                {
                    MessageBox.Show("Address can't be empty");
                    return;
                }
                if (contactTextBox.Text == "")
                {
                    MessageBox.Show("Contact can't be empty");
                    return;
                }
                if (customerComboBox.Text == "")
                {
                    MessageBox.Show("ple select your district");
                    return;
                }
                customerDistrict.Code = Convert.ToInt32(codeTextBox.Text);
                
                customerDistrict.Name = nameTextBox.Text;
                customerDistrict.Address = addressTextBox.Text;
                customerDistrict.Contact = contactTextBox.Text;
                customerDistrict.District = customerComboBox.Text;

             
                if(_customerManager.UpdateCustomer(customerDistrict))
                {
                    MessageBox.Show("Updated");
                    customerDataGridView.DataSource = _customerManager.DisplayData();
                    saveButton.Text = "Save";
                    codeTextBox.Text = "";
                    nameTextBox.Text = "";
                    addressTextBox.Text = "";
                    contactTextBox.Text = "";
                    customerComboBox.Text = "Select";
                }
                else
                {
                    MessageBox.Show("not updated");
                }

                
                

                


            }

            
        }
        

        private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;

                DataGridViewRow row = customerDataGridView.Rows[index];

                codeTextBox.Text = row.Cells[2].Value.ToString();
                nameTextBox.Text = row.Cells[3].Value.ToString();
                addressTextBox.Text = row.Cells[4].Value.ToString();
                contactTextBox.Text = row.Cells[5].Value.ToString();
                customerComboBox.Text = row.Cells[6].Value.ToString();

                saveButton.Text = "Update";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+ "\n Select a row");
            }
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text=="")
            {
                MessageBox.Show("Enter search name");
            }
            else
            {
                CustomerDistrict customerDistrict = new CustomerDistrict();
                customerDistrict.Name = nameTextBox.Text;
                customerDataGridView.DataSource = _customerManager.Search(customerDistrict);
            }
        }

        private void customerDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.customerDataGridView.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
