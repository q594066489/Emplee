using Emploee.EntityFramework;

namespace Emploee.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly EmploeeDbContext _context;

        public InitialHostDbBuilder(EmploeeDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
