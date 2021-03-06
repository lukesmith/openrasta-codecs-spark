using System;
using System.Collections.Generic;
using System.Linq;
using OpenRasta.Codecs.Spark2.Matchers;
using OpenRasta.Codecs.Spark2.Model;

namespace OpenRasta.Codecs.Spark2.Specification
{
	public class ElementTransformerSpecification : IElementTransformerSpecification
	{
		private readonly IEnumerable<ElementTransformerActionsByMatch> _elementTransformerActionsByMatchs;

		public ElementTransformerSpecification(IEnumerable<ElementTransformerActionsByMatch> elementTransformerActionsByMatchs)
		{
			_elementTransformerActionsByMatchs = elementTransformerActionsByMatchs;
		}

		public IEnumerable<IElementTransformerAction> GetActionsForTag(Tag tag)
		{
			var allMatches =
				_elementTransformerActionsByMatchs.Where(x => x.Tags.MatchesAtLeastOne(tag)).ToArray();

			return GetActions(allMatches).Union(GetFinalActions(allMatches));
		}

		private IEnumerable<IElementTransformerAction> GetFinalActions(ElementTransformerActionsByMatch[] matches)
		{
			return matches.SelectMany(x => x.FinalElementTransformerActions);
		}

		private IEnumerable<IElementTransformerAction> GetActions(ElementTransformerActionsByMatch[] allMatches)
		{
			return allMatches.SelectMany(x => x.ElementTransformerActions);
		}

		public IEnumerable<IElementTransformerAction> GetActionsForElement(IElement element)
		{
			throw new Exception("Use the other one");
		}

		public IEnumerable<ElementTransformerActionsByMatch> GetElementTransformerActionsByMatch()
		{
			return _elementTransformerActionsByMatchs.ToArray();
		}
	}
}