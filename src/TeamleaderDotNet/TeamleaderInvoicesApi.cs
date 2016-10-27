using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.Invoices;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderInvoicesApi : TeamleaderApiBase
    {
        public TeamleaderInvoicesApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }
        
        public int AddInvoice(CreateInvoiceRequest createInvoiceRequest, List<KeyValuePair<string, string>> customFields)
        {
            if(string.IsNullOrWhiteSpace(createInvoiceRequest.contact_or_company)) throw new Exception();
            if(createInvoiceRequest.InvoiceLines == null || !createInvoiceRequest.InvoiceLines.Any()) throw new Exception();

            var fields = new List<KeyValuePair<string, string>>();
            
            fields.Add(new KeyValuePair<string, string>("sys_department_id", createInvoiceRequest.sys_department_id.ToString()));
            fields.Add(new KeyValuePair<string, string>("contact_or_company", createInvoiceRequest.contact_or_company));
            fields.Add(new KeyValuePair<string, string>("contact_or_company_id", createInvoiceRequest.contact_or_company_id.ToString()));

            if(!string.IsNullOrWhiteSpace(createInvoiceRequest.for_attention_of))
                fields.Add(new KeyValuePair<string, string>("for_attention_of", createInvoiceRequest.for_attention_of));

            fields.Add(new KeyValuePair<string, string>("payment_term", _enumMapper.MapPaymentTerm(createInvoiceRequest.PaymentTerm)));

            int invoiceLineId = 0;

            foreach (var invoiceLine in createInvoiceRequest.InvoiceLines)
            {
                invoiceLineId = invoiceLineId + 1;

                fields.Add(new KeyValuePair<string, string>(string.Format("description_{0}", invoiceLineId), invoiceLine.description));

                fields.Add(new KeyValuePair<string, string>(string.Format("price_{0}", invoiceLineId), invoiceLine.price.ToString()));

                fields.Add(new KeyValuePair<string, string>(string.Format("amount_{0}", invoiceLineId), invoiceLine.amount.ToString()));

                fields.Add(new KeyValuePair<string, string>(string.Format("vat_{0}", invoiceLineId), _enumMapper.MapVat(invoiceLine.VatTariff)));

                if(invoiceLine.product_id.HasValue)
                    fields.Add(new KeyValuePair<string, string>(string.Format("product_id_{0}", invoiceLineId), invoiceLine.product_id.Value.ToString()));

                if (invoiceLine.account.HasValue)
                    fields.Add(new KeyValuePair<string, string>(string.Format("account_{0}", invoiceLineId), invoiceLine.account.Value.ToString()));
            }

            fields.Add(new KeyValuePair<string, string>("draft_invoice", createInvoiceRequest.draft_invoice ? "1" : "0"));

            if(!string.IsNullOrWhiteSpace(createInvoiceRequest.po_number))
                fields.Add(new KeyValuePair<string, string>("po_number", createInvoiceRequest.po_number));

            if (customFields != null && customFields.Any())
            {
                foreach (var customField in customFields)
                {
                    fields.Add(new KeyValuePair<string, string>(string.Format("custom_field_{0}", customField.Key), customField.Value));
                }
            }
            
            var invoiceId = DoCall<string>("addInvoice.php", fields);

            return int.Parse(invoiceId);
        }


        public void BookDraftInvoice(int invoiceId)
        {
            var fields = new List<KeyValuePair<string, string>>();

            fields.Add(new KeyValuePair<string, string>("invoice_id", invoiceId.ToString()));

            DoCall<string>("bookDraftInvoice.php", fields);
        }

        public Stream DownloadInvoice(int invoiceId)
        {
            var fields = new List<KeyValuePair<string, string>>();

            fields.Add(new KeyValuePair<string, string>("invoice_id", invoiceId.ToString()));

            return DoStreamCall("downloadInvoicePDF.php", fields);


        }

        public Invoice GetInvoice(int invoiceId)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("invoice_id", invoiceId.ToString())
            };

            return DoCall<Invoice>("getInvoice.php", fields);
        }


    }
}
