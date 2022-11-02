using System;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Foundation;
using Windows.Web.Syndication;




var uri = new Uri("https://blogs.windows.com/feed");
var client = new SyndicationClient();
var feed = await client.RetrieveFeedAsync(uri);

//Just to keep it similar to my bad rust impl
List<string> titles = new List<string>();
foreach (var item in feed.Items)
{
    var heading = item.Title.Text;
    Console.WriteLine(heading);
    titles.Add(heading);
}

var feedtext = string.Join("\n", titles);
feedtext += "\0";


//not necessary, done in the generated files!
// unsafe
// {
//     fixed (char* lptext = feedtext)
//     {
//         PInvoke.MessageBox(default(HWND), lptext, "RSS_News", MESSAGEBOX_STYLE.MB_OK);
//     }
// }

var lptext = feedtext;

PInvoke.MessageBox(default(HWND), lptext, "RSS_News", MESSAGEBOX_STYLE.MB_OK);
