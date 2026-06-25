using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeradorTxt
{
    public class GeradorLayoutV2 : GeradorArquivoBase 
    {    
        public override void Gerar(List<Empresa> empresas, string path) 
        {
            var sb = new StringBuilder();

            foreach(var e in empresas) 
            {
                EscreverTipo00(sb, e);
                Incrementar("00");

                foreach(var d in e.Documentos) 
                {
                    ValidarSoma(d);
                    EscreverTipo01(sb, d);
                    Incrementar("01");

                    foreach(var i in d.Itens) 
                    {
                        // Aqui chamamos a lógica de escrita do item (Tipo 02)
                        EscreverTipo02(sb, i); 
                        Incrementar("02");

                        foreach(var c in i.Categorias) 
                        {
                            // Aqui chamamos a lógica de escrita do item (Tipo 03)
                            EscreverTipo03(sb, c);
                            Incrementar("03");
                        }
                    }
                }
            }

            EscreverRodape(sb);
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}