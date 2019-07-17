using EntityFramework.DynamicFilters;
using Emploee.EntityFramework;

namespace Emploee.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly EmploeeDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(EmploeeDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
