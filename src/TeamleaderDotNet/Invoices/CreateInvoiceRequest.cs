using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamleaderDotNet.Invoices
{
    public class CreateInvoiceRequest
    {
        
        public CreateInvoiceRequest(int departementId)
        {
            sys_department_id = departementId;
            InvoiceLines = new List<CreateInvoice_InvoiceLine>();
        }


        public void ForCompany(int companyId)
        {
            contact_or_company = "company";
            contact_or_company_id = companyId;
        }

        public void ForContact(int contactId)
        {
            contact_or_company = "contact";
            contact_or_company_id = contactId;
        }

        public void AddInvoiceLine(CreateInvoice_InvoiceLine invoiceLine)
        {
            InvoiceLines.Add(invoiceLine);
        }

        //contact_or_company: contact or company: Who is the invoice for?
        //contact_or_company_id:integer: ID of the contact or company
        //sys_department_id: ID of the department the invoice will be added to

        public string contact_or_company { get; private set; }
        public int contact_or_company_id { get; private set; }
        public int sys_department_id { get; private set; }
        public int? layout_id { get; set; }

        public string comments { get; set; }
        public string po_number { get; set; }
        public string for_attention_of { get; set; }
        public bool draft_invoice { get; set; }

        public PaymentTerm PaymentTerm { get; set; }
        public List<CreateInvoice_InvoiceLine> InvoiceLines { get; private set; }





    }


    public class CreateInvoice_InvoiceLine
    {
        public CreateInvoice_InvoiceLine(string description, double price, double amount, VatTariff vatTariff)
        {
            this.description = description;
            this.price = price;
            this.amount = amount;
            VatTariff = vatTariff;
        }

        public CreateInvoice_InvoiceLine(string description, double price, double amount, VatTariff vatTariff, int? productId, int? account)
        {
            this.description = description;
            this.price = price;
            this.amount = amount;
            VatTariff = vatTariff;
            product_id = productId;
            this.account = account;
        }

        public string description { get; set; }
        public string subtitle { get; set; }
        public double price { get; set; }
        public double amount { get; set; }
        public VatTariff VatTariff { get; set; }
        public int? product_id { get; set; }
        public int? account { get; set; }




    }
}
