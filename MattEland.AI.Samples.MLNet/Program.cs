﻿using MattEland.AI.Samples.MLNet;
using Microsoft.ML;
using Microsoft.ML.AutoML;

MLContext mlContext = new MLContext();

// BloodInGamesModelTrainer trainer = new BloodInGamesModelTrainer("ESRB.csv");

IDataView trainDataView = mlContext.Data.LoadFromTextFile<GameRating>("ESRB.csv", hasHeader: true, separatorChar: ',');

const int MAX_MINUTES = 60;

var experimentSettings = new BinaryExperimentSettings()
{
    MaxExperimentTimeInSeconds = MAX_MINUTES * 60,
    OptimizingMetric = BinaryClassificationMetric.PositiveRecall,
    CacheDirectoryName = null, // Run in memory
};

var experiment = mlContext.Auto().CreateBinaryClassificationExperiment(experimentSettings);
var result = experiment.Execute(trainDataView, 
    labelColumnName: "Blood", 
    samplingKeyColumn: null,
    progressHandler: new BinaryExperimentProgressHandler());

var bestRun = result.BestRun;

Console.WriteLine($"Best Run: {bestRun.TrainerName} ({bestRun.RuntimeInSeconds} seconds)");
ModelMetricsHelper.LogClassificationMetrics(bestRun.ValidationMetrics);

try
{
    mlContext.Model.Save(bestRun.Model, trainDataView.Schema, Path.Combine(Environment.CurrentDirectory, "Model.zip"));
    Console.WriteLine("Model Saved");
}
catch (IOException ex)
{
    Console.WriteLine($"Could not save model: {ex.Message}");
}

var engine = mlContext.Model.CreatePredictionEngine<GameRating, BloodPrediction>(bestRun.Model);

foreach (GameRating sampleGame in SampleGameDataSource.SampleGames)
{
    var prediction = engine.Predict(sampleGame);

    Console.WriteLine($"Predicting {prediction.Blood} for {sampleGame.Title} with a score of {prediction.Score}");
}