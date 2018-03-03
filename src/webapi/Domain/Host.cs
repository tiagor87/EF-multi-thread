using System;

namespace EFMultiThread.Domain
{
    public class Host
    {
        public long Id { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public double Threshold { get; set; }
        public int Type { get; set; }
    }

}
