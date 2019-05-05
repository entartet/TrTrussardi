namespace TrTrussardi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dishes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dishes()
        {
            this.CanceledDishes = new HashSet<CanceledDishes>();
            this.Compositions = new HashSet<Compositions>();
            this.OrderedDishes = new HashSet<OrderedDishes>();
        }
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Count { get; set; }
        public byte[] Picture { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrate { get; set; }
        public float Calories { get; set; }
        public int Val { get; set; }
        public int CategoryId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanceledDishes> CanceledDishes { get; set; }
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compositions> Compositions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderedDishes> OrderedDishes { get; set; }
    }
}
