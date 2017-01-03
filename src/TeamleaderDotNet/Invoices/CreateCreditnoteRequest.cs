using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamleaderDotNet.Invoices
{
    public class CreateCreditnoteRequest
    {
        
        public CreateCreditnoteRequest(int invoiceId)
        {
            invoice_id = invoiceId;
            InvoiceLines = new List<CreateInvoice_InvoiceLine>();
        }

        public void AddInvoiceLine(CreateInvoice_InvoiceLine invoiceLine)
        {
            InvoiceLines.Add(invoiceLine);
        }
        
        public int invoice_id { get; private set; }

        public List<CreateInvoice_InvoiceLine> InvoiceLines { get; private set; }


    }


}
