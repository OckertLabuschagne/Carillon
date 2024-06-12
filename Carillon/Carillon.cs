using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using System.Configuration;

using Microsoft.DirectX.DirectSound;

using com.olab_it.Helpers;
using com.olab_it;

namespace Carillon
{
    public partial class Carillon : ServiceBase
    {

        #region Fields
        CarillonPlayer player;
        #endregion Fields

        public Carillon()
        {
            InitializeComponent();
            player = new CarillonPlayer();
        }

        protected override void OnStart(string[] args)
        {
            player.Start(this.ServiceHandle);
        }

        protected override void OnStop()
        {
            player.Stop();
        }
    }
}
