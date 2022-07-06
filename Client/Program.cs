

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
    Console.Write("Analisi Attività {0}. ", activity);

    if (developerActivityList.Contains(activity))
    {
        Console.Write("Già assegnata.", activity);
    }
    else
    {

        bool riprovo = false;

        do
        {
            try
            {

                Console.Write("In assegnamento al developer, ", activity);
                StreamWriter developerActivityWriter = File.AppendText(DEVELOPER_ACTIVITY_FILE);
                developerActivityWriter.WriteLine(activity);
                developerActivityWriter.Close();

                riprovo = false;
            }
            catch (IOException e)
            {
                
                Console.WriteLine();
                Console.WriteLine("*** non saprei ci devo pensare ancora un attimo ...");
                Console.WriteLine();

                riprovo = true;
            }
        }
        while (riprovo);

    }

    //Thread.Sleep(new Random().Next(30, 500));
    Console.WriteLine();
}

Console.WriteLine("Ho finito per oggi, a domani");

