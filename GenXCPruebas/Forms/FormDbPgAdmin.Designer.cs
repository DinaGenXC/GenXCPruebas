
namespace GenXCPruebas.Forms
{
    partial class FormDbPgAdmin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDbPgAdmin));
            this.button2 = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lbProject = new System.Windows.Forms.Label();
            this.lbClient = new System.Windows.Forms.Label();
            this.lbUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(145, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load KML";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(145, 80);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(121, 20);
            this.txtProjectName.TabIndex = 4;
            // 
            // cboClient
            // 
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(145, 22);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(121, 21);
            this.cboClient.TabIndex = 5;
            // 
            // lbProject
            // 
            this.lbProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProject.Location = new System.Drawing.Point(15, 80);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(124, 20);
            this.lbProject.TabIndex = 6;
            this.lbProject.Text = "Project Name:";
            // 
            // lbClient
            // 
            this.lbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClient.Location = new System.Drawing.Point(75, 22);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(64, 21);
            this.lbClient.TabIndex = 7;
            this.lbClient.Text = "Client:";
            // 
            // lbUserId
            // 
            this.lbUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserId.Location = new System.Drawing.Point(64, 54);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(75, 20);
            this.lbUserId.TabIndex = 8;
            this.lbUserId.Text = "User Id:";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(145, 54);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(121, 20);
            this.txtUserId.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 48);
            this.label1.TabIndex = 10;
            // 
            // FormDbPgAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 145);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lbUserId);
            this.Controls.Add(this.lbClient);
            this.Controls.Add(this.lbProject);
            this.Controls.Add(this.cboClient);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.button2);
            this.Name = "FormDbPgAdmin";
            this.Text = "Upload Projects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Label lbProject;
        private System.Windows.Forms.Label lbClient;
        private System.Windows.Forms.Label lbUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
    }
}