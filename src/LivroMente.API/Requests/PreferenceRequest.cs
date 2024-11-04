using LivroMente.Domain.Models.PreferenceModel;

namespace LivroMente.API.Requests
{
    public class PreferenceRequest
    {
        public List<PrefenceItem> Items { get; set; } = new List<PrefenceItem>();  
        public List<PreferenceBackUrls> BackUrls { get; set;} = new List<PreferenceBackUrls>();
    }
}