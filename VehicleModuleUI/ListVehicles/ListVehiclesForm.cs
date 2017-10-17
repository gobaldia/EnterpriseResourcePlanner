﻿using CoreEntities.Exceptions;
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

namespace VehicleModuleUI.ListVehicles
{
    public partial class ListVehiclesForm : Form
    {
        public ListVehiclesForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            FillListBoxAvailableVehicles();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }

        private void FillListBoxAvailableVehicles()
        {
            try
            {
                var availableVehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();
                for (int index = 0; index < availableVehicles.Count; index++)
                {
                    this.listBoxAvailableVehicles.Items.Add(availableVehicles[0].GetFullToString());
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            
        }

        private void buttonBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
