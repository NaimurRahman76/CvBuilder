using Microsoft.AspNetCore.Http;
namespace CV_Maker.Utility
{
    public class Session
    {
        private readonly IHttpContextAccessor _Http;
        public Session(IHttpContextAccessor Http)
        {
            _Http = Http;
        }
        public long GetCvId()
        {
            var id=_Http.HttpContext.Session.GetInt32("cvId");
            if(id == 0|| id == null)
            {
                throw new Exception("Cv id is null while accessing from session");

            }
            var cvId=(long)id;
            return cvId;
        }
        public long GetSectionId()
        {
            var id = _Http.HttpContext.Session.GetInt32("sectionId");
            if (id == 0 || id == null)
            {
                throw new Exception("Section id is null while accessing from session");

            }
            var sectionId = (long)id;
            return sectionId;
        }
        public string SectionName()
        {
            var sectionName = _Http.HttpContext.Session.GetString("sectionName");
            if (sectionName == null)
            {
                throw new Exception("Section name is null while accessing from session");

            }
            
            return sectionName;
        }
    }
}
