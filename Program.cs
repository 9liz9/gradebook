using System;
using System.Collections.Generic;

namespace gradebook
{
    public class Program
    {
        private static List<Student> eleves = new List<Student>();
        private static List<Course> cours = new List<Course>();

        

        public static void Main(string[] args)
        {
     
            bool quitter = false;

            
            while (!quitter)
            {

                AfficherMenuPrincipal();
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        GestionMenuEleves();
                        break;
                    case "2":
                        GestionMenuCours();
                        break;
                    case "q":
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

            }
        }

        private static void AfficherLogo()
        {
            string logo = @"
   _____               _        ____              _    
  / ____|             | |      |  _ \            | |   
 | |  __ _ __ __ _  __| | ___  | |_) | ___   ___ | | __
 | | |_ | '__/ _` |/ _` |/ _ \ |  _ < / _ \ / _ \| |/ /
 | |__| | | | (_| | (_| |  __/ | |_) | (_) | (_) |   < 
  \_____|_|  \__,_|\__,_|\___| |____/ \___/ \___/|_|\_\
                                                       
                                                       
";
            Console.WriteLine(logo);
        }

        private static void AfficherMenuPrincipal()
        {
            AfficherLogo();
            Console.WriteLine($"{Environment.NewLine} === Menu Principal === {Environment.NewLine}");
            Console.WriteLine("1. Élèves");
            Console.WriteLine("2. Cours");
            Console.WriteLine("q. Quitter");
            Console.Write("Veuillez choisir une option : ");

        }

        private static void GestionMenuEleves()
        {
            bool retourMenuPrincipal = false;
            while (!retourMenuPrincipal)
            {
                Console.WriteLine($"{Environment.NewLine} === Menu Élèves === {Environment.NewLine}");

                Console.WriteLine("1. Lister les élèves");
                Console.WriteLine("2. Créer un nouvel élève");
                Console.WriteLine("3. Consulter un élève existant");
                Console.WriteLine("4. Ajouter une note et une appréciation pour un cours sur un élève existant");
                Console.WriteLine("5. Revenir au menu principal");
                Console.Write("Veuillez choisir une option : ");
                string choix = Console.ReadLine();
                Console.Clear();

                switch (choix)
                {
                    case "1":
                        AfficherEleves();
                        break;
                    case "2":
                        CreerEleve();
                        break;
                    case "3":
                        ConsulterEleve();
                        break;
                    case "4":
                        AjouterNoteAppreciation();
                        break;
                    case "5":
                        retourMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

              
            }
        }

        private static void AfficherEleves()
        {
            Console.WriteLine($"=== Liste des élèves === {Environment.NewLine}");
            if (eleves.Count == 0)
            {
                Console.WriteLine("Aucun élève enregistré.");
            }
            else
            {
                foreach (var eleve in eleves)
                {
                    Console.WriteLine($"ID: {eleve.Id} - Nom: {eleve.Nom} {eleve.Prenom} - Moyenne: {eleve.Moyenne}");
                }
            }
        }

        private static void CreerEleve()
        {
            Console.WriteLine($"=== Création d'un nouvel élève === {Environment.NewLine}");
            Student nouvelEleve = new Student();

            Console.Write("ID : ");
            nouvelEleve.Id = int.Parse(Console.ReadLine());

            Console.Write("Nom : ");
            nouvelEleve.Nom = Console.ReadLine();

            Console.Write("Prénom : ");
            nouvelEleve.Prenom = Console.ReadLine();

            Console.Write("Date de naissance (format jj/mm/aaaa) : ");
            nouvelEleve.DateDeNaissance = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            nouvelEleve.NotesAppreciations = new Dictionary<int, Tuple<double, string>>();

            eleves.Add(nouvelEleve);
            Console.WriteLine("Nouvel élève créé avec succès.");
        }

        private static void ConsulterEleve()
        {
            Console.WriteLine($"=== Consultation d'un élève === {Environment.NewLine}");
            Console.Write("ID de l'élève : ");
            int idEleve = int.Parse(Console.ReadLine());

            Student eleve = eleves.Find(e => e.Id == idEleve);
            if (eleve == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet ID.");
            }
            else
            {
                Console.WriteLine($"ID: {eleve.Id} - Nom: {eleve.Nom} {eleve.Prenom} - Date de naissance: {eleve.DateDeNaissance}");
                Console.WriteLine("=== Notes et appréciations ===");
                if (eleve.NotesAppreciations.Count == 0)
                {
                    Console.WriteLine("Aucune note et appréciation enregistrées.");
                }
                else
                {
                    foreach (var keyValuePair in eleve.NotesAppreciations)
                    {
                        int idCours = keyValuePair.Key;
                        double note = keyValuePair.Value.Item1;
                        string appreciation = keyValuePair.Value.Item2;
                        Console.WriteLine($"Cours: {cours.Find(c => c.Id == idCours).Nom} - Note: {note} - Appréciation: {appreciation}");
                    }
                }
            }
        }

        private static void AjouterNoteAppreciation()
        {
            Console.WriteLine("=== Ajout d'une note et d'une appréciation ===");
            Console.Write("ID de l'élève : ");
            int idEleve = int.Parse(Console.ReadLine());

            Student eleve = eleves.Find(e => e.Id == idEleve);
            if (eleve == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet ID.");
            }
            else
            {
                Console.Write("ID du cours : ");
                int idCours = int.Parse(Console.ReadLine());

                Course coursSelectionne = cours.Find(c => c.Id == idCours);
                if (coursSelectionne == null)
                {
                    Console.WriteLine("Aucun cours trouvé avec cet ID.");
                }
                else
                {
                    Console.Write("Note : ");
                    double note = double.Parse(Console.ReadLine());

                    Console.Write("Appréciation : ");
                    string appreciation = Console.ReadLine();

                    eleve.NotesAppreciations[idCours] = Tuple.Create(note, appreciation);
                    Console.WriteLine("Note et appréciation ajoutées avec succès.");
                }
            }
        }

        private static void GestionMenuCours()
        {
            bool retourMenuPrincipal = false;
            while (!retourMenuPrincipal)
            {
           
                Console.WriteLine($"{Environment.NewLine} === Menu Cours === {Environment.NewLine}");
                Console.WriteLine("1. Lister les cours");
                Console.WriteLine("2. Ajouter un nouveau cours");
                Console.WriteLine("3. Supprimer un cours");
                Console.WriteLine("4. Revenir au menu principal");
                Console.Write("Veuillez choisir une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AfficherCours();
                        break;
                    case "2":
                        AjouterCours();
                        break;
                    case "3":
                        SupprimerCours();
                        break;
                    case "4":
                        retourMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
                
            }
        }

        private static void AfficherCours()
        {
            Console.WriteLine("=== Liste des cours ===");
            if (cours.Count == 0)
            {
                Console.WriteLine("Aucun cours enregistré.");
            }
            else
            {
                foreach (var cours in cours)
                {
                    Console.WriteLine($"ID: {cours.Id} - Nom: {cours.Nom}");
                }
            }
        }

        private static void AjouterCours()
        {
            Console.WriteLine("=== Ajout d'un nouveau cours ===");
            Course nouveauCours = new Course();

            Console.Write("ID : ");
            nouveauCours.Id = int.Parse(Console.ReadLine());

            Console.Write("Nom : ");
            nouveauCours.Nom = Console.ReadLine();

            cours.Add(nouveauCours);
            Console.WriteLine("Nouveau cours ajouté avec succès.");
        }

        private static void SupprimerCours()
        {
            Console.WriteLine("=== Suppression d'un cours ===");
            Console.Write("ID du cours à supprimer : ");
            int idCours = int.Parse(Console.ReadLine());

            Course coursASupprimer = cours.Find(c => c.Id == idCours);
            if (coursASupprimer == null)
            {
                Console.WriteLine("Aucun cours trouvé avec cet ID.");
            }
            else
            {
                Console.WriteLine($"Êtes-vous sûr de vouloir supprimer le cours {coursASupprimer.Nom} ? (O/N)");
                string confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "o")
                {
                    cours.Remove(coursASupprimer);
                    SupprimerNotesAppreciationsCours(idCours);
                    Console.WriteLine("Cours supprimé avec succès.");
                }
            }
        }

        private static void SupprimerNotesAppreciationsCours(int idCours)
        {
            foreach (var eleve in eleves)
            {
                eleve.NotesAppreciations.Remove(idCours);
            }
        }
    }
}
