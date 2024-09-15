using System;
using System.Drawing;
using System.Windows.Forms;

public class Game

{

    public Player player;
    public Boolean inGame;
    public Boolean gameOver;
    public int score;
    public int timer;
    public int mult;

    public void Setup()
    {
        score = 0;
        inGame = false;
        gameOver = false;
        player = new Player(100, 100, 35);
        timer = 0;
        mult = 1;

    }

    public void Update(float dt)
    {


        //if player is off screen, end game
        if (player.getX() == (float)(Window.width)|| player.getX() == 0|| player.getY() == (float)(Window.height) || player.getY() == 0)
        {
            endGame();
        }

        if (inGame == true)
        {
            score = score + 10 * (int)dt;

            if (timer== 40)
            {
                timer=0;
                mult = mult + 1;
            }
            else
            {
                timer = timer + 1;
            }

        }

    }


    public void Draw(Graphics g)

    {
        Update(1);
        //System.Console.WriteLine(player.getDirection());

        if (inGame == true)//game play screen
        {

            //player
            player.update(1);

            Color c = Color.FromArgb(120, 245, 145);
            Brush brush = new SolidBrush(c);
            int d = player.getDirection();
            float s1 = player.getHead();
            float s2 = player.getTail();
            float head;
            float tail;

            if (d == 1 || d == 2)
            {
                head = s2;
                tail = s1;
            }
            else
            {
                head = s1;
                tail = s2;
            }

            g.FillEllipse(brush, player.getX(), player.getY(), head, tail);

            //spawner
            Color c2 = Color.FromArgb(0,0,0);
            Brush brush2 = new SolidBrush(c2);
            g.FillRectangle(brush2, (float)(Window.width * 0.45), (float)(Window.height * 0.45), (float)(Window.width * 0.05), (float)(Window.height * 0.05));


            Color c3 = Color.FromArgb(250, 0, 0);
            Brush brush3 = new SolidBrush(c3);


            float ex1 = (float)(Window.width * 0.45) + timer * mult;
            float ey1 = (float)(Window.height * 0.45)+ timer * mult;

            float ex2 = (float)(Window.width * 0.45)+timer* mult;
            float ey2 = (float)(Window.height * 0.45)+timer*10*mult;

            float ex3 = (float)(Window.width * 0.45)-timer*10;
            float ey3 = (float)(Window.height * 0.45)+timer*mult;

            float ex4 = (float)(Window.width * 0.45)+timer*mult;
            float ey4 = (float)(Window.height * 0.45)-timer*mult;

            float ex5 = (float)(Window.width * 0.45) - timer*mult;
            float ey5 = (float)(Window.height * 0.45) - timer *10+mult;

            g.FillEllipse(brush3,ex1,ey1, 25, 25);
            g.FillEllipse(brush3,ex2, ey2, 25, 25);
            g.FillEllipse(brush3, ex3, ey3, 25, 25);
            g.FillEllipse(brush3, ex4, ey4, 25, 25);
            g.FillEllipse(brush3, ex5, ey5, 25, 25);




            bool caseA = player.getX() < ex1 + 20 && player.getX() > ex1 - 20 && player.getY() < ey1 + 20 && player.getY() > ey1 - 20;
            bool caseB = player.getX() < ex2 + 20 && player.getX() > ex2 - 20 && player.getY() < ey2 + 20 && player.getY() > ey2 - 20;
            bool caseC = player.getX() < ex3 + 20 && player.getX() > ex3 - 20 && player.getY() < ey3 + 20 && player.getY() > ey3 - 20;
            bool caseD = player.getX() < ex4 + 20 && player.getX() > ex4 - 20 && player.getY() < ey4 + 20 && player.getY() > ey4 - 20;
            bool caseE = player.getX() < ex5 + 20 && player.getX() > ex5 - 20 && player.getY() < ey5 + 20 && player.getY() > ey5 - 20;



            if (caseA==true||caseB==true||caseC==true||caseD==true||caseE==true)
            {
                endGame();
            }



        }
        else if(gameOver==true)//gameover screen
        {
            Font font = new Font("Arial", 30);
            SolidBrush fontBrush = new SolidBrush(Color.Black);

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            g.DrawString("Game Over\n\nFinal Score: "+score, font, fontBrush,
               (float)(Window.width * 0.5),
               (float)(Window.height * 0.5),
               format);

        }
        else// start screen
        {
            Color c = Color.FromArgb(100, 250, 0, 0); // button color
            Brush brush = new SolidBrush(c);
            g.FillRectangle(brush, (float)(Window.width * 0.25), (float)(Window.height * 0.25), (float)(Window.width * 0.50), (float)(Window.height * 0.5));

            Font font = new Font("Arial", 30);
            SolidBrush fontBrush = new SolidBrush(Color.White);

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            g.DrawString("Click to start", font, fontBrush,
               (float)(Window.width * 0.5),
               (float)(Window.height * 0.5),
               format);

        }

    }

    public void MouseClick(MouseEventArgs mouse)
    {
        float x1 = mouse.Location.X;
        float x2 = (float)(Window.width * 0.25);
        float x3 = (float)(Window.width * 0.75);
        float y1 = mouse.Location.Y;
        float y2 = (float)(Window.height * 0.25);
        float y3 = (float)(Window.height * 0.75);

        bool onButton = false;

        if(x1>x2&&x1<x3&&y1>y2&&y1<y3)
        {
            onButton = true;
        }

        if (mouse.Button == MouseButtons.Left)
        {
            System.Console.WriteLine(mouse.Location.X + ", " + mouse.Location.Y);

            if (gameOver == false && inGame == false&&onButton==true)
            {
                startGame();
            }
        }
    }

    public void KeyDown(KeyEventArgs key)
    {
        if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
        {

            if (player.getDirection() != 4&&player.getDirection()!=3)//if player isnt going the opposite direction/player cant go backwards
            {
                player.changeDirection(3);//player is now going right
            }
        }
        else if (key.KeyCode == Keys.S || key.KeyCode == Keys.Down)
        {
            if (player.getDirection() != 1&&player.getDirection()!=2)
            {
                player.changeDirection(2);//player is now going down
            }
        }
        else if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
        {
            if (player.getDirection()!= 3&&player.getDirection()!=4)
            {
                player.changeDirection(4);//player is now going left
            }
        }
        else if (key.KeyCode == Keys.W || key.KeyCode == Keys.Up)
        {
            if (player.getDirection()!= 2&&player.getDirection()!=1)
            {
                player.changeDirection(1);//player is now going up
            }
        }
    }

    public void startGame()
    {
        inGame = true;
    }

    public void endGame()
    {
        inGame = false;
        gameOver = true;
    }
}
