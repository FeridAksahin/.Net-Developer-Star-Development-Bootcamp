﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkWorks01
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBStudentExamEntities : DbContext
    {
        public DBStudentExamEntities()
            : base("name=DBStudentExamEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TABLELESSON> TABLELESSON { get; set; }
        public virtual DbSet<TABLESCORE> TABLESCORE { get; set; }
        public virtual DbSet<TABLESTUDENT> TABLESTUDENT { get; set; }
    
        public virtual ObjectResult<SCORELIST_Result> SCORELIST()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SCORELIST_Result>("SCORELIST");
        }
    }
}
