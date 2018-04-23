// Developer Express Code Central Example:
// How to implement simple copy/paste operations in the GridView from a toolbar menu
// 
// This example illustrates how to implement simple copy/paste/delete operations in
// the GridView.
// You can find more in the article
// http://www.devexpress.com/scid=A1266
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4528

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;


namespace DXGridCRUDoperations
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            InitGrid();

        }
        BindingList<Person> gridDataList = new BindingList<Person>();
        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridControl.DataSource = gridDataList;
            gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gridView1_InitNewRow);
        }

        void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;

            if (view !=null && personToEdit != null)
            {               
                view.SetRowCellValue(e.RowHandle, view.Columns["FirstName"],personToEdit.FirstName);
                view.SetRowCellValue(e.RowHandle, view.Columns["SecondName"], personToEdit.SecondName);
                view.SetRowCellValue(e.RowHandle, view.Columns["Info"], personToEdit.Info); 
            }           
        }
        private EditForm f1;
        private Person personToEdit;
        BindingList<Person> personList = new BindingList<Person>();
        private void iAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            personToEdit = new Person();
            EditPerson(personToEdit, "NewPerson", CloseNewPersonHandler);
        }
        private void EditPerson(Person person, string windowTitle, FormClosingEventHandler closedDelegate)
        {
            f1 = new EditForm(person, false) { Text = windowTitle };
            f1.FormClosing += closedDelegate;
            f1.ShowDialog();
        }
        private void CloseNewPersonHandler(object sender, FormClosingEventArgs e)
        {

            if (((EditForm)sender).DialogResult == DialogResult.OK)
            {
                try
                {                    
                    // personList.Add(personToEdit); //add via Datasource                    
                   //((IList)gridView1.DataSource).Add(personToEdit);  
                    gridView1.AddNewRow();
                }
                catch (Exception ex)
                {
                    HandleExcepton(ex);
                }
                SetNewFocus();
            }
            personToEdit = null;
        }
        private void SetNewFocus()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (personToEdit.FirstName == gridView1.GetRowCellValue(i, gridView1.Columns["FirstName"]).ToString())
                {
                    gridView1.FocusedRowHandle = i;
                    break;
                }
            }
        }
        private void HandleExcepton(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        private void iCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                string s = String.Empty;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    s += gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns[i]) + "\n";
                }
                Clipboard.SetDataObject(s);
            }
            else
            {
                MessageBox.Show("Row is not selected");
            }
        }
        private void iPaste_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                IDataObject data = Clipboard.GetDataObject();
                if (data.GetDataPresent(DataFormats.Text) && gridView1.FocusedRowHandle > -1)
                {
                    string s = data.GetData(DataFormats.Text).ToString();
                    string[] a = s.Split('\n');
                    int i = 0;
                    foreach (GridColumn item in gridView1.Columns)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, item, a[i]);
                        i++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Row is not selected");
            }
        }
        private void iInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            personToEdit = new Person();
            InsertPerson(personToEdit, "InsertForm", InsertPersonHandler);
        }
        private void InsertPerson(Person person, string windowTitle, FormClosingEventHandler closedDelegate)
        {
            f1 = new EditForm(person, true) { Text = windowTitle };
            f1.FormClosing += closedDelegate;
            f1.ShowDialog();
        }
        private void InsertPersonHandler(object sender, FormClosingEventArgs e)
        {
            EditForm form = sender as EditForm;
            if (form != null)
            {
                if (form.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!String.IsNullOrWhiteSpace(form.NewPosition))
                        {
                            int pos = Convert.ToInt32(form.NewPosition);
                            if (pos > personList.Count - 1)
                            {

                                personList.Add(personToEdit);
                            }
                            else
                            {
                                
                                personList.Insert(pos, personToEdit);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect position value");
                        }

                    }
                    catch (Exception ex)
                    {
                        HandleExcepton(ex);
                    }
                }
                SetNewFocus();
            }
            personToEdit = null;
        }
        private void iDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeletePerson(gridView1.FocusedRowHandle);
        }
        public Person GetCurrentPerson()
        {
            return gridView1.GetRow(gridView1.FocusedRowHandle) as Person;
        }
        private void DeletePerson(int focusedRowHandle)
        {
            if (focusedRowHandle < 0)
            {
                MessageBox.Show("You didn't select a person to delete");
                return;
            }
            if (MessageBox.Show("Do you really want to delete the selected person?", "Delete Person", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            try
            {
                //Deleting from datasource
                //personToEdit = GetCurrentPerson();
                //personList.Remove(personToEdit);
                //Deleting from View
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                HandleExcepton(ex);
            }
            gridView1.FocusedRowHandle = focusedRowHandle;
            personToEdit = null;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsMultiSelect && gridView1.SelectedRowsCount > 0)
            {
                gridView1.DeleteSelectedRows();
            }
        }

    }
}