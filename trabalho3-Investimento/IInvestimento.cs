using System;
using System.Collections.Generic;
using System.Text;

namespace trabalho3_Investimento
{
    interface IInvestimento
    {
        string Nome
        {
            get;
            set;
        }
        double Capital_inicial
        {
            get;
            set;
        }

        double Juros
        {
            get;
            set;
        }
        double Periodo
        {
            get;
            set;
        }

        public void CalcMontante();
        public void ConverteEscalaTempo();
    }
}
