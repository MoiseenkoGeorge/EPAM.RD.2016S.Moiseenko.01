using System;

namespace Entities
{
    [Serializable]
    public struct VisaRecord
    {
        public string Country { get; set; }

        public DateTime From { get; set; }

        public DateTime Until { get;  set; }
        /// <param name="country"> Name of country</param>
        /// <param name="from"> The start time of visa</param>
        /// <param name="until"> The end time of visa</param>
        public VisaRecord(string country, DateTime from, DateTime until)
        {
            Country = country;
            From = from;
            Until = until;
        }
    }
}