using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

#if Win8
using TaskyWin8.SyncTodayServiceReference;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
#else
using System.Security.Cryptography;
using Tasky.Droid.SyncTodayServiceReference;
#endif

namespace Tasky.BL.Managers
{
    public static class RemoteTaskManager
    {
		public static string UserName = "test@test.com";
        public static string Password = "Password123";
        public static string ClientRegistrationID = "8c3a75ed-5c06-4b36-bd6e-87b8c7f20452";
        public static string ServerUrl = "http://wsdl.sync.today/TaskDatabase.asmx";

        internal static User loggedUser;
        internal static Account clientAccount;
#if Win8
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

        public static long DateTimeUtcNowOurTicks()
        {
			DateTime centuryBegin = new DateTime (631139004000000000); //new DateTime(2001, 1, 1).ToUniversalTime();
            DateTime currentDate = DateTime.UtcNow;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
			var result = (long)elapsedSpan.TotalSeconds / 10;
			return result;
        }

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

		#if Win8
		private async static void Login()
        {
            if (loggedUser != null && clientAccount != null) return;
            Binding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(ServerUrl);

            wsdl = new TaskDatabaseSoapClient(binding, address);
            string salt = await wsdl.GetUserSaltAsync(UserName);
            string hashedPasword = CreateHash1(Password, salt);
            string finalPassword = CreateHash2(hashedPasword, salt);
            loggedUser = await wsdl.LoginUser2Async(UserName, finalPassword);
            clientAccount = await wsdl.GetAccountForClientAsync(loggedUser.InternalId, Guid.Parse(ClientRegistrationID));
        }

        public static void SaveTask(Task item)
        {
            Login();

            if (loggedUser != null)
            {
                NuTask task = new NuTask();
                task.Body = item.Notes;
                task.Completed = item.Done;
                task.ExternalId = item.ID.ToString();
                task.Subject = item.Name;

                wsdl.SaveTaskAsync(clientAccount, loggedUser, task);
            }
        }

        public static async Task<NuTask[]> GetNewTasks(Task[] localTasks) {
            Login();

            if (loggedUser != null)
            {
                NuTask[] remoteTasks = await wsdl.GetTasksAsync(clientAccount, loggedUser);
                return remoteTasks.Where(p => localTasks.Where(r => r.ID.ToString() == p.ExternalId).Count() == 0).ToArray();
            }

            return new NuTask[] { };
        }

        public static void ChangeExternalId(string oldId, Task newTask)
        {
            Login();

            if (loggedUser != null)
            {
                NuTask remoteTask = new NuTask();
                remoteTask.Body = newTask.Notes;
                remoteTask.Completed = newTask.Done;
                remoteTask.ExternalId = newTask.ID.ToString();
                remoteTask.Subject = newTask.Name;
                wsdl.ChangeTaskExternalIdAsync(clientAccount, loggedUser, oldId, remoteTask);
            }
        }

		#else
		private static void Login()
		{
			if (loggedUser != null && clientAccount != null) return;

			wsdl = new TaskDatabase();
			string salt = wsdl.GetUserSalt(UserName);
			string hashedPasword = CreateHash1(Password, salt);
			string finalPassword = CreateHash2(hashedPasword, salt);
			loggedUser = wsdl.LoginUser2(UserName, finalPassword);
			if (loggedUser != null) {
				clientAccount = wsdl.GetAccountForClient (loggedUser.InternalId, Guid.Parse (ClientRegistrationID));
			}
		}

		public static void SaveTask(Task item)
		{
			Login();

			if (loggedUser != null) {
				NuTask task = new NuTask ();
				task.Body = item.Notes;
				task.Completed = item.Done;
				task.ExternalId = item.ID.ToString ();
				task.Subject = item.Name;

				wsdl.SaveTask (clientAccount, loggedUser, task);
			}
		}
		#endif
    }
}
