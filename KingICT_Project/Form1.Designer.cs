namespace KingICT_Project
{
    partial class UiMainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UiOriginIataCodeGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.UiOriginSearchTextBox = new System.Windows.Forms.TextBox();
            this.UiDepartureDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.UiCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UiDestinationButton = new System.Windows.Forms.Button();
            this.UiOriginButton = new System.Windows.Forms.Button();
            this.UiSearchButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UiSearchResultDataGridView = new System.Windows.Forms.DataGridView();
            this.UiCurrentSelectionListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiOriginIataCodeGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiSearchResultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UiCurrentSelectionListBox);
            this.groupBox1.Controls.Add(this.UiSearchButton);
            this.groupBox1.Controls.Add(this.UiOriginButton);
            this.groupBox1.Controls.Add(this.UiDestinationButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UiCurrencyComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.UiDepartureDateTimePicker);
            this.groupBox1.Controls.Add(this.UiOriginSearchTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UiOriginIataCodeGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 491);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight properties";
            // 
            // UiOriginIataCodeGridView
            // 
            this.UiOriginIataCodeGridView.AllowUserToAddRows = false;
            this.UiOriginIataCodeGridView.AllowUserToDeleteRows = false;
            this.UiOriginIataCodeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UiOriginIataCodeGridView.Location = new System.Drawing.Point(6, 58);
            this.UiOriginIataCodeGridView.Name = "UiOriginIataCodeGridView";
            this.UiOriginIataCodeGridView.ReadOnly = true;
            this.UiOriginIataCodeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UiOriginIataCodeGridView.Size = new System.Drawing.Size(230, 230);
            this.UiOriginIataCodeGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Airport";
            // 
            // UiOriginSearchTextBox
            // 
            this.UiOriginSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.UiOriginSearchTextBox.Location = new System.Drawing.Point(88, 34);
            this.UiOriginSearchTextBox.Name = "UiOriginSearchTextBox";
            this.UiOriginSearchTextBox.Size = new System.Drawing.Size(148, 20);
            this.UiOriginSearchTextBox.TabIndex = 2;
            // 
            // UiDepartureDateTimePicker
            // 
            this.UiDepartureDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UiDepartureDateTimePicker.Location = new System.Drawing.Point(115, 384);
            this.UiDepartureDateTimePicker.Name = "UiDepartureDateTimePicker";
            this.UiDepartureDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.UiDepartureDateTimePicker.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(3, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Departure Date";
            // 
            // UiCurrencyComboBox
            // 
            this.UiCurrencyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UiCurrencyComboBox.FormattingEnabled = true;
            this.UiCurrencyComboBox.Location = new System.Drawing.Point(115, 417);
            this.UiCurrencyComboBox.Name = "UiCurrencyComboBox";
            this.UiCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.UiCurrencyComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(3, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Currency";
            // 
            // UiDestinationButton
            // 
            this.UiDestinationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UiDestinationButton.Location = new System.Drawing.Point(121, 294);
            this.UiDestinationButton.Name = "UiDestinationButton";
            this.UiDestinationButton.Size = new System.Drawing.Size(115, 23);
            this.UiDestinationButton.TabIndex = 13;
            this.UiDestinationButton.Text = "Destination >>";
            this.UiDestinationButton.UseVisualStyleBackColor = true;
            // 
            // UiOriginButton
            // 
            this.UiOriginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UiOriginButton.Location = new System.Drawing.Point(6, 294);
            this.UiOriginButton.Name = "UiOriginButton";
            this.UiOriginButton.Size = new System.Drawing.Size(115, 23);
            this.UiOriginButton.TabIndex = 14;
            this.UiOriginButton.Text = "Origin >>";
            this.UiOriginButton.UseVisualStyleBackColor = true;
            // 
            // UiSearchButton
            // 
            this.UiSearchButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.UiSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UiSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UiSearchButton.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.UiSearchButton.Location = new System.Drawing.Point(159, 444);
            this.UiSearchButton.Name = "UiSearchButton";
            this.UiSearchButton.Size = new System.Drawing.Size(77, 27);
            this.UiSearchButton.TabIndex = 15;
            this.UiSearchButton.Text = "Search";
            this.UiSearchButton.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UiSearchResultDataGridView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(291, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 491);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search results";
            // 
            // UiSearchResultDataGridView
            // 
            this.UiSearchResultDataGridView.AllowUserToAddRows = false;
            this.UiSearchResultDataGridView.AllowUserToDeleteRows = false;
            this.UiSearchResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UiSearchResultDataGridView.Location = new System.Drawing.Point(6, 48);
            this.UiSearchResultDataGridView.Name = "UiSearchResultDataGridView";
            this.UiSearchResultDataGridView.ReadOnly = true;
            this.UiSearchResultDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UiSearchResultDataGridView.Size = new System.Drawing.Size(485, 437);
            this.UiSearchResultDataGridView.TabIndex = 0;
            // 
            // UiCurrentSelectionListBox
            // 
            this.UiCurrentSelectionListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UiCurrentSelectionListBox.FormattingEnabled = true;
            this.UiCurrentSelectionListBox.ItemHeight = 16;
            this.UiCurrentSelectionListBox.Location = new System.Drawing.Point(6, 323);
            this.UiCurrentSelectionListBox.Name = "UiCurrentSelectionListBox";
            this.UiCurrentSelectionListBox.Size = new System.Drawing.Size(230, 20);
            this.UiCurrentSelectionListBox.TabIndex = 16;
            // 
            // UiMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UiMainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheapest Flights";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiOriginIataCodeGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiSearchResultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox UiOriginSearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView UiOriginIataCodeGridView;
        private System.Windows.Forms.Button UiDestinationButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox UiCurrencyComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker UiDepartureDateTimePicker;
        private System.Windows.Forms.Button UiSearchButton;
        private System.Windows.Forms.Button UiOriginButton;
        private System.Windows.Forms.ListBox UiCurrentSelectionListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView UiSearchResultDataGridView;
    }
}

