using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestTest.ItemDetails.BatchDetails;


namespace RestTest
{
    public class EInvoiceIrpSchema
    {
        public string Version => "1.03";

        public TransactionDetails.TransDtls TransDtls { get; set; }
        public DocumentDetails.DocDtls DocDtls { get; set; }
        public SellerDetails.SellerDtls SellerDtls { get; set;}
        public BuyerDetails.BuyerDtls BuyerDtls { get; set; }

        public ShipToDetails.ShipDtls ShipDtls{ get; set; }

        public DispatchDetails.DispDtls DispDtls { get; set; }

        public IList<ItemDetails.Item> ItemList { get; set; }

        public DocumentTotal.ValDtls ValDtls { get; set; }

        public PaymentDetails.PayDtls PayDtls { get; set; }

        public ReferenceDetails.RefDtls RefDtls { get; set; }
        public AdditionalSupporting.AddlDtls AddlDtls { get; set; }

        public ExportDetails.ExpDtls ExpDtls { get; set; }
        public Ewaybill.EwbDtls EwbDtls { get; set; }

    }

    namespace TransactionDetails
    {
        public class TransDtls
        {
            public string TaxSch { get; set; }
            public string SupTyp { get; set; }

            public string RegRev { get; set; }

            /**
         * GSTIN of E-Commerce operator
         */
            public string EcmGstin { get; set; }

            public string IgstOnIntra { get; set; }
        }

        public class SupTyp
        {
            public string B2B => "B2B";

            public string SEZWP => "SEZWP";
            public string SEZWOP => "SEZWOP";
            public string EXP => "EXP";

        }


        public class RegRev : YesNo
        {

        }

        public class IgstOnIntra : YesNo
        {

        }
    }


    namespace DocumentDetails
    {
        public class DocDtls
        {
            public string Typ { get; set; }

            // document number
            public string No { get; set; }

            // DD/MM/YYYY
            public string Dt { get; set; }
        }

        

        /* Document Type */
        public class Typ
        {
            public string Invoice => "INV";
            public string CreditNote => "CRN";
            public string DebitNote => "DBN";
        }
    }
    public class AddressDetails
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public int Pin { get; set; }
        public string Stcd { get; set; }

    }

    public class TraderDetails:AddressDetails
    {
        public string Gstin { get; set; }
        public string LglNm { get; set; }
        public string TrdNm { get; set; }

    }
    public class CompanyDetails: TraderDetails
    {
        public string Ph { get; set; }
        public string Em { get; set; }
    }

    namespace SellerDetails
    {
        public class SellerDtls: CompanyDetails
        {
            
        }
    }

    namespace BuyerDetails
    {
        public class BuyerDtls : CompanyDetails
        {
            public string Pos { get; set; }
        }
    }

    
    namespace DispatchDetails
    {
        public class DispDtls: AddressDetails
        {
            public string Nm { get; set; }
        }
    }

    namespace ShipToDetails
    {
        public class ShipDtls: TraderDetails
        {

        }
    }

    namespace ItemDetails
    {
        public class Item
        {
            public string SlNo { get; set; }
            public string? PrdDesc { get; set; }
            public string IsServc { get; set; }
            public string HsnCd { get; set; }
            public BchDtls BchDtls { get; set; }
            public string Barcde { get; set; }
            public double Qty { get; set; }
            public double FreeQty { get; set; }
            public string Unit { get; set; }
            public double UnitPrice { get; set; }
            public double TotAmt { get; set; }
            public double Discount { get; set; }
            public double PreTaxVal { get; set; }
            public double AssAmt { get; set; }
            public double GstRt { get; set; }
            public double IgstAmt { get; set; }
            public double CgstAmt { get; set; }
            public double SgstAmt { get; set; }
            public double CesRt { get; set; }
            public double CesAmt { get; set; }
            public double CesNonAdvlAmt { get; set; }
            public double StateCesRt { get; set; }
            public double StateCesAmt { get; set; }
            public double StateCesNonAdvlAmt { get; set; }
            public double OthChrg { get; set; }
            public string OrdLineRef { get; set; }
            public string OrgCntry { get; set; }
            public string PrdSlNo { get; set; }
            public double TotItemVal { get; set; }

            public IList<AttribDtls> AttribDtls { get; set; }
        }

        public class AttribDtls
        {
            public string Nm { get; set; }
            public string Val { get; set; }
        }

        public class ItemFormat
        {
            public string QtyFormat => "10,3";
            public string FreeQtyFormat => "10,3";
            public string UnitPriceFormat => "12,2";
            public string TotAmtFormat => "12,2";
            public string DiscountFormat => "12,2";
            public string PreTaxValFormat => "12,2";
            public string AssAmtFormat => "12,2";
            public string GstRtFormat => "3,3";
            public string IgstAmtFormat => "12,2";
            public string CgstAmtFormat => "12,2";
            public string SgstAmtFormat => "12,2";
            public string CesRtFormat => "3,3";
            public string CesAmtFormat => "12,2";
            public string CesNonAdvlAmtFormat => "12,2";
            public string StateCesRtFormat => "3,3";
            public string StateCesAmtFormat => "12,2";
            public string StateCesNonAdvlAmtFormat => "12,2";
            public string OthChrgFormat => "12,2";
            public string TotItemValFormat => "12,2";

        }

        public class IsServc : YesNo
        {

        }
        namespace BatchDetails
        {
            public class BchDtls
            {
                public string Nm { get; set; }
                public string ExpDt { get; set; }
                public string WrDt { get; set; }


            }
        }
    }

    namespace DocumentTotal
    {
        public class ValDtls
        {
            public double AssVal { get; set; }
            public double CgstVal { get; set; }
            public double SgstVal { get; set; }
            public double IgstVal { get; set; }
            public double CesVal { get; set; }
            public double StCesVal { get; set; }
            public double Discount { get; set; }
            public double OthChrg { get; set; }
            public double RndOffAmt { get; set; }
            public double TotInvVal { get; set; }
            public double TotInvValFc { get; set; }
        }

        public class ValDtlsFormat
        {
            public string AssValFormat => "14,2";
            public string CgstValFormat => "14,2";
            public string IgstValFormat => "14,2";
            public string StCesValFormat => "14,2";
            public string DiscountFormat => "14,2";
            public string OthChrgFormat => "14,2";
            public string RndOffAmtFormat => "2,2";
            public string TotInvValFcFormat => "14,2";

        }
    }


    namespace PaymentDetails
    {
        public class PayDtls
        {
            public string Nm { get; set; }
            public string Mode { get; set; }
            public string FinInsBr { get; set; }
            public string PayTerm { get; set; }
            public string PayInstr{ get; set; }
            public string CrTrn { get; set; }
            public string DirDr { get; set; }
            public int CrDay { get; set; }
            public double  PaidAmt{ get; set; }
            public double PaymtDue { get; set; }
            public string AccDet { get; set; }

        }
        public class PayDtlsFormat
        {
            public string PaidAmtFormat => "14,2";
            public string PaymtDueFormat => "14,2";

        }
    }

    namespace ReferenceDetails
    {
        public class RefDtls
        {
            public string InvRm { get; set; }
            public string InvStDt { get; set; }
            public string InvEndDt { get; set; }

            public IList<PrecDocDtls> PrecDocDtls { get; set; }
            public IList<ContrDtls> ContrDtls { get; set; }

        }

        public class PrecDocDtls
        {
            public string InvNo { get; set; }
            public string InvDt { get; set; }
            public string OthRefNo { get; set; }
        }

        // Contract Reference Number
        public class ContrDtls
        {
            public string RecAdvRefr { get; set; }
            public string RecAdvDt { get; set; }
            public string TendRefr { get; set; }
            public string ContrRefr { get; set; }
            public string ExtRefr { get; set; }
            public string ProjRefr { get; set; }
            public string PORefr { get; set; }
            public string PORefDt { get; set; }



        }
    }

    namespace AdditionalSupporting
    {
        public class AddlDtls
        {
            public AddlDocument AddlDocument { get; set; }
        }

        public class AddlDocument
        {
            public string Url { get; set; }
            public string Docs { get; set; }
            public string Info { get; set; }

        }

    }

    namespace ExportDetails
    {
        public class ExpDtls
        {
            public string ShipBNo { get; set; }
            public string ShipBDt { get; set; }
            public string Port { get; set; }
            public string RefClm { get; set; }
            public string ForCur { get; set; }
            public string CntCode { get; set; }
            public double ExpDuty { get; set; }
        }

        public class ExpDtlsFormat
        {
            public string ExpDutyFormat => "12,2";
        }
    }

    namespace Ewaybill
    {
        public class EwbDtls
        {
            public string TransId { get; set; }
            public string TransName{ get; set; }
            public string TransMode{ get; set; }
            public int Distance{ get; set; }
            public string TransDocNo { get; set; }
            public string TransDocDt { get; set; }
            public string VehNo { get; set; }
            public string VehType { get; set; }


        }
    }

    public class YesNo
    {
        public static string Yes => "Y";
        public static string No => "N";
    }
    public class DocumentDate
    {
        public string DateFormat => "DD/MM/YYYY";
    }
}
