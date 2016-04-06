namespace Chapter_08_8_TwoDecks
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
            this.deck1ListBox = new System.Windows.Forms.ListBox();
            this.deck2ListBox = new System.Windows.Forms.ListBox();
            this.deck1Label = new System.Windows.Forms.Label();
            this.deck2Label = new System.Windows.Forms.Label();
            this.moveToDeck2 = new System.Windows.Forms.Button();
            this.moveToDeck1 = new System.Windows.Forms.Button();
            this.reset1 = new System.Windows.Forms.Button();
            this.reset2 = new System.Windows.Forms.Button();
            this.suffle1 = new System.Windows.Forms.Button();
            this.shuffle2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deck1ListBox
            // 
            this.deck1ListBox.FormattingEnabled = true;
            this.deck1ListBox.Location = new System.Drawing.Point(12, 37);
            this.deck1ListBox.Name = "deck1ListBox";
            this.deck1ListBox.Size = new System.Drawing.Size(125, 225);
            this.deck1ListBox.TabIndex = 0;
            // 
            // deck2ListBox
            // 
            this.deck2ListBox.FormattingEnabled = true;
            this.deck2ListBox.Location = new System.Drawing.Point(201, 37);
            this.deck2ListBox.Name = "deck2ListBox";
            this.deck2ListBox.Size = new System.Drawing.Size(119, 225);
            this.deck2ListBox.TabIndex = 1;
            // 
            // deck1Label
            // 
            this.deck1Label.AutoSize = true;
            this.deck1Label.Location = new System.Drawing.Point(12, 21);
            this.deck1Label.Name = "deck1Label";
            this.deck1Label.Size = new System.Drawing.Size(35, 13);
            this.deck1Label.TabIndex = 2;
            this.deck1Label.Text = "label1";
            // 
            // deck2Label
            // 
            this.deck2Label.AutoSize = true;
            this.deck2Label.Location = new System.Drawing.Point(198, 21);
            this.deck2Label.Name = "deck2Label";
            this.deck2Label.Size = new System.Drawing.Size(99, 13);
            this.deck2Label.TabIndex = 3;
            this.deck2Label.Text = "Deck #2 (52 cards)";
            // 
            // moveToDeck2
            // 
            this.moveToDeck2.Location = new System.Drawing.Point(144, 80);
            this.moveToDeck2.Name = "moveToDeck2";
            this.moveToDeck2.Size = new System.Drawing.Size(51, 23);
            this.moveToDeck2.TabIndex = 4;
            this.moveToDeck2.Text = ">>";
            this.moveToDeck2.UseVisualStyleBackColor = true;
            this.moveToDeck2.Click += new System.EventHandler(this.moveToDeck2_Click);
            // 
            // moveToDeck1
            // 
            this.moveToDeck1.Location = new System.Drawing.Point(144, 129);
            this.moveToDeck1.Name = "moveToDeck1";
            this.moveToDeck1.Size = new System.Drawing.Size(51, 23);
            this.moveToDeck1.TabIndex = 5;
            this.moveToDeck1.Text = "<<";
            this.moveToDeck1.UseVisualStyleBackColor = true;
            this.moveToDeck1.Click += new System.EventHandler(this.moveToDeck1_Click);
            // 
            // reset1
            // 
            this.reset1.Location = new System.Drawing.Point(12, 269);
            this.reset1.Name = "reset1";
            this.reset1.Size = new System.Drawing.Size(125, 23);
            this.reset1.TabIndex = 6;
            this.reset1.Text = "Reset Deck #1";
            this.reset1.UseVisualStyleBackColor = true;
            this.reset1.Click += new System.EventHandler(this.reset1_Click);
            // 
            // reset2
            // 
            this.reset2.Location = new System.Drawing.Point(201, 269);
            this.reset2.Name = "reset2";
            this.reset2.Size = new System.Drawing.Size(125, 23);
            this.reset2.TabIndex = 7;
            this.reset2.Text = "Reset Deck #2";
            this.reset2.UseVisualStyleBackColor = true;
            this.reset2.Click += new System.EventHandler(this.reset2_Click);
            // 
            // suffle1
            // 
            this.suffle1.Location = new System.Drawing.Point(12, 298);
            this.suffle1.Name = "suffle1";
            this.suffle1.Size = new System.Drawing.Size(125, 23);
            this.suffle1.TabIndex = 8;
            this.suffle1.Text = "Shuffle Deck #1";
            this.suffle1.UseVisualStyleBackColor = true;
            this.suffle1.Click += new System.EventHandler(this.suffle1_Click);
            // 
            // shuffle2
            // 
            this.shuffle2.Location = new System.Drawing.Point(201, 298);
            this.shuffle2.Name = "shuffle2";
            this.shuffle2.Size = new System.Drawing.Size(125, 23);
            this.shuffle2.TabIndex = 9;
            this.shuffle2.Text = "Shuffle Deck #2";
            this.shuffle2.UseVisualStyleBackColor = true;
            this.shuffle2.Click += new System.EventHandler(this.shuffle2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 331);
            this.Controls.Add(this.shuffle2);
            this.Controls.Add(this.suffle1);
            this.Controls.Add(this.reset2);
            this.Controls.Add(this.reset1);
            this.Controls.Add(this.moveToDeck1);
            this.Controls.Add(this.moveToDeck2);
            this.Controls.Add(this.deck2Label);
            this.Controls.Add(this.deck1Label);
            this.Controls.Add(this.deck2ListBox);
            this.Controls.Add(this.deck1ListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Two Decks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox deck1ListBox;
        private System.Windows.Forms.ListBox deck2ListBox;
        private System.Windows.Forms.Label deck1Label;
        private System.Windows.Forms.Label deck2Label;
        private System.Windows.Forms.Button moveToDeck2;
        private System.Windows.Forms.Button moveToDeck1;
        private System.Windows.Forms.Button reset1;
        private System.Windows.Forms.Button reset2;
        private System.Windows.Forms.Button suffle1;
        private System.Windows.Forms.Button shuffle2;
    }
}

