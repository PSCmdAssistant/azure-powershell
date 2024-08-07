 

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSAccessUri
    {
        public string AccessSAS { get; set; }

        public string SecurityDataAccessSAS { get; set; }

    }
}