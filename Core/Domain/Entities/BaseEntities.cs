using System;
namespace Core.Entities
{
    public class AuditBaseEntity
    {
        public int? ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }

    public class CatalogBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }


}

