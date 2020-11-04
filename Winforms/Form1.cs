using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unique_Column
{
    public partial class Form1 : Form
    {

        SfDataGrid sfDataGrid1;

        public Form1()
        {
            InitializeComponent();
            sfDataGrid1 = new SfDataGrid();
            sfDataGrid1.Dock = DockStyle.Fill;
            this.Controls.Add(sfDataGrid1);
            OrderInfoCollection orderInfoCollection = new OrderInfoCollection();
            sfDataGrid1.DataSource = orderInfoCollection.Orders;
            sfDataGrid1.CurrentCellValidating += SfDataGrid1_CurrentCellValidating;
        }

        private void SfDataGrid1_CurrentCellValidating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellValidatingEventArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                for (int i = 0; i < sfDataGrid1.View.Records.Count; i++)
                {
                    if ((this.sfDataGrid1.View.Records[i].Data as OrderInfo).OrderID.ToString().Equals((e.NewValue.ToString()))&&(e.NewValue.ToString() != e.OldValue.ToString()))
                    {
                        e.IsValid = false;
                        e.ErrorMessage = "Invalid Value";
                        break;
                    }
                }
            }
        }
    } 
}
