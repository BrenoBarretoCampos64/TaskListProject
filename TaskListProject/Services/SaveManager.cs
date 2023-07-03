﻿using TaskListProject.Entities;
using Task = TaskListProject.Entities.Task;

namespace TaskListProject.Services
{
    internal class SaveManager
	{
        private string DatabaseFileName = "task-database.json";

        public void SaveData(TaskList taskList)
		{
			string path = GetSaveFileDirectory();
			var tasksToBeSaved = taskList.GetTasks();
			var tasksFormattedToJson = Newtonsoft.Json.JsonConvert.SerializeObject(tasksToBeSaved);
			File.WriteAllText(path, tasksFormattedToJson);
		}

		public List<Task> LoadData()
		{
			string path = GetSaveFileDirectory();
			string justText = File.ReadAllText(path);
			Task[]? loadedTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<Task[]>(justText);
			List<Task> tasks = loadedTasks.ToList();
			return tasks;
		}

		public string GetSaveFileDirectory()
		{
            string currentApplicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return currentApplicationDirectory + DatabaseFileName;
        }
	}
}
