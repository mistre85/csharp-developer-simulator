

//il cliente assegna delle attività allo svilppatore (dal suo file al file dello sviluppatore).

//questa attività avviene casualmente in un intervallo di 5-10 secondi; ( Thread.Sleep(1000) );

//qualce volta perà il cliente viene distratto (il programma si chiude casualmente? - oppure c'è un'eccezione)

//quindi il cliente deve ricominciare possibilmente senza riassegnare task già assegnati allo sviluppatore ( che controlli ?? )



//sviluppi

//1. leggere tutta la lista di attività e salvarla per elaborala

//1.    creare i reader e i writer per leggere dal file
//      C:\Users\mistre\source\repos\csharp-developer-simulator\client_activity.txt
//      al file C:\Users\mistre\source\repos\csharp-developer-simulator\developer_activity.txt
//      dovremmo fare una apertura in lettura di un file e in scrittura di un altro file

//2. leggere la linea = attività e salvarala da qualche parte --> read su client_activity.txt
//3. scrivere l'attivà che abbiamo recuperato nell'atro file --> write su developer_activity.txt

//4. Tread.Sleep(...tot secondi casuali...)

//5. si ricomincia da punto 2 fino alla fine del file client_activity.txt










using libreria;

const string CLIENT_ACTIVITY_FILE = "C:\\Users\\mistre\\source\\repos\\csharp-developer-simulator\\client_activity.txt";
const string DEVELOPER_ACTIVITY_FILE = "C:\\Users\\mistre\\source\\repos\\csharp-developer-simulator\\developer_activity.txt";


string[] clientActivityList = File.ReadAllLines(CLIENT_ACTIVITY_FILE);
string[] developerActivityList = File.ReadAllLines(DEVELOPER_ACTIVITY_FILE);

Console.WriteLine("Sono il cliente");

string lastAssignedActivity = "";

if (developerActivityList.Length > 0)
{
    Console.WriteLine("Lo sviluppatore ha già in carico delle attività");
}
else
{
    Console.WriteLine("Lo sviluppatore è senza attività");
}

Console.WriteLine("Procedo con l'assegnamento delle attività");

foreach (string activity in clientActivityList)
{
    if (developerActivityList.Contains(activity))
    {
        Console.WriteLine("Attività {0} già assegnata", activity);
    }
    else
    {

        Console.WriteLine("attività '{0}' in assegnamento al developer", activity);
        StreamWriter developerActivityWriter = File.AppendText(DEVELOPER_ACTIVITY_FILE);
        developerActivityWriter.WriteLine(activity);
        developerActivityWriter.Close();

    }
    Thread.Sleep(new Random().Next(3, 5) * 1000);
}

Console.WriteLine("Ho finito per oggi, a domani");
