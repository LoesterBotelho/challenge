using System;
using System.Collections.Generic;
using NUnit.Framework;
using GeradorTxt;

[TestFixture]
public class TesteGerador
{
    // Adicionamos os [TestCase] de volta para que o NUnit saiba quais dados usar
    [TestCase(100.00, 50.00, 50.00, true)]
    [TestCase(100.00, 50.005, 50.005, true)]
    [TestCase(100.00, 50.01, 50.01, false)]
    public void Deve_Validar_Soma_Dos_Itens(decimal total, decimal item1, decimal item2, bool sucessoEsperado)
    {
        var doc = new Documento { 
            Numero = "001", 
            Valor = total, 
            Itens = new List<ItemDocumento> { 
                new ItemDocumento { Valor = item1 }, 
                new ItemDocumento { Valor = item2 } 
            } 
        };
        
        var mock = new GeradorMock();
        string nomeTeste = $"Deve_Validar_Soma_Dos_Itens({total}, {item1}, {item2})";

        try 
        {
            mock.TestarValidacao(doc);
            
            // Lógica para quando o código NÃO lança exceção
            if (sucessoEsperado) {
                Console.WriteLine($"{nomeTeste} : Sucesso");
            } else {
                Console.WriteLine($"{nomeTeste} : FALHOU (Esperava falha, mas passou)");
            }
        }
        catch (Exception)
        {
            // Lógica para quando o código LANÇA exceção
            if (sucessoEsperado) {
                Console.WriteLine($"{nomeTeste} : FALHOU (Esperava sucesso, mas deu erro)");
            } else {
                Console.WriteLine($"{nomeTeste} : Sucesso (Falha capturada como esperado)");
            }
        }
    }
}

public class GeradorMock : GeradorArquivoBase 
{
    public override void Gerar(List<Empresa> empresas, string path) { }
    public void TestarValidacao(Documento d) => ValidarSoma(d);
}