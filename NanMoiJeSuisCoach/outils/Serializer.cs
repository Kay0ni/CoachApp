using NanMoiJeSuisCoach.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoachV1.outils
{
    abstract class Serializer
    {
        public static void serialize(string filename, Profil profil)
        {
            string fichier = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename);

            if (File.Exists(fichier))
            {
                File.Delete(fichier);
            }
            try
            {
                string jsonString = JsonSerializer.Serialize(profil);

                File.WriteAllText(fichier, jsonString);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Erreur d'écriture : " + e.Message);
            }
        }

        public static Profil deserialize(string filename) {
            Profil profil = null;

            string fichier = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename);

            if (File.Exists(fichier)) { 
                try
                {
                    string jsonString = File.ReadAllText(fichier);

                    profil = JsonSerializer.Deserialize<Profil>(jsonString);
                } catch
                {
                    
                }
            }
            return profil;
        }
    }
}
