using ClientMrTerenceAPI.Entities;
using Newtonsoft.Json;
using System.Linq;
using ClientTerenceAPI.Request;
int inputString;

do
{
    
    Console.WriteLine("Taper '1' pour Bouteille");
    Console.WriteLine("Taper '2' pour Fournisseur");
    Console.WriteLine("Taper '3' pour Adresse");
    Console.WriteLine("Taper '4' pour Emplacement");
    Console.WriteLine("Taper 'q' pour quitter");
    string? choix = Console.ReadLine();
    if (choix == null && choix != "1" && choix != "2" && choix != "3" && choix != "4" && choix != "q")
    {
        Console.WriteLine("Veuillez taper un des chiffres indiqué dans la liste ou quitter");
    }
    switch
    (choix)
    {
        case "1":
            Console.WriteLine("\n");
            Console.WriteLine("Taper l'id d'une bouteille");
            bool tryparse = int.TryParse(Console.ReadLine(), out inputString);
            if (inputString < 0 || inputString > 1000 || tryparse == false)
            {
                Console.WriteLine("Veuillez taper un ID valide");
                break;
            }
            BouteilleRequest.GetOneBouteille(Console.ReadLine());
            break;

        case "2":
            Console.WriteLine("\n");
            Console.WriteLine("Taper l'id d'un fournisseur");
            tryparse = int.TryParse(Console.ReadLine(), out inputString);
            if (inputString < 0 || inputString > 1000 || tryparse == false)
            {
                Console.WriteLine("Veuillez taper un ID valide");
                break;
            }
            FournisseurRequest.GetOneFournisseur(Console.ReadLine());
            break;

        case "3":
            Console.WriteLine("\n");
            Console.WriteLine("Taper l'id d'une adresse");
            tryparse = int.TryParse(Console.ReadLine(), out inputString);
            if (inputString < 0 || inputString > 1000 || tryparse == false)
            {
                Console.WriteLine("Veuillez taper un ID valide");
                break;
            }
            AdresseRequest.GetOneAdresse(Console.ReadLine());
            break;

        case "4":
            Console.WriteLine("\n");
            Console.WriteLine("Taper l'id d'un emplacement");
            tryparse = int.TryParse(Console.ReadLine(), out inputString);
            if (inputString < 0 || inputString > 1000 || tryparse == false)
            {
                Console.WriteLine("Veuillez taper un ID valide");
                break;
            }
            EmplacementRequest.GetOneEmplacement(Console.ReadLine());
            break;

        case "q":
            Environment.Exit(0);
            break;

        default:
            break;
    };
} while (true);


