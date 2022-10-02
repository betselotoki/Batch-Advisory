using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class Advisor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string AssignedBatch { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Batch AssignedBatchNavigation { get; set; } = null!;
    }
}
