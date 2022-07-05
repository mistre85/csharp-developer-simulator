

//lo sviluppatore legge le attività dal suo file di attività (developer_activity) da risolvere
//per risolvere le attività ci impega dai 3 ai 15 secondi
//se le risolve le elimina dalla lista
//se non le risolve la porta in fondo alla lista per farle in un secondo momento


//1. creare il reader 
//2. aprire il file developer_activity.txt

//3. leggo la riga = task ??? 

//4. bool risolta = true || false --> new Random().NextDouble() > 0.5;

//5. risolta == false --> dobbiamo scrivere il file di modo che l'ultima riga sia il task corrente.
//5.1 risolta == true --> dobbiamo scrivere il file in modo che la lista sia aggiornata senza il task corrente.

//6. ripeto dl punto ?? 


Console.ReadLine();
return;




















StreamReader clientActivity = File.OpenText("C:\\Users\\mistre\\source\\repos\\csharp-developer-simulator\\developer_activity.txt");

while (!clientActivity.EndOfStream)
{
    string activity = clientActivity.ReadLine();
    Console.WriteLine("Presa in carico attivtà: {0}", activity);

    int resolveTime = new Random().Next(3, 16);
    Console.WriteLine("Risoluzione in corso...");
    Thread.Sleep(resolveTime);

    bool risolta = new Random().NextDouble() > 0.5;


}