using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //C# Threading Class

namespace MultipleQueues
{
    public class ThreadClass
    {
        public int ThreadPriority; //Thread Priority
        public int ThreadNumber; //Thread Number
        public Thread _Thread; //Initializes a new instance of the Thread class.
        public ThreadStart _ThreadStart; //When a managed thread is created, the method that executes on the thread is represented by a ThreadStart delegate
        public int WorkingTime; //Thread Will Work Up To Working Time
        public int Index; //Thread Counter When Thread Created

        public void DoProccess()
        {
            int counter = 0;
            for (int i = 0; i < 1000000; i++)
            {
                for (int j = 0; j < 1000000; j++)
                {
                    counter++;
                }
            }
        } //Thread Process
        public void DecreaseWorkingTime() 
        {
            this.WorkingTime--;
        } //Thread Working Time Decreasing
        public void AssignWorkingTime(int WT)
        {
            this.WorkingTime = WT;
        } //Incoming Parameter Will Assign As Working Time
        public ThreadClass(int I) //ThreadClass Constructor
        {
            this._ThreadStart = new ThreadStart(DoProccess); //Create Delegate
            this._Thread = new Thread(_ThreadStart); //Create Thread
            this.WorkingTime = this.ThreadPriority; //Assign Thread Priority As Working Time 
            this.Index = I; //Incoming Parameter Will Assign To Index. Incoming Parameter is Thread Counter When Thread Created.
        }
    }
}
