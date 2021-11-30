﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattEland.AI.Samples.MLNet
{
    public static class SampleGameDataSource
    {
        public static IEnumerable<GameRating> SampleGames
        {
            get
            {
                yield return new GameRating()
                {
                    Title = "Teen Side Scroller",
                    AlcoholReference = true,
                    CartoonViolence = true,
                    MildLanguage = true,
                    CrudeHumor = true,
                    Violence = true,
                    MildSuggestiveThemes = true
                };
                yield return new GameRating()
                {
                    Title = "Shoddy Surgeon Simulator",
                    BloodAndGore = true,
                    DrugReference = true,
                    PartialNudity = true,
                };
                yield return new GameRating()
                {
                    Title = "Assistant to the Lawn Service Manager 2022",
                    MildLanguage = true,
                    CrudeHumor = true,
                    AlcoholReference = true,
                };
                yield return new GameRating()
                {
                    Title = "Kinda Sus",
                    MildCartoonViolence = true
                };
                yield return new GameRating()
                {
                    Title = "The Earthlings are Coming",
                    MildViolence = true,
                    MildFantasyViolence = true,                    
                };
                yield return new GameRating()
                {
                    Title = "Intense Shoot-o-rama: Why would anyone play this edition",
                    BloodAndGore = true,
                    DrugReference = true,
                    AlcoholReference = true,
                    PartialNudity = true,
                    StrongLanguage = true,
                    SexualContent = true,
                    SexualThemes = true,
                    MatureHumor = true,
                    Lyrics = true,
                    IntenseViolence = true,
                    CrudeHumor = true,
                    Blood = true,
                };
            }
        }
    }
}
