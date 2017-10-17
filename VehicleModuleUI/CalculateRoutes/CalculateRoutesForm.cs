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

namespace VehicleModuleUI.CalculateRoutes
{
    public partial class CalculateRoutesForm : Form
    {
        public CalculateRoutesForm()
        {
            InitializeComponent();
            FillListBoxVehiclesOrderedByCapacity();
        }

        private void FillListBoxVehiclesOrderedByCapacity()
        {
            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehiclesOrderedByCapacityConsideringStudentsNumber();
            for (int index = 0; index < vehicles.Count; index++)
            {
                this.listBoxVehiclesOrderedByCapacity.Items.Add(vehicles[index]);
            }
        }

        private void listBoxVehiclesOrderedByCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
