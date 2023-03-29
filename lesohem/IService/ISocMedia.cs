


using lesohem.DataBase;

public interface ISocMedia
{
    SocMedium Save(SocMedium socMedium);
    string[] Get(int id);
}