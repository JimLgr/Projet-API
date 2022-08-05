using ClientMrTerenceAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTerenceAPI.Request
{
    public class BouteilleRequest
    {
        public static void GetOneBouteille(string pBouteille)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response
                    = client.GetAsync($"https://localhost:7272/api/Bouteille/{pBouteille}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Bouteille? bouteille
                        = JsonConvert.DeserializeObject<Bouteille>(json);
                    if (bouteille != null)
                    {
                        Console.WriteLine($" BouteilleId : {bouteille.bouteilleId} \n" +
                            $" Label : {bouteille.label} \n" +
                            $" Origine : {bouteille.origine} \n" +
                            $" Année de mise en bouteille : {bouteille.anneeDeMiseEnBouteille} \n" +
                            $" Type de vin : {bouteille.type} \n" +
                            $" Degree : {bouteille.degreeAlcool} \n" +
                            $" Volume : {bouteille.volume} \n" +
                            $" Marque : {bouteille.marque} \n" +
                            $" En Stock : {bouteille.stock} \n" +
                            $" Review : {bouteille.review} \n"
                            );
                    }
                }
            }
        }
    }
}
