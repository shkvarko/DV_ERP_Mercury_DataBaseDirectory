using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP_Mercury.Common;

namespace ERPMercuryDatabaseDirectory
{
    /// <summary>
    /// Класс "Расчет заказа"
    /// </summary>
    public class CCalcOrder
    {
        #region Свойства
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        private System.Guid m_uuidID;
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public System.Guid ID
        {
            get { return m_uuidID; }
            set { m_uuidID = value; }
        }
        /// <summary>
        /// Дата
        /// </summary>
        private System.DateTime m_dtCalcOrderDate;
        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime CalcOrderDate
        {
            get { return m_dtCalcOrderDate; }
            set { m_dtCalcOrderDate = value; }
        }
        /// <summary>
        /// Номер
        /// </summary>
        private System.String m_strNum;
        /// <summary>
        /// Номер
        /// </summary>
        public System.String Num
        {
            get { return m_strNum; }
            set { m_strNum = value; }
        }
        /// <summary>
        /// Товарная марка
        /// </summary>
        private CProductTradeMark m_objProductTradeMark;
        /// <summary>
        /// Товарная марка
        /// </summary>
        public CProductTradeMark ProductTradeMark
        {
            get { return m_objProductTradeMark; }
            set { m_objProductTradeMark = value; }
        }
        /// <summary>
        /// Название товарной марки
        /// </summary>
        public System.String ProductTradeMarkName
        {
            get {  return ( ( m_objProductTradeMark == null ) ? "" : m_objProductTradeMark.Name ); }
        }
        /// <summary>
        /// Приложение к расчету заказа
        /// </summary>
        private List<CCalcOrderItem> m_objCalcOrderItemList;
        /// <summary>
        /// Приложение к расчету заказа
        /// </summary>
        public List<CCalcOrderItem> CalcOrderItemList
        {
            get { return m_objCalcOrderItemList; }
            set { m_objCalcOrderItemList = value; }
        }
        /// <summary>
        /// Расчет прогноза продаж
        /// </summary>
        private CSalePrognosis m_objSalePrognosis;
        /// <summary>
        /// Расчет прогноза продаж
        /// </summary>
        public CSalePrognosis SalePrognosis
        {
            get { return m_objSalePrognosis; }
            set { m_objSalePrognosis = value; }
        }
        /// <summary>
        /// Название Расчета прогноза продаж
        /// </summary>
        public System.String SalePrognosisName
        {
            get { return ((m_objSalePrognosis == null) ? "" : m_objSalePrognosis.ToString() ); }
        }

        #endregion

        #region Конструктор
        public CCalcOrder()
        {
            m_uuidID = System.Guid.Empty;
            m_strNum = "";
            m_dtCalcOrderDate = System.DateTime.Today;
            m_objCalcOrderItemList = null;
            m_objProductTradeMark = null;
            m_objSalePrognosis = null;
        }
        public CCalcOrder(System.Guid uuidID, System.String strNum, System.DateTime dtCalcOrderDate,
            CProductTradeMark objProductTradeMark)
        {
            m_uuidID = uuidID;
            m_strNum = strNum;
            m_dtCalcOrderDate = dtCalcOrderDate;
            m_objCalcOrderItemList = null;
            m_objProductTradeMark = objProductTradeMark;
            m_objSalePrognosis = null;
        }
        #endregion

        #region Список объектов
        /// <summary>
        /// Возвращает список расчетов
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <returns>список расчетов</returns>
        public static List<CCalcOrder> GetCalcOrderList(UniXP.Common.CProfile objProfile, 
            System.Data.SqlClient.SqlCommand cmdSQL)
        {
            List<CCalcOrder> objList = new List<CCalcOrder>();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetCalcOrderListFromERP_Report]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    CProductTradeMark objProductTradeMark = null;
                    CCalcOrder objCalcOrder = null;

                    while (rs.Read())
                    {
                        objProductTradeMark = new CProductTradeMark();
                        objProductTradeMark.ID_Ib = System.Convert.ToInt32(rs["OWNER_ID"]);
                        objProductTradeMark.Name = (System.String)rs["OWNER_NAME"];
                        objProductTradeMark.ProductVtm = new CProductVtm();
                        objProductTradeMark.ProductVtm.ID_Ib = System.Convert.ToInt32(rs["VTM_ID"]);
                        objProductTradeMark.ProductVtm.Name = (System.String)rs["VTM_NAME"];

                        objCalcOrder = new CCalcOrder();
                        objCalcOrder.m_uuidID = (System.Guid)rs["CALCORDER_GUID"];
                        objCalcOrder.m_strNum = (System.String)rs["CALCORDER_NUM"];
                        objCalcOrder.m_dtCalcOrderDate = System.Convert.ToDateTime(rs["CALCORDER_BEGINDATE"]);
                        objCalcOrder.m_objProductTradeMark = objProductTradeMark;

                        if (rs["SALEPROGNOSIS_ID"] != System.DBNull.Value)
                        {
                            objCalcOrder.m_objSalePrognosis = new CSalePrognosis(System.Convert.ToDateTime(rs["REPORTDATE"]),
                                System.Convert.ToInt32(rs["SALEPROGNOSIS_ID"]), System.Convert.ToInt32(rs["MonthID"]), 
                                System.Convert.ToInt32(rs["YearID"]), System.Convert.ToString(rs["YearMonth"]) );
                        }

                        objList.Add(objCalcOrder);
                    }
                }
                rs.Dispose();

                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось получить список расчетов.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return objList;
        }
        #endregion

        #region Расчет заказа
        /// <summary>
        /// Запускает хранимую процедуру по расчету заказа для указанной товарной марки
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="objProductOwner">товарная марка</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - успешное завершение операции; false - ошибка</returns>
        public static System.Boolean CalcOrder(UniXP.Common.CProfile objProfile,
            System.Data.SqlClient.SqlCommand cmdSQL, ERP_Mercury.Common.CProductOwner objProductOwner, CSalePrognosis objSalePrognosis, ref System.String strErr)
        {
            System.Boolean bRet = false;
            System.Int32 iCmdTimeOut = 600;
            if (objProductOwner == null)
            {
                strErr = "Не указана товарная марка.";
                return bRet;
            }
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        strErr = "Не удалось получить соединение с базой данных.";
                        return bRet;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }
                cmd.CommandTimeout = iCmdTimeOut;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_CalcOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Owner_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (objSalePrognosis != null)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SALEPROGNOSIS_ID", System.Data.SqlDbType.Int));
                    cmd.Parameters["@SALEPROGNOSIS_ID"].Value = objSalePrognosis.ID;
                }
                cmd.Parameters["@Owner_Guid"].Value = objProductOwner.uuidID;
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@ERROR_NUM"].Value;
                strErr = (System.String)cmd.Parameters["@ERROR_MES"].Value;
                bRet = (iRes == 0);

                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                strErr = "Не удалось сформировать расчет.\n\nТекст ошибки : " + f.Message;
            }
            return bRet;
        }

        #endregion

        #region Удаление расчета
        /// <summary>
        /// Удалить запись из БД
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <returns>true - удачное завершение; false - ошибка</returns>
        public System.Boolean Remove(UniXP.Common.CProfile objProfile)
        {
            System.Boolean bRet = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            //System.Data.SqlClient.SqlTransaction DBTransaction = null;
            try
            {
                DBConnection = objProfile.GetDBSource();
                if (DBConnection == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось получить соединение с базой данных.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return bRet;
                }
                //DBTransaction = DBConnection.BeginTransaction();
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = DBConnection;
                //cmd.Transaction = DBTransaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_DeleteCalcOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CALCORDER_GUID", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@CALCORDER_GUID"].Value = this.ID;
                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                bRet = (iRes == 0);


                if (bRet == true)
                {
                    // подтверждаем транзакцию
                    //DBTransaction.Commit();
                }
                else
                {
                    // откатываем транзакцию
                    //DBTransaction.Rollback();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка удаления расчета заказа.\n\nТекст ошибки: " +
                    (System.String)cmd.Parameters["@ERROR_MES"].Value, "Ошибка",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                cmd.Dispose();
            }
            catch (System.Exception f)
            {
                //DBTransaction.Rollback();
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось удалить расчет заказа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                DBConnection.Close();
            }
            return bRet;
        }

        #endregion

        public override string ToString()
        {
            return ( m_dtCalcOrderDate.ToShortDateString() + " " + m_strNum );
        }
    }
    /// <summary>
    /// Класс "Приложение к расчету заказа"
    /// </summary>
    public class CCalcOrderItem
    {
        #region Свойства
        /// <summary>
        /// Товар
        /// </summary>
        private CProduct m_objProduct;
        /// <summary>
        /// Товар
        /// </summary>
        public CProduct objProduct
        {
            get { return m_objProduct; }
            set { m_objProduct = value; }
        }
        /// <summary>
        /// Товар является новинкой
        /// </summary>
        private System.Boolean m_bPartsIsNew;
        /// <summary>
        /// Товар является новинкой
        /// </summary>
        public System.Boolean PartsIsNew
        {
            get { return m_bPartsIsNew; }
            set { m_bPartsIsNew = value; }
        }
        /// <summary>
        /// продажи за последние 3 месяца
        /// </summary>
        private System.Decimal m_SALE_FOR_3MONTH;
        /// <summary>
        /// продажи за последние 3 месяца
        /// </summary>
        public System.Decimal SALE_FOR_3MONTH
        {
            get { return m_SALE_FOR_3MONTH; }
            set { m_SALE_FOR_3MONTH = value; }
        }
        /// <summary>
        /// средние недельные фактические отгрузки за 3 месяца
        /// </summary>
        private System.Decimal m_SALE_FOR_3MONTH_IN_WEEK_AVG;
        /// <summary>
        /// средние недельные фактические отгрузки за 3 месяца
        /// </summary>
        public System.Decimal SALE_FOR_3MONTH_IN_WEEK_AVG
        {
            get { return m_SALE_FOR_3MONTH_IN_WEEK_AVG; }
            set { m_SALE_FOR_3MONTH_IN_WEEK_AVG = value; }
        }
        /// <summary>
        /// план продаж на следующие 3 месяца
        /// </summary>
        private System.Decimal m_PLAN_FOR_3MONTH;
        /// <summary>
        /// план продаж на следующие 3 месяца
        /// </summary>
        public System.Decimal PLAN_FOR_3MONTH
        {
            get { return m_PLAN_FOR_3MONTH; }
            set { m_PLAN_FOR_3MONTH = value; }
        }
        /// <summary>
        /// средние недельные продажи по плану на следующие 3 месяца
        /// </summary>
        private System.Decimal m_PLAN_FOR_3MONTH_IN_WEEK_AVG;
        /// <summary>
        /// средние недельные продажи по плану на следующие 3 месяца
        /// </summary>
        public System.Decimal PLAN_FOR_3MONTH_IN_WEEK_AVG
        {
            get { return m_PLAN_FOR_3MONTH_IN_WEEK_AVG; }
            set { m_PLAN_FOR_3MONTH_IN_WEEK_AVG = value; }
        }
        /// <summary>
        /// остаток на складе
        /// </summary>
        private System.Int32 m_QUANTITY_IN_STOCK;
        /// <summary>
        /// остаток на складе
        /// </summary>
        public System.Int32 QUANTITY_IN_STOCK
        {
            get { return m_QUANTITY_IN_STOCK; }
            set { m_QUANTITY_IN_STOCK = value; }
        }
        /// <summary>
        /// товар в пути
        /// </summary>
        private System.Int32 m_QUANTITY_IN_WAY;
        /// <summary>
        /// товар в пути
        /// </summary>
        public System.Int32 QUANTITY_IN_WAY
        {
            get { return m_QUANTITY_IN_WAY; }
            set { m_QUANTITY_IN_WAY = value; }
        }
        /// <summary>
        /// заказано товара
        /// </summary>
        private System.Int32 m_QUANTITY_IN_ORDER;
        /// <summary>
        /// заказано товара
        /// </summary>
        public System.Int32 QUANTITY_IN_ORDER
        {
            get { return m_QUANTITY_IN_ORDER; }
            set { m_QUANTITY_IN_ORDER = value; }
        }
        /// <summary>
        /// минимальный товарный запас в неделях продаж
        /// </summary>
        private System.Decimal m_QUANTITY_MIN_STOCK_IN_WEEK;
        /// <summary>
        /// минимальный товарный запас в неделях продаж
        /// </summary>
        public System.Decimal QUANTITY_MIN_STOCK_IN_WEEK
        {
            get { return m_QUANTITY_MIN_STOCK_IN_WEEK; }
            set { m_QUANTITY_MIN_STOCK_IN_WEEK = value; }
        }
        /// <summary>
        /// группы приоритета
        /// </summary>
        private System.String m_ABC;
        /// <summary>
        /// группы приоритета
        /// </summary>
        public System.String ABC
        {
            get { return m_ABC; }
            set { m_ABC = value; }
        }
        /// <summary>
        /// коэффициент сезонности
        /// </summary>
        private System.Decimal m_KOEFF_SEASON_AVG;
        /// <summary>
        /// коэффициент сезонности
        /// </summary>
        public System.Decimal KOEFF_SEASON_AVG
        {
            get { return m_KOEFF_SEASON_AVG; }
            set { m_KOEFF_SEASON_AVG = value; }
        }
        /// <summary>
        /// прогноз продаж на 3 месяца вперед
        /// </summary>
        private System.Decimal m_PREDICTION_FOR_3MONTH;
        /// <summary>
        /// прогноз продаж на 3 месяца вперед
        /// </summary>
        public System.Decimal PREDICTION_FOR_3MONTH
        {
            get { return m_PREDICTION_FOR_3MONTH; }
            set { m_PREDICTION_FOR_3MONTH = value; }
        }
        /// <summary>
        /// средние недельные прогнозные продажи на следующие 3 месяца
        /// </summary>
        private System.Decimal m_PREDICTION_FOR_3MONTH_IN_WEEK_AVG;
        /// <summary>
        /// средние недельные прогнозные продажи на следующие 3 месяца
        /// </summary>
        public System.Decimal PREDICTION_FOR_3MONTH_IN_WEEK_AVG
        {
            get { return m_PREDICTION_FOR_3MONTH_IN_WEEK_AVG; }
            set { m_PREDICTION_FOR_3MONTH_IN_WEEK_AVG = value; }
        }
        /// <summary>
        /// коэффициент отклонения планового значения от прогнозного
        /// </summary>
        private System.Decimal m_KOEFF_DIV;
        /// <summary>
        /// коэффициент отклонения планового значения от прогнозного
        /// </summary>
        public System.Decimal KOEFF_DIV
        {
            get { return m_KOEFF_DIV; }
            set { m_KOEFF_DIV = value; }
        }
        /// <summary>
        /// Товарная марка
        /// </summary>
        public System.String ProductTradeMarkName
        { get { return m_objProduct.ProductTradeMarkName; } }
        /// <summary>
        /// Товарная линия
        /// </summary>
        public System.String ProductLineName
        { get { return m_objProduct.ProductLineName; } }
        /// <summary>
        /// Товарная группа
        /// </summary>
        public System.String ProductTypeName
        { get { return m_objProduct.ProductTypeName; } }
        /// <summary>
        /// Товарная подгруппа
        /// </summary>
        public System.String ProductSubTypeName
        { get { return m_objProduct.ProductSubTypeName; } }
        /// <summary>
        /// Оригинальное наименование товара
        /// </summary>
        public System.String ProductOriginalName
        { get { return m_objProduct.OriginalName; } }
        /// <summary>
        /// Код ТН ВЭД
        /// </summary>
        public System.String CodeTNVD
        { get { return m_objProduct.CodeTNVD; } }
        /// <summary>
        /// Код товара
        /// </summary>
        public System.Int32 IB_ID
        { get { return m_objProduct.ID_Ib; } }
        /// <summary>
        /// Товар (наименование)
        /// </summary>
        public System.String ProductName
        { get { return m_objProduct.Name; } }
        /// <summary>
        /// Референс (код поставщика)
        /// </summary>
        public System.String ProductReference
        { get { return m_objProduct.Reference; } }
        /// <summary>
        /// Артикул
        /// </summary>
        public System.String ProductArticle
        { get { return m_objProduct.Article; } }
        /// <summary>
        /// Штрих-код
        /// </summary>
        public System.String ProductBarCode
        { get { return ( ( ( m_objProduct.BarcodeList != null ) && (  m_objProduct.BarcodeList.Count > 0 ) ) ? m_objProduct.BarcodeList[0] : "" ) ; } }
        /// <summary>
        /// Страна производства
        /// </summary>
        public System.String ProductCountryProduction
        { get { return ((m_objProduct.Country != null) ? m_objProduct.Country.Name : ""); } }
        /// <summary>
        /// Веc, кг.
        /// </summary>
        public System.Decimal ProductWeight
        { get { return m_objProduct.Weight; } }
        /// <summary>
        /// Масса пластиковой тары, кг.
        /// </summary>
        public System.Decimal ProductPlasticContainerWeight
        { get { return m_objProduct.PlasticContainerWeight; } }
        /// <summary>
        /// Масса бумажной тары, кг.
        /// </summary>
        public System.Decimal ProductPaperContainerWeight
        { get { return m_objProduct.PaperContainerWeight; } }
        /// <summary>
        /// % спирта денатур.
        /// </summary>
        public System.Decimal ProductAlcoholicContentPercent
        { get { return m_objProduct.AlcoholicContentPercent; } }
        /// <summary>
        /// Тариф поставщика
        /// </summary>
        public System.Decimal ProductVendorPrice
        { get { return m_objProduct.VendorPrice; } }
        /// <summary>
        /// Валюта тарифа
        /// </summary>
        public System.String ProductCurrency
         { get { return ((m_objProduct.Currency != null) ? m_objProduct.Currency.CurrencyAbbr : ""); } }
        /// <summary>
        /// Количество единиц продукции в коробках
        /// </summary>
        public System.Int32 ProductBoxQuantity
        { get { return m_objProduct.BoxQuantity; } }
        /// <summary>
        /// Количество единиц продукции в упаковке
        /// </summary>
        public System.Int32 ProductPackQuantity
        { get { return m_objProduct.PackQuantity; } }
        /// <summary>
        /// Количество единиц продукции в упаковке для расчета заказа
        /// </summary>
        public System.Int32 ProductPackQuantityForCalc
        { get { return m_objProduct.PackQuantityForCalc; } }
        /// <summary>
        /// Срок процессирования
        /// </summary>
        public System.Int32 ProductProcessDayCount
         { get { return ((m_objProduct.ProductTradeMark != null) ? m_objProduct.ProductTradeMark.ProcessDayCount : 0); } }
        /// <summary>
        /// Новинка
        /// </summary>
        public System.String ProductIsNew
        { get { return ( ( m_bPartsIsNew == true ) ? "новинка" : "" ); } }

        /// <summary>
        /// скорректированные средние недельные продажи
        /// </summary>
        private System.Decimal m_CORRECT_FOR_3MONTH_IN_WEEK_AVG;
        /// <summary>
        /// скорректированные средние недельные продажи
        /// </summary>
        public System.Decimal CORRECT_FOR_3MONTH_IN_WEEK_AVG
        {
            get { return m_CORRECT_FOR_3MONTH_IN_WEEK_AVG; }
            set { m_CORRECT_FOR_3MONTH_IN_WEEK_AVG = value; }
        }
        /// <summary>
        /// средние недельные продажи для расчета
        /// </summary>
        private System.Decimal m_FOR_CALC_WEEK_AVG;
        /// <summary>
        /// средние недельные продажи для расчета
        /// </summary>
        public System.Decimal FOR_CALC_WEEK_AVG
        {
            get { return m_FOR_CALC_WEEK_AVG; }
            set { m_FOR_CALC_WEEK_AVG = value; }
        }
        /// <summary>
        /// Товарный запас (шт.)
        /// </summary>
        private System.Decimal m_QUANTITY_RESOURCE;
        /// <summary>
        /// Товарный запас (шт.)
        /// </summary>
        public System.Decimal QUANTITY_RESOURCE
        {
            get { return m_QUANTITY_RESOURCE; }
            set { m_QUANTITY_RESOURCE = value; }
        }
        /// <summary>
        /// Количество недель продаж, на которые планируется рассчитываемый заказ
        /// </summary>
        private System.Int32 m_WEEK_QTY_FOR_CALC;
        /// <summary>
        /// Количество недель продаж, на которые планируется рассчитываемый заказ
        /// </summary>
        public System.Int32 WEEK_QTY_FOR_CALC
        {
            get { return m_WEEK_QTY_FOR_CALC; }
            set { m_WEEK_QTY_FOR_CALC = value; }
        }
        /// <summary>
        /// Потребность (шт.)
        /// </summary>
        private System.Int32 m_REQUIREMENT;
        /// <summary>
        ///Потребность (шт.)
        /// </summary>
        public System.Int32 REQUIREMENT
        {
            get { return m_REQUIREMENT; }
            set { m_REQUIREMENT = value; }
        }
        /// <summary>
        /// Потребность скорректированная (шт.)
        /// </summary>
        private System.Int32 m_REQUIREMENT_CORRECT;
        /// <summary>
        ///Потребность скорректированная (шт.)
        /// </summary>
        public System.Int32 REQUIREMENT_CORRECT
        {
            get { return m_REQUIREMENT_CORRECT; }
            set { m_REQUIREMENT_CORRECT = value; }
        }
        /// <summary>
        /// Расчет заказа (шт.)
        /// </summary>
        private System.Int32 m_CALCULATION_ORDER_QTY;
        /// <summary>
        /// Расчет заказа (шт.)
        /// </summary>
        public System.Int32 CALCULATION_ORDER_QTY
        {
            get { return m_CALCULATION_ORDER_QTY; }
            set { m_CALCULATION_ORDER_QTY = value; }
        }
        /// <summary>
        /// Расчет заказа (сумма)
        /// </summary>
        private System.Decimal m_CALCULATION_ORDER_MONEY;
        /// <summary>
        /// Расчет заказа (сумма)
        /// </summary>
        public System.Decimal CALCULATION_ORDER_MONEY
        {
            get { return m_CALCULATION_ORDER_MONEY; }
            set { m_CALCULATION_ORDER_MONEY = value; }
        }
        /// <summary>
        /// Вес заказа (кг.)
        /// </summary>
        private System.Decimal m_ORDER_WEIGHT;
        /// <summary>
        /// Вес заказа (кг.)
        /// </summary>
        public System.Decimal ORDER_WEIGHT
        {
            get { return m_ORDER_WEIGHT; }
            set { m_ORDER_WEIGHT = value; }
        }
        /// <summary>
        /// Заказ (коробок/паллет)
        /// </summary>
        private System.Decimal m_ORDER_BOX_QUANTITY;
        /// <summary>
        /// Заказ (коробок/паллет)
        /// </summary>
        public System.Decimal ORDER_BOX_QUANTITY
        {
            get { return m_ORDER_BOX_QUANTITY; }
            set { m_ORDER_BOX_QUANTITY = value; }
        }
        /// <summary>
        /// ТЗ с учетом заказа (шт.)
        /// </summary>
        private System.Decimal m_QUANTITY_RESOURCE_WITH_ORDER;
        /// <summary>
        /// ТЗ с учетом заказа (шт.)
        /// </summary>
        public System.Decimal QUANTITY_RESOURCE_WITH_ORDER
        {
            get { return m_QUANTITY_RESOURCE_WITH_ORDER; }
            set { m_QUANTITY_RESOURCE_WITH_ORDER = value; }
        }
        #endregion

        #region Конструктор
        public CCalcOrderItem()
        {
            m_ABC = "";
            m_bPartsIsNew = false;
            m_KOEFF_DIV = 0;
            m_KOEFF_SEASON_AVG = 0;
            m_objProduct = null;
            m_PLAN_FOR_3MONTH = 0;
            m_PLAN_FOR_3MONTH_IN_WEEK_AVG = 0;
            m_PREDICTION_FOR_3MONTH = 0;
            m_PREDICTION_FOR_3MONTH_IN_WEEK_AVG = 0;
            m_QUANTITY_IN_ORDER = 0;
            m_QUANTITY_IN_STOCK = 0;
            m_QUANTITY_IN_WAY = 0;
            m_QUANTITY_MIN_STOCK_IN_WEEK = 0;
            m_SALE_FOR_3MONTH = 0;
            m_SALE_FOR_3MONTH_IN_WEEK_AVG = 0;
        }
        #endregion

        #region Список объектов
        /// <summary>
        /// Возвращает приложение к расчету
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <returns>список расчетов</returns>
        public static List<CCalcOrderItem> GetCalcOrderItemList(UniXP.Common.CProfile objProfile,
            System.Data.SqlClient.SqlCommand cmdSQL, System.Guid CalcOrderID)
        {
            List<CCalcOrderItem> objList = new List<CCalcOrderItem>();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetCalcOrderListItemsFromERP_Report]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CALCORDER_GUID", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@CALCORDER_GUID"].Value = CalcOrderID;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    CProduct objProduct = null;
                    CCurrency objCurrency = null;
                    CCountry objCountry = null;
                    CProductTradeMark objProductTradeMark = null;
                    CProductType objProductType = null;
                    CProductSubType objProductSubType = null;
                    CMeasure objMeasure = null;
                    CCalcOrderItem objCalcOrderItem = null;

                    while (rs.Read())
                    {
                        objCurrency = null;
                        objCountry = null;
                        objProductTradeMark = null;
                        objProductType = null;
                        objProductSubType = null;
                        // товарная марка
                        objProductTradeMark = new CProductTradeMark();
                        objProductTradeMark.Name = (System.String)rs["OWNER_NAME"];
                        objProductTradeMark.ID_Ib = System.Convert.ToInt32(rs["OWNER_ID"]);
                        objProductTradeMark.ProductVtm = new CProductVtm();
                        objProductTradeMark.ProductVtm.ID_Ib = System.Convert.ToInt32(rs["VTM_ID"]);
                        objProductTradeMark.ProductVtm.Name = (System.String)rs["VTM_NAME"];
                        objProductTradeMark.ProcessDayCount = System.Convert.ToInt32(rs["OWNER_PROCESSDAYSCOUNT"]);
                        // товарная группа
                        objProductType = new CProductType();
                        objProductType.ID_Ib = System.Convert.ToInt32(rs["PARTTYPE_ID"]);
                        objProductType.Name = (System.String)rs["PARTTYPE_NAME"];
                        // товарная подгруппа
                        objProductSubType = new CProductSubType();
                        objProductSubType.ID_Ib = System.Convert.ToInt32(rs["PARTSUBTYPE_ID"]);
                        objProductSubType.Name = (System.String)rs["PARTSUBTYPE_NAME"];
                        objProductSubType.ProductLine = new CProductLine();
                        objProductSubType.ProductLine.ID_Ib = System.Convert.ToInt32(rs["PARTSECSUBTYPE_ID"]);    
                        objProductSubType.ProductLine.Name = (System.String)rs["PARTSECSUBTYPE_NAME"];
                        // страна производства
                        objCountry = new CCountry();
                        if (rs["COUNTRY_PROD_ID"] != System.DBNull.Value)
                        {
                            objCountry.Name = (System.String)rs["COUNTRY_NAME"];
                        }
                        // валюта
                        objCurrency = new CCurrency( System.Guid.Empty, "", ( (rs["CURRENCY_CODE"] == System.DBNull.Value) ? "" : (System.String)rs["CURRENCY_CODE"]), ""  );
                        // единица измерения
                        objMeasure = new CMeasure();
                        objMeasure.Name = (System.String)rs["MEASURE_NAME"];

                        // товар
                        objProduct = new CProduct(System.Guid.Empty, System.Convert.ToInt32(rs["PARTS_ID"]),
                            (System.String)rs["PARTS_NAME"], (System.String)rs["PARTS_ORIGNAME"],
                            (System.String)rs["PARTS_NAME"], (System.String)rs["PARTS_ARTICLE"],
                            objProductTradeMark, objProductType, objProductSubType, objCountry, objCurrency,
                            ((rs["PARTS_VENDORPRICE"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PARTS_VENDORPRICE"])),
                            ((rs["PARTS_BOXQTY"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["PARTS_BOXQTY"])),
                            ((rs["PARTS_PACKQTY"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["PARTS_PACKQTY"])),
                            ((rs["PARTS_PACKQTYFORCALC"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["PARTS_PACKQTYFORCALC"])),
                            ((rs["PARTS_WEIGHT"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PARTS_WEIGHT"])),
                            ((rs["PARTS_PAPERCONTAINERWEIGHT"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PARTS_PAPERCONTAINERWEIGHT"])),
                            ((rs["PARTS_PLASTICCONTAINERWEIGHT"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PARTS_PLASTICCONTAINERWEIGHT"])),
                            ((rs["PARTS_ALCOHOLICCONTENTPERCENT"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PARTS_ALCOHOLICCONTENTPERCENT"])),
                            true, // ((rs["Parts_IsActive"] == System.DBNull.Value) ? false : System.Convert.ToBoolean(rs["Parts_IsActive"])),
                            ((rs["PARTS_NOTVALID"] == System.DBNull.Value) ? false : System.Convert.ToBoolean(rs["PARTS_NOTVALID"])),
                            ((rs["PARTS_ACTUALNOTVALID"] == System.DBNull.Value) ? false : System.Convert.ToBoolean(rs["PARTS_ACTUALNOTVALID"])),
                            "", //((rs["Parts_Certificate"] == System.DBNull.Value) ? "" : (System.String)rs["Parts_Certificate"]),
                            ((rs["PARTS_CODETNVD"] == System.DBNull.Value) ? "" : (System.String)rs["PARTS_CODETNVD"]),
                            ((rs["PARTS_REFERENCE"] == System.DBNull.Value) ? "" : (System.String)rs["PARTS_REFERENCE"]),
                            objMeasure, null, 0
                            );
                        if (rs["PARTS_BARCODE"] != System.DBNull.Value)
                        {
                            objProduct.BarcodeList = new List<string>();
                            objProduct.BarcodeList.Add((System.String)rs["PARTS_BARCODE"]);
                        }
                        objCalcOrderItem = new CCalcOrderItem();
                        objCalcOrderItem.objProduct = objProduct;
                        objCalcOrderItem.PartsIsNew = System.Convert.ToBoolean(rs["PARTS_IS_NEW"]);
                        objCalcOrderItem.PLAN_FOR_3MONTH = ((rs["PLAN_FOR_3MONTH"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PLAN_FOR_3MONTH"]));
                        objCalcOrderItem.PLAN_FOR_3MONTH_IN_WEEK_AVG = ((rs["PLAN_FOR_3MONTH_IN_WEEK_AVG"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PLAN_FOR_3MONTH_IN_WEEK_AVG"]));
                        objCalcOrderItem.PREDICTION_FOR_3MONTH = ((rs["PREDICTION_FOR_3MONTH"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PREDICTION_FOR_3MONTH"]));
                        objCalcOrderItem.PREDICTION_FOR_3MONTH_IN_WEEK_AVG = ((rs["PREDICTION_FOR_3MONTH_IN_WEEK_AVG"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["PREDICTION_FOR_3MONTH_IN_WEEK_AVG"]));
                        objCalcOrderItem.SALE_FOR_3MONTH = ((rs["SALE_FOR_3MONTH"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["SALE_FOR_3MONTH"]));
                        objCalcOrderItem.SALE_FOR_3MONTH_IN_WEEK_AVG = ((rs["SALE_FOR_3MONTH_IN_WEEK_AVG"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["SALE_FOR_3MONTH_IN_WEEK_AVG"]));
                        objCalcOrderItem.QUANTITY_IN_ORDER = ((rs["QUANTITY_IN_ORDER"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["QUANTITY_IN_ORDER"]));
                        objCalcOrderItem.QUANTITY_IN_STOCK = ((rs["QUANTITY_IN_STOCK"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["QUANTITY_IN_STOCK"]));
                        objCalcOrderItem.QUANTITY_IN_WAY = ((rs["QUANTITY_IN_WAY"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["QUANTITY_IN_WAY"]));
                        objCalcOrderItem.QUANTITY_MIN_STOCK_IN_WEEK = ((rs["QUANTITY_MIN_STOCK_IN_WEEK"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["QUANTITY_MIN_STOCK_IN_WEEK"]));
                        objCalcOrderItem.KOEFF_SEASON_AVG = ((rs["KOEFF_SEASON_AVG"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["KOEFF_SEASON_AVG"]));
                        objCalcOrderItem.KOEFF_DIV = ((rs["KOEFF_DIV"] == System.DBNull.Value) ? 0 : System.Convert.ToDecimal(rs["KOEFF_DIV"]));
                        objCalcOrderItem.ABC = ((rs["ABC"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["ABC"]));
                        objList.Add(objCalcOrderItem);
                    }
                }
                rs.Dispose();

                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось получить приложение к расчету.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return objList;
        }
        #endregion

    }
    /// <summary>
    /// Класс "Расчет прогноза продаж"
    /// </summary>
    public class CSalePrognosis
    {
        #region Свойства
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        private System.Int32 m_idID;
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public System.Int32 ID
        {
            get { return m_idID; }
            set { m_idID = value; }
        }
        /// <summary>
        /// Дата формирования
        /// </summary>
        private System.DateTime m_dtSalePrognosisDate;
        /// <summary>
        /// Дата формирования
        /// </summary>
        public System.DateTime SalePrognosisDate
        {
            get { return m_dtSalePrognosisDate; }
            set { m_dtSalePrognosisDate = value; }
        }
        /// <summary>
        /// Номер
        /// </summary>
        private System.String m_strNum;
        /// <summary>
        /// Номер
        /// </summary>
        public System.String Num
        {
            get { return m_strNum; }
            set { m_strNum = value; }
        }
        /// <summary>
        /// Год
        /// </summary>
        private System.Int32 m_iYear;
        /// <summary>
        /// Год 
        /// </summary>
        public System.Int32 SalePrognosisYear
        {
            get { return m_iYear; }
            set { m_iYear = value; }
        }
        /// <summary>
        /// Месяц
        /// </summary>
        private System.Int32 m_iMonth;
        /// <summary>
        /// Месяц 
        /// </summary>
        public System.Int32 SalePrognosisMonth
        {
            get { return m_iMonth; }
            set { m_iMonth = value; }
        }
        #endregion

        #region Конструктор
        public CSalePrognosis()
        {
            m_dtSalePrognosisDate = System.DateTime.MinValue;
            m_idID = 0;
            m_iMonth = 0;
            m_iYear = 0;
            m_strNum = "";
        }
        public CSalePrognosis(System.DateTime dtSalePrognosisDate, System.Int32 idID, System.Int32 iMonth, System.Int32 iYear, System.String strNum)
        {
            m_dtSalePrognosisDate = dtSalePrognosisDate;
            m_idID = idID;
            m_iMonth = iMonth;
            m_iYear = iYear;
            m_strNum = strNum;
        }
        #endregion

        #region Список объектов
        /// <summary>
        /// Возвращает список расчетов прогноза продаж
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <returns>список расчетов прогноза продаж</returns>
        public static List<CSalePrognosis> GetSalePrognosisList(UniXP.Common.CProfile objProfile,
            System.Data.SqlClient.SqlCommand cmdSQL)
        {
            List<CSalePrognosis> objList = new List<CSalePrognosis>();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetSalePrognosisListFromERP_Report]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                         objList.Add(new CSalePrognosis(System.Convert.ToDateTime(rs["REPORTDATE"]),
                                System.Convert.ToInt32(rs["SALEPROGNOSIS_ID"]), System.Convert.ToInt32(rs["MonthID"]),
                                System.Convert.ToInt32(rs["YearID"]), System.Convert.ToString(rs["YearMonth"])));
                    }
                }
                rs.Dispose();

                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось получить список расчетов прогноза продаж.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return objList;
        }
        #endregion

        public override string ToString()
        {
            return ( m_strNum + " (год: " + m_iYear.ToString() + ", месяц: " + m_iMonth.ToString() + " от " + m_dtSalePrognosisDate.ToShortDateString() + ")" );
        }


    }
}
