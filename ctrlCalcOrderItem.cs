using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPMercuryDatabaseDirectory
{

    public partial class ctrlCalcOrderItem : UserControl
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private CCalcOrder m_objCalcOrder;
        private System.Boolean m_bPlanIsChanged;
        public System.Boolean PlanIsChanged
        {
            get { return m_bPlanIsChanged; }
        }
        #endregion

        #region События
        // Создаем закрытое экземплярное поле для блокировки синхронизации потоков
        private readonly Object m_eventLock = new Object();
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeCalcOrderItemEventArgs> m_ChangeCalcOrderItem;
        // Создаем в классе член-событие
        public event EventHandler<ChangeCalcOrderItemEventArgs> ChangeCalcOrderItem
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                lock (m_eventLock) { m_ChangeCalcOrderItem += value; }
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                lock (m_eventLock) { m_ChangeCalcOrderItem -= value; }
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeCalcOrderItem(ChangeCalcOrderItemEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeCalcOrderItemEventArgs> temp = m_ChangeCalcOrderItem;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeCalcOrderItem(CCalcOrder objCalcOrder, System.Boolean bIsChanged)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeCalcOrderItemEventArgs e = new ChangeCalcOrderItemEventArgs(objCalcOrder, bIsChanged);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeCalcOrderItem(e);
        }
        #endregion

        #region Конструктор
        public ctrlCalcOrderItem(UniXP.Common.CProfile objProfile, CCalcOrder objCalcOrder)
        {
            m_objProfile = objProfile;

            InitializeComponent();
            
            m_objCalcOrder = objCalcOrder;
            m_bPlanIsChanged = false;
        }
        #endregion

        #region Загрузить приложение к расчету
        /// <summary>
        /// Загружает приложение к расчету
        /// </summary>
        public void LoadCalcOrderItems()
        {
            if (m_objCalcOrder == null) { return; }
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
                this.SuspendLayout();
                treeList.CellValueChanged -= new DevExpress.XtraTreeList.CellValueChangedEventHandler(treeList_CellValueChanged);
                treeList.Nodes.Clear();

                if (m_objCalcOrder.CalcOrderItemList == null)
                {
                    m_objCalcOrder.CalcOrderItemList = CCalcOrderItem.GetCalcOrderItemList(m_objProfile, null, m_objCalcOrder.ID);
                }

                if ((m_objCalcOrder.CalcOrderItemList != null) && (m_objCalcOrder.CalcOrderItemList.Count > 0))
                {
                    treeList.DataSource = m_objCalcOrder.CalcOrderItemList;
                }

                if (treeList.Nodes.Count > 0)
                {
                    treeList.FocusedNode = treeList.Nodes[0];
                }
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка построения содержимого расчета заказа.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
                this.ResumeLayout(false);
                SetPropertiesModified(false);
                treeList.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treeList_CellValueChanged);
            }

            return;
        }
        #endregion

        #region Индикация изменений
        private void SetPropertiesModified(System.Boolean bModified)
        {
            if (bModified == m_bPlanIsChanged) { return; }

            m_bPlanIsChanged = bModified;
            SimulateChangeCalcOrderItem( m_objCalcOrder, m_bPlanIsChanged);
        }
        public void ResetPlanChanges()
        {
            m_bPlanIsChanged = false;
        }
        private void treeList_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка изменения данных в ячейке.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                SetPropertiesModified(true);
            }

            return;

        }
        #endregion

        #region Закрытие закладки
        /// <summary>
        /// Закрывает закладку
        /// </summary>
        public void CloseStockOrderTypeParts()
        {
            try
            {
                if (m_bPlanIsChanged == true)
                {
                    DialogResult resDlg = DevExpress.XtraEditors.XtraMessageBox.Show("\nСохранить изменения?", "Подтверждение",
                    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);

                    switch (resDlg)
                    {
                        case DialogResult.Yes:
                            //SavePartsList();
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось корректно закрыть закладку.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region Печать
        public void PrintCalcOrderItem()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ExportToExcel();
                Cursor.Current = Cursors.Default;

            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "Ошибка печати\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Экспорт бюджета в MS Excel
        /// </summary>
        private void ExportToExcel()
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            System.Int32 iStartRow = 3;
            //Excel.Range oRng;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                object m = Type.Missing;
                //oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                if (oWB.Worksheets.Count > 0)
                {
                    oSheet = (Excel._Worksheet)oWB.Worksheets[1];
                }
                else
                {
                    oWB.Worksheets.Add(m, m, m, Excel.XlSheetType.xlWorksheet);
                    oSheet = (Excel._Worksheet)oWB.Worksheets[1];
                }

                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in treeList.Columns)
                {
                    oSheet.Cells[iStartRow, objColumn.VisibleIndex + 1] = objColumn.Caption;
                }
                iStartRow++;
                oSheet.get_Range("G1", "G1000").NumberFormat = "# ##0";
                oSheet.get_Range("K1", "K1000").NumberFormat = "0000";
                oSheet.get_Range("M1", "M1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("N1", "N1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("O1", "O1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("P1", "P1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("Q1", "Q1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("T1", "T1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("U1", "U1000").NumberFormat = "# ##0";
                oSheet.get_Range("V1", "V1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("W1", "W1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("X1", "X1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("Z1", "Z1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("Y1", "Y1000").NumberFormat = "# ##0";
                oSheet.get_Range("AA1", "AA1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("AB1", "AB1000").NumberFormat = "# ##0,00";
                oSheet.get_Range("AD1", "AD1000").NumberFormat = "# ##0";
                oSheet.get_Range("AE1", "AE1000").NumberFormat = "# ##0";
                oSheet.get_Range("AF1", "AF1000").NumberFormat = "# ##0";
                oSheet.get_Range("AH1", "AH1000").NumberFormat = "# ##0";
                oSheet.get_Range("AJ1", "AJ1000").NumberFormat = "# ##0";
                oSheet.get_Range("AK1", "AK1000").NumberFormat = "# ##0";
                oSheet.get_Range("AL1", "AL1000").NumberFormat = "# ##0";
                oSheet.get_Range("AM1", "AM1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("AN1", "AN1000").NumberFormat = "# ##0,000";
                oSheet.get_Range("AO1", "AO1000").NumberFormat = "# ##0";
                oSheet.get_Range("AP1", "AP1000").NumberFormat = "# ##0";

                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeList.Nodes)
                {

                    oSheet.Cells[iStartRow, 1] = System.Convert.ToString(objNode.GetValue(colTradeMark));
                    oSheet.Cells[iStartRow, 2] = System.Convert.ToString(objNode.GetValue(colProductLineName));
                    oSheet.Cells[iStartRow, 3] = System.Convert.ToString(objNode.GetValue(colProductTypeName));
                    oSheet.Cells[iStartRow, 4] = System.Convert.ToString(objNode.GetValue(colProductSubTypeName));
                    oSheet.Cells[iStartRow, 5] = System.Convert.ToString(objNode.GetValue(colProductOriginalName));
                    oSheet.Cells[iStartRow, 6] = System.Convert.ToString(objNode.GetValue(colCodeTNVD));
                    oSheet.Cells[iStartRow, 7] = objNode.GetValue(colIB_ID);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 7], oSheet.Cells[iStartRow, 7]).NumberFormat = "# ##0";
                    oSheet.Cells[iStartRow, 8] = objNode.GetValue(colProductName);
                    oSheet.Cells[iStartRow, 9] = objNode.GetValue(colProductReference);
                    oSheet.Cells[iStartRow, 10] = objNode.GetValue(colProductArticle);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 11], oSheet.Cells[iStartRow, 11]).NumberFormat = "0000";
                    oSheet.Cells[iStartRow, 11] = "''" + objNode.GetValue(colProductBarCode) + "'";
                    oSheet.Cells[iStartRow, 12] = objNode.GetValue(colProductCountryProduction);
                    oSheet.Cells[iStartRow, 13] =  System.Convert.ToDecimal( objNode.GetValue(colProductWeight) );
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 13], oSheet.Cells[iStartRow, 13]).NumberFormat = "# ##0,000";
                    oSheet.Cells[iStartRow, 14] = objNode.GetValue(colProductPlasticContainerWeight);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 14], oSheet.Cells[iStartRow, 14]).NumberFormat = "# ##0,000";
                    oSheet.Cells[iStartRow, 15] = objNode.GetValue(colProductPaperContainerWeight);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 15], oSheet.Cells[iStartRow, 15]).NumberFormat = "# ##0,000";
                    oSheet.Cells[iStartRow, 16] = objNode.GetValue(colProductAlcoholicContentPercent);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 16], oSheet.Cells[iStartRow, 16]).NumberFormat = "# ##0,00";
                    oSheet.Cells[iStartRow, 17] = objNode.GetValue(colProductVendorPrice);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 17], oSheet.Cells[iStartRow, 17]).NumberFormat = "# ##0,00";
                    oSheet.Cells[iStartRow, 18] = objNode.GetValue(colProductCurrency);
                    oSheet.Cells[iStartRow, 19] = objNode.GetValue(colABC);
                    oSheet.Cells[iStartRow, 20] = objNode.GetValue(colQUANTITY_MIN_STOCK_IN_WEEK);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 20], oSheet.Cells[iStartRow, 20]).NumberFormat = "# ##0";
                    oSheet.Cells[iStartRow, 21] = objNode.GetValue(colProductPackQuantityForCalc);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 21], oSheet.Cells[iStartRow, 21]).NumberFormat = "# ##0";
                    oSheet.Cells[iStartRow, 22] = objNode.GetValue(colPLAN_FOR_3MONTH_IN_WEEK_AVG);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 22], oSheet.Cells[iStartRow, 22]).NumberFormat = "# ##0,00";
                    oSheet.Cells[iStartRow, 23] = objNode.GetValue(colSALE_FOR_3MONTH_IN_WEEK_AVG);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 23], oSheet.Cells[iStartRow, 23]).NumberFormat = "# ##0,00";
                    oSheet.Cells[iStartRow, 24] = objNode.GetValue(colKOEFF_SEASON_AVG);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 24], oSheet.Cells[iStartRow, 24]).NumberFormat = "# ##0,000";
                    oSheet.Cells[iStartRow, 25] = objNode.GetValue(colPREDICTION_FOR_3MONTH_IN_WEEK_AVG);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 25], oSheet.Cells[iStartRow, 25]).NumberFormat = "# ##0,000";
                    oSheet.Cells[iStartRow, 26] = objNode.GetValue(colKOEFF_DIV);
                    oSheet.Cells[iStartRow, 28] = oSheet.get_Range(oSheet.Cells[iStartRow, 28], oSheet.Cells[iStartRow, 28]).Formula = "=ЕСЛИ((RC[-2]>3/10);((RC[-6]+RC[-3])/2);(ЕСЛИ((RC[-6]>RC[-3]);RC[-6];RC[-3])))";
                    if (System.Convert.ToDouble(objNode.GetValue(colKOEFF_DIV)) >= 0.3)
                    {
                        oSheet.get_Range(oSheet.Cells[iStartRow, 26], oSheet.Cells[iStartRow, 26]).Interior.Color = 255;
                        oSheet.get_Range(oSheet.Cells[iStartRow, 26], oSheet.Cells[iStartRow, 26]).Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                        oSheet.get_Range(oSheet.Cells[iStartRow, 28], oSheet.Cells[iStartRow, 28]).Interior.Color = 255;
                        oSheet.get_Range(oSheet.Cells[iStartRow, 28], oSheet.Cells[iStartRow, 28]).Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                    }
                    else
                    {
                        oSheet.get_Range(oSheet.Cells[iStartRow, 26], oSheet.Cells[iStartRow, 26]).Interior.Pattern = Excel.XlPattern.xlPatternNone;
                        oSheet.get_Range(oSheet.Cells[iStartRow, 28], oSheet.Cells[iStartRow, 28]).Interior.Pattern = Excel.XlPattern.xlPatternNone;
                    }
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 26], oSheet.Cells[iStartRow, 26]).NumberFormat = "# ##0,000";
                    oSheet.Cells[iStartRow, 27] = objNode.GetValue(colPREDICTION_FOR_3MONTH_IN_WEEK_AVG); //objNode.GetValue(colCORRECT_FOR_3MONTH_IN_WEEK_AVG);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 27], oSheet.Cells[iStartRow, 27]).NumberFormat = "# ##0,00";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 27], oSheet.Cells[iStartRow, 27]).Interior.Color = 35;
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 27], oSheet.Cells[iStartRow, 27]).Interior.Parent = "xlSolid"; // Excel.XlPattern.xlPatternSolid;
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 28], oSheet.Cells[iStartRow, 28]).NumberFormat = "# ##0,00";
                    oSheet.Cells[iStartRow, 29] = objNode.GetValue(colProductIsNew);
                    oSheet.Cells[iStartRow, 30] = objNode.GetValue(colQUANTITY_IN_STOCK);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 30], oSheet.Cells[iStartRow, 30]).NumberFormat = "# ##0";
                    oSheet.Cells[iStartRow, 31] = objNode.GetValue(colQUANTITY_IN_WAY);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 31], oSheet.Cells[iStartRow, 31]).NumberFormat = "# ##0";
                    oSheet.Cells[iStartRow, 32] = objNode.GetValue(colQUANTITY_IN_ORDER);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 32], oSheet.Cells[iStartRow, 32]).NumberFormat = "# ##0";
                    oSheet.Cells[iStartRow, 33] = objNode.GetValue(colProductProcessDayCount);
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 33], oSheet.Cells[iStartRow, 33]).NumberFormat = "# ##0";
                    // товарный запас
                    oSheet.get_Range(oSheet.Cells[iStartRow, 34], oSheet.Cells[iStartRow, 34]).Formula = "=ЕСЛИ( (RC[-4]+RC[-3]+RC[-2] - (RC[-6]*RC[-1])) < 0;0;(RC[-4]+RC[-3]+RC[-2] - (RC[-6]*RC[-1])))";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 34], oSheet.Cells[iStartRow, 34]).NumberFormat = "# ##0";
                    // Количество недель для расчета
                    oSheet.Cells[iStartRow, 35] = 3;
                    // Потребность в товаре
                    oSheet.get_Range(oSheet.Cells[iStartRow, 36], oSheet.Cells[iStartRow, 36]).Formula = "=RC[-8]*(RC[-16]+RC[-1])-RC[-2]";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 36], oSheet.Cells[iStartRow, 36]).NumberFormat = "# ##0";
                    // Потребность скорректировнная
                    oSheet.get_Range(oSheet.Cells[iStartRow, 37], oSheet.Cells[iStartRow, 37]).Formula = "=ЕСЛИ(RC[-1]<0;0;RC[-1])";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 37], oSheet.Cells[iStartRow, 37]).NumberFormat = "# ##0";
                    // Расчет заказа (шт.)
                    oSheet.get_Range(oSheet.Cells[iStartRow, 38], oSheet.Cells[iStartRow, 38]).Formula = "=ОКРУГЛ((RC[-1]/RC[-17]);0)*RC[-17]";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 38], oSheet.Cells[iStartRow, 38]).Formula = "=ОКРУГЛВВЕРХ((RC[-1]/RC[-17]);1)*RC[-17]";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 38], oSheet.Cells[iStartRow, 38]).NumberFormat = "# ##0";
                    // Расчет заказа (сумма)
                    oSheet.get_Range(oSheet.Cells[iStartRow, 39], oSheet.Cells[iStartRow, 39]).Formula = "=RC[-1]*RC[-22]";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 39], oSheet.Cells[iStartRow, 39]).NumberFormat = "# ##0,000";
                    // Вес заказа (сумма)
                    oSheet.get_Range(oSheet.Cells[iStartRow, 40], oSheet.Cells[iStartRow, 40]).Formula = "=RC[-2]*RC[-27]";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 40], oSheet.Cells[iStartRow, 40]).NumberFormat = "# ##0,000";
                    // Заказ коробок/паллет
                    oSheet.get_Range(oSheet.Cells[iStartRow, 41], oSheet.Cells[iStartRow, 41]).Formula = "=RC[-3]/RC[-20]";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 41], oSheet.Cells[iStartRow, 41]).NumberFormat = "# ##0";
                    // ТЗ с учетом заказа
                    oSheet.get_Range(oSheet.Cells[iStartRow, 42], oSheet.Cells[iStartRow, 42]).Formula = "=ЕСЛИ(RC[-14]=0;0;((RC[-8]+RC[-4])/RC[-14]))";
                    //oSheet.get_Range(oSheet.Cells[iStartRow, 42], oSheet.Cells[iStartRow, 42]).NumberFormat = "# ##0";

                    iStartRow++;
                }
                oSheet.get_Range("A1", "Z1").EntireColumn.AutoFit();
                oSheet.get_Range("Z1", "AZ1").ColumnWidth = 15;

                oSheet.get_Range("A3", "AZ3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A3", "AZ3").WrapText = true;
                oSheet.get_Range("A3", "AZ3").ColumnWidth = 20;
                oSheet.get_Range("X1", "X1").EntireColumn.Hidden = true;
                oSheet.get_Range("AA1", "AA1").EntireColumn.Hidden = true;

                ((Excel._Worksheet)oWB.Worksheets[1]).Activate();
                //oSheet.get_Range("AA1", "AA65000").Locked = false;
                //oSheet.get_Range("AI1", "AI65000").Locked = false;
                //oSheet.get_Range("AK1", "AK65000").Locked = false;
                //oSheet.Protect("A1", true, true, true, true, true, true, false, false, false, false, false, false, false, false, false);

                //// теперь у нас нужное количество листов
                //// попробуем пройти список ячеек за один проход
                //System.Guid uuidProductOwnerId = System.Guid.Empty;
                //System.Guid uuidProductTypeId = System.Guid.Empty;
                //System.Int32 iSheetNum = 0;
                //System.Int32 iStartRowNum = 4;
                //oSheet = null;
                //foreach (CPlanCell objPlanCell in m_objPlanOrder.PlanCellList)
                //{
                //    if (objPlanCell.ProductOwner.Id.CompareTo(uuidProductOwnerId) != 0)
                //    {
                //        // меняется товарная марка и, как следствие, лист
                //        if (oSheet != null)
                //        {
                //            for (System.Int32 i = 2; i <= 14; i++)
                //            {
                //                oSheet.get_Range(oSheet.Cells[iStartRowNum + 1, i], oSheet.Cells[iStartRowNum + 1, i]).Formula = "=СУММ(R[-" + (iStartRowNum - 4).ToString() + "]C:R[-1]C)";
                //                oSheet.get_Range(oSheet.Cells[iStartRowNum + 1, i], oSheet.Cells[iStartRowNum + 1, i]).NumberFormat = "# ##0";
                //                oSheet.get_Range(oSheet.Cells[iStartRowNum + 1, i], oSheet.Cells[iStartRowNum + 1, i]).Font.Bold = true;
                //                oSheet.get_Range(oSheet.Cells[iStartRowNum + 1, i], oSheet.Cells[iStartRowNum + 1, i]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                //            }
                //            oSheet.get_Range("A1", "Z1").EntireColumn.AutoFit();
                //            oSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                //            oSheet.PageSetup.Zoom = false;
                //            oSheet.PageSetup.FitToPagesTall = 1;
                //            oSheet.PageSetup.FitToPagesTall = 1;
                //        }

                //        iStartRowNum = 4;
                //        iSheetNum++;
                //        uuidProductOwnerId = objPlanCell.ProductOwner.Id;
                //        oSheet = (Excel._Worksheet)oWB.Worksheets[iSheetNum];
                //        oSheet.Name = objPlanCell.ProductOwner.Name.Replace('/', ' ');
                //        oSheet.Cells[1, 1] = objPlanCell.ProductOwner.Name.Replace('\t', ' ');
                //        // Имена столбцов
                //        oSheet.Cells[3, 1] = "Товарная группа";
                //        oSheet.Cells[3, 2] = "Январь";
                //        oSheet.Cells[3, 3] = "Февраль";
                //        oSheet.Cells[3, 4] = "Март";
                //        oSheet.Cells[3, 5] = "Апрель";
                //        oSheet.Cells[3, 6] = "Май";
                //        oSheet.Cells[3, 7] = "Июнь";
                //        oSheet.Cells[3, 8] = "Июль";
                //        oSheet.Cells[3, 9] = "Август";
                //        oSheet.Cells[3, 10] = "Сентябрь";
                //        oSheet.Cells[3, 11] = "Октябрь";
                //        oSheet.Cells[3, 12] = "Ноябрь";
                //        oSheet.Cells[3, 13] = "Декабрь";

                //        oSheet.get_Range("A3", "M3").Font.Size = 12;
                //        oSheet.get_Range("A3", "M3").Font.Bold = true;
                //        oSheet.get_Range("A3", "M3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                //    }
                //    if (objPlanCell.ProductType.Id.CompareTo(uuidProductTypeId) != 0)
                //    {
                //        // меняется товарная группа
                //        uuidProductTypeId = objPlanCell.ProductType.Id;
                //        iStartRowNum++;
                //        oSheet.Cells[iStartRowNum, 1] = objPlanCell.ProductType.Name;
                //        oSheet.get_Range(oSheet.Cells[iStartRowNum, 14], oSheet.Cells[iStartRowNum, 14]).Formula = "=СУММ(RC[-12]:RC[-1])";
                //        oSheet.get_Range(oSheet.Cells[iStartRowNum, 14], oSheet.Cells[iStartRowNum, 14]).NumberFormat = "# ##0";
                //        oSheet.get_Range(oSheet.Cells[iStartRowNum, 14], oSheet.Cells[iStartRowNum, 14]).Font.Bold = true;
                //        oSheet.get_Range(oSheet.Cells[iStartRowNum, 14], oSheet.Cells[iStartRowNum, 14]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                //    }
                //    oSheet.Cells[iStartRowNum, (System.Convert.ToInt32(objPlanCell.Month) + 1)] = objPlanCell.PlanQuantity;
                //}

                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (System.Exception f)
            {
                oXL = null;
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка экспорта в MS Excel.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        private void treeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public partial class ChangeCalcOrderItemEventArgs : EventArgs
    {
        private readonly System.Boolean m_bIsChanged;
        public System.Boolean IsChanged
        { get { return m_bIsChanged; } }

        private readonly CCalcOrder m_objCalcOrder;
        public CCalcOrder CalcOrder
        { get { return m_objCalcOrder; } }
        
        public ChangeCalcOrderItemEventArgs( CCalcOrder objCalcOrder, System.Boolean bIsChanged)
        {
            m_objCalcOrder = objCalcOrder;
            m_bIsChanged = bIsChanged;
        }
    }

}
