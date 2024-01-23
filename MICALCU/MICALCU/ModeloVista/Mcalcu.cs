using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MICALCU.ModeloVista
{
    public class Mcalcu : BaseViewModel
    {
        private string _entradaActual = "0";
        private string _operadorActual = "";
        private double _primerNumero = 0.0;
        private bool _seEstaIngresandoNumero = false;

        public ICommand NumeroCommand { get; private set; }
        public ICommand OperadorCommand { get; private set; }
        public ICommand IgualCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }
        public ICommand DecimalCommand { get; private set; }
        public ICommand EliminarCommand { get; private set; }

        public ICommand CCommand { get; private set; }
        public ICommand DividirCommand { get; private set; }
        public ICommand PorCommand { get; private set; }
        public ICommand MasCommand { get; private set; }
        public ICommand SieteCommand { get; private set; }
        public ICommand OchoCommand { get; private set; }
        public ICommand NueveCommand { get; private set; }
        public ICommand MenosCommand { get; private set; }
        public ICommand CuatroCommand { get; private set; }
        public ICommand CincoCommand { get; private set; }
        public ICommand SeisCommand { get; private set; }
        public ICommand MultiCommand { get; private set; }
        public ICommand UnoCommand { get; private set; }
        public ICommand DosCommand { get; private set; }
        public ICommand TresCommand { get; private set; }
        public ICommand CeroCommand { get; private set; }
        public ICommand PuntoCommand { get; private set; }

        public string EntradaActual
        {
            get { return _entradaActual; }
            set { SetValue(ref _entradaActual, value); }
        }

        public string OperadorActual
        {
            get { return _operadorActual; }
            set { SetValue(ref _operadorActual, value); }
        }

        public double PrimerNumero
        {
            get { return _primerNumero; }
            set { SetValue(ref _primerNumero, value); }
        }

        public bool SeEstaIngresandoNumero
        {
            get { return _seEstaIngresandoNumero; }
            set { SetValue(ref _seEstaIngresandoNumero, value); }
        }

        public Mcalcu()
        {
            NumeroCommand = new Command<string>(EnBotonNumeroClickeado);
            OperadorCommand = new Command<string>(EnBotonOperadorClickeado);
            IgualCommand = new Command(EnBotonIgualClickeado);
            LimpiarCommand = new Command(EnBotonLimpiarClickeado);
            DecimalCommand = new Command(EnBotonDecimalClickeado);
            EliminarCommand = new Command(EnBotonEliminarClickeado);

            CCommand = new Command(EnBotonLimpiarClickeado);
            DividirCommand = new Command(() => EnBotonOperadorClickeado("/"));
            PorCommand = new Command(() => EnBotonOperadorClickeado("*"));
            MasCommand = new Command(() => EnBotonOperadorClickeado("+"));
            SieteCommand = new Command(() => EnBotonNumeroClickeado("7"));
            OchoCommand = new Command(() => EnBotonNumeroClickeado("8"));
            NueveCommand = new Command(() => EnBotonNumeroClickeado("9"));
            MenosCommand = new Command(() => EnBotonOperadorClickeado("-"));
            CuatroCommand = new Command(() => EnBotonNumeroClickeado("4"));
            CincoCommand = new Command(() => EnBotonNumeroClickeado("5"));
            SeisCommand = new Command(() => EnBotonNumeroClickeado("6"));
            MultiCommand = new Command(() => EnBotonOperadorClickeado("*"));
            UnoCommand = new Command(() => EnBotonNumeroClickeado("1"));
            DosCommand = new Command(() => EnBotonNumeroClickeado("2"));
            TresCommand = new Command(() => EnBotonNumeroClickeado("3"));
            CeroCommand = new Command(() => EnBotonNumeroClickeado("0"));
            PuntoCommand = new Command(EnBotonDecimalClickeado);
        }

        private void EnBotonNumeroClickeado(string presionado)
        {
            if (EntradaActual == "0" || !SeEstaIngresandoNumero)
            {
                EntradaActual = "";
                SeEstaIngresandoNumero = true;
            }

            EntradaActual += presionado;
        }

        private void EnBotonOperadorClickeado(string operadorPresionado)
        {
            if (SeEstaIngresandoNumero)
            {
                if (OperadorActual != "")
                {
                    double segundoNumero = double.Parse(EntradaActual);
                    EntradaActual = Calcular(PrimerNumero, segundoNumero, OperadorActual).ToString();
                }
                else
                {
                    PrimerNumero = double.Parse(EntradaActual);
                }

                OperadorActual = operadorPresionado;
                SeEstaIngresandoNumero = false;
            }
        }

        private void EnBotonIgualClickeado()
        {
            if (SeEstaIngresandoNumero)
            {
                double segundoNumero = double.Parse(EntradaActual);
                EntradaActual = Calcular(PrimerNumero, segundoNumero, OperadorActual).ToString();
                OperadorActual = "";
                SeEstaIngresandoNumero = false;
            }
        }

        private void EnBotonLimpiarClickeado()
        {
            EntradaActual = "0";
            OperadorActual = "";
            PrimerNumero = 0.0;
            SeEstaIngresandoNumero = false;
        }

        private void EnBotonDecimalClickeado()
        {
            if (!EntradaActual.Contains("."))
            {
                EntradaActual += ".";
            }
        }

        private void EnBotonEliminarClickeado()
        {
            if (EntradaActual.Length > 0)
            {
                EntradaActual = EntradaActual.Substring(0, EntradaActual.Length - 1);
            }
        }

        private double Calcular(double primerNumero, double segundoNumero, string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return primerNumero + segundoNumero;
                case "-":
                    return primerNumero - segundoNumero;
                case "*":
                    return primerNumero * segundoNumero;
                case "/":
                    if (segundoNumero != 0)
                    {
                        return primerNumero / segundoNumero;
                    }
                    else
                    {
                        EntradaActual = "Error";
                        return 0;
                    }
                default:
                    return 0;
            }
        }
    }
}
