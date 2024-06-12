namespace Carillon
{
    partial class CarillonInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CarillonServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.CarillonServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // CarillonServiceProcessInstaller
            // 
            this.CarillonServiceProcessInstaller.Password = null;
            this.CarillonServiceProcessInstaller.Username = null;
            // 
            // CarillonServiceInstaller
            // 
            this.CarillonServiceInstaller.ServiceName = "Carillon";
            this.CarillonServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // CarillonInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.CarillonServiceProcessInstaller,
            this.CarillonServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller CarillonServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller CarillonServiceInstaller;
    }
}