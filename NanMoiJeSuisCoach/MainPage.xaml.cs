// using AuthenticationServices;
using CoachV1.outils;
using NanMoiJeSuisCoach.Modele;

namespace NanMoiJeSuisCoach
{
    public partial class MainPage : ContentPage
    {
        private readonly string nomFichier = "saveprofil";
        public MainPage()
        {
            InitializeComponent();
        }

        public void getProfil()
        {
            try
            {
                Profil profil = Serializer.deserialize(nomFichier);

            }
            catch
            {
                DisplayAlert("Erreur", "Impossible de charger le profil", "Ok");
            }
        }

            public void btCalculer_Clicked(object sender, EventArgs e)
        {
            try
            {
                string sex = radioHomme.IsChecked ? "Homme" : "Femme";
                double weight = double.Parse(entPoids.Text);
                double height = double.Parse(entCM.Text);
                int age = int.Parse(entAge.Text);

                Profil profil = new Profil(sex, weight, height, age);

                string result = profil.GetResult();
                double img = profil.IMG;
                if (result == "Parfait") {
                    reaction.Source = "resources/img/normal.jpg";
                } else if (result == "Absolute GRAGAS")
                {
                    reaction.Source = "resources/img/fat.png";
                } else if (result == "Trop maigre")
                {
                    reaction.Source = "resources/img/skinny.png";
                }
                lblResult.Text = "IMG : " + Math.Round(img) + "%. " + result;
            } catch
            {
                DisplayAlert("Erreur", "Saisie incorrects", "Ok");
            }
        }

    }

}
