using System;
using GXPEngine;	// For Mathf

public struct Vec2
{
    public float x;
    public float y;

    public Vec2(float pX = 0, float pY = 0)
    {
        x = pX;
        y = pY;
    }

    public override string ToString()
    {
        return String.Format("( {0}  ,  {1} )", x, y);
    }

    public void SetXY(float pX, float pY)
    {
        x = pX;
        y = pY;
    }
    public void SetXY(Vec2 vec)
    {
        x = vec.x;
        y = vec.y;
    }

    public float Length()
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float len = Length();
        if (len > 0)
        {
            x /= len;
            y /= len;
        }
    }

    public Vec2 Normalized()
    {
        Vec2 result = new Vec2(x, y);
        result.Normalize();
        return result;
    }

    public float Dot(Vec2 other)
    {
        return x * other.x + y * other.y;
    }

    public Vec2 Normal(bool reversed = false)
    {
        if (!reversed)
        {
            return new Vec2(-y, x).Normalized();
        }
        else
        {
            return new Vec2(y, -x).Normalized();
        }
    }

    public void Reflect(Vec2 pNormal, float pBounciness = 1)
    {
        this -= (1 + pBounciness) * (Dot(pNormal.Normalized()) * pNormal.Normalized());
    }

    public float ScalarProjection(Vec2 scalar)
    {
        Vec2 dot = new Vec2(x, y);
        return dot.Dot(scalar.Normalized());
    }

    public Vec2 UnitNormal()
    {
        Vec2 unitNormal = new Vec2(x, y);
        unitNormal.Normalized();
        return unitNormal.Normal();
    }

    public static Vec2 operator +(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x + right.x, left.y + right.y);
    }

    public static Vec2 operator -(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x - right.x, left.y - right.y);
    }

    public static Vec2 operator -(Vec2 left, int right)
    {
        return new Vec2(left.x - right, left.y - right);
    }

    public static Vec2 operator -(int left, Vec2 right)
    {
        return new Vec2(left - right.x, left - right.y);
    }

    public static Vec2 operator *(Vec2 v, float scalar)
    {
        return new Vec2(v.x * scalar, v.y * scalar);
    }

    public static Vec2 operator *(float scalar, Vec2 v)
    {
        return new Vec2(v.x * scalar, v.y * scalar);
    }

    public static Vec2 operator /(Vec2 v, float scalar)
    {
        return new Vec2(v.x / scalar, v.y / scalar);
    }

    public static bool operator ==(Vec2 vec1, Vec2 vec2)
    {
        if (vec1.x == vec2.x && vec1.y == vec2.y) return true;
        else return false;
    }

    public static bool operator !=(Vec2 vec1, Vec2 vec2)
    {
        if (vec1.x != vec2.x || vec1.y != vec2.y) return true;
        else return false;
    }

    public void SetAngleDegrees(float angle)
    {
        float length = Length();
        SetXY(GetUnitVectorDeg(angle));
        x *= length;
        y *= length;
    }

    public void SetAngleRadians(float angle)
    {
        float length = Length();
        SetXY(GetUnitVectorRad(angle));
        x *= length;
        y *= length;
    }

    public float GetAngleRadians()
    {
        return Mathf.Atan2(y, x);
    }
    public float GetAngleDegrees()
    {
        return Rad2Deg(Mathf.Atan2(y, x));
    }

    public void RotateDegrees(float angle)
    {
        SetAngleDegrees(GetAngleDegrees() + angle);
    }
    public void RotateRadians(float angle)
    {
        SetAngleRadians(GetAngleRadians() + angle);
    }

    public void RotateAroundDegrees(float angle, Vec2 point)
    {
        Vec2 offset = this - point;
        offset.RotateDegrees(angle);
        this = point + offset;
    }
    public void RotateAroundRadians(float angle, Vec2 point)
    {
        Vec2 offset = this - point;
        offset.RotateRadians(angle);
        this = point + offset;
    }

    public static float CompareFloats(float a, float threshold = 0.000001f)
    {
        // make so that small floats become 0
        return a <= threshold && a >= -threshold ? 0.0f : a;
    }

    public static float Deg2Rad(float angle)
    {
        return angle * (Mathf.PI / 180f);
    }

    public static float Rad2Deg(float angle)
    {
        return angle * (180f / Mathf.PI);
    }

    public static Vec2 GetUnitVectorDeg(float angle)
    {
        float Angle = Deg2Rad(angle);
        return new Vec2(CompareFloats(Mathf.Cos(Angle), 0.000001f),
                        CompareFloats(Mathf.Sin(Angle), 0.000001f));
    }

    public static Vec2 GetUnitVectorRad(float angle)
    {
        return new Vec2(CompareFloats(Mathf.Cos(angle), 0.000001f),
                        CompareFloats(Mathf.Sin(angle), 0.000001f)
        );
    }

    public static Vec2 RandomUnitVector()
    {
        double randNum = new Random().Next() / 100000f;

        return new Vec2(CompareFloats(Mathf.Cos((float)randNum * (Mathf.PI * 2))),
                        CompareFloats(Mathf.Sin((float)randNum * (Mathf.PI * 2)))
        );
    }
}