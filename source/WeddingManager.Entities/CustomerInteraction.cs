//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingManager.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerInteraction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Nullable<System.DateTimeOffset> DateSuppressed { get; set; }
        public int InteractionType { get; set; }
        public System.DateTimeOffset Date { get; set; }
        public string Notes { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomerInteractionType CustomerInteractionType { get; set; }
    }
}