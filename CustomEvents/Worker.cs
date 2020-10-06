﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEventsAndEventArgs
{

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, worktype);
            //}

            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }

        }

        protected virtual void OnWorkCompleted()
        {
            //if(WorkCompleted != null)
            //{
            //    WorkCompleted(hours, worktype);
            //}

            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }

        }


    }
}
