using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
