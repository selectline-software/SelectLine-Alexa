using System;

namespace LambdaSLAPI
{
    class Models
    {
        public class Info
        {
            public String Company { get; set; }

            public String Product { get; set; }

            public String Description { get; set; }

            public String Version { get; set; }

            public String BuildDate { get; set; }

            public Boolean IsBackendManagerRunning { get; set; }
        }

        public class Login
        {
            public String AccessToken { get; set; }

            public String TokenType { get; set; }
        }

        public class Article
        {
            public class PaymentClass
            {
                public String ProfitAccountGroupNumber { get; set; }

                public String ProfitAccountGroupLabel { get; set; }

                public String ExpenseAccountGroupNumber { get; set; }

                public String ExpenseAccountGroupLabel { get; set; }

                public Object QuantityDiscountGroupNumber { get; set; }

                public Object QuantityDiscountGroupLabel { get; set; }

                public String PurchaseTaxCode { get; set; }

                public String PurchaseTaxLabel { get; set; }

                public Object PurchaseAccountNumber { get; set; }

                public String SaleTaxCode { get; set; }

                public String SaleTaxLabel { get; set; }

                public Object SaleAccountNumber { get; set; }

                public Object PriceQuantityUnit { get; set; }

                public String PriceQuantityFactor { get; set; }

                public String PriceReferenceArticleNumber { get; set; }

                public Object PriceReferenceArticleLabel { get; set; }

                public String PriceUnitFactor { get; set; }

                public String SaleLotSize { get; set; }

                public String CommissionGroupNumber { get; set; }

                public String CommissionGroupLabel { get; set; }

                public String EuropeanPurchaseTaxCode { get; set; }

                public String EuropeanPurchaseTaxLabel { get; set; }

                public Object ImportTaxCode { get; set; }

                public Object ImportTaxLabel { get; set; }

                public Object ExportTaxCode { get; set; }

                public Object ExportTaxLabel { get; set; }

                public String CostCentreNumber { get; set; }

                public String CostCentreLabel { get; set; }

                public Object PayerNumber { get; set; }

                public Object PayerLabel { get; set; }

                public String SurchargeCalculationFlag { get; set; }

                public String SurchargeCalculationLabel { get; set; }

                public Boolean IsCommissionAllowed { get; set; }

                public Boolean IsDiscountAllowed { get; set; }

                public Boolean IsCashDiscountAllowed { get; set; }

                public Double ListPrice { get; set; }

                public Double CalculationPrice { get; set; }
            }

            public class WarehouseClass
            {
                public String Stock { get; set; }

                public String AvailableStock { get; set; }

                public String ReservedStock { get; set; }

                public String OrderedStock { get; set; }

                public Object ProductionWarehouseNumber { get; set; }

                public Object ProductionWarehouseLabel { get; set; }

                public String WarehouseStrategyFlag { get; set; }

                public String WarehouseStrategyLabel { get; set; }
            }

            public class CustomFieldsClass
            {
                public Object CustomText1 { get; set; }

                public Object CustomText2 { get; set; }

                public String CustomNumber1 { get; set; }

                public String CustomNumber2 { get; set; }

                public String CustomNumber3 { get; set; }

                public String CustomNumber4 { get; set; }

                public DateTime CustomDate1 { get; set; }

                public DateTime CustomDate2 { get; set; }

                public Boolean CustomIndicator1 { get; set; }

                public Boolean CustomIndicator2 { get; set; }

                public Boolean CustomIndicator3 { get; set; }

                public Boolean CustomIndicator4 { get; set; }
            }

            public class IntrastatClass
            {
                public Object OriginalCountryToken { get; set; }

                public Object OriginalCountryLabel { get; set; }

                public Object GoodsNumber { get; set; }

                public Object GoodsLabel { get; set; }
            }

            public String Number { get; set; }

            public String EuropeanArticleNumber { get; set; }

            public String Name { get; set; }

            public String Description { get; set; }

            public String AdditionalDescription { get; set; }

            public Object MatchCode { get; set; }

            public String ArticleGroupNumber { get; set; }

            public String ArticleGroupLabel { get; set; }

            public String QuantityUnit { get; set; }

            public String Weight { get; set; }

            public Boolean IsWarehouseArtikel { get; set; }

            public String WarehouseId { get; set; }

            public Object QuantityFormulaNumber { get; set; }

            public Object QuantityFormulaLabel { get; set; }

            public String ArticleKind { get; set; }

            public String ArticleKindLabel { get; set; }

            public String SerialOrChargeNumberFlag { get; set; }

            public String SerialOrChargeNumberLabel { get; set; }

            public Object VariantArticleNumber { get; set; }

            public Object VariantArticleLabel { get; set; }

            public Boolean HasMinusWarning { get; set; }

            public Object ManufacturerSupplierNumber { get; set; }

            public Object ManufacturerSupplierLabel { get; set; }

            public Object ManufacturerArticleNumber { get; set; }

            public String DefaultSupplierNumber { get; set; }

            public String DefaultSupplierLabel { get; set; }

            public String DispositionFlag { get; set; }

            public String DispositionLabel { get; set; }

            public String AutomaticOrderFlag { get; set; }

            public String AutomaticOrderLabel { get; set; }

            public DateTime PhasingOutDate { get; set; }

            public Boolean IsInactive { get; set; }

            public Boolean IsShopActive { get; set; }

            public Object RejectArticleNumber { get; set; }

            public Object RejectArticleLabel { get; set; }

            public String RejectRating { get; set; }

            public String ExpirationDays { get; set; }

            public Boolean IsEffortArticle { get; set; }

            public Boolean IsFavorite { get; set; }

            public PaymentClass Payment { get; set; }

            public WarehouseClass Warehouse { get; set; }

            public CustomFieldsClass CustomFields { get; set; }

            public IntrastatClass Intrastat { get; set; }

            public Object Set { get; set; }

            public Object ReferenceAndSerial { get; set; }
        }

        public class Storage
        {
            public class StoragePlaceClass
            {
                public String Id { get; set; }

                public String WarehouseName { get; set; }

                public String Warehouse { get; set; }

                public Object Article { get; set; }

                public Object DimensionName1 { get; set; }

                public String Dimension1 { get; set; }

                public Object DimensionName2 { get; set; }

                public String Dimension2 { get; set; }

                public Object DimensionName3 { get; set; }

                public String Dimension3 { get; set; }

                public String StorageType { get; set; }
            }

            public String ArticleNumber { get; set; }

            public String ArticleName { get; set; }

            public StoragePlaceClass StoragePlace { get; set; }

            public Double Stock { get; set; }

            public Double PackedStock { get; set; }

            public Double ReservedStock { get; set; }

            public Double OrderedStock { get; set; }

            public Double ProducedStock { get; set; }

            public String PriceQuantity { get; set; }

            public String QuantityUnit { get; set; }

            public Object PriceQuantityUnit { get; set; }

            public Object Serialnumber { get; set; }

            public Object ExpirationDate { get; set; }
        }
    }
}