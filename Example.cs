using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;

namespace MongoDBHelper
{
    class Program
    {
        public enum Status
        {
            Online,
            DoNotDisturb,
            Idle,
            Offline
        }

        public class User
        {
            [BsonId]
            public ObjectId _Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime LastLogin { get; set; }
            public Status Status { get; set; }

            public User(string firstName, string lastName, string phoneNumber, DateTime lastLogin, Status status)
            {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                LastLogin = lastLogin;
                Status = status;
            }

            /*
                users: Table name on MongoDB
                If you want to change your table name just change it.
                
                Forexample:
                public static MongoDBMethods<Food> methods = new MongoDBMethods<Food>("foods");
            */
            public static MongoDBMethods<User> methods = new MongoDBMethods<User>("users");
        }

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                User[] users = new User[]
                {
                    new User("Adams", "Smith", "+11111111111", DateTime.Now, Status.Offline),
                    new User("Baker", "Johnson", "+12222222222", DateTime.Now, Status.DoNotDisturb),
                    new User("Clark", "Smith", "+13333333333", DateTime.Now, Status.Idle),
                    new User("Davis", "Williams", "+14444444444", DateTime.Now, Status.Online),
                };

                //await Models.User.methods.Insert(users[2]);

                //var user = await Models.User.methods.FindOne(u => u.FirstName == "Baker");
                //user.LastLogin = DateTime.Now;
                //await Models.User.methods.Update(u => u._Id == user._Id, user);

                //await Models.User.methods.DeleteAll();

                //await Models.User.methods.Insert(users);

                //var user = await Models.User.methods.FindOne(u => u.FirstName == "Clark");
                //Console.WriteLine(user.Status);

                //await Models.User.methods.DeleteOne(u => u.FirstName == "Davis");

                //var user = await Models.User.methods.FindOne(u => u.FirstName == "Baker");
                //await Models.User.methods.DeleteMany(u => u.LastLogin == user.LastLogin);

                //var userList = await Models.User.methods.Find(u => u.LastName == "Smith");
                //var userList = await Models.User.methods.ListAll();
                //foreach (var user in userList)
                //{
                //    Console.WriteLine($"{user._Id} {user.FirstName} {user.LastName} {user.PhoneNumber} {user.LastLogin} {user.Status}");
                //}

                Console.WriteLine("Done");
                Console.ReadKey();
            }).GetAwaiter().GetResult();
        }
    }
}
