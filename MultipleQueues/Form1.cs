//İstanbul Kültür University
//Computer Science & Engineering
//Name : Hikmet 
//Surname : ERGÜN 
//StudentID : 0801020603
//EMail : hikmet@hikmetergun.net
//Term : 2011 Summer
//Project : Multiple Priority Queues
//Description : The program will simulate Multiple-Priority Queues. Threads & Queues creating to the limit of user needs.
//Threads & Queues creating dynamically. After Queues creation, threads are creating and enqueueing to equivalent queue.
//Always check the highest priority level queue.If highest priority level queue have thread start from there. 
//Loop until the highest priority level queue count equals to zero and then go lower priority level queue.
//When all queues empty, the program stop simulation timer and notify user about program finished. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleQueues
{
    public partial class Form1 : Form
    {
        #region Variables
        public static int QMAX=12;
        public static int TMAX=12;
        public QueueClass[] QueueArray = new QueueClass[QMAX]; //Queue Array Keeps All Queues
        public ThreadClass[] ThreadArray = new ThreadClass[TMAX]; //Thread Array Keeps All Threads
        public int[] ThreadPriorityArray;//Thread Priority Array Keeps All Threads Priority For Turn Back
        public int QueueCounter = 0; //Queue Counter, How Many Queues Created? 
        public int ThreadCounter = 0; //Thread Counter, How Many Threads Created?
        public bool Assigned=false; //If Thread Successfully Assigned, It Takes "True"
        public bool Alive = false; //If Thread is Alive, It Takes "True"
        public int WorkingThreadIndex=0; //Index Of Which Thread Working
        public int QueueIndex = 0; //Index Of Which Queue Have Threads
        public Random PriorityG = new Random(); //Random Priority Variable
        public Random NumberG = new Random(); //Random Number Variable
        public ThreadClass TYTemp; //Temporary Variable 
        public bool FirstTime = true; //First Time Run Control
        public int SimulationCounter=0;//Simulation Counter
        #endregion

        #region Functions
        public int NumberGenerator()
        {
            return NumberG.Next(1000, 9999);
        } //Random Thread Number Generator
        public int PriorityGenerator()
        {
            return PriorityG.Next(0, Convert.ToInt32(txt_NoQ.Text));
        } //Random Thread Priority Generator 
        public void CreateThreadYapisi(int NoT)
        {
            ThreadPriorityArray = new int[NoT];
            txt_Details.AppendText("\r\n------------Threads Creating------------");
            for (ThreadCounter = 0; ThreadCounter < NoT; ThreadCounter++) //Loop Will Turn Up To What Write On "Thread Number" In GUI 
            {
                try
                {
                    ThreadArray[ThreadCounter] = new ThreadClass(ThreadCounter); //New ThreadClass Constructor Calling With ThreadCounter Parameter & Assigning To ThreadArray
                    ThreadArray[ThreadCounter].ThreadNumber = NumberGenerator(); //Random Number Generator Assign Number To ThreadNumber
                    ThreadArray[ThreadCounter].ThreadPriority = PriorityGenerator(); //Random Priority Generator Assign Priority To ThreadPriority
                    ThreadPriorityArray[ThreadCounter] = ThreadArray[ThreadCounter].ThreadPriority;//Priority Assigning to Array For Keeping First Priority
                    txt_Details.AppendText("\r\nThread Created. Number : " + ThreadArray[ThreadCounter].ThreadNumber +
                                                           " Priority : " + ThreadArray[ThreadCounter].ThreadPriority); //Writing
                    AssignThreadToQueue(ThreadArray[ThreadCounter]); //Created Thread Sending As Parameter To Function For Assigning To Equivalent Queue
                }
                catch (Exception Exc) { MessageBox.Show(Exc.Message); }
            }
            txt_Details.AppendText("\r\n------------Threads Created------------");
        } //Creates Threads
        public void CreateQueueYapisi(int NoQ) 
        {
            txt_Details.AppendText("\r\n------------Queues Creating------------");
            for (int i = 0; i < NoQ; i++)//Loop Will Turn Up To What Write On "Queue Number" In GUI
            {
                try
                {
                    QueueArray[i] = new QueueClass(Convert.ToInt32(Math.Pow(2, i)));//New QueueClass Object Creating & Quanta Time Sending As Parameter. Quanta Time is Power Of 2.
                    txt_Details.AppendText("\r\nQueue Created. Number : " + QueueCounter +
                                           " Quanta : " + QueueArray[i].QueueQuanta); //Writing
                    if (QueueCounter < Convert.ToInt32(txt_NoQ.Text)) //If QueueCounter Less Than "Queue Number", Queue Counter + 1
                    {
                        QueueCounter++;
                    }
                }
                catch (Exception Exc) { MessageBox.Show(Exc.Message); }
            }
            txt_Details.AppendText("\r\n------------Queues Created------------");
        } //Creates Queues
        public void AssignThreadToQueue(ThreadClass TY) 
        {
            try
            {
                int i = QueueCounter; //Assign QueueCounter To i For Temporarily
                do //Scan The Queues Which Queue Number Equal To Thread Priority
                {
                    if (TY.ThreadPriority == i) //When Thread Priority Equals to QueueCounter
                    {
                        TY.AssignWorkingTime(QueueArray[i].QueueQuanta);//Call ThreadClass.AssignWorkingTime(int) Function & Sen Queue Quanta As Parameter
                        QueueArray[i].Queue.Enqueue(TY); //Incoming Parameter(TY) Enqueueing to Queue
                        Assigned = true; //Assign Flag OK
                        txt_Details.AppendText("\r\nThread: " + TY.ThreadNumber +
                                               " Priority: " + TY.ThreadPriority +
                                               " Added To " + i +
                                               ". Queue. Thread Will Get " + TY.WorkingTime + " Second."); //Writing
                    }
                    else
                    {
                        i--; //Decrease Queue Counter
                    }
                } while (Assigned == false); //When Assigned Flag OK, Exit Loop
                Assigned = false; //Before The Exit Assigned Flag Set To False Because Of Next Assigning
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        } //Assigns Created Threads To Queues When & Enqueue When Queue Switching
        public bool CheckQueueHaveThread(Queue<ThreadClass> Q)
        {
            if (Q.Count== 0) //If Given Parameter Queue(Q) Have No Threads, Its Count Equals Zero. 
            {
                return false;
            }
            else
            {
                return true;
            }
        } //Checking If Queue Have Thread, Return True
        public void QueueSwitcher(ThreadClass TY) 
        {
            TY.ThreadPriority -= 1; //Decrease Thread Priority When Thread Used All Quanta For Assigning To Lower-Priority Queue
            QueueArray[TY.ThreadPriority].Queue.Enqueue(TY); //Enqueueing to Lower-Priority Queue
            TY.AssignWorkingTime(QueueArray[TY.ThreadPriority].QueueQuanta);//Queue Quanta Assigning To Thread Working Time
            txt_Details.AppendText("\r\nThread Used All Quanta & Switched To Lower-Queue. Thread Number : " + TY.ThreadNumber +
                                   " Priority : " + TY.ThreadPriority +
                                   " Quanta : " + TY.WorkingTime); //Writing
            txt_Details.AppendText("\r\n---------------------------------");
        }  //Queue Switcher. Take Threads to Lower Priority Queue
        public int WhichQueueHaveThread() 
        {
            int index = 0; //Initiliazie 
            for (int i = QueueCounter-1; i >= 0; i--) //Scan Queues.The Loop Will Start From The Top Of The QueueCounter
            {
                if(CheckQueueHaveThread(QueueArray[i].Queue)) //If Queue Have Thread , It Will True
                {
                    index=i; //Index Equals To Loop Counter
                    break;
                }
            }
            return index; //Return Index
        } //Return Index Of Which Queue Have Thread
        public bool SimulationFinished() 
        {
            bool Finished = true; //Initiliazie
            for (int i = QueueCounter - 1; i >= 0; i--) //Scan Queues.The Loop Will Start From The Top Of The QueueCounter
            {
                if(CheckQueueHaveThread(QueueArray[i].Queue))//If Any Of Queue Have Thread It Will Return True
                {
                    Finished = false; //If Queue Have Thread, Simulation Not Finished Yet. So Finished Flag = False
                    break;
                }
            }
            return Finished; //Return Finished Flag
        }  //Checking If All Queues Empty
        public void TurnBack() 
        {
            txt_Details.AppendText("\r\n------Threads Distributing-------"); //Writing
            for(int i=0;i<=ThreadCounter-1;i++)
            //for (int i = ThreadCounter-1; i >= 0; i--) 
            {
                ThreadArray[i].ThreadPriority = ThreadPriorityArray[i];
                
                txt_Details.AppendText("\r\nThread Distributed. Number : " + ThreadArray[i].ThreadNumber +
                                       " Priority : " + ThreadArray[i].ThreadPriority);
                AssignThreadToQueue(ThreadArray[i]);
            }
            txt_Details.AppendText("\r\n------Threads Distributed--------"); //Writing
        }
        #endregion

        #region Events
        public void SimulationTimer_Tick(object sender, EventArgs e) 
        {
            if (SimulationFinished()) //If Simulation Finished True
            {
                if (FirstTime == false)
                {
                    txt_Details.AppendText("\r\nThread Finished. Number : " + ThreadArray[WorkingThreadIndex].ThreadNumber +
                                                       " Priority : " + ThreadArray[WorkingThreadIndex].ThreadPriority +
                                                       " Working Time : " + ThreadArray[WorkingThreadIndex].WorkingTime);
                    TurnBack();
                    FirstTime = true;
                    SimulationCounter+=1;
                }
                if(SimulationCounter==Convert.ToInt32(txt_SimulationCounter.Text))
                //else
                {
                   /* txt_Details.AppendText("\r\nThread Finished. Number : " + ThreadArray[WorkingThreadIndex].ThreadNumber +
                                                       " Priority : " + ThreadArray[WorkingThreadIndex].ThreadPriority +
                                                       " Working Time : " + ThreadArray[WorkingThreadIndex].WorkingTime); */
                    txt_Details.AppendText("\r\n---------------------------------"); //Writing
                    SimulationTimer.Enabled = false; //Stop Simulation Timer
                    txt_Details.AppendText("\r\n---------------------------------"); //Writing
                    txt_Details.AppendText("\r\nSimulation Finished.");
                }
            }
            else //If Simulation Not Finished Yet
            {
                if (FirstTime == true) //If The Program Running First Time
                {
                    try
                    {
                        QueueIndex = WhichQueueHaveThread(); //Go Highest Priority Level Queue & Assign Index To QueueIndex
                        TYTemp = QueueArray[QueueIndex].Queue.Peek(); //First Object Of Queue ASsigning To TYTemp, Temporarily
                        QueueArray[QueueIndex].Queue.Dequeue(); //Dequeue First Object Of Queue
                        if (TYTemp._Thread.ThreadState == System.Threading.ThreadState.Suspended)
                        {
                            TYTemp._Thread.Resume(); //Resume First Object Thread
                        }
                        else if (TYTemp._Thread.ThreadState == System.Threading.ThreadState.Unstarted)
                        {
                            TYTemp._Thread.Start(); //Start First Object Thread
                        }
                        txt_Details.AppendText("\r\n---------------------------------"); //Writing
                        txt_Details.AppendText("\r\nThread Started. Number : " + TYTemp.ThreadNumber +
                                               " Priority : " + TYTemp.ThreadPriority +
                                               " Working Time : " + TYTemp.WorkingTime); //Writing
                        TYTemp.DecreaseWorkingTime(); //Call ThreadClass.DecreaseWorkingTime Function For Decreasing First Object Working Time
                        WorkingThreadIndex = TYTemp.Index; //TYTemp Object Index Assigning To WorkingThreadIndex For Controlling Which Thread Working
                        Alive = true; //Thread Started, So Set Alive To True
                        FirstTime = false;//Set First Time Flag To False, Because Programme Runned Once.
                    }
                    catch (Exception Exc) { MessageBox.Show(Exc.Message); }
                }
                if (Alive && ThreadArray[WorkingThreadIndex].WorkingTime > 0) //If Any Thread Alive & Have Working Time 
                {
                    txt_Details.AppendText("\r\nThread Still Working. Number : " + ThreadArray[WorkingThreadIndex].ThreadNumber +
                                           " Priority : " + ThreadArray[WorkingThreadIndex].ThreadPriority +
                                           " Working Time : " + ThreadArray[WorkingThreadIndex].WorkingTime);//Writing
                    ThreadArray[WorkingThreadIndex].DecreaseWorkingTime(); //Decrease Working Time Of Working Thread
                }
                else if (Alive && ThreadArray[WorkingThreadIndex].WorkingTime == 0) //If Any Thread Alive & Don't Have Working Time
                {
                    try
                    {
                        Alive = false; //Set Alive Flag To False Because It Dont Have Time For Working & Will Suspend.
                        if (ThreadArray[WorkingThreadIndex].ThreadPriority > 0) //If Thread Priority Bigger Than Zero, Queue Switch
                        {
                            ThreadArray[WorkingThreadIndex]._Thread.Suspend(); //Suspend The Thread
                            QueueSwitcher(ThreadArray[WorkingThreadIndex]);//Send Suspended Thread As Parameter To QueueSwitcher Function. It Will Enqueue Parameter To Lower-Priority Queue
                            QueueIndex = WhichQueueHaveThread(); //Go Highest Priority Level Queue & Assign Index To QueueIndex
                        }
                        else //If Thread Priority Equals To Zero, Abort The Thread
                        {
                            ThreadArray[WorkingThreadIndex]._Thread.Suspend(); //Suspend The Thread //It was Abort
                            txt_Details.AppendText("\r\nThread Finished. Number : " + ThreadArray[WorkingThreadIndex].ThreadNumber +
                                                   " Priority : " + ThreadArray[WorkingThreadIndex].ThreadPriority +
                                                   " Working Time : " + ThreadArray[WorkingThreadIndex].WorkingTime); //Writing
                            txt_Details.AppendText("\r\n---------------------------------"); //Writing
                        }
                    }
                    catch (Exception Exc) { MessageBox.Show(Exc.Message); }
                }
                else if (Alive == false) //If None Of Threads Alive
                {
                    try
                    {
                        QueueIndex = WhichQueueHaveThread(); //Go To Top Level Priority
                        TYTemp = QueueArray[QueueIndex].Queue.Peek(); //Get The First Item Of Queue
                        QueueArray[QueueIndex].Queue.Dequeue(); //Dequeue First Item Of Queue
                        if (TYTemp._Thread.ThreadState == System.Threading.ThreadState.Suspended) //If TYTemp Suspended, Now Resume
                        {
                            TYTemp._Thread.Resume(); //Resume The Thread
                            txt_Details.AppendText("\r\nThread Working Again. Number : " + TYTemp.ThreadNumber +
                                                " Priority : " + TYTemp.ThreadPriority +
                                                " Working Time : " + TYTemp.WorkingTime); //Writing
                        }
                        else if(TYTemp._Thread.ThreadState == System.Threading.ThreadState.Unstarted)//If TYTemp Not Started/Not Suspend Before, Now Start
                        {
                            TYTemp._Thread.Start(); //Start The Thread
                            txt_Details.AppendText("\r\nThread Started. Number : " + TYTemp.ThreadNumber +
                                                " Priority : " + TYTemp.ThreadPriority +
                                                " Working Time : " + TYTemp.WorkingTime); //Writing
                        }
                        TYTemp.DecreaseWorkingTime();//Decrease Working Time Of Thread Object
                        Alive = true; //Thread Resumed/Started So Set Alive Flag To True
                        WorkingThreadIndex = TYTemp.Index; //TYTemp Object Index Assigning To WorkingThreadIndex For Controlling Which Thread Working
                    }
                    catch (Exception Exc) { MessageBox.Show(Exc.Message); }
                }
            }
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            SimulationTimer.Enabled = false; //Stop Simulation
        } //Stop Button 
        private void btn_Resume_Click(object sender, EventArgs e)
        {
            SimulationTimer.Enabled = true; //Continue To Simulation
        } //Resume Button
        public void btn_Start_Click(object sender, EventArgs e)
        {
            if (txt_NoQ.Text == "") //Error Provider For "Queue Number". It Cannot Be Empty
            {
                ErrPrv.SetError(txt_NoQ, "Please Enter Queue Number");
            }
            else
            {
                ErrPrv.SetError(txt_NoQ, "");
            }
            if (txt_NoT.Text == "") //Error Provider For "Thread Number". It Cannot Be Empty
            {
                ErrPrv.SetError(txt_NoT, "Please Enter Thread Number");
            }
            else
            {
                ErrPrv.SetError(txt_NoT, "");
            }
            try
            {
                QMAX = Convert.ToInt32(txt_NoQ.Text); //Queue Number Assigning To QMAX Variable 
                TMAX = Convert.ToInt32(txt_NoT.Text);  //Thread Number Assigning To TMAX Variable 
                txt_Details.AppendText("\r\n------------Simulation Started------------");
                CreateQueueYapisi(Convert.ToInt32(txt_NoQ.Text)); //Create Queues & Send "Queue Number" As Parameter
                CreateThreadYapisi(Convert.ToInt32(txt_NoT.Text)); //Create Threads & Send "Thread Number" As Parameter
                SimulationTimer.Enabled = true; //Start Simulation Timer
                btn_Start.Enabled = false; //Start Button Only Clicking Once A Program 
                btn_Resume.Enabled = true; //Resume Button Enabled Simulation Control
                btn_Stop.Enabled = true; //Stop Button Enabled For Simulation Control
            }
            catch (Exception Exc) { MessageBox.Show(Exc.Message); }
        } //Start Button
        public Form1()
        {
            InitializeComponent();
            btn_Resume.Enabled = false;
            btn_Stop.Enabled = false;
        }
        #endregion
    }
}