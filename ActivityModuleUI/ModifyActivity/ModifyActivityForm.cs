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

namespace ActivityModuleUI.ModifyActivity
{
    public partial class ModifyActivityForm : Form
    {
        public ModifyActivityForm()
        {
            InitializeComponent();
            FillActivitiesCombo();
        }

        private void FillActivitiesCombo()
        {
            IActivityLogic activityOperations = Provider.GetInstance.GetActivityOperations();
            List<Activity> activities = activityOperations.GetActivities();

            for (int index = 0; index < activities.Count(); index++)
            {
                this.comboBoxSelectActivityToModify.Items.Add(activities[index]);
            }
            this.comboBoxSelectActivityToModify.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxSelectActivityToModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var selected = (Activity) combo.SelectedItem;
            this.textBoxActivityName.Text = selected.Name;
            this.dateTimePickerActivityDate.Value = selected.Date;
            this.numericUpDownActivityCost.Value = selected.Cost;
            this.buttonModify.Enabled = true;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelError.Visible = false;
                var originalActivity = (Activity)this.comboBoxSelectActivityToModify.SelectedItem;
                var newActivityValues = originalActivity;
                newActivityValues.Name = this.textBoxActivityName.Text;
                newActivityValues.Date = this.dateTimePickerActivityDate.Value;
                newActivityValues.Cost = (int) this.numericUpDownActivityCost.Value;
                IActivityLogic activityOperations = Provider.GetInstance.GetActivityOperations();
                activityOperations.ModifyActivityById(originalActivity.Id, newActivityValues);
                this.labelSuccess.Visible = true;
                this.labelSuccess.Text = Constants.ACTIVITY_SUCCESSFULLY_MODIFIED;
            }
            catch (CoreException ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            this.ReloadComboBoxSelectActivitiesToModify();
            this.CleanFields();
        }

        private void ReloadComboBoxSelectActivitiesToModify()
        {
            this.comboBoxSelectActivityToModify.Items.Clear();
            this.FillActivitiesCombo();
        }

        private void CleanFields()
        {
            this.textBoxActivityName.Text = string.Empty;
            this.numericUpDownActivityCost.Value = 0;
        }
    }
}
