using System;

namespace GeradorTxt
{
    /// <summary>
    /// Classe responsável por contabilizar a quantidade de linhas geradas por tipo
    /// e calcular o total do arquivo.
    /// </summary>
    public class ContadorLinhas
    {
        public int Tipo00 { get; set; }
        public int Tipo01 { get; set; }
        public int Tipo02 { get; set; }
        public int Tipo03 { get; set; }

        /// <summary>
        /// O total de linhas é a soma de cada tipo + as 5 linhas fixas de rodapé:
        /// 4 linhas do tipo '09' e 1 linha do tipo '99'.
        /// </summary>
        public int TotalLinhas => Tipo00 + Tipo01 + Tipo02 + Tipo03 + 5;
    }
}