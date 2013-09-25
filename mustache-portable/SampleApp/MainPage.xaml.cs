using Mustache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            FormatCompiler compiler = new FormatCompiler();
            compiler.RegisterTag(new PluralizeTagDefinition(), true);
            compiler.RegisterTag(new PluralTagDefinition(), false);
            Generator generator = compiler.Compile("Hello {{Title}}, {{Count}} notificat{{#pluralize Count}}ion{{#plural}}ions{{/pluralize}}!!! ");
            string result = generator.Render(new SampleData() { Title = "test user 42", Count = 1 });
            result += generator.Render(new SampleData() { Title = "test user", Count = 41 });


            txt.Text = result;
        }

        public class SampleData
        {
            public string Title { get; set; }

            public int Count { get; set; }
        }
    }
}
