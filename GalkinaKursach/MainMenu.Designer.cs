namespace GalkinaKursach
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.importDataTable = new System.Windows.Forms.DataGridView();
            this.resultDataTable = new System.Windows.Forms.DataGridView();
            this.averageResultDataTable = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фааToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.faqMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDataInfo = new System.Windows.Forms.Label();
            this.labelAverageDataInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averageResultDataTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(12, 489);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(312, 263);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            // 
            // importDataTable
            // 
            this.importDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.importDataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.importDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.importDataTable.Location = new System.Drawing.Point(12, 48);
            this.importDataTable.Name = "importDataTable";
            this.importDataTable.Size = new System.Drawing.Size(312, 422);
            this.importDataTable.TabIndex = 6;
            // 
            // resultDataTable
            // 
            this.resultDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultDataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataTable.Location = new System.Drawing.Point(342, 48);
            this.resultDataTable.Name = "resultDataTable";
            this.resultDataTable.Size = new System.Drawing.Size(588, 422);
            this.resultDataTable.TabIndex = 12;
            // 
            // averageResultDataTable
            // 
            this.averageResultDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.averageResultDataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.averageResultDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.averageResultDataTable.Location = new System.Drawing.Point(342, 489);
            this.averageResultDataTable.Name = "averageResultDataTable";
            this.averageResultDataTable.Size = new System.Drawing.Size(588, 263);
            this.averageResultDataTable.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Входные данные";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Общий анализ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Средние показатели";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фааToolStripMenuItem,
            this.analyzeMenuButton,
            this.faqMenuButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(950, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фааToolStripMenuItem
            // 
            this.фааToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMenuButton});
            this.фааToolStripMenuItem.Name = "фааToolStripMenuItem";
            this.фааToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.фааToolStripMenuItem.Text = "Файл";
            // 
            // importMenuButton
            // 
            this.importMenuButton.Name = "importMenuButton";
            this.importMenuButton.Size = new System.Drawing.Size(118, 22);
            this.importMenuButton.Text = "Импорт";
            this.importMenuButton.Click += new System.EventHandler(this.importMenuButton_Click);
            // 
            // analyzeMenuButton
            // 
            this.analyzeMenuButton.Name = "analyzeMenuButton";
            this.analyzeMenuButton.Size = new System.Drawing.Size(59, 20);
            this.analyzeMenuButton.Text = "Анализ";
            this.analyzeMenuButton.Click += new System.EventHandler(this.analyzeMenuButton_Click);
            // 
            // faqMenuButton
            // 
            this.faqMenuButton.Name = "faqMenuButton";
            this.faqMenuButton.Size = new System.Drawing.Size(65, 20);
            this.faqMenuButton.Text = "Справка";
            this.faqMenuButton.Click += new System.EventHandler(this.faqMenuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 767);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Примечание:";
            // 
            // labelDataInfo
            // 
            this.labelDataInfo.AutoSize = true;
            this.labelDataInfo.Location = new System.Drawing.Point(9, 794);
            this.labelDataInfo.Name = "labelDataInfo";
            this.labelDataInfo.Size = new System.Drawing.Size(28, 13);
            this.labelDataInfo.TabIndex = 20;
            this.labelDataInfo.Text = "data";
            // 
            // labelAverageDataInfo
            // 
            this.labelAverageDataInfo.AutoSize = true;
            this.labelAverageDataInfo.Location = new System.Drawing.Point(9, 819);
            this.labelAverageDataInfo.Name = "labelAverageDataInfo";
            this.labelAverageDataInfo.Size = new System.Drawing.Size(28, 13);
            this.labelAverageDataInfo.TabIndex = 21;
            this.labelAverageDataInfo.Text = "data";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 841);
            this.Controls.Add(this.labelAverageDataInfo);
            this.Controls.Add(this.labelDataInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.averageResultDataTable);
            this.Controls.Add(this.resultDataTable);
            this.Controls.Add(this.importDataTable);
            this.Controls.Add(this.chart);
            this.Name = "MainMenu";
            this.Text = "Исследование суточных показателей уровня загрязнения воздуха на предприятии";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averageResultDataTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView importDataTable;
        private System.Windows.Forms.DataGridView resultDataTable;
        private System.Windows.Forms.DataGridView averageResultDataTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фааToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuButton;
        private System.Windows.Forms.ToolStripMenuItem analyzeMenuButton;
        private System.Windows.Forms.ToolStripMenuItem faqMenuButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDataInfo;
        private System.Windows.Forms.Label labelAverageDataInfo;
    }
}

