using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routine.Api.Model
{
    public class EmloyeeDto
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public string EmployeeNo { get; set; }

        public string Name { get; set; }

        public string GenderDisplay { get; set; }

        public int Age { get; set; }

    }
}
