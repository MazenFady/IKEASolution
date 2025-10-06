using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } // Primary key
        public int CreatedBy { get; set; } // User ID who created the record USerID

        public DateTime CreatedOn { get; set; } = DateTime.Now; // Timestamp of creation

        public int LastModifiedBy { get; set; } // User ID who last modified the record

        public DateTime LastModifiedOn { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } // Soft delete flag

    }
}
