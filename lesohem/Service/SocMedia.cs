using lesohem.DataBase;

namespace lesohem.Service
{
    public class SocMedia : ISocMedia
    {
        LesohemContext db;
        public SocMedia(LesohemContext db) => this.db = db;
        public SocMedium Save(SocMedium media)
        {
            db.SocMedia.Add(media);
            db.SaveChanges();
            return media;
        }
        public string[] Get(int id)
        {
            var res = db.SocMedia.Where(i => i.PersonId == id);
            string Link = "";
            foreach (var item in res)
            {
                Link += item.Link + " ";
            }
            string[] subs = Link.Split(' ').Where(x => x != "").ToArray();
            return subs;
        }
    }
}
