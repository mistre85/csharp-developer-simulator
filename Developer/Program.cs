

//lo sviluppatore legge le attività dal suo file di attività (developer_activity) da risolvere
//per risolvere le attività ci impega dai 3 ai 5 secondi
//se le risolve le elimina dalla lista
//se non le risolve la porta in fondo alla lista per farle in un secondo momento


//1. creare il reader 
//2. aprire il file developer_activity.txt

//3. leggo la riga = task ??? 

//4. bool risolta = true || false --> new Random().NextDouble() > 0.5;

//5. risolta == false --> dobbiamo scrivere il file di modo che l'ultima riga sia il task corrente.
//5.1 risolta == true --> dobbiamo scrivere il file in modo che la lista sia aggiornata senza il task corrente.

//6. ripeto dl punto ?? 


const string DEVELOPER_ACTIVITY_FILE = "C:\\Users\\mistre\\source\\repos\\csharp-developer-simulator\\developer_activity.txt";



Console.WriteLine("Sono lo sviluppatore");

string[] developerActivityList;

while (true)
{
    try
    {
        developerActivityList = File.ReadAllLines(DEVELOPER_ACTIVITY_FILE);

    }catch(IOException e)
    {
        developerActivityList = new string[0];
    }
    

    if (developerActivityList.Length == 0)
    {
        Console.Clear();
        Console.WriteLine("Non ho attvità da fare, prendo un caffè");
        Thread.Sleep(1000);
    }

    foreach (string activity in developerActivityList)
    {
        Console.Write("Attività {0} presa in carico...", activity);

        bool riprovo = false;

        do
        {
            try
            {
                
                string[] updatedActivity = File.ReadAllLines(DEVELOPER_ACTIVITY_FILE);
                List<string> updatedActivityList = new List<string>(updatedActivity);

                bool resolved = new Random().NextDouble() > 0.5;


                if (resolved)
                {

                    updatedActivityList.Remove(activity);
                    File.WriteAllLines(DEVELOPER_ACTIVITY_FILE, updatedActivityList.ToArray());
                    Console.WriteLine("risolta ed eliminata", activity);
                }
                else
                {

                    updatedActivityList.Remove(activity);
                    updatedActivityList.Insert(updatedActivityList.Count(), activity);
                    File.WriteAllLines(DEVELOPER_ACTIVITY_FILE, updatedActivityList.ToArray());

                    Console.WriteLine("non risolta, messa in coda.", activity);
                    //da mettere in coda

                }

                riprovo = false;

            }
            catch (IOException e)
            {
                riprovo = true;
                Console.WriteLine("");
                Console.WriteLine("*** non mi è chiara, mi prendo ancora un del tempo. ***");
                Console.WriteLine("");

            }

        } while (riprovo);


        //Thread.Sleep(new Random().Next(30, 500));
    }


}