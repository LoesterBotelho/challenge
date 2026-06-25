using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;

namespace GeradorTxt
{
    public abstract class GeradorArquivoBase
    {
        protected ContadorLinhas Contador = new ContadorLinhas();
        
        protected void ValidarSoma(Documento doc) {                
            if (Math.Abs(doc.Itens.Sum(i => i.Valor) - doc.Valor) > 0.01m)
                throw new Exception($"Erro: Soma inconsistente no documento {doc.Numero}");
        }

        protected void Incrementar(string tipo) {
            if (tipo == "00") Contador.Tipo00++;
            else if (tipo == "01") Contador.Tipo01++;
            else if (tipo == "02") Contador.Tipo02++;
            else if (tipo == "03") Contador.Tipo03++;
        }

        protected void EscreverRodape(StringBuilder sb) {
            sb.AppendLine($"09|00|{Contador.Tipo00}");
            sb.AppendLine($"09|01|{Contador.Tipo01}");
            sb.AppendLine($"09|02|{Contador.Tipo02}");
            sb.AppendLine($"09|03|{Contador.Tipo03}");
            sb.AppendLine($"99|{Contador.TotalLinhas}");
        }

        public abstract void Gerar(List<Empresa> empresas, string outputPath);

        protected string ToMoney(decimal val)
        {
            // Força ponto como separador decimal, conforme muitos leiautes.
            return val.ToString("0.00", CultureInfo.InvariantCulture);
        }

        protected void EscreverTipo00(StringBuilder sb, Empresa emp)
        {
            // 00|CNPJEMPRESA|NOMEEMPRESA|TELEFONE
            sb.Append("00").Append("|")
              .Append(emp.CNPJ).Append("|")
              .Append(emp.Nome).Append("|")
              .Append(emp.Telefone).AppendLine();
        }

        protected void EscreverTipo01(StringBuilder sb, Documento doc)
        {
            // 01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO
            sb.Append("01").Append("|")
              .Append(doc.Modelo).Append("|")
              .Append(doc.Numero).Append("|")
              .Append(ToMoney(doc.Valor)).AppendLine();
        }

        protected void EscreverTipo02(StringBuilder sb, ItemDocumento item)
        {
            // 02|DESCRICAOITEM|VALORITEM
            sb.Append("02").Append("|")
              .Append(item.Descricao).Append("|")
              .Append(ToMoney(item.Valor)).AppendLine();
        }

        protected void EscreverTipo03(StringBuilder sb, CategoriaItem cat) // Corrigido de Categoria para CategoriaItem
        {
            // 03|NUMEROCATEGORIA|DESCRICAOCATEGORIA
            sb.Append("03").Append("|")
            .Append(cat.NumeroCategoria).Append("|")
            .Append(cat.DescricaoCategoria).AppendLine();
        }    
    }
}
