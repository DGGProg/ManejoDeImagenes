namespace ManejoDeImagenes
{
    partial class ControlHistogramas
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel26 = new System.Windows.Forms.Panel();
            this.Histograma_3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Histograma_2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Histograma_1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma_1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel26
            // 
            this.panel26.AutoScroll = true;
            this.panel26.Controls.Add(this.Histograma_3);
            this.panel26.Controls.Add(this.Histograma_2);
            this.panel26.Controls.Add(this.Histograma_1);
            this.panel26.Location = new System.Drawing.Point(3, 3);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(584, 634);
            this.panel26.TabIndex = 16;
            // 
            // Histograma_3
            // 
            this.Histograma_3.BorderlineColor = System.Drawing.Color.Black;
            this.Histograma_3.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.Histograma_3.ChartAreas.Add(chartArea1);
            this.Histograma_3.Location = new System.Drawing.Point(3, 432);
            this.Histograma_3.Name = "Histograma_3";
            this.Histograma_3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.Histograma_3.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Black;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.Histograma_3.Series.Add(series1);
            this.Histograma_3.Size = new System.Drawing.Size(577, 199);
            this.Histograma_3.TabIndex = 2;
            this.Histograma_3.Text = "chart1";
            // 
            // Histograma_2
            // 
            this.Histograma_2.BorderlineColor = System.Drawing.Color.Black;
            this.Histograma_2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.Histograma_2.ChartAreas.Add(chartArea2);
            this.Histograma_2.Location = new System.Drawing.Point(3, 218);
            this.Histograma_2.Name = "Histograma_2";
            this.Histograma_2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.Histograma_2.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Green};
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Black;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.Histograma_2.Series.Add(series2);
            this.Histograma_2.Size = new System.Drawing.Size(577, 199);
            this.Histograma_2.TabIndex = 1;
            this.Histograma_2.Text = "chart1";
            // 
            // Histograma_1
            // 
            this.Histograma_1.BorderlineColor = System.Drawing.Color.Black;
            this.Histograma_1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.AxisX.Maximum = 255D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.ScaleView.Zoomable = false;
            chartArea3.Name = "ChartArea1";
            this.Histograma_1.ChartAreas.Add(chartArea3);
            this.Histograma_1.Location = new System.Drawing.Point(4, 3);
            this.Histograma_1.Name = "Histograma_1";
            this.Histograma_1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.Histograma_1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Black;
            series3.IsVisibleInLegend = false;
            series3.Name = "Series1";
            this.Histograma_1.Series.Add(series3);
            this.Histograma_1.Size = new System.Drawing.Size(576, 199);
            this.Histograma_1.TabIndex = 0;
            this.Histograma_1.Text = "chart1";
            // 
            // ControlHistogramas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel26);
            this.Name = "ControlHistogramas";
            this.Size = new System.Drawing.Size(587, 638);
            this.panel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Histograma_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histograma_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.DataVisualization.Charting.Chart Histograma_3;
        private System.Windows.Forms.DataVisualization.Charting.Chart Histograma_2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Histograma_1;

    }
}
