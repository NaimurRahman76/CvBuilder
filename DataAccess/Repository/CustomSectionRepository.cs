using BusinessObject.DataModel;
using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomSectionRepository :GenericRepository<CustomSection>, ICustomSectionRepository
    {
        public CustomSectionRepository(ApplicationDbContext db):base(db) { }

        public async Task AddCustomSection(CustomSection customSection, long cvId)
        {
            var temCv =await _db.Cvs.Include(x => x.SectionList).FirstOrDefaultAsync(o => o.Id == cvId);
            temCv.SectionList.Add(customSection);
        }

        public async Task<List<CustomSection>> GetAllCustomSectionAsync(long cvId)
        {
            var sections = await _db.Cvs.Include(x => x.SectionList).FirstOrDefaultAsync(x => x.Id == cvId);
            return sections.SectionList;
        }
        public async Task Update(CustomSection customSection)
        {
            var tempCustomSection =await _dbSet.FindAsync(customSection.Id);
            tempCustomSection.SectionName=customSection.SectionName;
        }
    }
}
