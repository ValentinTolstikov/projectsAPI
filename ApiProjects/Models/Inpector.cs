//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiProjects.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Inpector
    {
        public int IdInspector { get; set; }
        public int IdTask { get; set; }
        public int IdEmployee { get; set; }

        [JsonIgnore]
        public virtual Task Task { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
