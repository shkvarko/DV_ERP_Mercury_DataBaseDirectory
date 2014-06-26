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
    public partial class frmDatabaseDirectory : DevExpress.XtraEditors.XtraForm
    {
        #region Переменные, Свойства, Константы
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private ERP_Mercury.Common.EnumDirectSimple m_DirectSimple;
        ERP_Mercury.Common.ctrlDatabaseDirectory m_objDatabaseDirectory;
        #endregion

        #region Конструктор
        public frmDatabaseDirectory(UniXP.Common.CProfile objProfile, ERP_Mercury.Common.EnumDirectSimple DirectSimple, UniXP.Common.MENUITEM objMenuItem)
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_DirectSimple = DirectSimple;
            m_objMenuItem = objMenuItem;

            m_objDatabaseDirectory = new ERP_Mercury.Common.ctrlDatabaseDirectory(m_objProfile, m_DirectSimple, m_objMenuItem);
            if (m_objDatabaseDirectory != null)
            {
                this.Controls.Add(m_objDatabaseDirectory);
                m_objDatabaseDirectory.Dock = DockStyle.Fill;
            }
        }
        #endregion

        #region Загрузка формы
        private void frmDatabaseDirectory_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_objDatabaseDirectory != null)
                {
                    if (m_objDatabaseDirectory.bRefreshTreeList() == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка открытия формы.", "Ошибка",
                          System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка открытия формы.\n\nТекст ошибки:\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Закрытие формы
        private void frmDirect_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_objDatabaseDirectory != null)
                {
                    if (m_objDatabaseDirectory.Modified == true)
                    {
                        if (System.Windows.Forms.MessageBox.Show(this,
                            "Данные описания объекта были изменены.\nВыйти из формы без сохранения изменений?", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        // запускаем процесс сохранения
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }

            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "frmDirect_FormClosing\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion
    }

    #region Формы собственности
    public class EditStateType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.StateType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы клиентов
    public class EditCustomerType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.CustomerType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы адресов
    public class EditAddressType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AddressType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Префиксы адресов
    public class EditAddressPrefix : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AddressPrefix, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Помещения
    public class EditFlat : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Flat, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Строения
    public class EditBuilding : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Building, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Корпуса зданий
    public class EditSubBuilding : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.SubBuilding, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Страны
    public class EditCountry : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Country, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Регионы
    public class EditRegion : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Region, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы населенных пунктов
    public class EditLocalityPrefix : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.LocalityPrefix, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Города
    public class EditCity : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.City, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Отделы
    public class EditDepartament : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Departament, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Должности
    public class EditJobPosition : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.JobPosition, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы телефонных номеров
    public class EditPhoneType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.PhoneType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Телефонные номера
    public class EditPhone : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Phone, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Признаки активности клиента
    public class CustomerActiveTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.CustomerActiveType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы лицензий
    public class LicenceTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.LicenceType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы РТТ
    public class RttTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.RttType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Признак активности РТТ
    public class RttActiveTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.RttActiveType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Спецкод РТТ
    public class RttSpecCodeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.RttSpecCode, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Цель приобретения товара
    public class TargetBuyEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.TargetBuy, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Товарный каталог
    public class ProductCatalogEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductOwner, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Тип торгового оборудования
    public class EquipmentTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.EquipmentType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Возможность установки
    public class AvailibilityEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Availability, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Размер
    public class SizeEqEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.SizeEq, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Сегментация
    public class SegmentationEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Segmentation, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Торговая сеть
    public class DistribNetEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.DistribNet, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы расчетных счетов
    public class AccountTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AccountType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Области
    public class OblastEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Oblast, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Категории клиентов
    public class CustomerCategoryEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.CustomerCategory, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Тип группы условий
    public class ConditionGroupTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ConditionGroupType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Тип объектов, входящих в группу
    public class ConditionObjectTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ConditionObjectType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы правил
    public class RuleTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.RuleType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Хранимые процедуры
    public class StoredProcedureEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.StoredProcedure, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region ВТМ
    public class ProductVtmEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductVTM, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Товарная группа
    public class ProductTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region ТОварная линия
    public class ProductLineEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductLine, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Товарная подгруппа
    public class ProductSubTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductSubType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Товарная марка
    public class ProductTradeMarkEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductTradeMark, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Категория товара
    public class ProductCategoryEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ProductCategory, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы договоров с поставщиком
    public class VendorContractTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.VendorContractType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы платежных документов
    public class VendorPaymentDocTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.VendorPaymentDocType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Виды тарифов
    public class CarrierRateTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.CarrierRateType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Водитель
    public class DriverEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Driver, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Автомобиль
    public class VehicleEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Vehicle, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы дополнительных расходов для путевого листа
    public class RouteSheetAdvancedExpenseTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AdvancedExpenseType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы путевых листов
    public class RouteSheetTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.RouteSheetType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы цен
    public class PriceTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.PriceType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Регион доставки
    public class RegionDeliveryEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.RegionDelivery, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }

    #endregion

    #region Тип договора
    public class AgreementTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AgreementType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Состояние договора
    public class AgreementStateEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AgreementState, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Основание действия
    public class AgrementBasementEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AgrementBasement, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Цель приобретения
    public class AgrementReasonEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AgrementReason, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Условия доставки
    public class AgreementDeliveryConditionEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AgreementDeliveryCondition, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Условия оплаты
    public class AgreementPaymentConditionEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AgreementPaymentCondition, objMenuItem);
            //frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Stock, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion
   
    #region Склад
    public class StockEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Stock, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Место хранения
    public class WareHouseEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.WareHouse, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Тип хранилища
    public class WareHouseTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.WareHouseType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Дочерние подразделения
    public class ChildCustEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ChildCustCode, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Тип поставщика
    public class VendorTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.VendorType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Валюта
    public class CurrencyEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Currency, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Единицы измерения
    public class MeasureEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Measure, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы документов о качестве товара
    public class CertificateTypeEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.CertificateType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы констант
    public class EditConstType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.ConstType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Константы
    public class EditConst : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Const, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Состояния заказа
    public class EditLotOrderState : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.LotOrderState, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Состояния КЛП
    public class EditKLPState : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.KLPState, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Типы дополнительных расходов
    public class EditSurcharges : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.Surcharges, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Виды отсрочки платежа
    public class EditVendorContractDelayType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.VendorContractDelayType, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region ставки НДС
    public class EditNDSRate : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.NDSRate, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Канал сбыта
    public class EditSegmentationChanel : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.SegmentationChanel, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }    
    #endregion

    #region Рынок сбыта
    public class EditSegmentationMarket : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.SegmentationMarket, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region Субканал сбыта
    public class EditSegmentationSubChannel : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.SegmentationSubChanel, objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }
    #endregion

    #region План счетов
    public class EditAccountPlan : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.AccountPlan, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Проекты
    public class EditBudgetProject : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.BudgetProject, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Виды оплат
    public class EditEarningType : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.EarningType, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Состояния накладной
    public class EditWaybillState : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.WaybillState, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Виды отгрузки накладной
    public class EditWaybillShipMode : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.WaybillShipMode, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Состояния накладной на возврат товара
    public class EditBackWaybillState : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.BackWaybillState, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Причины возврата товара
    public class EditWaybillBackReason : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.WaybillBackReason, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Виды отгрузки накладной на внутреннее перемещение
    public class EditIntWaybillShipMode : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.IntWaybillShipMode, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Состояния накладной на внутреннее перемещение
    public class EditIntWaybillState : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.IntWaybillState, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Виды отгрузки заказа на внутреннее перемещение
    public class EditIntOrderShipMode : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.IntOrderShipMode, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

    #region Состояния заказа на внутреннее перемещение
    public class EditIntOrderState : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmDatabaseDirectory obj = new frmDatabaseDirectory(objMenuItem.objProfile, ERP_Mercury.Common.EnumDirectSimple.IntOrderState, objMenuItem) { Text = strCaption, MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent, Visible = true };
        }
    }
    #endregion

}
