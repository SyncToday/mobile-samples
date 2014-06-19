using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasky.BL;
using TaskyWin8.SyncTodayServiceReference;

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
		
		public static async Task<IList<Task>> GetTasks ()
		{
            var localTasks = new List<Task>(DAL.TaskRepository.GetTasks());
            NuTask[] newTasks = await RemoteTaskManager.GetNewTasks(localTasks.ToArray());
            if (newTasks.Length > 0)
            {
                foreach (NuTask newTask in newTasks)
                {
                    Task task = new Task();
                    task.Done = newTask.Completed;
                    task.Name = newTask.Subject;
                    task.Notes = newTask.Body;
                    var itemId = DAL.TaskRepository.SaveTask(task);
                    RemoteTaskManager.ChangeExternalId(newTask.ExternalId, task);
                }
                localTasks = new List<Task>(DAL.TaskRepository.GetTasks());
            }
			return localTasks;
		}
		
		public static int SaveTask (Task item)
		{
            var itemId = DAL.TaskRepository.SaveTask(item);
            RemoteTaskManager.SaveTask(item);
            return itemId;
        }
		
		public static int DeleteTask(int id)
		{
            return DAL.TaskRepository.DeleteTask(id);
		}
		
	}
}