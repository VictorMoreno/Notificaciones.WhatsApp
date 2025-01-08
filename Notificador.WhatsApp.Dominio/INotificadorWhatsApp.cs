namespace Notificador.WhatsApp.Dominio;

public interface INotificadorWhatsApp
{
    void Notificar(string mensaje, List<string> destinatarios);
}