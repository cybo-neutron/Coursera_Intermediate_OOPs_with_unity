using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configData.BallImpulseForce; }
    }

    public static float BallTimer
    {
        get
        {
            //return configData.BallTimer;
            return ConfigurationData.ballTimer;
        }
    }

    public static float minBallSpawnTime
    {
        get { return ConfigurationData.minBallSpawnTime; }
    }

    public static float maxBallSpawnTime
    {
        get { return ConfigurationData.maxBallSpawnTime; }
    }

    public static float blockPoints
    {
        get { return ConfigurationData.blockPoints; }
    }

    public static float bonusBlockPoints
    {
        get { return ConfigurationData.bonusBlockPoints; }
    }

    public static float pickupBlockPoints
    {
        get { return ConfigurationData.pickupBlockPoints; }
    }

    public static float standardBlockProbability
    {
        get { return ConfigurationData.standardBlockProbability; }
    }

    public static float bonusBlockProbability
    {
        get { return ConfigurationData.bonusBlockProbability; }
    }

    public static float pickupBlockProbability
    {
        get { return ConfigurationData.pickupBlockProbability; }
    }
    public static int ballsLeft
    {
        get { return ConfigurationData.ballsLeft; }

        set { ConfigurationUtils.ballsLeft = value; }
    }


    public static ConfigurationData configData;

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}
