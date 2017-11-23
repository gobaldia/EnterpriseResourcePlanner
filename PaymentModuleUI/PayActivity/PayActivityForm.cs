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

namespace PaymentModuleUI.PayActivity
{
    public partial class PayActivityForm : Form
    {
        private int AmountToBePaid { get; set; } = 0;
        public PayActivityForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadFormInitialData();
        }

        #region Utility Methods
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void LoadFormInitialData()
        {
            labelAmountToPay.Text = AmountToBePaid.ToString();
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            List<Student> systemStudents = studentOperations.GetStudents();

            foreach (Student student in systemStudents)
                this.comboBoxStudentsNumbers.Items.Add(student.GetStudentNumber());

            this.CleanLists();
        }
        private void CleanLists()
        {
            this.listBoxStudentActivities.Items.Clear();
            this.checkedListBoxAvailableActivities.Items.Clear();
        }
        private void CleanForm(bool cleanComboSelectedChange = false)
        {
            CleanLists();
            textBoxName.Text = string.Empty;
            textBoxDocument.Text = string.Empty;
            labelError.Text = string.Empty;
            labelSuccess.Text = string.Empty;
            AmountToBePaid = 0;
            labelAmountToPay.Text = "0";
            if(!cleanComboSelectedChange)
                this.comboBoxStudentsNumbers.SelectedIndex = -1;
        }
        private void FillFormWithStudentData(Student student)
        {
            FillStudentActivitiesList(student.Activities);
            FillAvailableActivitiesList(student);
        }
        private void FillStudentActivitiesList(List<Activity> selectedStudentActivities)
        {
            foreach (var activity in selectedStudentActivities)
                listBoxStudentActivities.Items.Add(activity);
        }
        private void FillAvailableActivitiesList(Student student)
        {
            List<Activity> studentNoRegisteredActivities = this.GetStudentNotRegisteredActivities(student.Activities);
            foreach (var activity in studentNoRegisteredActivities)
            {
                checkedListBoxAvailableActivities.Items.Add(
                    new ComboBoxItem
                    {
                        Value = activity,
                        Text = string.Format("Name: {0}, Date: {1}, Amount: $ ", activity.Name, activity.Date, activity.Cost)
                    });
            }
            if (studentNoRegisteredActivities?.Count == 0)
                labelError.Text = Constants.NO_AVAILABLE_ACTIVITIES;
            else
                labelError.Text = string.Empty;
        }
        private List<Activity> GetStudentNotRegisteredActivities(List<Activity> studentActivities)
        {
            IActivityLogic activityOperations = Provider.GetInstance.GetActivityOperations();
            List<Activity> systemActivities = activityOperations.GetActivities();

            List<Activity> result;
            if (studentActivities?.Count > 0)
            {
                result = systemActivities.Where(sysActivity
                    => !studentActivities.Any(studentActivity
                    => sysActivity.Id.Equals(studentActivity.Id))).ToList();
            }
            else
                result = systemActivities;

            return result;
        }
        private bool ValidateActivities()
        {
            bool result = true;
            if (checkedListBoxAvailableActivities.Items.Count <= 0)
                result = false;
            else if(checkedListBoxAvailableActivities.CheckedItems.Count <= 0)
            {
                labelError.Text = Constants.SELECT_ONE_ACTIVITY;
                result = false;
            }
            return result;
        }
        private List<Activity> GetCheckedActivities()
        {
            List<Activity> activities = new List<Activity>();
            foreach (var item in this.checkedListBoxAvailableActivities.CheckedItems)
                activities.Add((Activity)(((ComboBoxItem)item).Value));

            return activities;
        }
        #endregion

        private void ButtonPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateActivities())
                {
                    labelError.Text = string.Empty;
                    IPaymentLogic paymentOperations = Provider.GetInstance.GetPaymentOperations();
                    IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();

                    int selectedStudentNumber = Convert.ToInt32(comboBoxStudentsNumbers.SelectedItem);
                    Student student = studentOperations.GetStudentByNumber(selectedStudentNumber);
                    List<Activity> activitiesToBePaid = GetCheckedActivities();
                    paymentOperations.PayAndAddStudentActivities(activitiesToBePaid, student);

                    labelSuccess.Text = Constants.SUCCESS_ACTIVITY_REGISTRATION_AND_PAYMENT;
                    CleanForm();
                }
            }
            catch (CoreException ex)
            {
                CleanLists();
                labelSuccess.Text = string.Empty;
                this.labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                CleanLists();
                labelSuccess.Text = string.Empty;
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }

        private void StudentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentsNumbers.SelectedIndex > -1)
            {
                CleanForm(true);

                IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
                int selectedStudentNumber = Convert.ToInt32(comboBoxStudentsNumbers.SelectedItem);
                Student student = studentOperations.GetStudentByNumber(selectedStudentNumber);

                textBoxName.Text = student.GetFullName();
                textBoxDocument.Text = student.GetDocumentNumber();
                FillFormWithStudentData(student);
            }
        }

        private void checkedListBoxAvailableActivities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e != null)
            {
                var comboItem = ((ComboBoxItem)checkedListBoxAvailableActivities.Items[e.Index]).Value;
                if (e.NewValue == CheckState.Checked)
                    AmountToBePaid += ((Activity)comboItem).Cost;
                else
                    AmountToBePaid -= ((Activity)comboItem).Cost;

                labelAmountToPay.Text = AmountToBePaid.ToString();
            }
        }
    }
}
