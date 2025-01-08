// See https://aka.ms/new-console-template for more information

using Notificador.WhatsApp.Aplicacion;

Console.WriteLine("Hello, World!");

new NotificadorWhatsApp().Ejecutar("Esto es una prueba super chachi pistachi \u2764.",
    new List<string>() { "34610345417", "34665314991" });