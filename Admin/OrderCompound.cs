//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderCompound
    {
        public long Order { get; set; }
        public long Dish { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
        public string Status { get; set; }
    
        public virtual Dish Dish1 { get; set; }
        public virtual DishStatus DishStatus { get; set; }
        public virtual Order Order1 { get; set; }
    }
}
