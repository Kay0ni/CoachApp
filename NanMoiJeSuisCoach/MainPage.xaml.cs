// using AuthenticationServices;
using CoachV1.outils;
using NanMoiJeSuisCoach.Modele;

namespace NanMoiJeSuisCoach
{
    public partial class MainPage : ContentPage
    {
        private Profil profil = null;
        private readonly SQLiteDb database = null;

        public MainPage()
        {
            InitializeComponent();
            database = new SQLiteDb();
            SqliteSelect();
        }

        private async void SqliteSelect()
        {
            profil = await database.GetLastItemAsync();

            if (profil != null)
            {
                if (profil.Sexe == "Homme")
                {
                    radioHomme.IsChecked = true;
                } else
                {
                    radioFemme.IsChecked = true;
                }
                entPoids.Text = profil.Poids.ToString();
                entCM.Text = profil.Taille.ToString();
                entAge.Text = profil.Age.ToString();

            }

            showProfil();
        }

        private async void SqliteInsert(Profil profil)
        {
            int id = await database.SaveItemAsync(profil);
        }

        public void showProfil()
        {
            if (profil != null)
            {
                string result = profil.GetResult();
                double img = profil.IMG;
                if (result == "Parfait")
                {
                    reaction.Source = "resources/img/normal.jpg";
                }
                else if (result == "Absolute GRAGAS")
                {
                    reaction.Source = "resources/img/fat.png";
                }
                else if (result == "Trop maigre")
                {
                    reaction.Source = "resources/img/skinny.png";
                }
                lblResult.Text = "IMG : " + Math.Round(img) + "%. " + result;
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
                DateTimeOffset date = DateTimeOffset.Now;

                profil = new Profil(null, sex, weight, height, age, date); 

                SqliteInsert(profil);

                showProfil();
            } catch
            {
                DisplayAlert("Erreur", "Saisie incorrects", "Ok");
            }
        }
    }

}
