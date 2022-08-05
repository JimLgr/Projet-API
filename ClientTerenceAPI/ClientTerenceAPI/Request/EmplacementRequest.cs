using ClientMrTerenceAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTerenceAPI.Request
{
    public class EmplacementRequest
    {
        public static void GetOneEmplacement(string pEmplacement)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response
                    = client.GetAsync($"https://localhost:7272/api/Emplacement/{pEmplacement}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Emplacement? emplacement
                        = JsonConvert.DeserializeObject<Emplacement>(json);
                    if (emplacement != null)
                    {
                        Console.WriteLine($" EmplacementId : {emplacement.EmplacementId} \n" +
                            $" Casier : {emplacement.Casier} \n" +
                            $" Etagère : {emplacement.Etagere} \n");
                    }
                }
            }
        }
    }
}
