﻿using System;
using System.Collections.Generic;
using System.Web;
using SoftTech.Wui;

namespace SoftTech.WebConsole
{
  public class HSync : HWebSynchronizeHandler
  {
    public HSync()
      : base(new Dictionary<string, Func<object, JsonData[], HContext, HtmlResult<HElement>>> 
        { 
          { "default", Main.HView }, 
          {"part1", Part1.HView}, 
          {"part2", Part2.HView},
          {"auth-view", AuthView.HView},
        })
    {
    }
  }
}
