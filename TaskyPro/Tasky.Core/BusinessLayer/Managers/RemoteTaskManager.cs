using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#if Win8
using System.ServiceModel;
using System.ServiceModel.Channels;
using TaskyWin8.SyncTodayServiceReference;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
#else
#if WINDOWS_PHONE
using System.ServiceModel;
using System.ServiceModel.Channels;
using Windows.Storage.Streams;
using System.Security.Cryptography;
using Tasky.WinPhone.SyncTodayServiceReference;
using System.Threading;
#else
#if iOS
using Tasky.SyncTodayServiceReference;
using System.Security.Cryptography;
#else
using System.Security.Cryptography;
using Tasky.Droid.SyncTodayServiceReference;
#endif
#endif
#endif

namespace Tasky.BL.Managers
{
    public static class RemoteTaskManager
    {
        public static string UserName = string.Empty; //"test@test.com";

        public static string Password = "Password123";
        public static string ClientRegistrationID = "8c3a75ed-5c06-4b36-bd6e-87b8c7f20452";
        public static string ServerUrl = "http://wsdl.sync.today/TaskDatabase.asmx";

        private static string finalPassword;
        internal static User loggedUser;
        internal static Account clientAccount;
#if Win8 || WINDOWS_PHONE
        internal static TaskDatabaseSoapClient wsdl; 
#else        
        internal static TaskDatabase wsdl;
#endif

        /// <summary>
        /// Salted password hashing with PBKDF2-SHA1.
        /// Author: havoc AT defuse.ca
        /// www: http://crackstation.net/hashing-security.htm
        /// Compatibility: .NET 3.0 and later.
        /// </summary>
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
		public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        // http://stackoverflow.com/questions/23023058/using-pbkdf2-encryption-in-a-metro-winrt-application
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
			#if Win8
            byte[] encryptionKeyOut;
            IBuffer saltBuffer = CryptographicBuffer.CreateFromByteArray(salt);
            KeyDerivationParameters kdfParameters = KeyDerivationParameters.BuildForPbkdf2(saltBuffer, PBKDF2_ITERATIONS);

            // Get a KDF provider for PBKDF2 and hash the source password to a Cryptographic Key using the SHA256 algorithm.
            // The generated key for the SHA256 algorithm is 256 bits (32 bytes) in length.
            KeyDerivationAlgorithmProvider kdf = KeyDerivationAlgorithmProvider.OpenAlgorithm(KeyDerivationAlgorithmNames.Pbkdf2Sha1);
            IBuffer passwordBuffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
            CryptographicKey passwordSourceKey = kdf.CreateKey(passwordBuffer);

            // Generate key material from the source password, salt, and iteration count
            const int keySize = 256 / 8;  // 256 bits = 32 bytes  
            IBuffer key = CryptographicEngine.DeriveKeyMaterial(passwordSourceKey, kdfParameters, keySize);

            // send the generated key back to the caller
            CryptographicBuffer.CopyToByteArray(key, out encryptionKeyOut);

            return encryptionKeyOut;  // success
			#else
			Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
			pbkdf2.IterationCount = iterations;
			return pbkdf2.GetBytes(outputBytes);
			#endif
        }

#if WINDOWS_PHONE
        private static long _DateTimeUtcNowOurTicks = 0;
#endif
        public static long DateTimeUtcNowOurTicks()
        {
			#if Win8
			var task = wsdl.DateTimeUtcNowOurTicksAsync();
            task.Wait();
            return task.Result;
			#else
#if WINDOWS_PHONE
            _DateTimeUtcNowOurTicks = 0;
            wsdl.DateTimeUtcNowOurTicksCompleted += wsdl_DateTimeUtcNowOurTicksCompleted;
            wsdl.DateTimeUtcNowOurTicksAsync();
            while (_DateTimeUtcNowOurTicks == 0)
            {
                Thread.Sleep(500);
            }
            return _DateTimeUtcNowOurTicks;
#else
			return wsdl.DateTimeUtcNowOurTicks();
			#endif
#endif
        }

#if WINDOWS_PHONE
        static void wsdl_DateTimeUtcNowOurTicksCompleted(object sender, DateTimeUtcNowOurTicksCompletedEventArgs e)
        {
            _DateTimeUtcNowOurTicks = e.Result;
        }
#endif

        public static string CreateHash1(string password, string salt2)
        {
            byte[] salt = Convert.FromBase64String(salt2);
            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash).Substring(0, 32);
        }

        public static string CreateHash2(string hashedPassword1, string salt2)
        {
            byte[] salt = Convert.FromBase64String(salt2);
            hashedPassword1 += DateTimeUtcNowOurTicks();
            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(hashedPassword1, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash).Substring(0, 32);
        }

        private static string[] users;
        public static string[] Users { get { return users; } }

        public delegate void GetUsersCompleted();

        public 
		#if Win8
		async 
		#endif 
		static void GetUsers(GetUsersCompleted OnGetUsersCompleted)
        {
			#if Win8
			await 
#endif 
			Login();            

            if (loggedUser != null)
            {
                List<string> locUsers = new List<string>();                 
					#if Win8
					User[] remoteUsers =await wsdl.GetUsers2Async();
#else
#if WINDOWS_PHONE
                wsdl.GetUsers2Completed += wsdl_GetUsers2Completed;
                wsdl.GetUsers2Async();
                while (_remoteUsers == null)
                {
                    Thread.Sleep(500);
                }
                User[] remoteUsers = _remoteUsers;
#else
					User[] remoteUsers = wsdl.GetUsers2();
#endif
#endif
                foreach (var remoteUser in remoteUsers)
                {
                    locUsers.Add(remoteUser.Email);
                }
                if (!locUsers.Contains(UserName)) locUsers.Add(UserName);                
                users = locUsers.ToArray();
                if (OnGetUsersCompleted != null)
                    OnGetUsersCompleted();
            }
        }
#if WINDOWS_PHONE
        static User[] _remoteUsers = null;
        static void wsdl_GetUsers2Completed(object sender, GetUsers2CompletedEventArgs e)
        {
            _remoteUsers = e.Result;
        }
#endif

#if Win8
        internal async static System.Threading.Tasks.Task Login()
#else
        private static void Login()
#endif
        {
            if (loggedUser != null && clientAccount != null) return;
            if (string.IsNullOrWhiteSpace(UserName)) return;
#if Win8 || WINDOWS_PHONE
            Binding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(ServerUrl);
            wsdl = new TaskDatabaseSoapClient(binding, address);
#if Win8
            string salt = await wsdl.GetUserSaltAsync(UserName);
            CalculateFinalPassword( salt );
#else
            wsdl.GetUserSaltCompleted += wsdl_GetUserSaltCompleted;
            wsdl.GetUserSaltAsync(UserName);
#endif
#else
            wsdl = new TaskDatabase();
            string salt = wsdl.GetUserSalt(UserName);
			CalculateFinalPassword( salt );
#endif

#if Win8
            loggedUser = await wsdl.LoginUser2Async(UserName, finalPassword);
#else
#if WINDOWS_PHONE
            loggedUser = null;
            //wsdl.LoginUser2Async(UserName, finalPassword); <- done in wsdl_GetUserSaltCompleted
#else
            loggedUser = wsdl.LoginUser2(UserName, finalPassword);
#endif
#endif
            if (loggedUser != null)
            {
#if Win8
                clientAccount = await wsdl.GetAccountForClient2Async(loggedUser.InternalId.ToString(), Guid.Parse(ClientRegistrationID).ToString());
#else
#if WINDOWS_PHONE
                clientAccount = null;
                // clientAccount = await wsdl.GetAccountForClientAsync(loggedUser.InternalId, Guid.Parse(ClientRegistrationID));<- done in wsdl_LoginUser2Completed
#else
				#if iOS
				clientAccount = wsdl.GetAccountForClient2(loggedUser.InternalId, (ClientRegistrationID));
				#else
				clientAccount = wsdl.GetAccountForClient2(loggedUser.InternalId.ToString(), Guid.Parse(ClientRegistrationID).ToString());
#endif
#endif
				#endif
            }
        }

        private static void CalculateFinalPassword(string salt)
        {
            string hashedPasword = CreateHash1(Password, salt);
            finalPassword = CreateHash2(hashedPasword, salt);
        }

#if WINDOWS_PHONE
        static void wsdl_GetUserSaltCompleted(object sender, GetUserSaltCompletedEventArgs e)
        {
            CalculateFinalPassword(e.Result);
            wsdl.LoginUser2Completed += wsdl_LoginUser2Completed;
            wsdl.LoginUser2Async(UserName, finalPassword);
        }

        static void wsdl_LoginUser2Completed(object sender, LoginUser2CompletedEventArgs e)
        {
            loggedUser = e.Result;
            wsdl.GetAccountForClient2Completed += wsdl_GetAccountForClientCompleted;
            wsdl.GetAccountForClient2Async(loggedUser.InternalId.ToString(), Guid.Parse(ClientRegistrationID).ToString());
        }

        static void wsdl_GetAccountForClientCompleted(object sender, GetAccountForClient2CompletedEventArgs e)
        {
            clientAccount = e.Result;
        }
#endif
        public static 
		#if Win8
		async 
		#endif 
		void SaveTask(Task item)
        {
			#if Win8
			await 
			#endif 
			Login();   

            if (loggedUser != null)
            {
                NuTask task = new NuTask();
                task.Body = item.Notes;
                task.Completed = item.Done;
                task.ExternalId = item.ID.ToString();
                task.Subject = item.Name;
                if (string.IsNullOrWhiteSpace(item.Owner)) item.Owner = UserName;

#if Win8
                await wsdl.SaveTask2Async(item.Owner, task, ClientRegistrationID);
#else
#if WINDOWS_PHONE
                wsdl.SaveTask2Async(item.Owner, task, ClientRegistrationID);
#else
                wsdl.SaveTask(clientAccount, loggedUser, task);
#endif
#endif
            }
        }

        public static
#if Win8
        async
#endif
        void DeleteTask(int externalId)
        {
			#if Win8
			await 
			#endif 
            Login();

            if (loggedUser != null)
            {
#if Win8
                await
#endif
				#if Win8
				wsdl.DeleteTaskAsync
				#else
#if WINDOWS_PHONE
                wsdl.DeleteTaskAsync
#else
				wsdl.DeleteTask
				#endif
				#endif
				(clientAccount, externalId.ToString());
            }
        }

        public static 
		#if Win8
		async 
		#endif 
		void ChangeExternalId(string oldId, Task newTask)
        {
			#if Win8
			await 
			#endif 
			Login();   

            if (loggedUser != null)
            {
                NuTask remoteTask = new NuTask();
                remoteTask.Body = newTask.Notes;
                remoteTask.Completed = newTask.Done;
                remoteTask.ExternalId = newTask.ID.ToString();
                remoteTask.Subject = newTask.Name;
#if Win8
                await wsdl.ChangeTaskExternalIdAsync(clientAccount, loggedUser, oldId, remoteTask);
#else
#if WINDOWS_PHONE
                wsdl.ChangeTaskExternalIdAsync(clientAccount, loggedUser, oldId, remoteTask);
#else
                wsdl.ChangeTaskExternalId(clientAccount, loggedUser, oldId, remoteTask);
#endif
#endif
            }
        }

        private static NuTask[] DoTasksComparison(Task[] localTasks, NuTask[] remoteTasks)
        {
            // find changes from remote
            var remoteLocallyMappedTasks = remoteTasks.Where(p => localTasks.Where(r => r.ID.ToString() == p.ExternalId).Count() == 1).ToArray();
            var needsLocalUpdate = remoteLocallyMappedTasks.Where(p => localTasks.Where(r => r.ID.ToString() == p.ExternalId).FirstOrDefault().Modified < p.LastModified).ToArray();
            foreach (NuTask newTask in needsLocalUpdate)
            {
                Task task = new Task();
                task.Done = newTask.Completed;
                task.Name = newTask.Subject;
                task.Notes = newTask.Body;
                task.Modified = newTask.LastModified;
                task.ID = int.Parse(newTask.ExternalId);
                var itemId = DAL.TaskRepository.SaveTask(task);
            }

            // find changes from local
            var localRemotellyMappedTasks = localTasks.Where(p => remoteTasks.Where(r => p.ID.ToString() == r.ExternalId).Count() == 1).ToArray();
            var needsRemoteUpdate = localRemotellyMappedTasks.Where(p => remoteTasks.Where(r => p.ID.ToString() == r.ExternalId).FirstOrDefault().LastModified < p.Modified).ToArray();
            foreach (var localTask in needsRemoteUpdate)
            {
                SaveTask(localTask);
            }

            return remoteTasks.Where(p => localTasks.Where(r => r.ID.ToString() == p.ExternalId).Count() == 0).ToArray();
        }

#if Win8
        public static async Task<NuTask[]> GetNewTasks(Task[] localTasks)
#else
            public static NuTask[] GetNewTasks(Task[] localTasks)
#endif
        {
			#if Win8
			await 
			#endif 
			Login();   

            if (loggedUser != null)
            {
                NuTask[] remoteTasks = null;
#if Win8
                remoteTasks = await wsdl.GetTasksAsync(clientAccount, loggedUser);
#else
#if WINDOWS_PHONE
                wsdl.GetTasksCompleted += wsdl_GetTasksCompleted;
                wsdl.GetTasksAsync(clientAccount, loggedUser, localTasks);
#else
                remoteTasks = wsdl.GetTasks(clientAccount, loggedUser);
#endif
#endif
                if (remoteTasks != null) // <- for Windows_Phone done in wsdl_GetTasksCompleted
                {
                    return DoTasksComparison(localTasks, remoteTasks);
                }

            }

            return new NuTask[] { };
        }

#if WINDOWS_PHONE
        static void wsdl_GetTasksCompleted(object sender, GetTasksCompletedEventArgs e)
            {
                Task[] localTasks = (Task[])(e.UserState);
                NuTask[] newTasks = DoTasksComparison(localTasks, e.Result);

                if (newTasks.Length > 0)
                {
                    foreach (NuTask newTask in newTasks)
                    {
                        Task task = new Task();
                        task.Done = newTask.Completed;
                        task.Name = newTask.Subject;
                        task.Notes = newTask.Body;
                        task.Modified = newTask.LastModified;
                        //task.ID = int.Parse(newTask.ExternalId); NOT HERE!
                        var itemId = DAL.TaskRepository.SaveTask(task);
                        RemoteTaskManager.ChangeExternalId(newTask.ExternalId, task);
                    }
                }
            }
#endif
    }
}
