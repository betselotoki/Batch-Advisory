using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class ClassRoom
    {
        public string Room { get; set; } = null!;
        public int ClassSize { get; set; }
        public int Available { get; set; }
    }
}
