namespace SimulationApp
{
    partial class MainForm
    {
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Button btnRunSimulation;

        private void InitializeComponent()
        {
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // txtParameter
            // 
            this.txtParameter.Location = new System.Drawing.Point(100, 50);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(150, 22);
            this.txtParameter.TabIndex = 1;

            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Location = new System.Drawing.Point(100, 100);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(150, 50);
            this.btnRunSimulation.TabIndex = 0;
            this.btnRunSimulation.Text = "Run Simulation";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.txtParameter);
            this.Controls.Add(this.btnRunSimulation);
            this.Name = "MainForm";
            this.Text = "Simulation App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
