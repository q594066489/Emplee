using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.Job_Positions
{
    public class JobPosition : Entity
    {
        public short Position_no { get; set; }
        [MaxLength(200)]
        public string Position_name { get; set; }

        public short Parent_id { get; set; }
    }
}
