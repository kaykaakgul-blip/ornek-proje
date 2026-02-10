#nullable enable

namespace MarioJumpGame;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblScore = null!;
    private Label lblStatus = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblScore = new Label();
        lblStatus = new Label();

        SuspendLayout();
        // 
        // lblScore
        // 
        lblScore.AutoSize = true;
        lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblScore.ForeColor = Color.White;
        lblScore.Location = new Point(12, 9);
        lblScore.Name = "lblScore";
        lblScore.Size = new Size(84, 21);
        lblScore.TabIndex = 0;
        lblScore.Text = "Score: 0.0";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblStatus.ForeColor = Color.Gold;
        lblStatus.Location = new Point(12, 35);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(261, 19);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "Press SPACE to jump over obstacles.";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(960, 540);
        Controls.Add(lblStatus);
        Controls.Add(lblScore);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Mario Jump - Beginner C# Game";
        KeyDown += MainForm_KeyDown;
        ResumeLayout(false);
        PerformLayout();
    }
}
