using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System.Security.Cryptography;
/*IMPORTANT NOTES*/
/*
  1. Need to generate private key in the form of json file from the firebase web app 
  2. Add the json file that contains all your service account credentials into your project
  3. Make sure to add path
*/
namespace testingfirebasedb
{
    internal class Program
    {
        //initialize database
        public static FirestoreDb initializeDataBase()
        {
            //creating path (compulsory syntax -- just go with it)
            string path = AppDomain.CurrentDomain.BaseDirectory + @"firestore.json";
            //adding path into environment (compulsory syntax -- just go with it)
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            //creating database (argument passed: [your own project id of firebase])
            FirestoreDb tmp_database = FirestoreDb.Create("testdb-64de1");
            Console.WriteLine("Created database successful");
            return tmp_database;
        }

       
        /*main function needed to be async to wait for data to be saved before ending itself, and [Task] 
        instead of [void] is used is because we are now saving data which has delays*/
        
        static async Task Main(string[] args)
        {
            //store initialize database for usage
            FirestoreDb database = initializeDataBase();

            //async...await function to carry out data saving (it will wait for data to be successfully saved.)
            async Task saveData(transaction a_transaction)
            {
                DocumentReference docRef = database.Collection("transaction_3").Document("newDoc3");
                Dictionary<string,object> userdata1  = new Dictionary<string,object>()
                {
                    {"name",a_transaction.getName() },
                    {"id",a_transaction.getID()},
                    {"transaction_amount",a_transaction.getTransVal()},
                    {"transaction_date", a_transaction.getDateTime()}
                };
                await docRef.SetAsync(userdata1);
                Console.WriteLine("Data saved successfully");
            }

            //test case, creating new object
            transaction newTransaction = new transaction(8862.31, DateTime.UtcNow, "Steve", "22010178");
            //saving information
            await saveData(newTransaction);
        }
    }
}
