using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__Manager
{
    public enum ProjectStatus
    {
        Проект,
        Исполнение,
        Закрыт
    }
    public enum TaskStatus
    {
        Назначена,
        В_работе,
        На_проверке,
        Выполнена
    }


    public class Report
    {
        private string Text;
        private DateTime CompletionDate;
        private string Executor;

        public Report(string text, DateTime completionDate, string executor)
        {
            Text = text;
            CompletionDate = completionDate;
            Executor = executor;
        }
    }


    public class Task
    {
        private TaskStatus Status;
        private string Description;
        private DateTime DueDate;
        private string Initiator;
        private string Executor;
        private List<Report> Reports;

        public Task(TaskStatus status, string description, DateTime dueDate, string initiator)
        {
            Status = status;
            Description = description;
            DueDate = dueDate;
            Initiator = initiator;
            Reports = new List<Report>();
        }
        public void AssignExecutor(string executor)
        {
            Executor = executor;
            Status = TaskStatus.В_работе;
        }
        public void StartTask(Report report)
        {
            Status = TaskStatus.В_работе;
            Reports.Add(report);
        }


        public void ApproveReport()
        {
            Status = TaskStatus.Выполнена;
        }



        public class Project
        {
            private string Description;
            private DateTime DueDate;
            private ProjectStatus projectStatus;
            private string Customer;
            private string Teamleader;
            private List<Task> Tasks;


            public Project(string Description, DateTime DueDate, ProjectStatus projectStatus, string Customer, string Teamleader)
            {
                this.Description = Description;
                this.DueDate = DueDate;
                this.projectStatus = projectStatus;
                this.Customer = Customer;
                this.Teamleader = Teamleader;
                Tasks = new List<Task>();
            }

            /// <summary>
            /// метод для добавления новой задачи
            /// </summary>
            /// <param name="task"></param>
            public void AddTask(Task task)
            {
                if (projectStatus == ProjectStatus.Проект)
                {
                    Tasks.Add(task);
                }
                else
                {
                    Console.WriteLine("Задачи могут добавляться только тогда, когда проект находится в статусе \"Проект\"");
                }
            }
            public void ChangeStatus(ProjectStatus newStatus)
            {
                projectStatus = newStatus;
            }

            /// <summary>
            /// проверяет статус проекта, возвращает значение bool
            /// </summary>
            /// <returns></returns>
            public bool CheckProjectStatus()
            {
                foreach (var task in Tasks)
                {
                    if (task.Status != TaskStatus.Назначена)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}
