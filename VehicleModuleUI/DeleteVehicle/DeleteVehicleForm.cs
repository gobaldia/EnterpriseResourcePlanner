using CoreEntities.Entities;
using CoreEntities.Exceptions;
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

namespace VehicleModuleUI.DeleteVehicle
{
    public partial class DeleteVehicleForm : Form
    {
        public DeleteVehicleForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            FillVehiclesComboBox();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(500, 350);
        }

        private void FillVehiclesComboBox()
        {
            try
            {
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                var vehicles = vehicleOperations.GetVehicles();
                for (int index = 0; index < vehicles?.Count; index++)
                {
                    this.comboBoxSelectVehicleToDelete.Items.Add(vehicles[index]);
                }
                this.comboBoxSelectVehicleToDelete.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
            
        }

        private void comboBoxSelectVehicleToDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllResultLabels();
            this.buttonDelete.Enabled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserConfirmsThatWantToDeleteVehicle())
                {
                    var selectedVehicle = this.comboBoxSelectVehicleToDelete.SelectedItem as Vehicle;
                    IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                    vehicleOperations.DeleteVehicle(selectedVehicle);
                    this.ShowMessageVehicleWasDeleted(selectedVehicle);
                    this.ReloadComboBoxSelectVehicleToDelete();
                    this.HideAllResultLabels();
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

        private void ShowMessageVehicleWasDeleted(Vehicle selectedVehicle)
        {
            this.labelSuccess.Text = "Vehicle " + selectedVehicle + " was succesfully deleted.";
            this.labelSuccess.Visible = true;
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

        private void HideAllResultLabels()
        {
            this.labelError.Visible = false;
            this.labelSuccess.Visible = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
