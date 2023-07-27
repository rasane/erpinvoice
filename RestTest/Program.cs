// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using System.Text.Json;
using RestTest;
using RestTest.BuyerDetails;
using RestTest.DispatchDetails;
using RestTest.DocumentDetails;
using RestTest.DocumentTotal;
using RestTest.Ewaybill;
using RestTest.ExportDetails;
using RestTest.ItemDetails;
using RestTest.ItemDetails.BatchDetails;
using RestTest.PaymentDetails;
using RestTest.ReferenceDetails;
using RestTest.SellerDetails;
using RestTest.ShipToDetails;
using RestTest.TransactionDetails;

Console.WriteLine("Hello, World!");


var gstIn = @"27AAFCP0535R012";
var customerId = "C30026";
EInvoiceIrpSchema eInvoiceIrpSchema = new EInvoiceIrpSchema()
{
    TransDtls = new TransDtls()
    {
        TaxSch = "GST",
        SupTyp = "B2B",
        RegRev = "Y",
        IgstOnIntra = "N"
    },
    DocDtls = new DocDtls()
    {
        Typ = "INV",
        No = "DOC/105",
        Dt = "18/10/2020"
    },
    BuyerDtls = new BuyerDtls()
    {
        Gstin = gstIn,
        LglNm = "XYZ company pvt ltd",
        TrdNm = "XYZ Industries",
        Pos = "09",
        Addr1 = "7th block, kuvempu layout",
        Addr2 = "kuvempu layout",
        Loc = "GANDHINAGAR",
        Pin = 208003,
        Stcd = "09",
        Ph = "91111111111",
        Em = "xyz@yahoo.com"
    },
    SellerDtls = new SellerDtls()
    {
        Gstin = "09AAFCP0535R003",
        LglNm = "NIC company pvt ltd",
        TrdNm = "NIC Industries",
        Addr1 = "5th block, kuvempu layout",
        Addr2 = "kuvempu layout",
        Loc = "GANDHINAGAR",
        Pin = 208003,
        Stcd = "09",
        Ph = "9000000000",
        Em = "abc@gmail.com"
    },
    DispDtls = new DispDtls()
    {
        Nm = "ABC company pvt ltd",
        Addr1 = "7th block, kuvempu layout",
        Addr2 = "kuvempu layout",
        Loc = "Banagalore",
        Pin = 562160,
        Stcd = "29"
    },
    ShipDtls = new ShipDtls()
    {
        Gstin = "29AWGPV7107B1Z1",
        LglNm = "CBE company pvt ltd",
        TrdNm = "kuvempu layout",
        Addr1 = "7th block, kuvempu layout",
        Addr2 = "kuvempu layout",
        Loc = "Banagalore",
        Pin = 562160,
        Stcd = "29"
    },
    EwbDtls = new EwbDtls()
    {
        TransId = "12AWGPV7107B1Z1",
        TransName = "XYZ EXPORTS",
        TransMode = "1",
        Distance = 100,
        TransDocNo = "DOC01",
        TransDocDt = "18/08/2020",
        VehNo = "ka123456",
        VehType = "R"
    },
    ExpDtls = new ExpDtls()
    {
        ShipBNo = "A-248",
        ShipBDt = "01/08/2020",
        CntCode = "AE",
        ForCur = "AED",
        Port = "INABG1",
        RefClm = "N",
        ExpDuty = 0
    },
    ItemList = new List<Item>()
    {
        new Item()
        {
            AttribDtls = new List<AttribDtls>()
            {
                new AttribDtls()
                {
                    Nm = "Rice",
                    Val = "10000"
                }
            },
            PrdSlNo = "12345",
            OrgCntry = null,
            OrdLineRef = null,
            TotItemVal = 20790.19,
            OthChrg = 0,
            StateCesNonAdvlAmt = 0,
            StateCesAmt = 0,
            StateCesRt = 0,
            CesNonAdvlAmt = 0,
            CesAmt = 0,
            CesRt = 0,
            SgstAmt = 1113.76,
            CgstAmt = 1113.76,
            IgstAmt = 0,
            Qty = 100.345,
            AssAmt = 18562.67,
            PreTaxVal = 0,
            Discount = 0.07,
            TotAmt = 18562.74,
            UnitPrice = 883.94,
            Unit = "BAG",
            FreeQty = 10,
            GstRt = 12,
            Barcde = "123456",
            BchDtls = new BchDtls()
            {
                Nm = "123456",
                ExpDt = "01/08/2020",
                WrDt = "01/09/2020"
            },
            HsnCd = "1001",
            IsServc = YesNo.Yes,
            PrdDesc = "Rice",
            SlNo = "1"
        },
        new Item()
        {
            AttribDtls = new List<AttribDtls>()
            {
                new AttribDtls()
                {
                    Nm = "Rice",
                    Val = "10000"
                }
            },
            PrdSlNo = "12345",
            TotItemVal = 3225.6,
            OthChrg = 0,
            StateCesNonAdvlAmt = 0,
            StateCesAmt = 0,
            StateCesRt = 0,
            CesNonAdvlAmt = 0,
            CesAmt = 0,
            CesRt = 0,
            SgstAmt = 172.8,
            CgstAmt = 172.8,
            IgstAmt = 0,
            Qty = 12,
            AssAmt = 2880,
            PreTaxVal = 0,
            Discount = 0,
            TotAmt = 2880,
            UnitPrice = 240,
            Unit = "PCS",
            FreeQty = 0,
            GstRt = 12,
            BchDtls = new BchDtls()
            {
                Nm = "123456",
                ExpDt = "01/08/2020",
                WrDt = "01/09/2020"
            },
            HsnCd = "9405",
            IsServc = "N",
            SlNo = "2"
        }
    },
    ValDtls = new ValDtls()
    {
        AssVal = 21442.67,
        CgstVal = 1286.56,
        SgstVal = 1286.56,
        IgstVal = 0,
        CesVal = 0,
        StCesVal = 0,
        RndOffAmt = 0,
        TotInvVal = 24015.79,
        TotInvValFc = 0,
        Discount = 0,
        OthChrg = 0
    },
    PayDtls = new PayDtls()
    {
        Nm = "ABCDE",
        AccDet = "5697389713210",
        Mode = "Cash",
        FinInsBr = "SBIN11000",
        CrTrn = "test",
        PayInstr = "Gift",
        PayTerm = "100",
        DirDr = "test",
        CrDay = 100,
        PaidAmt = 10000,
        PaymtDue = 5000
    },
    RefDtls = new RefDtls()
    {
        InvRm = "TEST",
        PrecDocDtls = new List<PrecDocDtls>()
        {
            new PrecDocDtls()
            {
                InvNo = "DOC/002",
                InvDt = "01/08/2020",
                OthRefNo = "123456"
            }
        },
        ContrDtls = new List<ContrDtls>()
        {
            new ContrDtls()
            {
                RecAdvDt = "01/08/2020",
                RecAdvRefr = "Doc/003",
                TendRefr = "Abc001",
                ContrRefr = "Co123",
                ExtRefr = "Yo456",
                ProjRefr = "Doc-456",
                PORefr = "Doc-789",
                PORefDt = "01/08/2020"
            }
        },
        
    }

};

var jsonString = JsonSerializer.Serialize(eInvoiceIrpSchema);
//var jsonString = File.ReadAllText(@"00002.json");
HttpClient httpClient = new HttpClient();
var sandBoxUrl = "https://testapi.mygstcafe.com/eicore/v1.03/Invoice";
var username = "speaktosatishmh";
var password = "Satish@9044";
var apiId = "f7KWT4e0-iQUb-bpf2-G1lY-uUGDebdP";
var apiSecret = "f7KWT4e0iQUbbpf2";

httpClient.DefaultRequestHeaders.Add("Username", username);
httpClient.DefaultRequestHeaders.Add("Password", password);

httpClient.DefaultRequestHeaders.Add("APIId", apiId);
httpClient.DefaultRequestHeaders.Add("APISecret", apiSecret);
httpClient.DefaultRequestHeaders.Add("CustomerId", customerId);
httpClient.DefaultRequestHeaders.Add("GSTIN", gstIn);
httpClient.DefaultRequestHeaders.Add("Source", "API");
// 


var httpContent = JsonContent.Create<EInvoiceIrpSchema>(eInvoiceIrpSchema);

//var postResponse = await httpClient.PostAsync(sandBoxUrl, httpContent);
var postResponse = await httpClient.PostAsJsonAsync<string>(new Uri(sandBoxUrl), jsonString, CancellationToken.None);
Console.WriteLine(JsonSerializer.Serialize(postResponse, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true }));

if (!postResponse.IsSuccessStatusCode)
{
    Console.WriteLine($"request failed {postResponse.StatusCode} {postResponse.ReasonPhrase}");
    return;
}
var responseContent = await postResponse.Content.ReadAsStringAsync();

Console.WriteLine(responseContent);
Console.ReadLine();



