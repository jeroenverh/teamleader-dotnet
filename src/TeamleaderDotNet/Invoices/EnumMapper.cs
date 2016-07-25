using System;

namespace TeamleaderDotNet.Invoices
{
    public class EnumMapper
    {
        public string MapPaymentTerm(PaymentTerm pt)
        {
            switch (pt)
            {
                case PaymentTerm.Days_0:
                    return "0D";
                case PaymentTerm.Days_7:
                    return "7D";
                case PaymentTerm.Days_10:
                    return "10D";
                case PaymentTerm.Days_15:
                    return "15D";
                case PaymentTerm.Days_21:
                    return "21D";
                case PaymentTerm.Days_30:
                    return "30D";
                case PaymentTerm.Days_45:
                    return "45D";
                case PaymentTerm.Days_60:
                    return "60D";
                case PaymentTerm.EndOfMonth_30:
                    return "30DEM";
                case PaymentTerm.EndOfMonth_60:
                    return "60DEM";
                case PaymentTerm.EndOfMonth_90:
                    return "90DEM";
                default:
                    throw new Exception();
            }

        }

        public string MapVat(VatTariff vatTariff)
        {
            switch (vatTariff)
            {
                case VatTariff.Vat_00:
                    return "00";
                case VatTariff.Vat_06:
                    return "06";
                case VatTariff.Vat_12:
                    return "12";
                case VatTariff.Vat_21:
                    return "21";
                case VatTariff.CM:
                    return "CM";
                case VatTariff.EX:
                    return "EX";
                case VatTariff.MC:
                    return "MC";
                case VatTariff.VCMD:
                    return "VCMD";
                default:
                    throw new Exception();
            }
        }
    }
}