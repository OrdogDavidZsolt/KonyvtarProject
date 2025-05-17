using KonyvtarAPI.KonyvtarShared;

namespace KonyvtarAPI
{
    public class OlvasokService : IOlvasokCRUD
    {
        private readonly List<Olvasok> _olvasok;
        private readonly ILogger<OlvasokService> _logger;

        public OlvasokService(ILogger<OlvasokService> logger)
        {
            _olvasok = new List<Olvasok>();
            _logger = logger;
        }

        public void Add(Olvasok olvaso)
        {
            _olvasok.Add(olvaso);
            _logger.LogInformation("Olvasó hozzáadva");
        }

        public List<Olvasok> GetAllOlvasok()
        {
            return _olvasok;
        }

        public Olvasok GetOlvaso(int olvasoSzam)
        {
            return _olvasok.Find(o => o.OlvasoSzam == olvasoSzam);
        }

        public void Update(Olvasok olvaso)
        {
            var oldOlvaso = GetOlvaso(olvaso.OlvasoSzam);

            oldOlvaso.OlvasoSzam = olvaso.OlvasoSzam;
            oldOlvaso.OlvasoNev = olvaso.OlvasoNev;
            oldOlvaso.Lakcim = olvaso.Lakcim;
            oldOlvaso.SzuletesiDatum = olvaso.SzuletesiDatum;

            _logger.LogInformation("Olvasó frissítve");
        }

        public void Delete(int olvasoSzam)
        {
            _olvasok.RemoveAll(o => o.OlvasoSzam == olvasoSzam);
            _logger.LogInformation("Olvasó törölve");
        }
    }
}
