using KonyvtarAPI.KonyvtarShared;

namespace KonyvtarAPI
{
    public class KonyvekService : IKonyvekCRUD
    {
        private readonly List<Konyvek> _konyvek;
        private readonly ILogger<KonyvekService> _logger;

        public KonyvekService(ILogger<KonyvekService> logger)
        {
            _konyvek = new List<Konyvek>();
            _logger = logger;
        }

        public void Add(Konyvek konyv)
        {
            _konyvek.Add(konyv);
            _logger.LogInformation("Könyv hozzáadva");
        }

        public List<Konyvek> GetAllKonyvek()
        {
            return _konyvek;
        }

        public Konyvek GetKonyv(int leltariSzam)
        {
            return _konyvek.Find(k => k.LeltariSzam == leltariSzam);
        }

        public void Update(Konyvek konyv)
        {
            var oldKonyv = GetKonyv(konyv.LeltariSzam);

            oldKonyv.Cim = konyv.Cim;
            oldKonyv.Szerzo = konyv.Szerzo;
            oldKonyv.KiadasEve = konyv.KiadasEve;

            _logger.LogInformation("Könyv frissítve");
        }

        public void Delete(int leltariSzam)
        {
            _konyvek.RemoveAll(k => k.LeltariSzam == leltariSzam);
            _logger.LogInformation("Könyv törölve");
        }
    }
}
