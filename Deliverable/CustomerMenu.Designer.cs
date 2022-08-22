namespace Deliverable
{
    partial class CustomerMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAllCustomers = new System.Windows.Forms.Button();
            this.buttonAllManagers = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonGenre = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonAddGenre = new System.Windows.Forms.Button();
            this.buttonRent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Menu";
            // 
            // buttonAllCustomers
            // 
            this.buttonAllCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllCustomers.Location = new System.Drawing.Point(12, 58);
            this.buttonAllCustomers.Name = "buttonAllCustomers";
            this.buttonAllCustomers.Size = new System.Drawing.Size(178, 37);
            this.buttonAllCustomers.TabIndex = 1;
            this.buttonAllCustomers.Text = "View All &Boardgames";
            this.buttonAllCustomers.UseVisualStyleBackColor = true;
            this.buttonAllCustomers.Click += new System.EventHandler(this.buttonAllCustomers_Click);
            // 
            // buttonAllManagers
            // 
            this.buttonAllManagers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllManagers.Location = new System.Drawing.Point(12, 275);
            this.buttonAllManagers.Name = "buttonAllManagers";
            this.buttonAllManagers.Size = new System.Drawing.Size(176, 37);
            this.buttonAllManagers.TabIndex = 2;
            this.buttonAllManagers.Text = "&Review a Boardgame";
            this.buttonAllManagers.UseVisualStyleBackColor = true;
            this.buttonAllManagers.Click += new System.EventHandler(this.buttonAllManagers_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(14, 318);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(176, 37);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonGenre
            // 
            this.buttonGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenre.Location = new System.Drawing.Point(12, 101);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(178, 37);
            this.buttonGenre.TabIndex = 4;
            this.buttonGenre.Text = "View All &Genre Likes";
            this.buttonGenre.UseVisualStyleBackColor = true;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.Location = new System.Drawing.Point(14, 232);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(176, 37);
            this.buttonReturn.TabIndex = 5;
            this.buttonReturn.Text = "&Return a Boardgame";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonAddGenre
            // 
            this.buttonAddGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddGenre.Location = new System.Drawing.Point(12, 144);
            this.buttonAddGenre.Name = "buttonAddGenre";
            this.buttonAddGenre.Size = new System.Drawing.Size(176, 37);
            this.buttonAddGenre.TabIndex = 6;
            this.buttonAddGenre.Text = "&Add a Genre";
            this.buttonAddGenre.UseVisualStyleBackColor = true;
            this.buttonAddGenre.Click += new System.EventHandler(this.buttonAddGenre_Click);
            // 
            // buttonRent
            // 
            this.buttonRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRent.Location = new System.Drawing.Point(12, 187);
            this.buttonRent.Name = "buttonRent";
            this.buttonRent.Size = new System.Drawing.Size(176, 37);
            this.buttonRent.TabIndex = 7;
            this.buttonRent.Text = "&Rent a Boardgame";
            this.buttonRent.UseVisualStyleBackColor = true;
            this.buttonRent.Click += new System.EventHandler(this.buttonRent_Click);
            // 
            // CustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 365);
            this.Controls.Add(this.buttonRent);
            this.Controls.Add(this.buttonAddGenre);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAllManagers);
            this.Controls.Add(this.buttonAllCustomers);
            this.Controls.Add(this.label1);
            this.Name = "CustomerMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAllCustomers;
        private System.Windows.Forms.Button buttonAllManagers;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonGenre;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonAddGenre;
        private System.Windows.Forms.Button buttonRent;
    }
}