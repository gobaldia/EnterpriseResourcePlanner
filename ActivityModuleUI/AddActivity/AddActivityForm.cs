﻿using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using FrameworkCommon;
using ProviderManager;
using System;
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
            if (this.textBoxActivityName.Text == string.Empty)
            {
                this.labelError.Text = Constants.ACTIVITY_NAME_EMPTY;
                this.labelError.Visible = true;
            }
            else if (this.numericUpDownActivityCost.Value < 0)
            {
                this.labelError.Text = Constants.ACTIVITY_COST_NEGATIVE;
                this.labelError.Visible = true;
            }
            else try
            {
                this.labelError.Visible = false;

                var activityToAdd = new Activity();
                activityToAdd.Name = this.textBoxActivityName.Text;
                activityToAdd.Cost = (int) this.numericUpDownActivityCost.Value;
                activityToAdd.Date = dateTimePickerActivityDate.Value;

                IActivityLogic activitiesOperations = Provider.GetInstance.GetActivityOperations();
                activityToAdd.Id = activitiesOperations.GetNextActivityNumber();
                activitiesOperations.AddActivity(activityToAdd);
                this.CleanForm();
                this.labelSuccess.Text = Constants.SUCCESS_ACTIVITY_REGISTRATION;
            }
            catch (CoreException ex)
            {
                labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
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
