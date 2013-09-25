using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mustache;
using System.IO;

namespace SampleApp
{
    public class PluralizeTagDefinition : ContentTagDefinition
    {
        public PluralizeTagDefinition()
            : base("pluralize")
        {
        }

        protected override IEnumerable<TagParameter> GetParameters()
        {
            return new TagParameter[] { new TagParameter("value") };
        }
        protected override IEnumerable<string> GetChildTags()
        {
            return new string[] { "plural" };
        }

        protected override IEnumerable<string> GetClosingTags()
        {
            return new string[] { "pluralize" };
        }

        public override bool ShouldCreateSecondaryGroup(TagDefinition definition)
        {
            return new string[] { "plural"}.Contains(definition.Name);
        }

        public override bool ShouldGeneratePrimaryGroup(Dictionary<string, object> arguments)
        {
           var dVal = Convert.ToDouble(arguments["value"]);
           return (!(Math.Abs(dVal) > 1));
        }
        public override IEnumerable<TagParameter> GetChildContextParameters()
        {
            return new TagParameter[0];
        }
        protected override bool GetIsContextSensitive()
        {
            return false;
        }
    }
}
