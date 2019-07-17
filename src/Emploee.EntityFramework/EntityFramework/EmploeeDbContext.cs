﻿using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Emploee.Authorization.Roles;
using Emploee.Authorization.Users;
using Emploee.Chat;
using Emploee.Friendships;
using Emploee.MultiTenancy;
using Emploee.Storage;

namespace Emploee.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */

    public class EmploeeDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

         
        public EmploeeDbContext()
            : base("Default")
        {
            
        }

        public EmploeeDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public EmploeeDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public EmploeeDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
