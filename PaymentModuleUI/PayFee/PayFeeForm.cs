using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using FrameworkCommon;
using ProviderManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentModuleUI.PayFee
{
    public partial class PayFeeForm : Form
    {
        public PayFeeForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadFormInitialData();
        }

        #region Utility Methods
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(650, 565);
        }
        private void LoadFormInitialData()
        {
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            List<Student> systemStudents = studentOperations.GetStudents();
            
            foreach (Student student in systemStudents)
                this.comboBoxStudentNumbers.Items.Add(student.GetStudentNumber());
        }
        private void CleanForm(bool cleanSuccessMessage = false)
        {
            this.labelError.Text = string.Empty;
            if (cleanSuccessMessage)
                this.labelSuccess.Text = string.Empty;

            this.textBoxDocumentNumber.Text = string.Empty;
            this.textBoxFullName.Text = string.Empty;
            this.checkedListBoxNotPaidFees.Items.Clear();
            this.checkedListBoxPaidFees.Items.Clear();
        }
        private void FillFormWithStudentData(Student student)
        {
            textBoxDocumentNumber.Text = student.GetDocumentNumber();
            textBoxFullName.Text = student.GetFullName();

            IPaymentLogic paymentOperations = Provider.GetInstance.GetPaymentOperations();
            List<Fee> studentFees = paymentOperations.GetCurrentYearFeesByStudentNumber(student.StudentNumber);
            foreach (Fee f in studentFees)
            {
                if(f.IsPaid)
                    checkedListBoxPaidFees.Items.Add(f);
                else
                    checkedListBoxNotPaidFees.Items.Add(f);
            }
        }
        private bool ValidateFeesToBePaid()
        {
            bool isValid = true;
            if (checkedListBoxNotPaidFees.CheckedItems.Count > 0)
            {
                List<Fee> feesList = checkedListBoxNotPaidFees.CheckedItems.Cast<Fee>().ToList();
                Fee oldestNotCheckedFee = this.GetOldestNotCheckedFee();
                foreach (var fee in feesList)
                {
                    if (oldestNotCheckedFee != null && fee.Date > oldestNotCheckedFee.Date)
                    {
                        isValid = false;
                        this.labelError.Text = Constants.ERROR_MUST_PAY_OLDESTS_FEES_FIRST;
                        break;
                    }                           
                }
            }
            else
            {
                isValid = false;
                this.labelError.Text = Constants.NOFEES_TOBEPAID;
            }
            return isValid;

        }
        private Fee GetOldestNotCheckedFee()
        {
            Fee firsUnchecked = null;
            foreach(var item in checkedListBoxNotPaidFees.Items)
            {
                if (!checkedListBoxNotPaidFees.CheckedItems.Contains(item))
                {
                    firsUnchecked = (Fee)item;
                    break;
                }
            }
            return firsUnchecked;   
        }
        #endregion

        private void OnStudentNumber_SelectedIndexChange(object sender, EventArgs e)
        {
            if(comboBoxStudentNumbers.SelectedIndex > -1)
            {
                this.CleanForm(true);
                IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
                int selectedStudentNumber = Convert.ToInt32(comboBoxStudentNumbers.SelectedItem);
                Student student = studentOperations.GetStudentByNumber(selectedStudentNumber);

                FillFormWithStudentData(student);
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFeesToBePaid())
                {
                    labelError.Text = string.Empty;
                    IPaymentLogic paymentOperations = Provider.GetInstance.GetPaymentOperations();

                    List<Fee> feesToBePaid = this.checkedListBoxNotPaidFees.CheckedItems.Cast<Fee>().ToList();
                    paymentOperations.PayFees(feesToBePaid);

                    labelSuccess.Text = Constants.FEES_WHERE_SUCCESSFULLY_PAID;
                    CleanForm();
                    this.comboBoxStudentNumbers.SelectedIndex = -1;
                }
            }
            catch (CoreException ex)
            {
                CleanForm(true);
                this.labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                CleanForm(true);
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
