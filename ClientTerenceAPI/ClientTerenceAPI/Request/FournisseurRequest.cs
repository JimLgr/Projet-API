using ClientMrTerenceAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTerenceAPI.Request
{
    public class FournisseurRequest
    {
        public static void GetOneFournisseur(string pFournisseur)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response
                    = client.GetAsync($"https://localhost:7272/api/Fournisseur/{pFournisseur}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Fournisseur? fournisseur
                        = JsonConvert.DeserializeObject<Fournisseur>(json);
                    if (fournisseur != null)
                    {
                        Console.WriteLine($" FournisseurId : {fournisseur.fournisseurId} \n" +
                            $" Nom : {fournisseur.nom} \n" +
                            $" Prenom : {fournisseur.prenom} \n" +
                            $" Phone : {fournisseur.phone} \n" +
                            $" Email : {fournisseur.email} \n" +
                            $" Website : {fournisseur.website} \n" +
                            $" Fax : {fournisseur.fax} \n"
                            );
                    }
                }
            }
        }

    }
}
