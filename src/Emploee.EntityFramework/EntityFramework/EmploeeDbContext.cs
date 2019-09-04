using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Emploee.Approvals;
using Emploee.Approvals.EntityMapper.Approvals;
using Emploee.Authorization.Roles;
using Emploee.Authorization.Users;
using Emploee.Chat;
using Emploee.Emploee.Advertisements;
using Emploee.Emploee.Advertisements.EntityMapper.Advertisements;
using Emploee.Emploee.Dictionaries;
using Emploee.Emploee.Dictionaries.EntityMapper.Dictionaries;
using Emploee.Emploee.Job_Positions;
using Emploee.Emploee.Job_Positions.EntityMapper.Job_Positions;
using Emploee.Emploee.JobPersons;
using Emploee.Emploee.JobPersons.EntityMapper.JobPersons;
using Emploee.Emploee.JobPosts;
using Emploee.Emploee.JobPosts.EntityMapper.JobPosts;
using Emploee.Emploee.JobUrgents;
using Emploee.Emploee.JobUrgents.EntityMapper.JobUrgents;
using Emploee.Emploee.PersonInfos;
using Emploee.Emploee.PersonInfos.EntityMapper.PersonInfos;
using Emploee.Emploees.Companies;
using Emploee.Emploees.Companies.EntityMapper.Companies;
using Emploee.Friendships;
using Emploee.MultiTenancy;
using Emploee.PayLogs;
using Emploee.PayLogs.EntityMapper.PayLogs;
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
        
        public IDbSet<Company> Companys { get; set; }
        public IDbSet<JobPost> JobPosts { get; set; }
        public IDbSet<JobUrgent> JobUrgents { get; set; }
        public IDbSet<PersonInfo> PersonInfos { get; set; }
        public IDbSet<JobPerson> JobPersons { get; set; }

        public IDbSet<Approval> Approvals { get; set; }
        public IDbSet<Advertisement> Advertisements { get; set; }
        public IDbSet<Dictionary> Dictionarys { get; set; }
        public IDbSet<JobPosition> JobPositions { get; set; }
        public IDbSet<PayLog> PayLogs { get; set; }
        


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
        //代码生成器生成
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Ignore(a => a.Surname);
            modelBuilder.Entity<User>().Property(a => a.EmailAddress).IsOptional();
            modelBuilder.Configurations.Add(new CompanyCfg());
            modelBuilder.Configurations.Add(new JobPostCfg());
            modelBuilder.Configurations.Add(new JobUrgentCfg());
            modelBuilder.Configurations.Add(new PersonInfoCfg());
            modelBuilder.Configurations.Add(new JobPersonCfg());
            modelBuilder.Configurations.Add(new ApprovalCfg());
            modelBuilder.Configurations.Add(new AdvertisementCfg());
            modelBuilder.Configurations.Add(new DictionaryCfg());
            modelBuilder.Configurations.Add(new JobPositionCfg());
            modelBuilder.Configurations.Add(new PayLogCfg());
        }
    }
}
