using CoreEntities.Entities;
using CoreLogic;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
using MainComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainModuleUI
{
    public partial class MainForm : Form
    {
        private MainModule MainModule { get; set; }
        public MainForm(MainModule mainModule)
        {
            this.MainModule = mainModule;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.SetDefaultWindowsSize();
            this.CreateMenu(this.MainModule);
        }

        private void SetDefaultWindowsSize()
        {
            this.Size = new System.Drawing.Size(750, 500);
        }

        private void CreateMenu(MainModule mainModule)
        {
            ToolStripMenuItem mainMenuItem = new ToolStripMenuItem("Menu");
            this.mainMenuStrip.Items.Add(mainMenuItem);

            foreach (var module in mainModule.GetModules())
            {
                MenuMethodInput addModuleInput = new MenuMethodInput { Module = module, MenuItem = mainMenuItem };
                ToolStripMenuItem newmMenuItem = this.AddModuleToMenu(addModuleInput);
                foreach (var action in module.GetActions())
                {
                    var addActionInput = new MenuMethodInput
                    {
                        Module = module,
                        Action = action,
                        MenuItem = newmMenuItem
                    };
                    this.AddActionToModule(addActionInput);
                }
            }
        }

        private ToolStripMenuItem AddModuleToMenu(MenuMethodInput input)
        {
            var newMenuModule = new ToolStripMenuItem(input.Module.GetName(), null);
            input.MenuItem.DropDownItems.Add(newMenuModule);
            return newMenuModule;
        }

        private void AddActionToModule(MenuMethodInput input)
        {
            var actionSubMenu = new ToolStripMenuItem(input.Action.GetName(), null);
            actionSubMenu.Click += (sender, e) => ManageActionClick(input, e);
            input.MenuItem.DropDownItems.Add(actionSubMenu);
        }

        private void ManageActionClick(MenuMethodInput input, System.EventArgs e)
        {
            input.Action.Call();
        }
    }
}
