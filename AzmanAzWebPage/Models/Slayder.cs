//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AzmanAzWebPage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Slayder
    {
        public int slider_id { get; set; }
        public string slider_image { get; set; }
        public Nullable<int> slider_mehsul_id { get; set; }
    
        public virtual Mallar Mallar { get; set; }
    }
}