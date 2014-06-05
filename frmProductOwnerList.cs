using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPMercuryDatabaseDirectory
{
    public partial class frmProductOwnerList : DevExpress.XtraEditors.XtraForm
    {
        private UniXP.Common.CProfile m_objProfile;
        public ERP_Mercury.Common.CProductOwner SelectedProductOwner
        {
            get { return (cboxPartsOwner.SelectedItem == null ? null : (ERP_Mercury.Common.CProductOwner)cboxPartsOwner.SelectedItem); }
        }
        public CSalePrognosis SelectedSalePrognosis
        {
            get { return (cboxSalePrognosis.SelectedItem == null ? null : (CSalePrognosis)cboxSalePrognosis.SelectedItem); }
        }

        public frmProductOwnerList(UniXP.Common.CProfile objProfile )
        {
            m_objProfile = objProfile;

            InitializeComponent();

            LoadProductOwnerList();
            LoadSalePrognosisList();
        }

        private void LoadProductOwnerList()
        {
            try
            {
                List<ERP_Mercury.Common.CProductOwner> objProductOwnerList = ERP_Mercury.Common.CProductOwner.GetProductOwnerList(m_objProfile);
                cboxPartsOwner.Properties.Items.Clear();
                if (objProductOwnerList != null)
                {
                    foreach (ERP_Mercury.Common.CProductOwner objProductOwner in objProductOwnerList)
                    {
                        cboxPartsOwner.Properties.Items.Add(objProductOwner);
                    }

                    objProductOwnerList = null;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Не удалось загрузить список товарных марок.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return ;
        }

        private void LoadSalePrognosisList()
        {
            try
            {
                List<CSalePrognosis> objSalePrognosisList = CSalePrognosis.GetSalePrognosisList( m_objProfile, null );
                cboxSalePrognosis.Properties.Items.Clear();
                if (objSalePrognosisList != null)
                {
                    foreach ( CSalePrognosis objSalePrognosis in objSalePrognosisList)
                    {
                        cboxSalePrognosis.Properties.Items.Add(objSalePrognosis);
                    }

                    objSalePrognosisList = null;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Не удалось загрузить список прогнозов продаж.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                cboxPartsOwner.SelectedItem = null;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "btnCancel_Click.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboxPartsOwner.SelectedItem == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Укажате, пожалуйста, товарную марку.", "Внимание!",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "btnSave_Click.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

    }
}
