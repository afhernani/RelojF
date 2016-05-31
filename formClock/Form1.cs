using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formClock
{
    public partial class Form1 : Form
    {
        private Clock reloj;
        public delegate void setTextCallBack(object o, TimeIngoEventArgs time);
        public Form1()
        {
            InitializeComponent();
            Display.Text = "00:00:00";
            try
            {
                Task tar = Task.Factory.StartNew((SegundoChangeHandler) =>
                {
                    reloj = new Clock();
                    reloj.segundoChange += this.reloj_segundoChange;
                    reloj.Run();
                },TaskScheduler.FromCurrentSynchronizationContext()
            );
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //tar.Wait();

        }

        private void reloj_segundoChange(object o, TimeIngoEventArgs time)
        {
            if (Display.InvokeRequired)
            {
                setTextCallBack d = new setTextCallBack(reloj_segundoChange);
                this.Invoke(d, new object[] { o, time });
                
            }
            else 
            {
                Display.Text = time.Hora.ToString() + ":" + time.Minuto.ToString()
                + ":" + time.Segundo.ToString();
            }
        }
    }
}
