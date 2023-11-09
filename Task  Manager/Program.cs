using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task__Manager.Task;

namespace Task__Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Project project = new Project("Description of Project 1", DateTime.Now.AddDays(30), ProjectStatus.Проект, "Customer 1", "Team Lead 1");

            Task task1 = new Task(TaskStatus.Назначена, "Description of Task 1", DateTime.Now.AddDays(15), "Initiator 1");
            Task task2 = new Task(TaskStatus.Назначена, "Description of Task 2", DateTime.Now.AddDays(20), "Initiator 2");

            project.AddTask(task1);
            project.AddTask(task2);

            project.ChangeStatus(ProjectStatus.Исполнение);

            task1.AssignExecutor("Executor 1");
            task2.AssignExecutor("Executor 2");

            Report report1 = new Report("Report 1", DateTime.Now, "Executor 1");
            Report report2 = new Report("Report 2", DateTime.Now, "Executor 2");

            task1.StartTask(report1);
            task2.StartTask(report2);

            task1.ApproveReport();
            task2.ApproveReport();

            if (project.CheckProjectStatus())
            {
                Console.WriteLine("Все задачи выполены. Проект закончен.");
                project.ChangeStatus(ProjectStatus.Закрыт);
            }
            else
            {
                Console.WriteLine("Не все задачи завершены. Проект обрабатывается.");
            }
        }

    }
}
