namespace MarioJumpGame;

public partial class MainForm : Form
{
    private readonly Timer gameTimer = new() { Interval = 20 };
    private readonly Random random = new();
    private readonly List<Rectangle> obstacles = new();

    private readonly Rectangle leftWall;
    private readonly Rectangle rightWall;

    private Rectangle mario;
    private float marioVelocityY;
    private bool gameOver;

    private const float Gravity = 1.0f;
    private const float JumpForce = -16f;
    private const int GroundHeight = 440;
    private const int ObstacleWidth = 36;
    private const int ObstacleMinHeight = 40;
    private const int ObstacleMaxHeight = 140;
    private const int ObstacleSpeed = 8;
    private const int SpawnChance = 8;

    private DateTime gameStart;

    public MainForm()
    {
        InitializeComponent();

        mario = new Rectangle(140, GroundHeight - 48, 42, 48);
        leftWall = new Rectangle(80, 100, 14, 360);
        rightWall = new Rectangle(840, 100, 14, 360);

        gameStart = DateTime.Now;

        gameTimer.Tick += GameLoop;
        gameTimer.Start();
    }

    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Space)
        {
            return;
        }

        if (gameOver)
        {
            RestartGame();
            return;
        }

        bool isOnGround = mario.Y >= GroundHeight - mario.Height;
        if (isOnGround)
        {
            marioVelocityY = JumpForce;
        }
    }

    private void GameLoop(object? sender, EventArgs e)
    {
        if (gameOver)
        {
            return;
        }

        UpdateMarioPhysics();
        UpdateObstacles();
        CheckCollision();
        UpdateScore();

        Invalidate();
    }

    private void UpdateMarioPhysics()
    {
        marioVelocityY += Gravity;
        mario.Y += (int)marioVelocityY;

        int groundY = GroundHeight - mario.Height;
        if (mario.Y > groundY)
        {
            mario.Y = groundY;
            marioVelocityY = 0;
        }
    }

    private void UpdateObstacles()
    {
        if (random.Next(100) < SpawnChance)
        {
            int height = random.Next(ObstacleMinHeight, ObstacleMaxHeight + 1);
            int y = GroundHeight - height;
            obstacles.Add(new Rectangle(rightWall.X - 25, y, ObstacleWidth, height));
        }

        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            Rectangle moved = obstacles[i];
            moved.X -= ObstacleSpeed;
            obstacles[i] = moved;

            if (moved.Right < leftWall.Right)
            {
                obstacles.RemoveAt(i);
            }
        }
    }

    private void CheckCollision()
    {
        foreach (Rectangle obstacle in obstacles)
        {
            if (mario.IntersectsWith(obstacle))
            {
                gameOver = true;
                gameTimer.Stop();
                lblStatus.Text = "Game over! Press SPACE to restart.";
                return;
            }
        }
    }

    private void UpdateScore()
    {
        double seconds = (DateTime.Now - gameStart).TotalSeconds;
        lblScore.Text = $"Score: {seconds:0.0}";
    }

    private void RestartGame()
    {
        obstacles.Clear();
        mario = new Rectangle(140, GroundHeight - 48, 42, 48);
        marioVelocityY = 0;
        gameOver = false;
        gameStart = DateTime.Now;
        lblStatus.Text = "Press SPACE to jump over obstacles.";
        lblScore.Text = "Score: 0.0";
        gameTimer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        using Brush wallBrush = new SolidBrush(Color.FromArgb(56, 56, 56));
        using Brush groundBrush = new SolidBrush(Color.FromArgb(34, 139, 34));
        using Brush obstacleBrush = new SolidBrush(Color.Crimson);
        using Brush marioBrush = new SolidBrush(Color.Red);
        using Brush marioHatBrush = new SolidBrush(Color.Blue);

        g.FillRectangle(groundBrush, 0, GroundHeight, ClientSize.Width, ClientSize.Height - GroundHeight);
        g.FillRectangle(wallBrush, leftWall);
        g.FillRectangle(wallBrush, rightWall);

        foreach (Rectangle obstacle in obstacles)
        {
            g.FillRectangle(obstacleBrush, obstacle);
        }

        g.FillRectangle(marioBrush, mario);

        Rectangle hat = new(mario.X, mario.Y, mario.Width, 10);
        g.FillRectangle(marioHatBrush, hat);

        if (gameOver)
        {
            using Font gameOverFont = new("Segoe UI", 24, FontStyle.Bold);
            using Brush textBrush = new SolidBrush(Color.White);
            string text = "MARIO IS DOWN!";
            SizeF size = g.MeasureString(text, gameOverFont);
            float x = (ClientSize.Width - size.Width) / 2;
            float y = 180;
            g.DrawString(text, gameOverFont, textBrush, x, y);
        }
    }
}
