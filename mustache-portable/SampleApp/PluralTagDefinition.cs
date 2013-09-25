using Mustache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    public class PluralTagDefinition : ContentTagDefinition
    {
        public PluralTagDefinition()
            : base("plural")
        {
        }

        protected override bool GetIsContextSensitive()
        {
            return true;
        }

        protected override IEnumerable<string> GetClosingTags()
        {
            return new string[] { "pluralize" };
        }

        public override IEnumerable<TagParameter> GetChildContextParameters()
        {
            return new TagParameter[0];
        }
    }
}
