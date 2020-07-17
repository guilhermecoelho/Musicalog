using Microsoft.EntityFrameworkCore;
using Musicalog_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog.Data.Config
{
    public class ContextBase : DbContext
    {
        public ContextBase()
        {

        }

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StrincConectionConfig());
            }
        }

        public DbSet<AlbumsDomain> Albums { get; set; }


        private string StrincConectionConfig()
        {
            string strCon = "Data Source=DESKTOP-B1DJFST\\SQLEXPRESS; Initial Catalog = Musicalog; Integrated Security = SSPI";

            return strCon;
        }
    }
}
