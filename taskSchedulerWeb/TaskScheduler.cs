namespace taskSchedulerWeb
{
    public class TaskScheduler
    {
        private Queue <string> taskQueue = new Queue <string> ();

        public void AddTask(string task)
        {
            taskQueue.Enqueue(task);
            Console.WriteLine($"Task added: {task}"); 
        }

        public void ProcessTasks()
        {
            if (taskQueue.Count > 0)
            {
                Console.WriteLine($"Processing: {taskQueue.Dequeue()}");
            }
            else

                Console.WriteLine("No tasks to process");
        }
        public void ShowTasks()
        {
            if (taskQueue.Count == 0)
            { 
             Console.WriteLine("No pending tasks");
                return; 
            }

            Console.WriteLine("Pending tasks:"); 

            foreach (var task in taskQueue)
            {
                Console.WriteLine(task);
            }
        }

        //these methods signed for the web api controller
        //this API controller exposes endpoints to add, process, and list tasks 
        public bool HasPendingTasks()
        {
            return taskQueue.Count > 0;
        }

        public string ProcessTask()
        {
            if (taskQueue.Count > 0)
                return taskQueue.Dequeue();
            return null;
        }

        public List<string> GetTasks()
        {
            return new List<string>(taskQueue);
        }



    }
}
