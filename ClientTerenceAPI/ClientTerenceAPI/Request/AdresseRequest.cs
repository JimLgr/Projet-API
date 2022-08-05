using ClientMrTerenceAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTerenceAPI.Request
{
    public class AdresseRequest
    {
        public static void GetOneAdresse(string pAdresse)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response
                    = client.GetAsync($"https://localhost:7272/api/Adresse/{pAdresse}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Adresse? adresse
                        = JsonConvert.DeserializeObject<Adresse>(json);
                    if (adresse != null)
                    {
                        Console.WriteLine($" AdresseId : {adresse.AdresseId} \n" +
                            $" Numéro : {adresse.Numero} \n" +
                            $" Rue : {adresse.Rue} \n" +
                            $" Ville : {adresse.Ville} \n" +
                            $" Code postale : {adresse.CodePostale} \n" +
                            $" Pays : {adresse.Pays}");
                    }
                }
            }
        }


    }
}
