using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class BigML
    {
        public string city { get; set; }
        public string season { get; set; }
        public double? feelslike { get; set; }
        public double? humidity { get; set; }
        public string weekday { get; set; }

        /**
        *  Predictor for icecream from model/617855ace4279b24a10271fa
        *  Predictive model by BigML - Machine Learning Made Easy
*/
        public class Icecream
        {
            public static string PredictIcecream(string city, string season, double? feelslike, double? humidity, string weekday)
            {
                if (feelslike == null)
                {
                    return "Coffee";
                }
                if (feelslike > 19)
                {
                    if (weekday == null)
                    {
                        return "Coffee";
                    }
                    if (weekday.Equals("Friday"))
                    {
                        return "Lotus cookies";
                    }
                    if (!weekday.Equals("Friday"))
                    {
                        if (city == null)
                        {
                            return "Coffee";
                        }
                        if (city.Equals("ירושלים"))
                        {
                            if (humidity == null)
                            {
                                return "Coffee";
                            }
                            if (humidity > 21)
                            {
                                if (weekday.Equals("Wednesday"))
                                {
                                    return "Colourful";
                                }
                                if (!weekday.Equals("Wednesday"))
                                {
                                    if (weekday.Equals("Thursday"))
                                    {
                                        if (feelslike > 23.5)
                                        {
                                            return "Colourful";
                                        }
                                        if (feelslike <= 23.5)
                                        {
                                            return "Coffee";
                                        }
                                    }
                                    if (!weekday.Equals("Thursday"))
                                    {
                                        return "Coffee";
                                    }
                                }
                            }
                            if (humidity <= 21)
                            {
                                return "Coconut";
                            }
                        }
                        if (!city.Equals("ירושלים"))
                        {
                            if (humidity == null)
                            {
                                return "Oreo";
                            }
                            if (humidity > 86)
                            {
                                if (weekday.Equals("Tuesday"))
                                {
                                    if (feelslike > 31.5)
                                    {
                                        return "Strawberry";
                                    }
                                    if (feelslike <= 31.5)
                                    {
                                        return "Passionflower";
                                    }
                                }
                                if (!weekday.Equals("Tuesday"))
                                {
                                    return "Berries";
                                }
                            }
                            if (humidity <= 86)
                            {
                                if (feelslike > 33)
                                {
                                    if (weekday.Equals("Sunday"))
                                    {
                                        return "Coffee";
                                    }
                                    if (!weekday.Equals("Sunday"))
                                    {
                                        if (feelslike > 55)
                                        {
                                            return "Oreo";
                                        }
                                        if (feelslike <= 55)
                                        {
                                            if (feelslike > 45)
                                            {
                                                return "Marshmallow";
                                            }
                                            if (feelslike <= 45)
                                            {
                                                if (feelslike > 37.5)
                                                {
                                                    return "Mango";
                                                }
                                                if (feelslike <= 37.5)
                                                {
                                                    return "Marshmallow";
                                                }
                                            }
                                        }
                                    }
                                }
                                if (feelslike <= 33)
                                {
                                    if (city.Equals("בני ברק"))
                                    {
                                        if (feelslike > 27.5)
                                        {
                                            if (feelslike > 29.5)
                                            {
                                                return "Peanuts";
                                            }
                                            if (feelslike <= 29.5)
                                            {
                                                return "Lotus cookies";
                                            }
                                        }
                                        if (feelslike <= 27.5)
                                        {
                                            if (humidity > 53)
                                            {
                                                return "Mango";
                                            }
                                            if (humidity <= 53)
                                            {
                                                if (feelslike > 24.75)
                                                {
                                                    return "Coffee";
                                                }
                                                if (feelslike <= 24.75)
                                                {
                                                    return "Coconut";
                                                }
                                            }
                                        }
                                    }
                                    if (!city.Equals("בני ברק"))
                                    {
                                        if (city.Equals("פתח תקווה"))
                                        {
                                            return "Oreo";
                                        }
                                        if (!city.Equals("פתח תקווה"))
                                        {
                                            if (season == null)
                                            {
                                                return "Strawberry";
                                            }
                                            if (season.Equals("Spring"))
                                            {
                                                if (humidity > 21)
                                                {
                                                    return "Strawberry";
                                                }
                                                if (humidity <= 21)
                                                {
                                                    return "Coconut";
                                                }
                                            }
                                            if (!season.Equals("Spring"))
                                            {
                                                if (weekday.Equals("Thursday"))
                                                {
                                                    return "Strawberry";
                                                }
                                                if (!weekday.Equals("Thursday"))
                                                {
                                                    if (humidity > 35)
                                                    {
                                                        if (weekday.Equals("Wednesday"))
                                                        {
                                                            return "Coffee";
                                                        }
                                                        if (!weekday.Equals("Wednesday"))
                                                        {
                                                            return "Oreo";
                                                        }
                                                    }
                                                    if (humidity <= 35)
                                                    {
                                                        return "Coffee";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (feelslike <= 19)
                {
                    return "Seasonal fruit";
                }
                return null;
            }
        }
    }
}
