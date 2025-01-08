using Notificador.WhatsApp.Infraestructura;

namespace Notificador.WhatsApp.Aplicacion;

public class NotificadorWhatsApp
{
    public void Ejecutar(string mensaje, List<string> numerosDestino)
    {
        new FacebookNotificadorWhatsApp().Notificar(mensaje, numerosDestino);
    }
}