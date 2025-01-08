using System.Net.Http.Headers;
using Notificador.WhatsApp.Dominio;

namespace Notificador.WhatsApp.Infraestructura;

public class FacebookNotificadorWhatsApp : INotificadorWhatsApp
{
    private string _token =
        "EAASN4foU5NwBO60RQ4o4iL8TKVH0AC7XUbZB4bZCzGNucGtLvrSQCqEI6ghkPiw5GBZCXM36C3TjSahSCQzMQVK4sk4K9jSAiIKVAdeU6Ese0UU4U2RUZAyPCLBCKYaGsrC1CEMXr4qxZAwNSG6s5EZBnOpERp9Ob3jGoZBR91PITdEQjelT3AsUuyBpcxkYs1I7rLeDUQfD4UAM6TuZCzUYxkMfYmr9lgZDZD";

    private string _idTelefono = "484879711382988";

    public void Notificar(string mensaje, List<string> destinatarios)
    {
        HttpClient client = new HttpClient();

        foreach (var destinatario in destinatarios)
        {
            using (HttpRequestMessage request =
                   new HttpRequestMessage(HttpMethod.Post,
                       "https://graph.facebook.com/v21.0/" + _idTelefono + "/messages"))
            {
                request.Headers.Add("Authorization", "Bearer " + _token);
                request.Content =
                    new StringContent(
                        $"{{ \"messaging_product\": \"whatsapp\", \"to\": \"{destinatario}\", \"type\": \"text\", \"text\": {{ \"body\": \"{mensaje}\" }} }}");

                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}