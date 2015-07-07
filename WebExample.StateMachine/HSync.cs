using System;
using System.Collections.Generic;
using System.Web;
using SoftTech.Wui;

namespace WebExample.StateMachine
{
  public class HSync : HWebSynchronizeHandler
  {
    public HSync()
      : base(new Dictionary<string, Func<object, JsonData[], HContext, HtmlResult<HElement>>> 
        { 
          { "default", Main.HView },
          { "index", Main.HView },
        })
    {
    }
  }
}
