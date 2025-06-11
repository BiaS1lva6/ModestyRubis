using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModestyRubis.Models;

namespace ModestyRubis.Services
{
    public class CorreiosFreteService
    {
        public async Task<(decimal valor, int prazo)> CalcularFreteAsync(Frete frete)
        {
            string url = "https://ws.correios.com.br/calculador/CalcPrecoPrazo.asmx";

            string xmlRequest = $@"<?xml version='1.0' encoding='utf-8'?>
<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'
               xmlns:xsd='http://www.w3.org/2001/XMLSchema'
               xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
  <soap:Body>
    <CalcPrecoPrazo xmlns='http://tempuri.org/'>
      <nCdEmpresa></nCdEmpresa>
      <sDsSenha></sDsSenha>
      <nCdServico>04510</nCdServico>
      <sCepOrigem>{frete.CEPOrigem}</sCepOrigem>
      <sCepDestino>{frete.CEPDestino}</sCepDestino>
      <nVlPeso>{frete.Peso.ToString("0.000", CultureInfo.InvariantCulture)}</nVlPeso>
      <nCdFormato>1</nCdFormato>
      <nVlComprimento>{frete.Comprimento}</nVlComprimento>
      <nVlAltura>{frete.Altura}</nVlAltura>
      <nVlLargura>{frete.Largura}</nVlLargura>
      <nVlDiametro>0</nVlDiametro>
      <sCdMaoPropria>N</sCdMaoPropria>
      <nVlValorDeclarado>{frete.ValorDeclarado}</nVlValorDeclarado>
      <sCdAvisoRecebimento>N</sCdAvisoRecebimento>
    </CalcPrecoPrazo>
  </soap:Body>
</soap:Envelope>";

            using var httpClient = new HttpClient();
            var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");

            var response = await httpClient.PostAsync(url, content);
            var responseXml = await response.Content.ReadAsStringAsync();

            var xDoc = XDocument.Parse(responseXml);

            var valorString = xDoc.Descendants("Valor").FirstOrDefault()?.Value ?? "0";
            var prazoString = xDoc.Descendants("PrazoEntrega").FirstOrDefault()?.Value ?? "0";

            decimal valor = decimal.Parse(valorString.Replace(",", "."), CultureInfo.InvariantCulture);
            int prazo = int.Parse(prazoString);

            return (valor, prazo);
        }
    }
}

