using System;
using System.Collections.Generic;

namespace gradebook

{
    public class Student

    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public Dictionary<int, Tuple<double, string>> NotesAppreciations { get; set; } // Identifiant du cours -> (note, appréciation)

        public double Moyenne
        {
            get
            {
                if (NotesAppreciations.Count == 0)
                    return 0;

                double sommeNotes = 0;
                foreach (var tuple in NotesAppreciations.Values)
                {
                    sommeNotes += tuple.Item1;
                }
                return sommeNotes / NotesAppreciations.Count;
            }
        }

        internal void AjouterAppreciationCours(int idCours, string? appreciation)
        {
            throw new NotImplementedException();
        }

        internal void AjouterNoteCours(int idCours, float note)
        {
            throw new NotImplementedException();
        }
    }
}