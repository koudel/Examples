
namespace CardGame
{
    partial class Game
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.PlayerHandView = new System.Windows.Forms.ListView();
            this.ComputerHandView = new System.Windows.Forms.ListView();
            this.GameDeckView = new System.Windows.Forms.ListView();
            this.DeckImage = new System.Windows.Forms.PictureBox();
            this.StayButton = new System.Windows.Forms.Button();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.TypePicH = new System.Windows.Forms.PictureBox();
            this.TypePicD = new System.Windows.Forms.PictureBox();
            this.TypePicS = new System.Windows.Forms.PictureBox();
            this.TypePicC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeckImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicC)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerHandView
            // 
            this.PlayerHandView.HideSelection = false;
            this.PlayerHandView.Location = new System.Drawing.Point(12, 445);
            this.PlayerHandView.Name = "PlayerHandView";
            this.PlayerHandView.Size = new System.Drawing.Size(784, 97);
            this.PlayerHandView.TabIndex = 1;
            this.PlayerHandView.UseCompatibleStateImageBehavior = false;
            this.PlayerHandView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayerHandView_MouseClick);
            // 
            // ComputerHandView
            // 
            this.ComputerHandView.HideSelection = false;
            this.ComputerHandView.Location = new System.Drawing.Point(12, 12);
            this.ComputerHandView.Name = "ComputerHandView";
            this.ComputerHandView.Size = new System.Drawing.Size(784, 97);
            this.ComputerHandView.TabIndex = 2;
            this.ComputerHandView.UseCompatibleStateImageBehavior = false;
            // 
            // GameDeckView
            // 
            this.GameDeckView.HideSelection = false;
            this.GameDeckView.Location = new System.Drawing.Point(334, 221);
            this.GameDeckView.Name = "GameDeckView";
            this.GameDeckView.Size = new System.Drawing.Size(106, 104);
            this.GameDeckView.TabIndex = 3;
            this.GameDeckView.UseCompatibleStateImageBehavior = false;
            // 
            // DeckImage
            // 
            this.DeckImage.Image = ((System.Drawing.Image)(resources.GetObject("DeckImage.Image")));
            this.DeckImage.Location = new System.Drawing.Point(200, 221);
            this.DeckImage.Name = "DeckImage";
            this.DeckImage.Size = new System.Drawing.Size(77, 104);
            this.DeckImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeckImage.TabIndex = 4;
            this.DeckImage.TabStop = false;
            this.DeckImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeckImage_MouseClick);
            // 
            // StayButton
            // 
            this.StayButton.Location = new System.Drawing.Point(474, 258);
            this.StayButton.Name = "StayButton";
            this.StayButton.Size = new System.Drawing.Size(75, 23);
            this.StayButton.TabIndex = 5;
            this.StayButton.Text = "Stay";
            this.StayButton.UseVisualStyleBackColor = true;
            this.StayButton.Visible = false;
            this.StayButton.Click += new System.EventHandler(this.StayButton_Click);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BackColor = System.Drawing.Color.White;
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionTextBox.Location = new System.Drawing.Point(334, 195);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.Size = new System.Drawing.Size(106, 13);
            this.DescriptionTextBox.TabIndex = 6;
            // 
            // TypePicH
            // 
            this.TypePicH.Image = ((System.Drawing.Image)(resources.GetObject("TypePicH.Image")));
            this.TypePicH.Location = new System.Drawing.Point(446, 221);
            this.TypePicH.Name = "TypePicH";
            this.TypePicH.Size = new System.Drawing.Size(24, 22);
            this.TypePicH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TypePicH.TabIndex = 7;
            this.TypePicH.TabStop = false;
            this.TypePicH.Visible = false;
            this.TypePicH.Click += new System.EventHandler(this.TypePicH_Click);
            // 
            // TypePicD
            // 
            this.TypePicD.Image = ((System.Drawing.Image)(resources.GetObject("TypePicD.Image")));
            this.TypePicD.Location = new System.Drawing.Point(446, 249);
            this.TypePicD.Name = "TypePicD";
            this.TypePicD.Size = new System.Drawing.Size(24, 22);
            this.TypePicD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TypePicD.TabIndex = 8;
            this.TypePicD.TabStop = false;
            this.TypePicD.Visible = false;
            this.TypePicD.Click += new System.EventHandler(this.TypePicD_Click);
            // 
            // TypePicS
            // 
            this.TypePicS.Image = ((System.Drawing.Image)(resources.GetObject("TypePicS.Image")));
            this.TypePicS.Location = new System.Drawing.Point(446, 277);
            this.TypePicS.Name = "TypePicS";
            this.TypePicS.Size = new System.Drawing.Size(24, 22);
            this.TypePicS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TypePicS.TabIndex = 9;
            this.TypePicS.TabStop = false;
            this.TypePicS.Visible = false;
            this.TypePicS.Click += new System.EventHandler(this.TypePicS_Click);
            // 
            // TypePicC
            // 
            this.TypePicC.Image = ((System.Drawing.Image)(resources.GetObject("TypePicC.Image")));
            this.TypePicC.Location = new System.Drawing.Point(446, 303);
            this.TypePicC.Name = "TypePicC";
            this.TypePicC.Size = new System.Drawing.Size(24, 22);
            this.TypePicC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TypePicC.TabIndex = 10;
            this.TypePicC.TabStop = false;
            this.TypePicC.Visible = false;
            this.TypePicC.Click += new System.EventHandler(this.TypePicC_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(808, 554);
            this.Controls.Add(this.TypePicC);
            this.Controls.Add(this.TypePicS);
            this.Controls.Add(this.TypePicD);
            this.Controls.Add(this.TypePicH);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.StayButton);
            this.Controls.Add(this.DeckImage);
            this.Controls.Add(this.GameDeckView);
            this.Controls.Add(this.ComputerHandView);
            this.Controls.Add(this.PlayerHandView);
            this.Name = "Game";
            this.Text = "Card Game";
            ((System.ComponentModel.ISupportInitialize)(this.DeckImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypePicC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListView PlayerHandView;
        public System.Windows.Forms.ListView ComputerHandView;
        public System.Windows.Forms.ListView GameDeckView;
        public System.Windows.Forms.PictureBox DeckImage;
        public System.Windows.Forms.Button StayButton;
        public System.Windows.Forms.TextBox DescriptionTextBox;
        public System.Windows.Forms.PictureBox TypePicH;
        public System.Windows.Forms.PictureBox TypePicD;
        public System.Windows.Forms.PictureBox TypePicS;
        public System.Windows.Forms.PictureBox TypePicC;
    }
}

