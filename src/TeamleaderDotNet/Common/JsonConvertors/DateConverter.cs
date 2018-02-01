using Newtonsoft.Json.Converters;

namespace TeamleaderDotNet.Common.JsonConvertors
{
    public class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
