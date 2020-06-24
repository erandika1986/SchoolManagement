using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class ClassName
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CockpitName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
