using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
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

namespace ActivityModuleUI.DeleteActivity
{
    public partial class DeleteActivityForm : Form
    {
        public DeleteActivityForm()
        {
            InitializeComponent();
            FillActivitiesComboBox();
        }

        private void FillActivitiesComboBox()
        {
            IActivityLogic activityOperations = Provider.GetInstance.GetActivityOperations();
            List<Activity> activities = activityOperations.GetActivities();

            for (int index = 0; index < activities.Count(); index++)
            {
                this.comboBoxSelectActivityToDelete.Items.Add(activities[index]);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserConfirmsThatWantToDeleteSubject())
                {
                    var selectedActivityToDelete = (Activity)this.comboBoxSelectActivityToDelete.SelectedItem;
                    //ClassFactory.GetOrCreate<ActivityLogic>().DeleteActivityById(selectedActivityToDelete.Id);

                    IActivityLogic activityOperations = Provider.GetInstance.GetActivityOperations();
                    activityOperations.DeleteActivityById(selectedActivityToDelete.Id);

                    this.labelSuccess.Text = Constants.ACTIVITY_SUCCESSFULLY_DELETED;
                    this.ReloadComboBoxSelectActivityToDelete();
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                this.labelError.Text = "Something went wrong. Please try again.";
            }
        }

        private bool UserConfirmsThatWantToDeleteSubject()
        {
            var userAnswer = MessageBox.Show("Are you sure you want to delete this activity?",
                    "Delete Activity", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return userAnswer == DialogResult.Yes;
        }

        private void ReloadComboBoxSelectActivityToDelete()
        {
            this.comboBoxSelectActivityToDelete.Items.Clear();
            this.FillActivitiesComboBox();
        }

        private void comboBoxSelectActivityToDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonDelete.Enabled = true;
        }
    }
}
