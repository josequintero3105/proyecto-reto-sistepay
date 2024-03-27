using MongoDB.Driver;

namespace ProyectoBack.Repositories
{
    public class MongoConnect
    {
        public MongoClient Client;
        public IMongoDatabase Database;
        public MongoConnect()
        {
            Client = new MongoClient("mongodb+srv://dbCredinetDev2019:SisteCredito2019123@credinet2019development-0n9nb.azure.mongodb.net/admin?authSource=admin&replicaSet=CrediNet2019Development-shard-0&readPreference=primary&ssl=true");
            Database = Client.GetDatabase("DBRetoAprendiz");
        }
    }
}
