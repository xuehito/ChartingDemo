using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dotnetCHARTING;

namespace ChartingDemo
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Type = ChartType.Combo;//Horizontal;
            Chart1.Width = 600;
            Chart1.Height = 350;
            //Chart1.TempDirectory = "temp";
            Chart1.TempDirectory = "images";
            Chart1.Debug = true;
            Chart1.Title = "Hotspots";


            // This sample demonstrates how to use hotspots.

            //Chart1.DefaultElement.Hotspot.Attributes.OnMouseOver.StatusBarMessage = "%Name: %Value";
            //Chart1.DefaultElement.Hotspot.Attributes.Custom.Add("OnClick", "alert('%Name Clicked')");
            //Chart1.DefaultElement.Hotspot.ToolTip = "%Name: %Value";


            // *DYNAMIC DATA NOTE*
            // This sample uses random data to populate the chart. To populate
            // a chart with database data see the following resources:
            // - Classic samples folder
            // - Help File > Data Tutorials
            // - Sample: features/DataEngine.aspx
            SeriesCollection mySC = getRandomData();

            // Add the random data.
            Chart1.SeriesCollection.Add(mySC);
        }

        SeriesCollection getRandomData()
        {
            SeriesCollection SC = new SeriesCollection();
            Random myR = new Random(1);
            for (int a = 0; a < 4; a++)
            {
                Series s = new Series();
                s.Name = "Series " + (a + 1);
                for (int b = 0; b < 4; b++)
                {
                    Element e = new Element();
                    e.Name = "Element " + (b + 1);
                    e.YValue = myR.Next(50);
                    s.Elements.Add(e);
                }
                SC.Add(s);
            }

            // Set Different Colors for our Series
            SC[0].DefaultElement.Color = Color.FromArgb(49, 255, 49);
            SC[1].DefaultElement.Color = Color.FromArgb(255, 255, 0);
            SC[2].DefaultElement.Color = Color.FromArgb(255, 99, 49);
            SC[3].DefaultElement.Color = Color.FromArgb(0, 156, 255);

            return SC;
        }
    }


}