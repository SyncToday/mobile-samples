using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasky.BL;


#if Win8
using TaskyWin8.SyncTodayServiceReference;
#else
#if WINDOWS_PHONE
using Tasky.WinPhone.SyncTodayServiceReference;
#else
#if iOS
using Tasky.SyncTodayServiceReference;
#else
using Tasky.Droid.SyncTodayServiceReference;
#endif
#endif
#endif

namespace Tasky.BL.Managers
{
	public static class TaskManager
	{
		static TaskManager ()
		{
		}
		
		public static Task GetTask(int id)
		{
            return DAL.TaskRepository.GetTask(id);
		}
		
		#if Win8
		public static async Task<IList<Task>> GetTasks ()
		#else
		public static IList<Task> GetTasks ()
		#endif
		{
            var localTasks = new List<Task>(DAL.TaskRepository.GetTasks());
#if Win8
            NuTask[] newTasks = await RemoteTaskManager.GetNewTasks(localTasks.ToArray());
			#else
            NuTask[] newTasks = RemoteTaskManager.GetNewTasks(localTasks.ToArray());
            #endif
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
                localTasks = new List<Task>(DAL.TaskRepository.GetTasks());
            }
			return localTasks;
		}
		
		public static int SaveTask (Task item)
		{
            item.Modified = DateTime.UtcNow;
            var itemId = DAL.TaskRepository.SaveTask(item);
            RemoteTaskManager.SaveTask(item);
            return itemId;
        }
		
		public static int DeleteTask(int id)
		{
            RemoteTaskManager.DeleteTask(id);
            return DAL.TaskRepository.DeleteTask(id);
		}
		
	}
}