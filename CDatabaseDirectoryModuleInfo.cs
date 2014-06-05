using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPMercuryDatabaseDirectory
{
    public class CDatabaseDirectoryModuleClassInfo : UniXP.Common.CModuleClassInfo
    {
        public CDatabaseDirectoryModuleClassInfo()
        {
            UniXP.Common.CLASSINFO objClassInfo;

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditStateType";
            objClassInfo.strName = "Формы собственности";
            objClassInfo.strDescription = "Формы собственности";
            objClassInfo.lID = 0;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditCustomerType";
            objClassInfo.strName = "Типы клиентов";
            objClassInfo.strDescription = "Типы клиентов";
            objClassInfo.lID = 1;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CUSTOMERTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditAddressType";
            objClassInfo.strName = "Типы адресов";
            objClassInfo.strDescription = "Типы адресов";
            objClassInfo.lID = 2;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditAddressPrefix";
            objClassInfo.strName = "Префиксы адресов";
            objClassInfo.strDescription = "Префиксы адресов";
            objClassInfo.lID = 3;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditFlat";
            objClassInfo.strName = "Помещения";
            objClassInfo.strDescription = "Помещения";
            objClassInfo.lID = 4;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditBuilding";
            objClassInfo.strName = "Строения";
            objClassInfo.strDescription = "Строения";
            objClassInfo.lID = 5;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditSubBuilding";
            objClassInfo.strName = "Корпуса зданий";
            objClassInfo.strDescription = "Корпуса зданий";
            objClassInfo.lID = 6;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditCountry";
            objClassInfo.strName = "Страны";
            objClassInfo.strDescription = "Справочник стран";
            objClassInfo.lID = 7;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditRegion";
            objClassInfo.strName = "Регионы";
            objClassInfo.strDescription = "Справочник регионов";
            objClassInfo.lID = 8;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditLocalityPrefix";
            objClassInfo.strName = "Типы населенных пунктов";
            objClassInfo.strDescription = "Справочник типов населенных пунктов";
            objClassInfo.lID = 9;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditCity";
            objClassInfo.strName = "Города";
            objClassInfo.strDescription = "Справочник городов";
            objClassInfo.lID = 10;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditDepartament";
            objClassInfo.strName = "Отделы";
            objClassInfo.strDescription = "Справочник отделов";
            objClassInfo.lID = 11;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditJobPosition";
            objClassInfo.strName = "Должности";
            objClassInfo.strDescription = "Справочник занимаемых должностей";
            objClassInfo.lID = 12;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditPhoneType";
            objClassInfo.strName = "Типы телефонных номеров";
            objClassInfo.strDescription = "Справочник типов телефонных номеров";
            objClassInfo.lID = 13;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.BankEditor";
            objClassInfo.strName = "Банки";
            objClassInfo.strDescription = "Справочник банков";
            objClassInfo.lID = 14;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.CustomerActiveTypeEditor";
            objClassInfo.strName = "Признаки активности клиента";
            objClassInfo.strDescription = "Справочник признаков активности клиента";
            objClassInfo.lID = 15;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.LicenceTypeEditor";
            objClassInfo.strName = "Виды лицензий";
            objClassInfo.strDescription = "Справочник видов лицензий клиента";
            objClassInfo.lID = 16;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RttTypeEditor";
            objClassInfo.strName = "Тип РТТ";
            objClassInfo.strDescription = "Справочник типов РТТ";
            objClassInfo.lID = 17;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RttActiveTypeEditor";
            objClassInfo.strName = "Признак активности РТТ";
            objClassInfo.strDescription = "Справочник признаков активности РТТ";
            objClassInfo.lID = 18;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RttSpecCodeEditor";
            objClassInfo.strName = "Спец. кода для РТТ";
            objClassInfo.strDescription = "Справочник спецкодов для РТТ";
            objClassInfo.lID = 19;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.TargetBuyEditor";
            objClassInfo.strName = "Цель приобретения товара";
            objClassInfo.strDescription = "Справочник целей приобретения товара";
            objClassInfo.lID = 20;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductCatalogEditor";
            objClassInfo.strName = "Товарные марки";
            objClassInfo.strDescription = "Справочник каталога продукции";
            objClassInfo.lID = 21;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EquipmentTypeEditor";
            objClassInfo.strName = "Типы торгового оборудования";
            objClassInfo.strDescription = "Справочник типов торгового оборудования";
            objClassInfo.lID = 22;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AvailibilityEditor";
            objClassInfo.strName = "Возможность размещения";
            objClassInfo.strDescription = "Справочник вариантов размещения";
            objClassInfo.lID = 23;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.SizeEqEditor";
            objClassInfo.strName = "Размеры оборудования";
            objClassInfo.strDescription = "Справочник размеров";
            objClassInfo.lID = 24;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.SegmentationEditor";
            objClassInfo.strName = "Сегментация";
            objClassInfo.strDescription = "Справочник сегментации";
            objClassInfo.lID = 25;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.DistribNetEditor";
            objClassInfo.strName = "Торговая сеть";
            objClassInfo.strDescription = "Справочник торговых сетей";
            objClassInfo.lID = 26;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AccountTypeEditor";
            objClassInfo.strName = "Типы расчетных счетов";
            objClassInfo.strDescription = "Справочник типов расчетных счетов";
            objClassInfo.lID = 27;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.OblastEditor";
            objClassInfo.strName = "Области";
            objClassInfo.strDescription = "Справочник областей";
            objClassInfo.lID = 28;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_ADDRESSTYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.CustomerCategoryEditor";
            objClassInfo.strName = "Категории клиентов";
            objClassInfo.strDescription = "Справочник категорий клиентов";
            objClassInfo.lID = 29;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ConditionObjectTypeEditor";
            objClassInfo.strName = "Типы объектов";
            objClassInfo.strDescription = "Справочник типов объектов, входящих в группы";
            objClassInfo.lID = 30;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ConditionGroupTypeEditor";
            objClassInfo.strName = "Типы групп";
            objClassInfo.strDescription = "Справочник типов групп для условий";
            objClassInfo.lID = 31;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_GROUPSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RuleTypeEditor";
            objClassInfo.strName = "Виды правил";
            objClassInfo.strDescription = "Список типов правил";
            objClassInfo.lID = 32;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_GROUPSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.StoredProcedureEditor";
            objClassInfo.strName = "Хранимые процедуры";
            objClassInfo.strDescription = "Список хранимых процедур для правил";
            objClassInfo.lID = 33;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_GROUPSMALL";
            m_arClassInfo.Add(objClassInfo);


            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductVtmEditor";
            objClassInfo.strName = "ВТМ";
            objClassInfo.strDescription = "Список владельцев товарных марок";
            objClassInfo.lID = 37;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductTypeEditor";
            objClassInfo.strName = "Товарные группы";
            objClassInfo.strDescription = "Список товарных групп";
            objClassInfo.lID = 38;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductLineEditor";
            objClassInfo.strName = "Товарные линии";
            objClassInfo.strDescription = "Список товарных линий";
            objClassInfo.lID = 39;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductSubTypeEditor";
            objClassInfo.strName = "Товарные подгруппы";
            objClassInfo.strDescription = "Список товарных подгрупп";
            objClassInfo.lID = 40;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductTradeMarkEditor";
            objClassInfo.strName = "Товарные марки";
            objClassInfo.strDescription = "Список товарных марок";
            objClassInfo.lID = 41;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ViewProductDetail";
            objClassInfo.strName = "Товары";
            objClassInfo.strDescription = "Список товаров";
            objClassInfo.lID = 42;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ViewCalcOrder";
            objClassInfo.strName = "Расчет заказа";
            objClassInfo.strDescription = "Расчет заказа";
            objClassInfo.lID = 43;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ProductCategoryEditor";
            objClassInfo.strName = "Категории товара";
            objClassInfo.strDescription = "Список категорий товара";
            objClassInfo.lID = 44;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.VendorContractTypeEditor";
            objClassInfo.strName = "Типы договоров (поставщик)";
            objClassInfo.strDescription = "Список типов договоров с поставщиком";
            objClassInfo.lID = 45;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.VendorPaymentDocTypeEditor";
            objClassInfo.strName = "Типы платежных документов (поставщик)";
            objClassInfo.strDescription = "Список типов платежных документов при расчетах с поставщиком";
            objClassInfo.lID = 46;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.CarrierRateTypeEditor";
            objClassInfo.strName = "Типы тарифов (перевозчик)";
            objClassInfo.strDescription = "Список типов тарифов перевозчика";
            objClassInfo.lID = 47;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.DriverEditor";
            objClassInfo.strName = "Водители";
            objClassInfo.strDescription = "Справочник водителей";
            objClassInfo.lID = 48;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.VehicleEditor";
            objClassInfo.strName = "Автомобили";
            objClassInfo.strDescription = "Справочник автомобилей";
            objClassInfo.lID = 49;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RouteSheetAdvancedExpenseTypeEditor";
            objClassInfo.strName = "Виды дополнительных расходов";
            objClassInfo.strDescription = "Справочник типов дополнительных расходов для путевого листа";
            objClassInfo.lID = 50;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RouteSheetTypeEditor";
            objClassInfo.strName = "Типы путевых листов";
            objClassInfo.strDescription = "Справочник типов путевых листов";
            objClassInfo.lID = 51;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.PriceTypeEditor";
            objClassInfo.strName = "Типы цен в прайс-листе";
            objClassInfo.strDescription = "Справочник типов цен в прайс-листе";
            objClassInfo.lID = 52;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_PLANORDER";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.RegionDeliveryEditor";
            objClassInfo.strName = "Регион доставки";
            objClassInfo.strDescription = "Справочник регионов доставки";
            objClassInfo.lID = 53;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AgreementTypeEditor";
            objClassInfo.strName = "Тип договора";
            objClassInfo.strDescription = "Справочник типов договоров";
            objClassInfo.lID = 54;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AgreementStateEditor";
            objClassInfo.strName = "Состояние договора";
            objClassInfo.strDescription = "Справочник состояний договоров";
            objClassInfo.lID = 55;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AgrementBasementEditor";
            objClassInfo.strName = "Основания действия";
            objClassInfo.strDescription = "Справочник оснований действия";
            objClassInfo.lID = 56;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AgrementReasonEditor";
            objClassInfo.strName = "Цель приобретения";
            objClassInfo.strDescription = "Справочник целей приобретения";
            objClassInfo.lID = 57;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AgreementDeliveryConditionEditor";
            objClassInfo.strName = "Условия доставки";
            objClassInfo.strDescription = "Справочник условий доставки";
            objClassInfo.lID = 58;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.AgreementPaymentConditionEditor";
            //objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.StockEditor";
            objClassInfo.strName = "Условия оплаты";
            objClassInfo.strDescription = "Справочник условий оплаты";
            objClassInfo.lID = 59;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.StockEditor";
            objClassInfo.strName = "Склад";
            objClassInfo.strDescription = "Справочник складов";
            objClassInfo.lID = 60;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.WareHouseEditor";
            objClassInfo.strName = "Место хранения";
            objClassInfo.strDescription = "Справочник мест хранения";
            objClassInfo.lID = 61;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.WareHouseTypeEditor";
            objClassInfo.strName = "Тип хранилища";
            objClassInfo.strDescription = "Справочник типа хранилища";
            objClassInfo.lID = 62;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.ChildCustEditor";
            objClassInfo.strName = "Дочерние подразделения";
            objClassInfo.strDescription = "Дочерние подразделения";
            objClassInfo.lID = 63;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_GROUPSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.VendorTypeEditor";
            objClassInfo.strName = "Тип поставщика";
            objClassInfo.strDescription = "Справочник типов поставщика";
            objClassInfo.lID = 64;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.CurrencyEditor";
            objClassInfo.strName = "Валюта";
            objClassInfo.strDescription = "Справочник валют";
            objClassInfo.lID = 65;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.MeasureEditor";
            objClassInfo.strName = "Единицы измерения";
            objClassInfo.strDescription = "Справочник единиц измерения";
            objClassInfo.lID = 66;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.CertificateTypeEditor";
            objClassInfo.strName = "Типы документов о качестве товара";
            objClassInfo.strDescription = "Типы документов о качестве товара";
            objClassInfo.lID = 67;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_STATETYPESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditConstType";
            objClassInfo.strName = "Типы констант";
            objClassInfo.strDescription = "Типы констант";
            objClassInfo.lID = 68;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_LOTORDER_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditConst";
            objClassInfo.strName = "Константы";
            objClassInfo.strDescription = "Константы";
            objClassInfo.lID = 69;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_LOTORDER_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditLotOrderState";
            objClassInfo.strName = "Состояния заказов";
            objClassInfo.strDescription = "Состояния заказов";
            objClassInfo.lID = 70;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_LOTORDER_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditKLPState";
            objClassInfo.strName = "Состояния КЛП";
            objClassInfo.strDescription = "Состояния КЛП";
            objClassInfo.lID = 71;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_LOTORDER_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditSurcharges";
            objClassInfo.strName = "Типы дополнительных расходов";
            objClassInfo.strDescription = "Типы дополнительных расходов";
            objClassInfo.lID = 72;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_LOTORDER_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditVendorContractDelayType";
            objClassInfo.strName = "Виды отсрочки платежа";
            objClassInfo.strDescription = "Виды отсрочки платежа";
            objClassInfo.lID = 73;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CONTACTSSMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditNDSRate";
            objClassInfo.strName = "Ставки НДС";
            objClassInfo.strDescription = "Ставки налогов на добавленную стоимость";
            objClassInfo.lID = 74;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditSegmentationChanel";
            objClassInfo.strName = "Каналы сбыта";
            objClassInfo.strDescription = "Каналы сбыта";
            objClassInfo.lID = 75;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditSegmentationMarket";
            objClassInfo.strName = "Рынки сбыта";
            objClassInfo.strDescription = "Рынки сбыта";
            objClassInfo.lID = 76;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditSegmentationSubChannel";
            objClassInfo.strName = "Субканалы сбыта";
            objClassInfo.strDescription = "Субканалы сбыта";
            objClassInfo.lID = 77;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditAccountPlan";
            objClassInfo.strName = "План счетов";
            objClassInfo.strDescription = "План счетов";
            objClassInfo.lID = 78;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditBudgetProject";
            objClassInfo.strName = "Проекты";
            objClassInfo.strDescription = "Проекты";
            objClassInfo.lID = 79;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditEarningType";
            objClassInfo.strName = "Виды оплат";
            objClassInfo.strDescription = "Виды оплат";
            objClassInfo.lID = 80;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "IMAGES_CURRENCYRATESMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditWaybillState";
            objClassInfo.strName = "Состояния накладной";
            objClassInfo.strDescription = "Справочник возможных состояний документа \"Накладная\"";
            objClassInfo.lID = 81;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "document_small";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditWaybillShipMode";
            objClassInfo.strName = "Виды отгрузки";
            objClassInfo.strDescription = "Справочник вариантов проведения документа \"Накладная\"";
            objClassInfo.lID = 82;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "document_small";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditBackWaybillState";
            objClassInfo.strName = "Состояния накладной на возврат товара";
            objClassInfo.strDescription = "Справочник возможных состояний документа \"Накладная на возврат товара\"";
            objClassInfo.lID = 83;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "document_small";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryDatabaseDirectory.EditWaybillBackReason";
            objClassInfo.strName = "Причины возврата товара";
            objClassInfo.strDescription = "Справочник возможных причин возврата товара";
            objClassInfo.lID = 84;
            objClassInfo.nImage = 0;
            objClassInfo.strResourceName = "document_small";
            m_arClassInfo.Add(objClassInfo);
        }
    }

    public class CDatabaseDirectoryModuleInfo : UniXP.Common.CClientModuleInfo
    {
        public CDatabaseDirectoryModuleInfo()
            : base(Assembly.GetExecutingAssembly(),
                UniXP.Common.EnumDLLType.typeItem,
                new System.Guid("{F05199C7-C518-4d29-80E9-6929CEA98AE2}"),
                new System.Guid("{A6319AD0-08C0-49ED-B25B-659BAB622B15}"),
                ERPMercuryDatabaseDirectory.Properties.Resources.IMAGES_STATETYPESMALL,
                ERPMercuryDatabaseDirectory.Properties.Resources.IMAGES_STATETYPESMALL)
        {
        }

        /// <summary>
        /// Выполняет операции по проверке правильности установки модуля в системе.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Check(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Выполняет операции по установке модуля в систему.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Install(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Выполняет операции по удалению модуля из системы.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean UnInstall(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Производит действия по обновлению при установке новой версии подключаемого модуля.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Update(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Возвращает список доступных классов в данном модуле.
        /// </summary>
        public override UniXP.Common.CModuleClassInfo GetClassInfo()
        {
            return new CDatabaseDirectoryModuleClassInfo();
        }
    }

    public class ModuleInfo : PlugIn.IModuleInfo
    {
        public UniXP.Common.CClientModuleInfo GetModuleInfo()
        {
            return new CDatabaseDirectoryModuleInfo();
        }
    }
}
