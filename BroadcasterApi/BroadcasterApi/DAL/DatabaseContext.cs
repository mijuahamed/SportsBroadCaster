using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRole> MenuRolePermission { set; get; }
        DbSet<File> File { get; set; }
        public DbSet<UserFile> UserFile { set; get; }
    }
}
