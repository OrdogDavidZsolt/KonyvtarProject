using KonyvtarAPI.KonyvtarShared;

namespace KonyvtarAPI
{
    public interface IKolcsonzesCRUD
    {
        void Add(Kolcsonzes kolcsonzes);

        List<Kolcsonzes> GetAllKolcsonzes();

        Kolcsonzes GetKolcsonzes(int olvasoSzam, int leltariSzam);
        
        void Update(Kolcsonzes kolcsonzes);

        void Delete(int olvasoSzam, int leltariSzam);
    }
}
