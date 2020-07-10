using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    public static  float ballTimer;
    public static float minBallSpawnTime, maxBallSpawnTime;
    public static float blockPoints;
    public static float bonusBlockPoints;
    public static float pickupBlockPoints;
    public static float standardBlockProbability, bonusBlockProbability, pickupBlockProbability;
    public static int ballsLeft;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallTimer
    {
        get { return ballTimer; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader  streamReader = null;
        string[] values;
        try
        {
            streamReader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string line = streamReader.ReadLine();
            line = streamReader.ReadLine();
            values = line.Split(',');

            assignValues(values);
            
        }
        catch (Exception )
        {
            Debug.Log("Unable to open file");
        }
        finally
        {
            if (streamReader != null)
                streamReader.Close();
        }
        
    }


    void assignValues(string[]values)
    {
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce= float.Parse(values[1]);
        ballTimer = float.Parse(values[2]);
        minBallSpawnTime = float.Parse(values[3]);
        maxBallSpawnTime = float.Parse(values[4]);
        blockPoints = float.Parse(values[5]);
        bonusBlockPoints = float.Parse(values[6]);
        pickupBlockPoints = float.Parse(values[7]);
        standardBlockProbability = float.Parse(values[8]);
        bonusBlockProbability = float.Parse(values[9]);
        pickupBlockProbability = float.Parse(values[10]);
        ballsLeft = int.Parse(values[11]);



    }
    #endregion
}
