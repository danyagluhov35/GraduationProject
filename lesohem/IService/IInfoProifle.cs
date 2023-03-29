


using lesohem.DataBase;

public interface IInfoProfile
{
    string[] GetUser(int id);
    User Edit(User data, int id);
    User SaveImage(User data, int id);
    User GetImage(int id);
}