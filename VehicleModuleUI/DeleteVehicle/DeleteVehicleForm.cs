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

namespace VehicleModuleUI.DeleteVehicle
{
    public partial class DeleteVehicleForm : Form
    {
        public DeleteVehicleForm()
        {
            InitializeComponent();
            CheckIfIsThereAnyVehicleInSystem();
            FillVehiclesComboBox();
        }

        private void CheckIfIsThereAnyVehicleInSystem()
        {
            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();
            if (vehicles.Count() == 0)
            {
                this.labelError.Text = "Currently there is not any subject in the system.";
                this.labelError.Visible = true;
            }
        }

        private void FillVehiclesComboBox()
        {
            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();
            for(int index = 0; index < vehicles.Count; index++)
            {
                this.comboBoxSelectVehicleToDelete.Items.Add(vehicles[index]);
            }
            this.comboBoxSelectVehicleToDelete.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBoxSelectVehicleToDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            this.buttonDelete.Enabled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserConfirmsThatWantToDeleteVehicle())
                {
                    var selectedVehicle = this.comboBoxSelectVehicleToDelete.SelectedItem as Vehicle;
                    ClassFactory.GetOrCreate<VehicleLogic>().DeleteVehicle(selectedVehicle);
                    this.labelSuccess.Text = "Vehicle " + selectedVehicle + " was succesfully deleted.";
                    this.labelSuccess.Visible = true;
                    this.ReloadComboBoxSelectVehicleToDelete();
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
            catch (Exception ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
        }

        private bool UserConfirmsThatWantToDeleteVehicle()
        {
            var userAnswer = MessageBox.Show("Are you sure you want to delete this vehicle?",
                    "Delete Vehicle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return userAnswer == DialogResult.Yes;
        }

        private void ReloadComboBoxSelectVehicleToDelete()
        {
            this.comboBoxSelectVehicleToDelete.Items.Clear();
            this.FillVehiclesComboBox();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
