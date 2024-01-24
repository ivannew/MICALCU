using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MICALCU.ModeloVista
{
    public class Mcalcu : BaseViewModel
    {

        #region VARIABLES
        private double _num1;
        private double _num2;
        private string _operador;
        private bool _borrar;
        private string _resultado;
        private string _operacion;
        private bool _sumas;
        private bool _divisions;
        private bool _multiplicacions;
        private bool _restas;
      
        public Mcalcu(INavigation navigation)
        {
            Navigation = navigation;
            borrartodo();
        }
       
        public bool Divisions
        {
            get { return _divisions; }
            set
            {
                if (_divisions != value)
                {
                    SetValue(ref _divisions, value);
                    OnPropertyChanged(nameof(Divisions));
                }
            }
        }

        public bool Multiplicacions
        {
            get { return _multiplicacions; }
            set
            {
                if (_multiplicacions != value)
                {
                    SetValue(ref _multiplicacions, value);
                    OnPropertyChanged(nameof(Multiplicacions));
                }
            }
        }

        public bool Restas
        {
            get { return _restas; }
            set
            {
                if (_restas != value)
                {
                    SetValue(ref _restas, value);
                    OnPropertyChanged(nameof(Restas));
                }
            }
        }

        public bool Sumas
        {
            get { return _sumas; }
            set
            {
                if (_sumas != value)
                {
                    SetValue(ref _sumas, value);
                    OnPropertyChanged(nameof(Sumas));
                }
            }
        }

        public double num1
        {
            get { return _num1; }
            set { SetValue(ref _num1, value); }
        }

        public double num2
        {
            get { return _num2; }
            set { SetValue(ref _num2, value); }
        }

        public string Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value); }
        }

        public string Operacions
        {
            get { return _operacion; }
            set { SetValue(ref _operacion, value); }
        }
        #endregion

        #region PROCESOS
        private void Numero(string numero)
        {
            if (_borrar)
            {

                Resultado = "0";
                _borrar = false;
            }

            if (!string.IsNullOrEmpty(_operacion) && "+-x/".Contains(_operacion.Last()))
            {
                _operacion += " ";
            }

            if (Resultado == "0" && numero != ".")
            {

                Resultado = numero;
            }
            else if (!Resultado.Contains(".") || numero != ".")
            {
                Resultado+= numero;
            }

            _operacion += numero;
        }

        private void Operacion(string operador)
        {
            if (!string.IsNullOrEmpty(Resultado))
            {
                if (!_borrar)
                {
                    Calcular();
                    num1 = double.Parse(Resultado);
                    Operacions = $"{num1} {_operador}";
                }

                _operador = operador;
                _borrar = true;
                _operacion = $"{num1} {_operador}";


                switch (operador)
                {
                    case "+":
                        Sumas = true;
                        break;
                    case "-":
                        Restas= true;
                        break;
                    case "x":
                        Multiplicacions = true;
                        break;
                    case "/":
                        Divisions = true;
                        break;
                }
            }
            else
            {
                Resultado = "Error";
            }
        }

        private void Igual()
        {
            Calcular();
            _operador = "";
            Sumas = false;
            Restas = false;
            Multiplicacions = false;
            Divisions = false;

        }

        private void borrartodo()
        {
            Resultado = "0";
            _operacion = "";
            num1 = 0;
            num2 = 0;
            _operador = "";
            Sumas = false;
            Restas= false;
            Multiplicacions= false;
            Divisions= false;
        }

        private void BorrarUnNumero()
        {
            if (Resultado.Length > 0)
            {
                Resultado = Resultado.Substring(0, Resultado.Length - 1);
            }

            if (string.IsNullOrEmpty(Resultado))
            {
                Resultado = "0";
            }
        }

        private void Calcular()
        {
            if (double.TryParse(Resultado, out double resultadoNumerico))
            {
                num2 = resultadoNumerico;


                Resultado = ecuacion(num1, num2, _operador).ToString();
                _borrar = false;
            }
            else
            {
                Resultado = "Error";
            }
        }

        private double ecuacion(double num1, double num2, string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "x":
                    return num1 * num2;
                case "/":
                    return num2 != 0 ? num1 / num2 : double.NaN;
                default:
                    return num2;
            }
        }


    
        public ICommand NumCommand => new Command<string>(Numero);
        public ICommand OperaminiCommand => new Command<string>(Operacion);
        public ICommand IgualCommand => new Command(Igual);
        public ICommand borrarCommand => new Command(borrartodo);
        public ICommand BorrarNumeroCommand => new Command(BorrarUnNumero);
        #endregion
    }
}
