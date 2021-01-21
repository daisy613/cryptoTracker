using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoTracker.Core.Database;
using CryptoTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Core.Repositories
{
    public static class ExchangeSettingsRepository
    {
        public static async Task SetSettings(ExchangeSettings settings)
        {
            await using var database = new DatabaseContext();

            bool exists = database.ExchangeSettings.Any(x => x.Exchange == settings.Exchange);
            if (exists)
                database.ExchangeSettings.Update(settings);
            else
                await database.ExchangeSettings.AddAsync(settings);

            await database.SaveChangesAsync();
        }

        public static async Task<ExchangeSettings> GetSettings(SupportedExchanges requestedExchange)
        {
            await using var database = new DatabaseContext();

            ExchangeSettings settings = await database.ExchangeSettings.FirstOrDefaultAsync(x => x.Exchange == requestedExchange);
            settings ??= new()
            {
                Exchange = requestedExchange
            };

            return settings;
        }
    }
}
