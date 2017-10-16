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

namespace VehicleModuleUI.AddVehicle
{
    public partial class AddVehicleForm : Form
    {
        public AddVehicleForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.labelSuccess.Visible = false;
            this.labelError.Visible = false;
            var registration = this.textBoxRegistration.Text;
            var capacity = (int) this.numericUpDownCapacity.Value;
            try
            {
                Vehicle vehicle = new Vehicle(registration, capacity);
                ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicle);
                this.labelSuccess.Visible = true;
                this.labelSuccess.Text = "Vehicle " + vehicle + " was successfully added.";
            }
            catch(CoreException ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
