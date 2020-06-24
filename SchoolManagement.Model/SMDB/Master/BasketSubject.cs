using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class BasketSubject
    {
        public long ParentBasketCategoryId { get; set; }
        public long BasketSubjecId { get; set; }

        public virtual Subject ParentBasketSubject { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
