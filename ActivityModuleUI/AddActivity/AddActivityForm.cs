using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using FrameworkCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityModuleUI.AddActivity
{
    public partial class AddActivityForm : Form
    {
        public AddActivityForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFormData())
                {
                    labelError.Text = string.Empty;

                    var activityToAdd = new Activity();
                    activityToAdd.Name = this.textBoxActivityName.Text;
                    activityToAdd.Cost = (int) this.numericUpDownActivityCost.Value;
                    activityToAdd.Date = dateTimePickerActivityDate.Value;

                    ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(activityToAdd);
                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_ACTIVITY_REGISTRATION;
                }
            }
            catch (CoreException ex)
            {
                labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
                //TODO: Try log the error somewhere.
            }
        }

        private bool ValidateFormData()
        {
            return this.textBoxActivityName.Text != string.Empty &&
                this.numericUpDownActivityCost.Value > 0;
        }

        private void CleanForm()
        {
            this.textBoxActivityName.Text = string.Empty;
            this.numericUpDownActivityCost.Value = 0;
        }
    }
}
