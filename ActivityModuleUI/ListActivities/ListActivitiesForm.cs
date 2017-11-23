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

namespace ActivityModuleUI.ListActivities
{
    public partial class ListActivitiesForm : Form
    {
        public ListActivitiesForm()
        {
            InitializeComponent();
            FillActivitiesListBox();
        }

        private void FillActivitiesListBox()
        {
            IActivityLogic activityOperations = Provider.GetInstance.GetActivityOperations();
            List<Activity> activities = activityOperations.GetActivities();
            var activitiesSortedByDate = activities.OrderBy(a => a.Date).ToList();

            foreach (var activity in activitiesSortedByDate)
            {
                this.listBoxRegisteredActivities.Items.Add(activity);
            }
        }

        private void buttonBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listBoxRegisteredActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedActivity = this.listBoxRegisteredActivities.SelectedItem as Activity;
            this.FillActivitysStudents(selectedActivity);
        }

        private void FillActivitysStudents(Activity selectedActivity)
        {
            this.listBoxActivitysStudents.Items.Clear();
            var students = selectedActivity.Students;
            foreach (var student in students)
            {
                this.listBoxActivitysStudents.Items.Add(student);
            }
        }
    }
}
