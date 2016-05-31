using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace formClock
{
    public delegate void SegundoChangeHandler(Object o,
            TimeIngoEventArgs time);
    class Clock
    {
        private int _Hora, _Minuto, _Segundo;
        
        public event SegundoChangeHandler segundoChange;
        public void OnSegundoChange(Object o, TimeIngoEventArgs t)
        {
            if (segundoChange != null)
            {
                segundoChange(o, t);
            }
        }
        public void Run()
        {
            
            for (; ; )
            {
                Thread.Sleep(1000);
                System.DateTime dt = System.DateTime.Now;
                if (dt.Second != _Segundo)
                {
                    TimeIngoEventArgs timeIngo = new TimeIngoEventArgs(
                        dt.Hour, dt.Minute, dt.Second);
                    OnSegundoChange(this, timeIngo);
                }
                _Hora = dt.Hour; _Minuto = dt.Minute; _Segundo = dt.Second;
            }         
        }
    }
}
