namespace LifeGame
{
    partial class FormLifeGame
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
            this.comboBoxRules = new System.Windows.Forms.ComboBox();
            this.lbSeed = new System.Windows.Forms.Label();
            this.lbGens = new System.Windows.Forms.Label();
            this.lbRules = new System.Windows.Forms.Label();
            this.lbColors = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.textBoxGens = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxColors = new System.Windows.Forms.ComboBox();
            this.panelPaint = new System.Windows.Forms.Panel();
            this.labelGens = new System.Windows.Forms.Label();
            this.labelHash = new System.Windows.Forms.Label();
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxRules
            // 
            this.comboBoxRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRules.FormattingEnabled = true;
            this.comboBoxRules.Items.AddRange(new object[] {
            "Orthogonal",
            "Diagonal",
            "Alternating"});
            this.comboBoxRules.Location = new System.Drawing.Point(265, 16);
            this.comboBoxRules.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRules.Name = "comboBoxRules";
            this.comboBoxRules.Size = new System.Drawing.Size(135, 24);
            this.comboBoxRules.TabIndex = 1;
            this.comboBoxRules.SelectedIndexChanged += new System.EventHandler(this.comboBoxRules_SelectedIndexChanged);
            // 
            // lbSeed
            // 
            this.lbSeed.AutoSize = true;
            this.lbSeed.Location = new System.Drawing.Point(16, 20);
            this.lbSeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSeed.Name = "lbSeed";
            this.lbSeed.Size = new System.Drawing.Size(41, 17);
            this.lbSeed.TabIndex = 2;
            this.lbSeed.Text = "Seed";
            // 
            // lbGens
            // 
            this.lbGens.AutoSize = true;
            this.lbGens.Location = new System.Drawing.Point(16, 54);
            this.lbGens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGens.Name = "lbGens";
            this.lbGens.Size = new System.Drawing.Size(42, 17);
            this.lbGens.TabIndex = 3;
            this.lbGens.Text = "Gens";
            // 
            // lbRules
            // 
            this.lbRules.AutoSize = true;
            this.lbRules.Location = new System.Drawing.Point(211, 20);
            this.lbRules.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRules.Name = "lbRules";
            this.lbRules.Size = new System.Drawing.Size(44, 17);
            this.lbRules.TabIndex = 4;
            this.lbRules.Text = "Rules";
            // 
            // lbColors
            // 
            this.lbColors.AutoSize = true;
            this.lbColors.Location = new System.Drawing.Point(211, 54);
            this.lbColors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbColors.Name = "lbColors";
            this.lbColors.Size = new System.Drawing.Size(48, 17);
            this.lbColors.TabIndex = 5;
            this.lbColors.Text = "Colors";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Location = new System.Drawing.Point(71, 16);
            this.textBoxSeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSeed.MaxLength = 11;
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(116, 22);
            this.textBoxSeed.TabIndex = 6;
            this.textBoxSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxGens
            // 
            this.textBoxGens.Location = new System.Drawing.Point(71, 50);
            this.textBoxGens.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGens.MaxLength = 10;
            this.textBoxGens.Name = "textBoxGens";
            this.textBoxGens.Size = new System.Drawing.Size(116, 22);
            this.textBoxGens.TabIndex = 7;
            this.textBoxGens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(464, 12);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 50);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // comboBoxColors
            // 
            this.comboBoxColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColors.FormattingEnabled = true;
            this.comboBoxColors.Items.AddRange(new object[] {
            "Rainbow",
            "Vampire",
            "Spring"});
            this.comboBoxColors.Location = new System.Drawing.Point(267, 49);
            this.comboBoxColors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxColors.Name = "comboBoxColors";
            this.comboBoxColors.Size = new System.Drawing.Size(133, 24);
            this.comboBoxColors.TabIndex = 10;
            this.comboBoxColors.SelectedIndexChanged += new System.EventHandler(this.comboBoxColors_SelectedIndexChanged);
            // 
            // panelPaint
            // 
            this.panelPaint.Location = new System.Drawing.Point(1, 92);
            this.panelPaint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPaint.Name = "panelPaint";
            this.panelPaint.Size = new System.Drawing.Size(853, 591);
            this.panelPaint.TabIndex = 11;
            this.panelPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPaint_Paint);
            // 
            // labelGens
            // 
            this.labelGens.AutoSize = true;
            this.labelGens.Location = new System.Drawing.Point(5, 692);
            this.labelGens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGens.Name = "labelGens";
            this.labelGens.Size = new System.Drawing.Size(46, 17);
            this.labelGens.TabIndex = 12;
            this.labelGens.Text = "label1";
            // 
            // labelHash
            // 
            this.labelHash.AutoSize = true;
            this.labelHash.Location = new System.Drawing.Point(60, 692);
            this.labelHash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(46, 17);
            this.labelHash.TabIndex = 13;
            this.labelHash.Text = "label2";
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.lbSeed);
            this.panelControl.Controls.Add(this.lbGens);
            this.panelControl.Controls.Add(this.textBoxSeed);
            this.panelControl.Controls.Add(this.button2);
            this.panelControl.Controls.Add(this.comboBoxColors);
            this.panelControl.Controls.Add(this.btnReset);
            this.panelControl.Controls.Add(this.textBoxGens);
            this.panelControl.Controls.Add(this.lbColors);
            this.panelControl.Controls.Add(this.comboBoxRules);
            this.panelControl.Controls.Add(this.lbRules);
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(855, 92);
            this.panelControl.TabIndex = 14;
            // 
            // FormLifeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 719);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.labelHash);
            this.Controls.Add(this.labelGens);
            this.Controls.Add(this.panelPaint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormLifeGame";
            this.Text = "LifeGame";
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRules;
        private System.Windows.Forms.Label lbSeed;
        private System.Windows.Forms.Label lbGens;
        private System.Windows.Forms.Label lbRules;
        private System.Windows.Forms.Label lbColors;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.TextBox textBoxGens;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxColors;
        private System.Windows.Forms.Panel panelPaint;
        private System.Windows.Forms.Label labelGens;
        private System.Windows.Forms.Label labelHash;
        private System.Windows.Forms.Panel panelControl;
    }
}

