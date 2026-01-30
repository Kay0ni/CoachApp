using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NanMoiJeSuisCoach.Modele
{
    [Serializable]
    internal class Profil
    {
        private string sexe;
        private double poids;
        private double taille;
        private int age;
        private double img;
        private string msg;

        public Profil(string sexe, double poids, double taille, int age)
        {
            this.sexe = sexe;
            this.poids = poids;
            this.taille = taille;
            this.age = age;
            this.img = this.CalculerIMG();
            this.msg = this.GenererMessage();
        }

        public double Poids
        {
            get { return this.poids;  }
            set { this.poids = value; }
        }

        public string Sexe
        {
            get { return this.sexe; }
            set { this.sexe = value; }
        }

        public double Taille
        {
            get { return this.taille; }
            set { this.taille = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Message
        {
            get { return this.msg; }
        }

        public double IMG
        {
            get { return  this.img; }
            set { this.img = value; }
        }

        public string GetResult()
        {
            return this.msg;
        }

        private string GenererMessage() {
            string msg = "";
            double sexeFactor = (this.sexe == "Homme") ? 10 : 0;
            if (this.img < 25-sexeFactor) {
                msg = "Trop maigre";
            }
            else if (this.img >= 25 - sexeFactor && this.img < 30 - sexeFactor)
            {
                msg = "Parfait";
            }
            else if (this.img >= 30 - sexeFactor)
            {
                msg = "Absolute GRAGAS";
            }
            return msg;
        }

        private double CalculerIMG()
        {
            return (1.2 * this.poids / Math.Pow(this.taille/100, 2)) + (0.23 * this.age) - (10.83 * (this.sexe == "Homme" ? 1 : 0)) - 5.4;
        }
    }
}
