//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrTrussardi
{
    using System;
    using System.Collections.Generic;
    
    public partial class CanceledOrders
    {
        public int OrderId { get; set; }
        public string Cause { get; set; }
        public int COId { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}
