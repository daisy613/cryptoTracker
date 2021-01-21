using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.Core.Models
{
    public class ExchangeSettings
    {
        [Key]
        public SupportedExchanges Exchange { get; set; }

        public string Key { get; set; }

        public string Secret { get; set; }
    }
}
