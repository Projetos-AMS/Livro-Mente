using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LivroMente.Domain.Models.PreferenceModel
{
    public class PrefenceItem
    {
         [JsonPropertyName("title")]
        public string Title {get;set;}
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("unitprice")]
        public int UnitPrice { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        public string CurrencyId { get; set; }
    }
}