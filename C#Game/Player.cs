using System;

public class Player
{
    public float x;
    public float y;
    public int direction;// 1 is up, 2 is down, 3 is right and 4 is left
    public float size;
    public float stay;

    public Player(float a, float b, float c)
    {
        direction = 3;//starting going right
        x = a;
        y = b;
        size = c;
        stay = c;

    }

    //set methods

    //pos
    public void update(float dt)
    {

        if(direction==1)//up
        {
            y = y - 10*dt;

        }
        else if (direction==2)//down
        {
            y = y + 10*dt;

        }
        else if (direction==3)//right
        {
            x = x + 10*dt;

        }
        else if (direction==4)//left
        {
            x = x - 10*dt;

        }

    }

    //direction
    public void changeDirection(int dir)
    {
        direction = dir;
    }

    //size

    public void grow()
    {
        size = size + 20;
    }

    //get methods
    public int getDirection()
    {
        return direction;
    }

    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;
    }

    public float getSize()
    {
        return size;
    }

    public float getHead()
    {
        return size;
    }

    public float getTail()
    {
        return stay;
    }

}