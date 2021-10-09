  using System;
using trabalho3_Investimento;

namespace trabalho3_Investimento
{
    class Investimento : IInvestimento
    {
        private string _nome;
        private double _capital_inicial;
        private double _montante;
        private double _juros;
        private double _periodo;
        private bool _ehComposto;    // se não é simples
        private bool _ehAno;         // se não é mes

        public string Nome
        {
            get => _nome;
            set
            {
                if(value is string)
                {
                    _nome = value;
                }
            }
        }
        public double Capital_inicial
        {
            get => _capital_inicial;
            set
            {
                _capital_inicial = value;
                CalcMontante();
            }
        }

        public double Juros
        {
            get => _juros;
            set
            {
                _juros = value;
            }
        }
        public double Periodo
        {
            get => _periodo;
            set
            {
                _periodo = value;
                CalcMontante();
            }
        }
        public Investimento(bool ehAno, bool ehComposto)
        {
            _capital_inicial = 0;
            _montante = 0;
            _juros = 0;
            _periodo = 0;
            _ehAno = ehAno;
            _ehComposto = ehComposto;
        }
        public Investimento(string nome, double capital_inicial, double juros, double periodo, bool ehAno, bool ehComposto)
        {
            _nome = nome;
            _ehAno = ehAno;
            _ehComposto = ehComposto;
            _capital_inicial = capital_inicial;
            _juros = juros;
            _periodo = periodo;
            CalcMontante();
        }
        public void CalcMontante()
        {
            if (_ehComposto)
            {
                _montante = _capital_inicial * Math.Pow(1 + _juros, _periodo);
            }
            else
            {
                _montante = _capital_inicial * (1 + _juros) * _periodo;

            }
        }
        public void ConverteEscalaTempo()
        {
            if (_ehAno)
            {
                if (_ehComposto)
                {
                    _juros = Math.Pow(1 + _juros, 1.0d/12.0d) - 1;
                }
                else
                {
                    _juros /= 12.0d;
                }
                _periodo *= 12;

                _ehAno = false;
            }
            else
            {
                if (_ehComposto)
                {
                    _juros = Math.Pow(1 + _juros, 12.0d) - 1;
                }
                else
                {
                    _juros *= 12;
                }
                _periodo /= 12;

                _ehAno = true;
            }
        }
        public static Investimento ComparaInvestimento(Investimento a, Investimento b)
        {
            if((a._ehComposto != b._ehComposto) || (a._ehAno != b._ehAno))
            {
                Console.WriteLine("Investimentos de tipos diferentes não podem ser comparados!");
                return null;
            }
            if(a._montante > b._montante)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public static void PrintaInvestimento(Investimento a)
        {
            Console.WriteLine("Nome do investimento:\t{0}", a._nome);
            Console.Write("Tipo:\t");
            if (a._ehComposto)
            {
                Console.WriteLine("composto");
            }
            else
            {
                Console.WriteLine("simples");
            }
            Console.WriteLine("Capital inicial:\t{0:F}", a._capital_inicial);
            Console.Write("Juros:\t{0:P}", a._juros);
            if (a._ehAno)
            {
                Console.WriteLine(" a.a");
            }
            else
            {
                Console.WriteLine(" a.m");
            }
            Console.Write("Período:\t{0:F}", a._periodo);
            if (a._ehAno)
            {
                Console.WriteLine(" anos");
            }
            else
            {
                Console.WriteLine(" meses");
            }
            Console.WriteLine("Montante atual:\t{0:F}\n", a._montante);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Investimento a = new Investimento("Bolsa de valores", 1000, 0.013d, 15, false, true);
            Investimento b = new Investimento(false, true);
            b.Nome = "Celic";
            b.Capital_inicial = 1030.0d;
            b.Juros = 0.019d;
            b.Periodo = 11;

            Investimento.PrintaInvestimento(a);
            Investimento.PrintaInvestimento(b);
            Investimento.PrintaInvestimento(Investimento.ComparaInvestimento(a, b));

            a.ConverteEscalaTempo();

            Investimento.PrintaInvestimento(a);

        }
    }
}
