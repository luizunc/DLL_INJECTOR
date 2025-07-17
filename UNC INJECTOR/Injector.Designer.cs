namespace UNC_INJECTOR
{
    partial class Injector
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Injector));
            this.InjectButton = new Guna.UI2.WinForms.Guna2Button();
            this.DlladdButton = new Guna.UI2.WinForms.Guna2Button();
            this.DllRemoveButton = new Guna.UI2.WinForms.Guna2Button();
            this.ListDLL = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // InjectButton
            // 
            this.InjectButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.InjectButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.InjectButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.InjectButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.InjectButton.FillColor = System.Drawing.Color.White;
            this.InjectButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.InjectButton.ForeColor = System.Drawing.Color.Black;
            this.InjectButton.Location = new System.Drawing.Point(442, 12);
            this.InjectButton.Name = "InjectButton";
            this.InjectButton.Size = new System.Drawing.Size(180, 45);
            this.InjectButton.TabIndex = 0;
            this.InjectButton.Text = "INJECT";
            // 
            // DlladdButton
            // 
            this.DlladdButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DlladdButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DlladdButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DlladdButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DlladdButton.FillColor = System.Drawing.Color.White;
            this.DlladdButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DlladdButton.ForeColor = System.Drawing.Color.Black;
            this.DlladdButton.Location = new System.Drawing.Point(12, 12);
            this.DlladdButton.Name = "DlladdButton";
            this.DlladdButton.Size = new System.Drawing.Size(180, 45);
            this.DlladdButton.TabIndex = 1;
            this.DlladdButton.Text = "Select DLL";
            this.DlladdButton.Click += new System.EventHandler(this.DlladdButton_Click);
            // 
            // DllRemoveButton
            // 
            this.DllRemoveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DllRemoveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DllRemoveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DllRemoveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DllRemoveButton.FillColor = System.Drawing.Color.White;
            this.DllRemoveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DllRemoveButton.ForeColor = System.Drawing.Color.Black;
            this.DllRemoveButton.Location = new System.Drawing.Point(228, 12);
            this.DllRemoveButton.Name = "DllRemoveButton";
            this.DllRemoveButton.Size = new System.Drawing.Size(180, 45);
            this.DllRemoveButton.TabIndex = 2;
            this.DllRemoveButton.Text = "Remove DLL";
            this.DllRemoveButton.Click += new System.EventHandler(this.DllRemoveButton_Click);
            // 
            // ListDLL
            // 
            this.ListDLL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ListDLL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListDLL.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListDLL.ForeColor = System.Drawing.Color.White;
            this.ListDLL.FormattingEnabled = true;
            this.ListDLL.ItemHeight = 30;
            this.ListDLL.Location = new System.Drawing.Point(12, 63);
            this.ListDLL.Name = "ListDLL";
            this.ListDLL.Size = new System.Drawing.Size(610, 242);
            this.ListDLL.TabIndex = 3;
            this.ListDLL.SelectedIndexChanged += new System.EventHandler(this.ListDLL_SelectedIndexChanged);
            // 
            // Injector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.ListDLL);
            this.Controls.Add(this.DllRemoveButton);
            this.Controls.Add(this.DlladdButton);
            this.Controls.Add(this.InjectButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Injector";
            this.Text = "UNC INJECTOR";
            this.Load += new System.EventHandler(this.Injector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button InjectButton;
        private Guna.UI2.WinForms.Guna2Button DlladdButton;
        private Guna.UI2.WinForms.Guna2Button DllRemoveButton;
        private System.Windows.Forms.ListBox ListDLL;
    }
}

