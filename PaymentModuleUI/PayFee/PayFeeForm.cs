using CoreEntities.Entities;
using CoreLogic.Interfaces;
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
            this.Size = new System.Drawing.Size(600, 465);
        }
        private void LoadFormInitialData()
        {
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            List<Student> systemStudents = studentOperations.GetStudents();
            
            foreach (Student student in systemStudents)
                this.comboBoxStudentNumbers.Items.Add(student.GetStudentNumber());
        }
        private void FillFormWithStudentData(Student student)
        {
            textBoxDocumentNumber.Text = student.GetDocumentNumber();
            textBoxFullName.Text = student.GetFullName();

            IPaymentLogic paymentOperations = Provider.GetInstance.GetPaymentOperations();
            List<Fee> studentFees = paymentOperations.GetCurrentYearFeesByStudentNumber(student.StudentNumber);
            foreach (Fee f in studentFees)
                checkedListBoxOfFees.Items.Add(f);
        }
        #endregion

        private void OnStudentNumber_SelectedIndexChange(object sender, EventArgs e)
        {
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            int studentNumber = Convert.ToInt32(comboBoxStudentNumbers.SelectedItem);
            Student student = studentOperations.GetStudentByNumber(studentNumber);

            FillFormWithStudentData(student);
        }
    }
}
