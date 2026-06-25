using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeradorTxt
{
    public class GeradorLayoutV1 : GeradorArquivoBase
    {
        public override void Gerar(List<Empresa> empresas, string path)
        {
            var sb = new StringBuilder();
            
            foreach (var emp in empresas)
            {
                // Escreve e conta a linha tipo 00
                EscreverTipo00(sb, emp);
                Incrementar("00");

                foreach (var doc in emp.Documentos)
                {
                    // Valida a soma conforme requisito D
                    ValidarSoma(doc);
                    
                    // Escreve e conta a linha tipo 01
                    EscreverTipo01(sb, doc);
                    Incrementar("01");

                    foreach (var item in doc.Itens)
                    {
                        // Escreve e conta a linha tipo 02
                        EscreverTipo02(sb, item);
                        Incrementar("02");
                    }
                }
            }

            // Adiciona as linhas 09 e 99 ao final (requisitos E e F)
            EscreverRodape(sb);

            // Escreve o arquivo final
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}