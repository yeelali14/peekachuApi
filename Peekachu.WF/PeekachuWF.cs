using System;
using System.Diagnostics;
using System.Threading;

namespace Peekachu.WF
{
    public class PeekachuWF
    {
        
        public static bool CollectDiMesseges(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 100; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                Trace.WriteLine("method running: " + i.ToString());
                Thread.Sleep(3000);
            }

            return true;
        }
    }
}
