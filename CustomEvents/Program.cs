using System;

namespace CustomEventsAndEventArgs
{
    class Program
    {

        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked : " + e.Hours + " " + e.WorkType);
        }
        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work is done");

        }

    }
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
