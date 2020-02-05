using AutoShop_Shared.Models;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace AutoShop_Shared.Services
{
    public class JsonFileRepository<T> : IRepository<T>
    {
        public T GetItem(string id, string partitionKey)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Retourne des items venant d'un fichier JSON
        /// </summary>
        /// <param name="filepath">Chemin du fichier JSON</param>
        /// <returns>List du Type généric T</returns>
        public List<T> GetItems(AppSettings settings)
        {
            string result = "";
            if (typeof(T) == typeof(Badge))
            {
                result = System.IO.File.ReadAllText(settings.FilePath + settings.BadgesFileName);
            }
            if(typeof(T) == typeof(User))
            {
                result = System.IO.File.ReadAllText(settings.FilePath + settings.UsersFileName);
            }

            //Transformer le contenu en Objet c# => Desérialiser
            List<T> items = JsonConvert.DeserializeObject<List<T>>(result);

            //Retourner le résultat
            return items;
        }
    }
}
