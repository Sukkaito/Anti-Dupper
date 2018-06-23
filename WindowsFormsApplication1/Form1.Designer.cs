namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flatMaterialButton2 = new WindowsFormsApplication1.FlatMaterialButton();
            this.flatMaterialButton1 = new WindowsFormsApplication1.FlatMaterialButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flatMaterialButton2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 334);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anti-Dupper is on";
            // 
            // flatMaterialButton2
            // 
            this.flatMaterialButton2.CurrentColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.flatMaterialButton2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.flatMaterialButton2.ForeColor = System.Drawing.Color.White;
            this.flatMaterialButton2.Location = new System.Drawing.Point(0, 0);
            this.flatMaterialButton2.Name = "flatMaterialButton2";
            this.flatMaterialButton2.Size = new System.Drawing.Size(145, 45);
            this.flatMaterialButton2.TabIndex = 1;
            this.flatMaterialButton2.Text = "Turn Off";
            this.flatMaterialButton2.UseVisualStyleBackColor = false;
            this.flatMaterialButton2.Click += new System.EventHandler(this.flatMaterialButton2_Click);
            // 
            // flatMaterialButton1
            // 
            this.flatMaterialButton1.CurrentColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(239)))), ((int)(((byte)(236)))));
            this.flatMaterialButton1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.flatMaterialButton1.ForeColor = System.Drawing.Color.White;
            this.flatMaterialButton1.Location = new System.Drawing.Point(262, 141);
            this.flatMaterialButton1.Name = "flatMaterialButton1";
            this.flatMaterialButton1.Size = new System.Drawing.Size(145, 45);
            this.flatMaterialButton1.TabIndex = 0;
            this.flatMaterialButton1.Text = "Turn On";
            this.flatMaterialButton1.UseVisualStyleBackColor = false;
            this.flatMaterialButton1.Click += new System.EventHandler(this.flatMaterialButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 331);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flatMaterialButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anti-Dupper (Version 0.1)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatMaterialButton flatMaterialButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FlatMaterialButton flatMaterialButton2;


    }
}

