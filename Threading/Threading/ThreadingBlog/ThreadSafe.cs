using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingBlog
{
    public class ThreadSafe
    {
        static List<string> lstString = new List<string>();
        //List
        public void AddListItem()
        {
            lstString.Add("Item : "+lstString.Count);
            string[] Arr = lstString.ToArray();

            for (int i = 0; i < Arr.Length; i++)
                Console.WriteLine(Arr[i] + " - "+Thread.CurrentThread.ManagedThreadId);
        }

        //Add List Item Lock
        public void AddListItemLock()
        {
            string[] Arr;
            lock (lstString)
            lstString.Add("Item : " + lstString.Count);

            lock(lstString)
            Arr = lstString.ToArray();

            for (int i = 0; i < Arr.Length; i++)
                Console.WriteLine(Arr[i] + " - " + Thread.CurrentThread.ManagedThreadId);
        }

        public void ListSafety()
        {
            new Thread(AddListItem).Start();
            new Thread(AddListItem).Start();
            //new Thread(AddListItemLock).Start();
            //new Thread(AddListItemLock).Start();

        }
    }
}
