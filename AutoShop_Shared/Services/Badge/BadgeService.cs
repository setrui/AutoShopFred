using AutoShop_Shared.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;


namespace AutoShop_Shared.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly IRepository<Badge> _repository;
        private readonly AppSettings _settings;

        //Constructeur avec l'injection de la dépendance en paramètre
        public BadgeService(IRepository<Badge> repo, IOptionsMonitor<AppSettings> s)
        {
            //Ma variable privée = l'instance de l'injection de dépendance
            _repository = repo;
            _settings = s.CurrentValue;          
           
        }

        public Badge GetBadge(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Badge> GetBadges()
        {
            _settings.QuerySelect = "SELECT * FROM c ";
            _settings.QueryWhere = "WHERE c.partitionKey = 'Badges' ";
            List<Badge> badges = _repository.
                GetItems(_settings);

            return badges;
        }

    }
}
