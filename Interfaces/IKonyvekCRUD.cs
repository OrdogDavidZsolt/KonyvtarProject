using KonyvtarAPI.KonyvtarShared;

namespace KonyvtarAPI
{
    public interface IKonyvekCRUD
    {
        void Add(Konyvek konyv);

        List<Konyvek> GetAllKonyvek();

        Konyvek GetKonyv(int leltariSzam);

        void Update(Konyvek konyv);

        void Delete(int leltariSzam);
    }
}
