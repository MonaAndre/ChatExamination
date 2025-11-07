using System.Security.Cryptography.X509Certificates;

namespace ChatExamination;

// ws är protokollet som står för websocket
// wss är samma sak som https, alltså TLS/SSL aktiverad.
/*
 *
 * Händelser/Events skickas mellan klienten och servern.
 * Varje event har ett eventName och en data-innehåll.
 *
 * Vi väljer själva vilka event namn som vi vill lyssna på samt skicka.
 * Vi väljer själva vilken datastruktur samt vilka events som vi ska ha.
 *
 *
 */

class Program
{
    static async Task Main(string[] args)
    {
        Menu menu = new Menu();
       await  menu.OpenMenu();
    }
}