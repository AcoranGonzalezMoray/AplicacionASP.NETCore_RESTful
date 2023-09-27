using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Core.Entities
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int age { get; set; }
        public RoleEnum role { get; set; }
    }
}
