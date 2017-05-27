namespace Physics
{
    partial class MainWindow
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
            this.InputContainer = new System.Windows.Forms.TableLayoutPanel();
            this.HeightContainer = new System.Windows.Forms.TableLayoutPanel();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightInput = new System.Windows.Forms.RichTextBox();
            this.MassContainer = new System.Windows.Forms.TableLayoutPanel();
            this.MassLabel = new System.Windows.Forms.Label();
            this.MassInput = new System.Windows.Forms.RichTextBox();
            this.WindowContainer = new System.Windows.Forms.TableLayoutPanel();
            this.FormulaBox = new System.Windows.Forms.PictureBox();
            this.InputContainer.SuspendLayout();
            this.HeightContainer.SuspendLayout();
            this.MassContainer.SuspendLayout();
            this.WindowContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormulaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InputContainer
            // 
            this.InputContainer.ColumnCount = 4;
            this.InputContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InputContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InputContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InputContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InputContainer.Controls.Add(this.HeightContainer, 1, 0);
            this.InputContainer.Controls.Add(this.MassContainer, 0, 0);
            this.InputContainer.Controls.Add(this.FormulaBox, 0, 2);
            this.InputContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputContainer.Location = new System.Drawing.Point(3, 3);
            this.InputContainer.Name = "InputContainer";
            this.InputContainer.RowCount = 4;
            this.InputContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.InputContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.81482F));
            this.InputContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.81482F));
            this.InputContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.InputContainer.Size = new System.Drawing.Size(1000, 244);
            this.InputContainer.TabIndex = 0;
            // 
            // HeightContainer
            // 
            this.HeightContainer.ColumnCount = 2;
            this.HeightContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.HeightContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeightContainer.Controls.Add(this.HeightLabel, 0, 0);
            this.HeightContainer.Controls.Add(this.HeightInput, 1, 0);
            this.HeightContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeightContainer.Location = new System.Drawing.Point(253, 3);
            this.HeightContainer.Name = "HeightContainer";
            this.HeightContainer.RowCount = 1;
            this.HeightContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeightContainer.Size = new System.Drawing.Size(244, 48);
            this.HeightContainer.TabIndex = 2;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeightLabel.Location = new System.Drawing.Point(3, 0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(94, 48);
            this.HeightLabel.TabIndex = 0;
            this.HeightLabel.Text = "H0(m)";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeightInput
            // 
            this.HeightInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeightInput.Location = new System.Drawing.Point(103, 3);
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(138, 42);
            this.HeightInput.TabIndex = 1;
            this.HeightInput.Text = "";
            // 
            // MassContainer
            // 
            this.MassContainer.ColumnCount = 2;
            this.MassContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.MassContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MassContainer.Controls.Add(this.MassLabel, 0, 0);
            this.MassContainer.Controls.Add(this.MassInput, 1, 0);
            this.MassContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MassContainer.Location = new System.Drawing.Point(3, 3);
            this.MassContainer.Name = "MassContainer";
            this.MassContainer.RowCount = 1;
            this.MassContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MassContainer.Size = new System.Drawing.Size(244, 48);
            this.MassContainer.TabIndex = 0;
            // 
            // MassLabel
            // 
            this.MassLabel.AutoSize = true;
            this.MassLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MassLabel.Location = new System.Drawing.Point(3, 0);
            this.MassLabel.Name = "MassLabel";
            this.MassLabel.Size = new System.Drawing.Size(94, 48);
            this.MassLabel.TabIndex = 0;
            this.MassLabel.Text = "Mass(kg)";
            this.MassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MassInput
            // 
            this.MassInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MassInput.Location = new System.Drawing.Point(103, 3);
            this.MassInput.Name = "MassInput";
            this.MassInput.Size = new System.Drawing.Size(138, 42);
            this.MassInput.TabIndex = 1;
            this.MassInput.Text = "";
            // 
            // WindowContainer
            // 
            this.WindowContainer.ColumnCount = 1;
            this.WindowContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowContainer.Controls.Add(this.InputContainer, 0, 0);
            this.WindowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowContainer.Location = new System.Drawing.Point(0, 0);
            this.WindowContainer.Name = "WindowContainer";
            this.WindowContainer.RowCount = 2;
            this.WindowContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.WindowContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowContainer.Size = new System.Drawing.Size(1006, 753);
            this.WindowContainer.TabIndex = 1;
            // 
            // FormulaBox
            // 
            this.FormulaBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FormulaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormulaBox.Image = global::Physics.Properties.Resources.Formula;
            this.FormulaBox.Location = new System.Drawing.Point(3, 111);
            this.FormulaBox.Name = "FormulaBox";
            this.InputContainer.SetRowSpan(this.FormulaBox, 2);
            this.FormulaBox.Size = new System.Drawing.Size(244, 130);
            this.FormulaBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FormulaBox.TabIndex = 3;
            this.FormulaBox.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 753);
            this.Controls.Add(this.WindowContainer);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainWindow";
            this.Text = "Physics";
            this.InputContainer.ResumeLayout(false);
            this.HeightContainer.ResumeLayout(false);
            this.HeightContainer.PerformLayout();
            this.MassContainer.ResumeLayout(false);
            this.MassContainer.PerformLayout();
            this.WindowContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormulaBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel InputContainer;
        private System.Windows.Forms.TableLayoutPanel MassContainer;
        private System.Windows.Forms.Label MassLabel;
        private System.Windows.Forms.RichTextBox MassInput;
        private System.Windows.Forms.TableLayoutPanel WindowContainer;
        private System.Windows.Forms.TableLayoutPanel HeightContainer;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.RichTextBox HeightInput;
        private System.Windows.Forms.PictureBox FormulaBox;
    }
}

