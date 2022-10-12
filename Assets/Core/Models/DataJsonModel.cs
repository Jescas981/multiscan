using System.Collections.Generic;

namespace Multiscan.Models
{
    public class FingerData
    {
        public string name { get; set; }
        public double? volume { get; set; }
    }

    public class DataJsonModel
    {
        public string date { get; set; }
        public double pressure { get; set; }
        public IList<FingerData> fingers { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
    }
}
