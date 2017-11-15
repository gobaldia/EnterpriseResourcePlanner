using CoreEntities.Entities;
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
            var activities = ClassFactory.GetOrCreate<ActivityLogic>().GetActivities();
            for(int index = 0; index < activities.Count(); index++)
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
            this.ClearListBoxes();
            var combo = (ComboBox)sender;
            var selected = (Activity) combo.SelectedItem;
            this.textBoxActivityName.Text = selected.Name;
            this.dateTimePickerActivityDate.Value = selected.Date;
            this.numericUpDownActivityCost.Value = selected.Cost;
            FillAvailableStudentsListBox(selected.Id);
            FillRegisteredStudentsListBox(selected.Id);
        }

        private void FillAvailableStudentsListBox(int activityId)
        {
            var allStudents = ClassFactory.GetOrCreate<StudentLogic>().GetStudents();
            var activityStudents = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityById(activityId).Students;

            var availableStudents = allStudents.Except(activityStudents).ToList();

            for(int index = 0; index < availableStudents.Count(); index++)
            {
                this.listBoxAvailableStudents.Items.Add(availableStudents[index]);
            }
        }


        private void FillRegisteredStudentsListBox(int activityId)
        {
            var activityStudents = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityById(activityId).Students;

            for(int index = 0; index < activityStudents.Count(); index++)
            {
                this.listBoxAlreadyRegisteredStudents.Items.Add(activityStudents[index]);
            }
        }

        private void ClearListBoxes()
        {
            this.listBoxAvailableStudents.Items.Clear();
            this.listBoxAlreadyRegisteredStudents.Items.Clear();
        }
    }
}
