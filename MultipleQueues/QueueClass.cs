using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleQueues
{
    public class QueueClass
    {
        public Queue<ThreadClass> Queue; //Queue
        public int QueueQuanta { get; set; } //Queue Time

        public QueueClass(int QQ) //QueueClass Constractor
        {
            Queue=new Queue<ThreadClass>(); //Creating New Queue Which Will Keep ThreadClass Data
            this.QueueQuanta = QQ; //Incoming Parameter Assigning to QueueQuanta
        }
    }
}
