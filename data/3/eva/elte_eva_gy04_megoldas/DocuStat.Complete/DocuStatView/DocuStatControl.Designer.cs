namespace ELTE.DocuStat.View
{
    partial class DocuStatControl
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
            labelSentences = new System.Windows.Forms.Label();
            labelNonWhitespaceCharacters = new System.Windows.Forms.Label();
            textBoxIgnoredWords = new System.Windows.Forms.TextBox();
            spinBoxMinOccurrence = new System.Windows.Forms.NumericUpDown();
            spinBoxMinLength = new System.Windows.Forms.NumericUpDown();
            labelFleschReadingEase = new System.Windows.Forms.Label();
            labelColemanLieuIndex = new System.Windows.Forms.Label();
            labelProperNouns = new System.Windows.Forms.Label();
            labelCharacters = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            listBoxCounter = new System.Windows.Forms.ListBox();
            textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinOccurrence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinLength).BeginInit();
            SuspendLayout();
            // 
            // labelSentences
            // 
            labelSentences.AutoSize = true;
            labelSentences.Location = new System.Drawing.Point(83, 663);
            labelSentences.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSentences.Name = "labelSentences";
            labelSentences.Size = new System.Drawing.Size(137, 25);
            labelSentences.TabIndex = 28;
            labelSentences.Text = "Sentence count:";
            // 
            // labelNonWhitespaceCharacters
            // 
            labelNonWhitespaceCharacters.AutoSize = true;
            labelNonWhitespaceCharacters.Location = new System.Drawing.Point(83, 598);
            labelNonWhitespaceCharacters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelNonWhitespaceCharacters.Name = "labelNonWhitespaceCharacters";
            labelNonWhitespaceCharacters.Size = new System.Drawing.Size(228, 25);
            labelNonWhitespaceCharacters.TabIndex = 27;
            labelNonWhitespaceCharacters.Text = "Non-whitespace characters:";
            // 
            // textBoxIgnoredWords
            // 
            textBoxIgnoredWords.Location = new System.Drawing.Point(846, 658);
            textBoxIgnoredWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxIgnoredWords.Name = "textBoxIgnoredWords";
            textBoxIgnoredWords.Size = new System.Drawing.Size(276, 31);
            textBoxIgnoredWords.TabIndex = 26;
            // 
            // spinBoxMinOccurrence
            // 
            spinBoxMinOccurrence.Location = new System.Drawing.Point(953, 594);
            spinBoxMinOccurrence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            spinBoxMinOccurrence.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            spinBoxMinOccurrence.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            spinBoxMinOccurrence.Name = "spinBoxMinOccurrence";
            spinBoxMinOccurrence.Size = new System.Drawing.Size(171, 31);
            spinBoxMinOccurrence.TabIndex = 25;
            spinBoxMinOccurrence.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // spinBoxMinLength
            // 
            spinBoxMinLength.Location = new System.Drawing.Point(953, 529);
            spinBoxMinLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            spinBoxMinLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            spinBoxMinLength.Name = "spinBoxMinLength";
            spinBoxMinLength.Size = new System.Drawing.Size(171, 31);
            spinBoxMinLength.TabIndex = 24;
            spinBoxMinLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelFleschReadingEase
            // 
            labelFleschReadingEase.AutoSize = true;
            labelFleschReadingEase.Location = new System.Drawing.Point(386, 663);
            labelFleschReadingEase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFleschReadingEase.Name = "labelFleschReadingEase";
            labelFleschReadingEase.Size = new System.Drawing.Size(173, 25);
            labelFleschReadingEase.TabIndex = 23;
            labelFleschReadingEase.Text = "Flesch Reading Ease:";
            // 
            // labelColemanLieuIndex
            // 
            labelColemanLieuIndex.AutoSize = true;
            labelColemanLieuIndex.Location = new System.Drawing.Point(386, 598);
            labelColemanLieuIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelColemanLieuIndex.Name = "labelColemanLieuIndex";
            labelColemanLieuIndex.Size = new System.Drawing.Size(170, 25);
            labelColemanLieuIndex.TabIndex = 22;
            labelColemanLieuIndex.Text = "Coleman Lieu Index:";
            // 
            // labelProperNouns
            // 
            labelProperNouns.AutoSize = true;
            labelProperNouns.Location = new System.Drawing.Point(386, 533);
            labelProperNouns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelProperNouns.Name = "labelProperNouns";
            labelProperNouns.Size = new System.Drawing.Size(165, 25);
            labelProperNouns.TabIndex = 21;
            labelProperNouns.Text = "Proper noun count:";
            // 
            // labelCharacters
            // 
            labelCharacters.AutoSize = true;
            labelCharacters.Location = new System.Drawing.Point(83, 533);
            labelCharacters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelCharacters.Name = "labelCharacters";
            labelCharacters.Size = new System.Drawing.Size(140, 25);
            labelCharacters.TabIndex = 20;
            labelCharacters.Text = "Character count:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(711, 663);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(133, 25);
            label3.TabIndex = 19;
            label3.Text = "Ignored words:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(711, 598);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(228, 25);
            label2.TabIndex = 18;
            label2.Text = "Minimum word occurrence:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(711, 533);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(193, 25);
            label1.TabIndex = 17;
            label1.Text = "Minimum word length:";
            // 
            // listBoxCounter
            // 
            listBoxCounter.FormattingEnabled = true;
            listBoxCounter.ItemHeight = 25;
            listBoxCounter.Location = new System.Drawing.Point(646, 28);
            listBoxCounter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            listBoxCounter.Name = "listBoxCounter";
            listBoxCounter.Size = new System.Drawing.Size(543, 479);
            listBoxCounter.TabIndex = 16;
            // 
            // textBox
            // 
            textBox.Location = new System.Drawing.Point(83, 28);
            textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox.Size = new System.Drawing.Size(554, 479);
            textBox.TabIndex = 15;
            // 
            // DocuStatControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(labelSentences);
            Controls.Add(labelNonWhitespaceCharacters);
            Controls.Add(textBoxIgnoredWords);
            Controls.Add(spinBoxMinOccurrence);
            Controls.Add(spinBoxMinLength);
            Controls.Add(labelFleschReadingEase);
            Controls.Add(labelColemanLieuIndex);
            Controls.Add(labelProperNouns);
            Controls.Add(labelCharacters);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxCounter);
            Controls.Add(textBox);
            Name = "DocuStatControl";
            Size = new System.Drawing.Size(1273, 717);
            ((System.ComponentModel.ISupportInitialize)spinBoxMinOccurrence).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelSentences;
        private System.Windows.Forms.Label labelNonWhitespaceCharacters;
        private System.Windows.Forms.TextBox textBoxIgnoredWords;
        private System.Windows.Forms.NumericUpDown spinBoxMinOccurrence;
        private System.Windows.Forms.NumericUpDown spinBoxMinLength;
        private System.Windows.Forms.Label labelFleschReadingEase;
        private System.Windows.Forms.Label labelColemanLieuIndex;
        private System.Windows.Forms.Label labelProperNouns;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxCounter;
        private System.Windows.Forms.TextBox textBox;
    }
}
