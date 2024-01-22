using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MICALCU.ModeloVista
{
    public class Mcalcu : BaseViewModel
    {
        private string _entradaActual = "";
        private string _operadorActual = "";
        private double _primerNumero = 0.0;
        private bool _seEstaIngresandoNumero = false;

        public ICommand NumeroCommand { get; private set; }
        public ICommand OperadorCommand { get; private set; }
        public ICommand IgualCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }
        public ICommand DecimalCommand { get; private set; }
        public ICommand EliminarCommand { get; private set; }

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
