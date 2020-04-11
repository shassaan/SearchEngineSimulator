
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchEngineSimulator
{
    public class SearchEngine
    {

        public SearchEngine()
        {

        }


        public void Search(int mode, int toBeSearh, Action<string, int> callBack,Action<int> callBackNotify)
        {
            int index = 0;
            if (mode == 1)
            {
                var d = new Data();
                d.prepareData(1);
                AutoResetEvent[] signals = new AutoResetEvent[]
                {
                    new AutoResetEvent(false),
                    new AutoResetEvent(false),
                    new AutoResetEvent(false)
                };
                var t1 = new Thread(() => { index = d.SearchModeOne(toBeSearh, "Gold", signals[0],(data)=> {
                    callBackNotify.Invoke(data);

                }); });
                t1.Start();
                var t2 = new Thread(() => { index = d.SearchModeOne(toBeSearh, "Silver", signals[1], (data) => {
                    callBackNotify.Invoke(data);

                }); });
                t2.Start();
                var t3 = new Thread(() => { index = d.SearchModeOne(toBeSearh, "Platinum", signals[2], (data) => {
                    callBackNotify.Invoke(data);

                }); });

                t3.Start();
                int i = WaitHandle.WaitAny(signals);
                //Thread.Sleep(250);


                if (i == 0)
                {
                    
                    callBack.Invoke("Gold", index);
                }
                else if (i == 1)
                {
                   
                    callBack.Invoke("Silver", index);

                }
                else if (i == 2)
                {
                    
                    callBack.Invoke("Platinum", index);

                }
            }
            else if (mode == 2) {
                var d = new Data();
                d.prepareData(2);
                new Thread(() => { d.SearchModeTwo(toBeSearh, "Gold", (dataBank,i)=> {
                    callBack.Invoke(dataBank,i);

                }, (data) => {
                    callBackNotify.Invoke(data);

                }); }).Start();
                new Thread(() => { d.SearchModeTwo(toBeSearh, "Silver", (dataBank, i) => {
                    callBack.Invoke(dataBank, i);

                }, (data) => {
                    callBackNotify.Invoke(data);

                }); }).Start();
                new Thread(() => { d.SearchModeTwo(toBeSearh, "Platinum", (dataBank, i) => {
                    callBack.Invoke(dataBank, i);

                }, (data) => {
                    callBackNotify.Invoke(data);

                }); }).Start();

            }
        }
        
    }
}
