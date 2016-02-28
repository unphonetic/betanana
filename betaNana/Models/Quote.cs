//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace betaNana.Models
{
    public class Quote : EntityBase
    {

       [MaxLength(250)]
        public string Contact { get; set; }

        public bool SendTaxCertificate { get; set; }

        public bool Taxable {get; set;}
        
        public int Discount {get; set;}

        public int OrderNumber {get; set;}

        public IList<QuoteDetail> QuoteDetails {get; set;}



    }
}


/*
name                       name                       max_length
-------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------- ----------
QuoteID                    int                        4
DupeQuoteid                int                        4
LastUpdated                datetime                   8
Date                       smalldatetime              4
ProjectID                  int                        4
LeadID                     int                        4
Discount                   smallint                   2
QuoteNotes                 varchar                    -1
OfficeNotes                varchar                    -1
OrderNumber                int                        4
DateOrder                  smalldatetime              4
Taxable                    bit                        1
SLFastMfg                  bit                        1
DateSignoff                smalldatetime              4
DateDeposit                smalldatetime              4
DepositAmount              money                      8
DateOrderFinalized         smalldatetime              4
DateFinalConfirm           smalldatetime              4
DateEstPickup              smalldatetime              4
DateActualPickup           smalldatetime              4
DateEtaJobsite             smalldatetime              4
DateInvoicesSent           smalldatetime              4
BalanceReceived            money                      8
DateBalanceRcvd            smalldatetime              4
DateActualDelivery         smalldatetime              4
DateOrderAcknowledged      datetime                   8
FreightTrackingNumber      varchar                    25
Printed                    bit                        1
Ordered                    bit                        1
FreightSaved               bit                        1
FreightPriceSaved          money                      8
ShippingAddress            xml                        -1
FastShipping               bit                        1
TaxSaved                   bit                        1
TaxRateSaved               money                      8
CustomList                 xml                        -1
AddedByRep                 varchar                    50
SealySentDate              smalldatetime              4
QuoteStatusNotes           varchar                    -1
KeyedAlike                 bit                        1
ShippingPhone              varchar                    20
ShippingName               varchar                    50
ShippingCompany            varchar                    50
SLOrderNumber              varchar                    50
InstallerID                int                        4
InstallationDate           smalldatetime              4
QuotePDF                   varbinary                  -1
OrderConfirmationPDF       varbinary                  -1
ShippingTime               xml                        -1
DrawingType                int                        4
CustomDrawingPipeline      xml                        -1
PackingListPipeline        xml                        -1
InstallDate                datetime                   8
InstallConfirm_bak         bit                        1
ScreenSupplierID           int                        4
ScreenPipeline             xml                        -1
HardwarePipeline           xml                        -1
InstallerNotes             varchar                    -1
InstallConfirm             int                        4
ExtendedWarranty           bit                        1
ResponsibleRep             int                        4
GlassPipeline              xml                        -1
UnglazedOverride           bit                        1
PackagingType              int                        4
DrawingPriceOverride       money                      8
DrawingPriceIsOverridden   bit                        1
SalesForceID               varchar                    255
addedbyrepid               int                        4
datedepositreceived        datetime                   8
QuoteNotes2                varchar                    -1
SalesforceProjectID        varchar                    25
SalesforceLeadID           varchar                    25
Salesforceinstallerid      varchar                    25
salesforcescreensupplierid varchar                    25
DateRevisedETAJobsite      datetime                   8
DateFreightETAJobsite      datetime                   8
FreightETAJobsiteReason    varchar                    -1
RevisedETAJobsiteReason    varchar                    -1
OnHold                     bit                        1
AACO                       bit                        1
SendTaxCertificate         bit                        1
IncompleteOrderConfirmationbit                        1
IncompleteOrderConfirmationNotes                                                                                                 varchar                    -1
DateWorkOrderSent          datetime                   8
DateWorkOrderReceived      datetime                   8
FinalInvoiceAmount         money                      8
Rush                       bit                        1
OrderConfirmationSent      datetime                   8
CADSent                    datetime                   8
OrderConfirmationOpened    datetime                   8
CADOpened                  datetime                   8
PONumber                   varchar                    25
Cancelled                  bit                        1
RequiresSupervisor         bit                        1
TahaReview                 bit                        1
DateFactoryCompletion      datetime                   8
RecordType                 varchar                    -1
PriorityQuote              bit                        1
CanadianTaxStatus          varchar                    -1
Stage                      varchar                    -1
*/
