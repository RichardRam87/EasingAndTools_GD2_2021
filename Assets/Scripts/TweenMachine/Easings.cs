﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Easings
{
    public static float Linear(float x)
    {
        return x;
    }
    public static float EaseInQuad(float x)
    {
        return x * x;
    }

    public static float EaseInCubic(float x)
    {
        return x * x * x;
    }

    public static float EaseInQuart(float x)
    {
        return x * x * x * x;
    }
    
    public static float EaseInQuint(float x)
    {
        return x * x * x * x * x;
    }
}
