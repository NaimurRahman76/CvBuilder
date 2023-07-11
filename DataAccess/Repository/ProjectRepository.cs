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
    public class ProjectRepository :GenericRepository<ProjelctView>, IProjectRepository
    {
        
        public ProjectRepository(ApplicationDbContext db) : base(db) { }
        public async Task AddProject(ProjelctView porject, long cvId)
        {
            var cv =await _db.Cvs.Include(x => x.ProjectList).FirstOrDefaultAsync(o => o.Id == cvId);
            cv.ProjectList.Add(porject);
        }

        public async Task< List<ProjelctView>> GetAllProjectByCvId(long cvId)
        {
            var list = new List<ProjelctView>();
            var cv =await _db.Cvs.Include(_ => _.ProjectList).FirstOrDefaultAsync(x => x.Id == cvId);
            if (cv != null && cv.ProjectList != null) list = cv.ProjectList;
            return list;
        }
    }
}
