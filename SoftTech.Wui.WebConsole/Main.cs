using SoftTech.Wui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using System.Xml.Linq;
using MetaTech.Library;

namespace SoftTech.WebConsole
{
  public class Main
  {
    public static SoftTech.Wui.HtmlResult<HElement> HView(object _state, JsonData[] jsons, HContext context)
    {
      var state = _state.As<MainState>() ?? new MainState();

      foreach (var json in jsons.Else_Empty())
      {

        switch (json.JPath("data", "command").ToString_Fair())
        {
          case "text":
            state = state.With(text: json.JPath("value").ToString_Fair());
            System.Threading.Thread.Sleep(new Random().Next(0, 500));
            break;
          default:            
            break;
        }
      }
     

      var page = Page(state);
      return new SoftTech.Wui.HtmlResult<HElement>
      {
        Html = page,
        State = state,
      };
    }

   
    private static HElement Page(MainState state)
    {

      var page = h.Html
      (
        h.Head(          
          h.Element("title", "SoftTech.Wui.WebConsole")
        ),
        h.Body
        (
          h.Div
          (            
            h.Raw(string.Format("1<b>{0:dd.MM.yy.HH:mm:ss.fff}</b> 2", DateTime.Now))
          ),
          h.Input(h.type("text"), h.Attribute("onkeyup", ";"), new hdata{{"command", "text"}}),
          h.Div(state.Text),
          h.Div(h.A(h.href("multi.html"), "multi sync frames")),
          h.Div(h.A(h.href("auth-view.html"), "auth-view"))
          //h.Div(DateTime.UtcNow),
          //h.Input(h.type("button"), h.onclick(";"), h.value("update")),
          //h.Div(1, h.Attribute("js-init", "$(this).css('color', 'red')"))
        )
      );
      return page;
    }



    static readonly HBuilder h = null;

  }
  class MainState
  {
    public MainState(string text = null)
    {
      this.Text = text;
    }
    public readonly string Text;
    public MainState With(Option<string> text = null)
    {
      return new MainState(text: text.Else(Text));
    }
  }

}