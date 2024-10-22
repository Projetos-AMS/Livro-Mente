using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Models.PreferenceModel;

namespace LivroMente.Domain.Requests
{
    public class PreferenceRequest
    {
        public List<PrefenceItem> Items { get; set; } = new List<PrefenceItem>();  
        public List<PreferenceBackUrls> BackUrls { get; set;} = new List<PreferenceBackUrls>();
    }
}