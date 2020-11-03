# How to enter the unique value in WinForms DataGrid (SfDataGrid) ?

How to enter the unique value in WinForms DataGrid (SfDataGrid) ?

# About the sample
In SfDataGrid you can make a specific column accept unique value per row using SfDataGrid.CurrentCellValidating event.
```c#
sfDataGrid1.CurrentCellValidating += SfDataGrid1_CurrentCellValidating;
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
```
## Requirements to run the demo
 Visual Studio 2015 and above versions
