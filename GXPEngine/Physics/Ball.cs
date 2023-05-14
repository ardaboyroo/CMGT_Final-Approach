using System;
using System.Security.Cryptography;
using GXPEngine;

public class Ball : EasyDraw
{
    // These four public static fields are changed from MyGame, based on key input (see Console):
    public static bool drawDebugLine = false;
    public static bool wordy = false;
    public static float bounciness = 0.98f;
    // For ease of testing / changing, we assume every ball has the same acceleration (gravity):
    public static Vec2 acceleration = new Vec2(0, 0.25f);

    public Vec2 velocity;
    public Vec2 position;

    public readonly int radius;
    public readonly bool moving;

    MyGame myGame;

    // Mass = density * volume.
    // In 2D, we assume volume = area (=all objects are assumed to have the same "depth")
    public float Mass
    {
        get
        {
            return radius * radius * _density;
        }
    }

    Vec2 _oldPosition;
    Arrow _velocityIndicator;

    float _density = 1;

    public Ball(int pRadius, Vec2 pPosition, Vec2 pVelocity = new Vec2(), bool moving = true, int color = 230) : base(pRadius * 2 + 1, pRadius * 2 + 1)
    {
        myGame = (MyGame)game;
        myGame.movers.Add(this);
        radius = pRadius;
        position = pPosition;
        velocity = pVelocity;
        this.moving = moving;

        position = pPosition;
        UpdateScreenPosition();
        SetOrigin(radius, radius);

        Draw((byte)color, 200, 0);

        _velocityIndicator = new Arrow(position, new Vec2(0, 0), 10);
        AddChild(_velocityIndicator);
    }

    void Draw(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(radius, radius, 2 * radius, 2 * radius);
    }

    void UpdateScreenPosition()
    {
        x = position.x;
        y = position.y;
    }

    public void Step()
    {
        //Console.WriteLine($"X: {x} Y: {y}");

        velocity += acceleration;
        _oldPosition = position;
        position += velocity;
        // This can be removed after adding line segment collision detection:
        //BoundaryWrapAround();

        if (velocity.Length() > 0)      // Don't resolve collision if not moving
        {

            CollisionInfo firstCollision = FindEarliestCollision();
            if (firstCollision != null)
            {
                ResolveCollision(firstCollision);
            }

        }

        UpdateScreenPosition();

        //oldPosition = position;

        ShowDebugInfo();
    }

    float TimeOfImpact(Vec2 relativePositionStart, Vec2 movingBallVelocity, float sumRadii)
    {
        Vec2 u = relativePositionStart;
        float a = Mathf.Pow(movingBallVelocity.Length(), 2);
        float b = u.Dot(movingBallVelocity) * 2;
        float c = Mathf.Pow(u.Length(), 2) - Mathf.Pow(sumRadii, 2);

        float D = (b * b) - 4 * a * c;

        float min = (-b - Mathf.Sqrt(D)) / (2 * a);
        float max = (-b + Mathf.Sqrt(D)) / (2 * a);
        if (min <= max)
        {
            return min;
        }
        else
        {
            return max;
        }
    }

    Vec2 PointOfImpact(float t)
    {
        if (t <= 1 && t >= 0)
        {
            return _oldPosition + velocity * t;
        }
        else
        {
            return _oldPosition + velocity;
        }
    }

    Vec2 PointOfImpactDiscrete(CollisionInfo col)
    {
        return col.normal * -(col.timeOfImpact - radius);
    }

    CollisionInfo FindEarliestCollision()
    {
        MyGame myGame = (MyGame)game;
        // Check other movers:			
        for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
        {
            Ball mover = myGame.GetMover(i);
            if (mover != this)
            {
                Vec2 relativePosition = position - mover.position;
                if (relativePosition.Length() < radius + mover.radius)
                {
                    // TODO: compute correct normal and time of impact, and 
                    // 		 return *earliest* collision instead of *first detected collision*:

                    float toi = 0; // TODO TimeOfImpact(_oldPosition - mover.position, , mover);

                    Console.WriteLine(toi);
                    return new CollisionInfo(relativePosition, mover, toi); //TODO: different normal
                    // TODO: Don't *return* here!
                }
            }
        }
        // TODO: Check Line segments using myGame.GetLine();

        for (int i = 0; i < myGame.GetNumberOfLines(); i++)
        {
            LineSegment _lineSegment = myGame.GetLine(i);

            Vec2 differenceVector = position - _lineSegment.start;
            Vec2 lineVector = (_lineSegment.end - _lineSegment.start);
            Vec2 lineNormal = lineVector.Normal();
            float ballDistance = differenceVector.Dot(lineNormal);

            bool pastLeftSideOfTheLine = differenceVector.Dot(lineVector.Normalized()) < 0; // returns if ball side is past the left point of the line
            bool pastRightSideOfTheLine = differenceVector.Dot(lineVector.Normalized()) > lineVector.Length(); // returns if ball side is past the right point of the line


            if (ballDistance < radius && ballDistance > -radius && !pastLeftSideOfTheLine && !pastRightSideOfTheLine)
            {
                if (!(ballDistance < 0))
                {
                    return new CollisionInfo(lineVector.Normalized().Normal(), _lineSegment, ballDistance);
                }
                else
                {
                    return new CollisionInfo(lineVector.Normalized().Normal(true), _lineSegment, -ballDistance);
                }
            }
        }

        return null;
    }

    void ResolveCollision(CollisionInfo col)
    {
        // TODO: resolve the collision correctly: position reset & velocity reflection.
        // ...this is not an ideal collision resolve:
        if (col.other is Ball)
        {
            position.SetXY(PointOfImpact(col.timeOfImpact));
            Vec2 colSurface = col.normal.Normal();
            velocity.Reflect(col.normal);
        }
        if (col.other is LineSegment)
        {
            position += PointOfImpactDiscrete(col);
            velocity.Reflect(col.normal);

        }
    }

    void BoundaryWrapAround()
    {
        if (position.x < 0)
        {
            position.x += game.width;
        }
        if (position.x > game.width)
        {
            position.x -= game.width;
        }
        if (position.y < 0)
        {
            position.y += game.height;
        }
        if (position.y > game.height)
        {
            position.y -= game.height;
        }
    }

    void ShowDebugInfo()
    {
        if (drawDebugLine)
        {
            ((MyGame)game).DrawLine(_oldPosition, position);
        }
        _velocityIndicator.startPoint = position;
        _velocityIndicator.vector = velocity;
    }
}

