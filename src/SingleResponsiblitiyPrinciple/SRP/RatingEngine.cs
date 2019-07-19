﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace SingleResponsiblitiyPrinciple.SRP
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            var policyJson = FilePolicySource.GetPolicyFromSource();

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto:

                    Logger.Log("Rating AUTO policy...");

                    Logger.Log("Validating policy.");

                    if (string.IsNullOrEmpty(policy.Make))
                    {
                        Logger.Log("Auto policy must specify Make");
                        return;
                    }

                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }

                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:

                    Logger.Log("Rating LAND policy...");

                    Logger.Log("Validating policy.");

                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }

                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        Console.WriteLine("Insufficient bond amount.");
                        return;
                    }

                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:

                    Logger.Log("Rating LIFE policy...");

                    Logger.Log("Validating policy.");

                    if (policy.DateOfBirth == DateTime.MinValue)
                    {
                        Logger.Log("Life policy must include Date of Birth.");
                        return;
                    }

                    if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                    {
                        Logger.Log("Centenarians are not eligible for coverage.");
                        return;
                    }

                    if (policy.Amount == 0)
                    {
                        Logger.Log("Life policy must include an Amount.");
                        return;
                    }

                    var age = DateTime.Today.Year - policy.DateOfBirth.Year;

                    if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.Day ||
                        DateTime.Today.Month < policy.DateOfBirth.Month)
                    {
                        age--;
                    }

                    decimal baseRate = policy.Amount * age / 200;

                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }

                    Rating = baseRate;
                    break;

                default:

                    Logger.Log("Unknown policy type");
                    break;
            }

            Logger.Log("Rating completed.");
        }
    }
}
