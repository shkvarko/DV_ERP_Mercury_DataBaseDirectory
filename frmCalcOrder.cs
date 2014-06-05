using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPMercuryDatabaseDirectory
{
    public partial class frmCalcOrder : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private System.Boolean m_bPlanIsChanged;
        private List<CCalcOrder> m_objCalcOrderList;
        private DevExpress.XtraGrid.Views.Base.ColumnView ColumnView
        {
            get { return gridControlProductList.MainView as DevExpress.XtraGrid.Views.Base.ColumnView; }
        }
        private const System.Int32 m_iStartSplitterPosition = 180;
        #endregion

        #region Конструктор
        public frmCalcOrder(UniXP.Common.CProfile objProfile, UniXP.Common.MENUITEM objMenuItem)
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_objMenuItem = objMenuItem;
            m_bPlanIsChanged = false;
            m_objCalcOrderList = null;

            AddGridColumns();
            LoadCalcOrderList();
            Text = m_objMenuItem.strName;
        }
        #endregion

        #region Список расчетов
        private void AddGridColumns()
        {
            ColumnView.Columns.Clear();
            AddGridColumn(ColumnView, "ID", "УИ расчета");
            AddGridColumn(ColumnView, "CalcOrderDate", "Дата");
            AddGridColumn(ColumnView, "Num", "Номер");
            AddGridColumn(ColumnView, "ProductTradeMarkName", "Товарная марка");
            AddGridColumn(ColumnView, "SalePrognosisName", "Прогноз продаж");
            
            foreach (DevExpress.XtraGrid.Columns.GridColumn objColumn in ColumnView.Columns)
            {
                objColumn.OptionsColumn.AllowEdit = false;
                objColumn.OptionsColumn.AllowFocus = false;
                objColumn.OptionsColumn.ReadOnly = true;
                objColumn.Visible = (objColumn.FieldName != "ID");
            }
        }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Base.ColumnView view, string fieldName, string caption) { AddGridColumn(view, fieldName, caption, null); }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Base.ColumnView view, string fieldName, string caption, DevExpress.XtraEditors.Repository.RepositoryItem item) { AddGridColumn(view, fieldName, caption, item, "", DevExpress.Utils.FormatType.None); }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Base.ColumnView view, string fieldName, string caption, DevExpress.XtraEditors.Repository.RepositoryItem item, string format, DevExpress.Utils.FormatType type)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = view.Columns.AddField(fieldName);
            column.Caption = caption;
            column.ColumnEdit = item;
            column.DisplayFormat.FormatType = type;
            column.DisplayFormat.FormatString = format;
            column.VisibleIndex = view.VisibleColumns.Count;
        }

        /// <summary>
        /// Запрашивает список расчетов
        /// </summary>
        private void LoadCalcOrderList()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.splitContainerControl.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.gridControlProductList)).BeginInit();

                gridControlProductList.DataSource = null;

                m_objCalcOrderList = CCalcOrder.GetCalcOrderList( m_objProfile, null );

                if (m_objCalcOrderList != null)
                {
                    gridControlProductList.DataSource = m_objCalcOrderList;

                }

                this.splitContainerControl.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.gridControlProductList)).EndInit();
                splitContainerControl.SplitterPosition = m_iStartSplitterPosition;
                //splitContainerControl.Panel2.Size = new Size(200, splitContainerControl.Panel2.Size.Height);
                splitContainerControl.Refresh();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка обновления списка. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return ;
        }
        private void frmCalcOrder_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCalcOrderList();
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка открытия формы.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LoadCalcOrderList();
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка обновления списка расчетов.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }

        #endregion

        #region Загрузить содержимое расчета
        /// <summary>
        /// Возвращает ссылку на выбранный в списке товар
        /// </summary>
        /// <returns>ссылка на товар</returns>
        private CCalcOrder GetSelectedCalcOrder()
        {
            CCalcOrder objRet = null;
            try
            {
                if ((((DevExpress.XtraGrid.Views.Grid.GridView)gridControlProductList.MainView).RowCount > 0) &&
                    (((DevExpress.XtraGrid.Views.Grid.GridView)gridControlProductList.MainView).FocusedRowHandle >= 0))
                {
                    System.Guid uuidID = (System.Guid)(((DevExpress.XtraGrid.Views.Grid.GridView)gridControlProductList.MainView)).GetFocusedRowCellValue("ID");

                    if ((m_objCalcOrderList != null) && (m_objCalcOrderList.Count > 0) && (uuidID.CompareTo(System.Guid.Empty) != 0))
                    {
                        foreach (CCalcOrder objCalcOrder in m_objCalcOrderList)
                        {
                            if (objCalcOrder.ID.CompareTo(uuidID) == 0)
                            {
                                objRet = objCalcOrder;
                                break;
                            }
                        }
                    }
                }
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка поиска выбранного расчета. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return objRet;
        }
        private void gridControlProductList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CCalcOrder objSelectedCalcOrder = GetSelectedCalcOrder();
                LoadData(objSelectedCalcOrder);
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка просмотра приложения к расчету. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return;
        }


        private void LoadData(CCalcOrder objCalcOrder)
        {
            try
            {
                //System.String strStartProcess = "идет загрузка данных...";
                if (objCalcOrder == null) { return; }
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                System.Boolean bPageExsits = false;
                System.String strTabName = objCalcOrder.Num;
                foreach (DevExpress.XtraTab.XtraTabPage tabPageItem in tabControl.TabPages)
                {
                    if (tabPageItem.Name == strTabName)
                    {
                        bPageExsits = true;
                        tabControl.SelectedTabPage = tabPageItem;
                        break;
                    }
                }
                if (bPageExsits == true) { return; }

                DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
                if (tabPage != null)
                {
                    tabPage.Name = strTabName;
                    tabControl.TabPages.Add(tabPage);
                    tabControl.SelectedTabPage = tabPage;

                    ctrlCalcOrderItem ViewerCalcOrderItem = new ctrlCalcOrderItem(m_objProfile, objCalcOrder);
                    if (ViewerCalcOrderItem != null)
                    {
                        tabPage.Controls.Add(ViewerCalcOrderItem);
                        tabPage.Text = strTabName;
                        ViewerCalcOrderItem.Dock = DockStyle.Fill;

                        this.Refresh();

                        ViewerCalcOrderItem.LoadCalcOrderItems();
                        ViewerCalcOrderItem.ChangeCalcOrderItem += this.OnChangeCalcOrderItem;
                    }
                    this.Refresh();
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка загрузки плана закупок для ." + objCalcOrder.Num + "\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return;
        }
        private void SetPropertiesModified(System.Boolean bModified)
        {
            if (bModified == m_bPlanIsChanged) { return; }

            m_bPlanIsChanged = bModified;
        }

        private void OnChangeCalcOrderItem(Object sender, ChangeCalcOrderItemEventArgs e)
        {
            try
            {
                if (e.IsChanged == true)
                {
                    SetPropertiesModified(true);
                }
                if (tabControl.TabPages.Count > 0)
                {
                    foreach (DevExpress.XtraTab.XtraTabPage tabPage in tabControl.TabPages)
                    {
                        if (tabPage.Name == e.CalcOrder.Num)
                        {
                            tabPage.Image = (e.IsChanged == true) ? ERPMercuryDatabaseDirectory.Properties.Resources.warning : ERPMercuryDatabaseDirectory.Properties.Resources.check2;
                            tabPage.Refresh();
                            break;
                        }
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangePlanVariable.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        #endregion

        #region Закрыть закладки
        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                if ((tabControl.TabPages.Count == 0) || (tabControl.SelectedTabPage == null)) { return; }
                // закрываем закладку
                CloseTabPage(tabControl.SelectedTabPage, true);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("tabControl_CloseButtonClick.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// Закрывает закладку вместе с работающим в ней потоком
        /// </summary>
        /// <param name="tPage">закладка</param>
        /// <param name="bConfirm">Признак "Выдавать сообщение"</param>
        private void CloseTabPage(DevExpress.XtraTab.XtraTabPage tabPage, System.Boolean bConfirm)
        {
            System.String tPageText = "";
            try
            {
                if (tabControl.TabPages.Count == 0) { return; }
                if (tabPage == null) { return; }
                if (tabPage.Controls.Count == 0) { return; }
                tPageText = tabPage.Text;

                ctrlCalcOrderItem ViewerPlanProductOwner = (ctrlCalcOrderItem)tabPage.Controls[0];
                if (ViewerPlanProductOwner == null) { return; }

                if (ViewerPlanProductOwner.PlanIsChanged == true)
                {
                    DialogResult resDlg = DevExpress.XtraEditors.XtraMessageBox.Show("Сохранить изменения в расчете?", "Подтверждение",
                    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);

                    switch (resDlg)
                    {
                        case DialogResult.Yes:
                            {
                                //// попробуем сохранить
                                //if (bSavePlanOnlyOneProductOwner(tabPage) == true)
                                //{
                                    ViewerPlanProductOwner = null;
                                    tabControl.TabPages.Remove(tabPage);
                                    tabPage = null;
                                    this.Refresh();
                                //}
                                break;
                            }
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ViewerPlanProductOwner = null;
                    tabControl.TabPages.Remove(tabPage);
                    tabPage = null;
                    this.Refresh();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(tPageText + "\nCloseTabPage.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
            }
            finally
            {
            }
            return;
        }
        private void frmCalcOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tabControl.TabPages.Count > 0)
                {
                    System.Boolean bFindChanges = false;
                    foreach (DevExpress.XtraTab.XtraTabPage tabPage in tabControl.TabPages)
                    {
                        if (((ctrlCalcOrderItem)tabPage.Controls[0]).PlanIsChanged == true)
                        {
                            bFindChanges = true;
                            break;
                        }
                    }
                    if (bFindChanges == true)
                    {
                        DialogResult resDlg = DevExpress.XtraEditors.XtraMessageBox.Show(
                        "План заказа поставщику был изменен.\nСохранить изменения в плане?", "Подтверждение",
                        System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question);

                        switch (resDlg)
                        {
                            case DialogResult.Yes:
                                {
                                    //e.Cancel = (bSavePlan() == true) ? false : true;
                                    break;
                                }
                            case DialogResult.No:
                                break;
                            case DialogResult.Cancel:
                                {
                                    e.Cancel = true;
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка закрытия формы.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frmCalcOrder_FormClosing);
                this.Close();
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCalcOrder_FormClosing);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка отмены изменений.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK,  System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        #endregion

        #region Печать
        private void barBtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabControl.TabPages.Count == 0) { return; }
            if (tabControl.SelectedTabPage == null) { return; }
            if (tabControl.SelectedTabPage.Controls.Count == 0) { return; }

            ctrlCalcOrderItem ViewerPlanProductOwner = (ctrlCalcOrderItem)tabControl.SelectedTabPage.Controls[0];
            if (ViewerPlanProductOwner == null) { return; }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SendMessageToLog("идет экспорт данных в Microsoft Excel...");
                ViewerPlanProductOwner.PrintCalcOrderItem();
                SendMessageToLog("завершен экспорт данных в Microsoft Excel");
                Cursor.Current = Cursors.Default;

            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "Ошибка печати\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Журнал сообщений
        private void SendMessageToLog(System.String strMessage)
        {
            try
            {
                m_objMenuItem.SimulateNewMessage(strMessage);
                this.Refresh();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "SendMessageToLog.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Расчет заказа
        /// <summary>
        /// Расчет заказа
        /// </summary>
        private void CalcOrder()
        {
            try
            {
                frmProductOwnerList objfrmProductOwnerList = new frmProductOwnerList(m_objProfile);
                if (objfrmProductOwnerList != null)
                {
                    if ((objfrmProductOwnerList.ShowDialog() == DialogResult.OK) &&
                        (objfrmProductOwnerList.SelectedProductOwner != null))
                    {
                        System.String strErr = "";
                        System.String strProductOwnerName = "Выбрана товарная марка: " + objfrmProductOwnerList.SelectedProductOwner.Name;
                        System.String strSaleprognosisName = ((objfrmProductOwnerList.SelectedSalePrognosis == null) ? "" : ( "прогноз продаж: " + objfrmProductOwnerList.SelectedSalePrognosis.ToString() ) ) ;

                        if (DevExpress.XtraEditors.XtraMessageBox.Show(
                            strProductOwnerName + "\n" + strSaleprognosisName + ".\n\nРасчет заказа может занять несколько минут.\nНачать расчет?", "Подтверждение",
                            System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SendMessageToLog("идет расчет заказа для товарной марки " + objfrmProductOwnerList.SelectedProductOwner.Name + "...");
                            this.Refresh();
                            this.Cursor = Cursors.WaitCursor;
                            if (CCalcOrder.CalcOrder(m_objProfile, null, objfrmProductOwnerList.SelectedProductOwner, objfrmProductOwnerList.SelectedSalePrognosis, ref strErr) == true)
                            {
                                this.Cursor = Cursors.Default;
                                SendMessageToLog("расчет заказа завершен");
                                DevExpress.XtraEditors.XtraMessageBox.Show(
                                    "Заказ успешно расчитан. Нажмите кнопку \"Обновить\"", "Информация",
                                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                SendMessageToLog("ошибка расчета заказа");
                                DevExpress.XtraEditors.XtraMessageBox.Show(
                                   "Ошибка расчета заказа.\n\nТекст ошибки: " + strErr, "Ошибка",
                                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                    }

                }
                objfrmProductOwnerList = null;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка расчета заказа.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }
        private void barBtnCalcOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CalcOrder();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "barBtnCalcOrder_ItemClick.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Удаление расчета заказа
        private void RemoveCalcOrder( CCalcOrder objCalcOrder )
        {
            if (objCalcOrder == null) { return ;}

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (objCalcOrder.Remove(m_objProfile) == true)
                {
                    CCalcOrder objCalcOrderForDelete = null;
                    foreach (CCalcOrder objItem in m_objCalcOrderList)
                    {
                        if (objItem.ID.CompareTo(objCalcOrder.ID) == 0)
                        {
                            objCalcOrderForDelete = objItem;
                            break;
                        }
                    }
                    if (objCalcOrderForDelete != null)
                    {
                        m_objCalcOrderList.Remove(objCalcOrderForDelete);
                        gridControlProductList.RefreshDataSource();
                    }
                }
                
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка удаления расчета. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return ;

        }
        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CCalcOrder objCalcOrder = GetSelectedCalcOrder();
                if(objCalcOrder != null )
                {
                    if( DevExpress.XtraEditors.XtraMessageBox.Show( "Подтвердите удаления расчета: " + objCalcOrder.ToString(), "Внимание",
                        System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes )
                    {
                        RemoveCalcOrder(objCalcOrder);
                    }
                }
                
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка удаления расчета. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return ;

        }
        #endregion


    }

    public class ViewCalcOrder : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmCalcOrder obj = new frmCalcOrder(objMenuItem.objProfile, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }

    }

}
