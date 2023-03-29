using lesohem.DataBase;

namespace lesohem.Service
{
    public class InfoProfile : IInfoProfile
    {
        LesohemContext _db;
        public InfoProfile(LesohemContext db) => _db = db;

        public User Edit(User data, int id)
        {
            User? user = _db.Users.FirstOrDefault(u => u.Id == id);
            try
            {
                if (user == null)
                    Console.WriteLine($"Error!");
                if (data.CountryName != null)
                    user.CountryName = data.CountryName;
                else if (data.CityName != null)
                    user.CityName = data.CityName;
                else if (data.GroupName != null)
                    user.GroupName = data.GroupName;
                else if (data.DirectionName != null)
                    user.DirectionName = data.DirectionName;
                else if (data.Gender != null)
                    user.Gender = data.Gender;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine($"Ошибка!");
            }

            return user;
        }


        public string[] GetUser(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            string data = user.CountryName + "," + user.CityName + "," + user.Gender + "," + user.GroupName + "," + user.DirectionName;
            string[] res = data.Split(',');
            return res;
        }

        public User SaveImage(User data, int id)
        {
            User? user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception("Пользователь не найден!");
            user.Photo = data.Photo;
            _db.SaveChanges();
            return user!;
        }
        public User GetImage(int id)
        {
            User? user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception("Пользователь не найден!");
            return user!;
        }
    }
}
