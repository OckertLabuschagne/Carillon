﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace Carillon
{
    [RunInstaller(true)]
    public partial class CarillonInstaller : System.Configuration.Install.Installer
    {
        public CarillonInstaller()
        {
            InitializeComponent();
        }
    }
}
