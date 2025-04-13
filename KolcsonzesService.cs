namespace KonyvtarAPI
{
    public class KolcsonzesService : IKolcsonzesCRUD
    {
        private readonly List<Kolcsonzes> _kolcsonzesek;
        private readonly ILogger<KolcsonzesService> _logger;

        public KolcsonzesService(ILogger<KolcsonzesService> logger)
        {
            _kolcsonzesek = [];
            _logger = logger;
        }

        public void Add(Kolcsonzes kolcsonzes)
        {
            _kolcsonzesek.Add(kolcsonzes);
            _logger.LogInformation("Kölcsönzés hozzáadva");
        }

        public List<Kolcsonzes> GetAllKolcsonzes()
        {
            return _kolcsonzesek;
        }

        public Kolcsonzes GetKolcsonzes(int olvasoSzam, int leltariSzam)
        {
            return _kolcsonzesek.Find(k => k.OlvasoSzam == olvasoSzam && k.LeltariSzam == leltariSzam);
        }

        public void Update(Kolcsonzes kolcsonzes)
        {
            var oldKolcsonzes = GetKolcsonzes(kolcsonzes.OlvasoSzam, kolcsonzes.LeltariSzam);

            oldKolcsonzes.OlvasoSzam = kolcsonzes.OlvasoSzam;
            oldKolcsonzes.LeltariSzam = kolcsonzes.LeltariSzam;
            oldKolcsonzes.KolcsonzesIdeje = kolcsonzes.KolcsonzesIdeje;
            oldKolcsonzes.VisszahozasHatarido = kolcsonzes.VisszahozasHatarido;
            
            _logger.LogInformation("Kölcsönzés frissítve");
        }

        public void Delete(int olvasoSzam, int leltariSzam)
        {
            _kolcsonzesek.RemoveAll(k => k.OlvasoSzam == olvasoSzam && k.LeltariSzam == leltariSzam);
            _logger.LogInformation("Kölcsönzés törölve");
        }
    }
}
