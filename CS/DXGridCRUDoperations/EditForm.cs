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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXGridCRUDoperations
{
    public partial class EditForm : Form
    {
        public EditForm(Person person, bool insertFlag)
        {
            InitializeComponent();            
            textEdit1.DataBindings.Add("EditValue",person,"FirstName");
            textEdit2.DataBindings.Add("EditValue", person, "SecondName");
            textEdit3.DataBindings.Add("EditValue", person, "Info");
            if (!insertFlag)
            {
                labelControl4.Visible = false;
                textEdit4.Visible = false;
            }
            else
            {
                textEdit4.EditValueChanged += new EventHandler(textEdit4_EditValueChanged);
            }
        }
        //// Fields...

        private string _NewPosition;
        public string NewPosition
        {
            get { return _NewPosition; }
            set { _NewPosition = value; }
        }
        void textEdit4_EditValueChanged(object sender, EventArgs e)
        {
            NewPosition = ((TextEdit)sender).EditValue.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
