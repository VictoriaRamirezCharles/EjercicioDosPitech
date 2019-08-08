using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjercicioDos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
           
        }

        private void BotonUno_Clicked(object sender, EventArgs e)
        {
            var suma1 = Convert.ToInt32(lblNumeroUno.Text);
            var suma2 = Convert.ToInt32(lblNumeroDos.Text);
            var numero = Convert.ToUInt32(botonUno.Text);
            var sumatoria = suma1 + suma2;
            if (numero != sumatoria)
            {
                DisplayAlert("Suma", "Respuesta Incorrecta", "Aceptar");
            }
            else
            {
                DisplayAlert("Suma", "Correcto", "Aceptar");
                generaradorEjercicios();
            }
        }

        private void BotonDos_Clicked(object sender, EventArgs e)
        {
            var suma1 = Convert.ToInt32(lblNumeroUno.Text);
            var suma2 = Convert.ToInt32(lblNumeroDos.Text);
            var numero = Convert.ToUInt32(botonDos.Text);
            var sumatoria = suma1 + suma2;
            if (numero != sumatoria)
            {
                DisplayAlert("Suma", "Respuesta Incorrecta", "Aceptar");
            }
            else
            {
                DisplayAlert("Suma", "Correcto", "Aceptar");
                generaradorEjercicios();
            }
        }

        private void BotonTres_Clicked(object sender, EventArgs e)
        {
            var suma1 = Convert.ToInt32(lblNumeroUno.Text);
            var suma2 = Convert.ToInt32(lblNumeroDos.Text);
            var numero = Convert.ToUInt32(botonTres.Text);
            var sumatoria = suma1 + suma2;
            if (numero != sumatoria)
            {
                DisplayAlert("Suma", "Respuesta Incorrecta", "Aceptar");
            }
            else
            {
                DisplayAlert("Suma", "Correcto", "Aceptar");
                generaradorEjercicios();
            }
        }

        private void BotonCuatro_Clicked(object sender, EventArgs e)
        {
            var suma1 = Convert.ToInt32(lblNumeroUno.Text);
            var suma2 = Convert.ToInt32(lblNumeroDos.Text);
            var numero = Convert.ToUInt32(botonCuatro.Text);
            var sumatoria = suma1 + suma2;
            if (numero != sumatoria)
            {
                DisplayAlert("Suma", "Respuesta Incorrecta", "Aceptar");
            }
            else
            {
                DisplayAlert("Suma", "Correcto", "Aceptar");
                generaradorEjercicios();
            }
        }
         public void generaradorEjercicios()
        {
            Random ramdom = new Random();

            int suma1 = ramdom.Next(10000, 99999);
            int suma2 = ramdom.Next(10000, 99999);
            int opcion2 = ramdom.Next(10000, 99999);
            int opcion3 = ramdom.Next(10000, 99999);
            int opcion4 = ramdom.Next(10000, 99999);

            int resul = suma1 + suma2;
            Ejercicio ejercicio = new Ejercicio
            {
                Instruction = "Selecciona el resultado de la siguiente suma.",
                Problem = new[] { suma1, suma2 },
                Options = new[] { resul, opcion2, opcion3, opcion4 },
                Result = resul
            };

            string json = JsonConvert.SerializeObject(ejercicio);

            var filename = Path.Combine("/sdcard", "ejercicio.json");
            using (var file = new StreamWriter(File.Create(filename)))
            {

                file.WriteLine(json);

            }
            Console.WriteLine(json);
            consumiendoJsonLocal(json);

            
       

        }

        public void consumiendoJsonLocal(string json)
        {
            Ejercicio ej = JsonConvert.DeserializeObject<Ejercicio>(json);
            lblNumeroUno.Text = ej.Problem[0].ToString();
            lblNumeroDos.Text = ej.Problem[1].ToString();
            botonUno.Text = ej.Options[0].ToString();
            botonDos.Text = ej.Options[1].ToString();
            botonTres.Text = ej.Options[2].ToString();
           // botonCuatro.Text = ej.Options[3].ToString();

            if (ej.Problem[0] % 10 == 2 || ej.Problem[0] % 10 == 4 || ej.Problem[0] % 10 == 6 || ej.Problem[0] % 10 == 8)
            {
                int resul = ej.Result;
                botonCuatro.Text = Convert.ToString(resul);
                botonUno.Text = ej.Options[3].ToString();
            }
            else
            {
                int resul = ej.Result;
                botonUno.Text = Convert.ToString(resul);
                botonCuatro.Text = ej.Options[3].ToString();
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            generaradorEjercicios();

        }
    }

}
