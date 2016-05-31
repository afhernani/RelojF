using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace formClock
{
    public class TimeIngoEventArgs : EventArgs
    {
        public TimeIngoEventArgs(int hora, int minuto, int segundo)
        {
            Hora = hora; Minuto = minuto; Segundo = segundo;
        }

        public readonly int Hora, Minuto, Segundo;
    }
}
