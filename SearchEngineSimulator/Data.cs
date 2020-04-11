using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchEngineSimulator
{
    public class Data
    {
        public int[] Gold { get; set; } = new int[5000];
        public  int[] Silver { get; set; } = new int[5000];
        public  int[] Platinum { get; set; } = new int[5000];
        //public int MyProperty { get; set; } = new int[5000];



        public  void prepareData(int mode)
        {
            if (mode == 1)
            {
                var r = new Random();
                for (int i = 0; i < 5000; i++)
                {
                    Gold[i] = r.Next(1, 100);
                    Silver[i] = r.Next(1, 100);
                    Platinum[i] = r.Next(1, 100);


                }
            } else if (mode == 2)
            {
                var r = new Random();
                for (int i = 0; i < 5000; i++)
                {
                    Gold[i] = r.Next(1, 1000);
                    Silver[i] = r.Next(500, 1400);
                    Platinum[i] = r.Next(700, 1800);
                }
            }
        }

        public  int SearchModeOne(int tobeSearch,string dataBank,object state,Action<int> callBackNotify)
        {
            var signal = state as AutoResetEvent;
                if (dataBank.Equals("Gold"))
                {
                    for (int i = 0; i < 5000; i++)
                    {
                        callBackNotify.Invoke(Gold[i]);
                        if (Gold[i] == tobeSearch)
                        {
                            signal.Set();
                            return i;
                        }
                        Thread.Sleep(250);
                    }
                }
                else if (dataBank.Equals("Silver"))
                {
                    for (int i = 0; i < 5000; i++)
                    {
                        callBackNotify.Invoke(Silver[i]);
                        if (Silver[i] == tobeSearch)
                        {
                            signal.Set();
                            return i;
                        }
                        Thread.Sleep(500);
                    }
                }
                else if (dataBank.Equals("Platinum"))
                {
                    for (int i = 0; i < 5000; i++)
                    {
                        callBackNotify.Invoke(Platinum[i]);
                        if (Platinum[i] == tobeSearch)
                        {
                            signal.Set();
                            return i;
                        }
                        Thread.Sleep(1000);
                    }
                }
            
            
            return 0;
        }

        public void SearchModeTwo(int tobeSearch,string dataBank,Action<string,int> callBack, Action<int> callBackNotify)
        {
            if (dataBank.Equals("Gold"))
            {
                for (int i = 0; i < 5000; i++)
                {
                    callBackNotify.Invoke(Gold[i]);
                    if (Gold[i] == tobeSearch)
                    {
                        callBack.Invoke("Gold",i);
                    }
                    Thread.Sleep(500);
                }
            }
            else if (dataBank.Equals("Silver"))
            {
                
                for (int i = 0; i < 5000; i++)
                {
                    callBackNotify.Invoke(Silver[i]);
                if (Silver[i] == tobeSearch)
                    {
                        callBack.Invoke("Silver", i);
                    }
                    Thread.Sleep(500);
                }
            }
            else if (dataBank.Equals("Platinum"))
            {
                for (int i = 0; i < 5000; i++)
                {
                    callBackNotify.Invoke(Platinum[i]);
                if (Platinum[i] == tobeSearch)
                    {
                        callBack.Invoke("Silver", i);
                    }
                    Thread.Sleep(500);
                }
            }
        }

        
    }
}
