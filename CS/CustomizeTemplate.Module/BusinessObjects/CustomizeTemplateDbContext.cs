using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;

namespace  CustomizeTemplate.Module.BusinessObjects {
	public class CustomizeTemplateDbContext : DbContext {
		public CustomizeTemplateDbContext(String connectionString)
			: base(connectionString) {
		}
		public CustomizeTemplateDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Contact> Contacts { get; set; }
	}
}