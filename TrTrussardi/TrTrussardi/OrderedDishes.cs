namespace TrTrussardi
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderedDishes
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int ODId { get; set; }
    
        public virtual Dishes Dishes { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
