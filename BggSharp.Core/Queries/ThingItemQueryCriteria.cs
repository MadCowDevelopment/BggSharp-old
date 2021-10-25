using System.Collections.Generic;
using System.Linq;

namespace BggSharp.Core.Queries
{
    public class ThingItemQueryCriteria : QueryCriteria
    {
        private readonly IReadOnlyCollection<string> _ids;

        public ThingItemQueryCriteria(IEnumerable<string> ids)
        {
            _ids = ids.ToList().AsReadOnly();
        }

        protected override string Command => "thing";

        /// <summary>
        /// Specifies that, regardless of the type of thing asked for by id, the results are filtered by the THINGTYPE(s)
        /// specified. Multiple THINGTYPEs can be specified in a comma-delimited list.
        /// </summary>
        public IReadOnlyCollection<ThingType> ThingTypes { get; set; }

        /// <summary>
        /// Returns version info for the item.
        /// </summary>
        public bool Versions { get; set; } = false;

        /// <summary>
        ///Returns videos for the item.
        /// </summary>
        public bool Videos { get; set; } = false;

        /// <summary>
        /// Returns ranking and rating stats for the item.
        /// </summary>
        public bool Stats { get; set; } = false;

        /// <summary>
        /// Returns marketplace data.
        /// </summary>
        public bool Marketplace { get; set; } = false;

        /// <summary>
        /// Returns all comments about the item. Also includes ratings when commented. See page parameter.
        /// </summary>
        public bool Comments { get; set; } = false;

        /// <summary>
        /// Returns all ratings for the item. Also includes comments when rated. See page parameter. The ratingcomments
        /// and comments parameters cannot be used together, as the output always appears in the comments node of the
        /// XML; comments parameter takes precedence if both are specified. Ratings are sorted in descending rating value,
        /// based on the highest rating they have assigned to that item (each item in the collection can have a different rating).
        /// </summary>
        public bool RatingComments { get; set; } = false;

        /// <summary>
        /// Defaults to 1, controls the page of data to see for historical info, comments, and ratings data.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Set the number of records to return in paging. Minimum is 10, maximum is 100.
        /// </summary>
        public int? PageSize { get; set; }

        protected override IEnumerable<(string, string)> GetParameters()
        {
            var parameters = new List<(string, string)>();
            parameters.Add(("id", string.Join(",", _ids)));
            if (ThingTypes?.Any() ?? false) parameters.Add(("type", string.Join(",", ThingTypes)));
            if (Versions) parameters.Add(("versions", "1"));
            if (Videos) parameters.Add(("videos", "1"));
            if (Stats) parameters.Add(("stats", "1"));
            if (Marketplace) parameters.Add(("marketplace", "1"));
            if (Comments) parameters.Add(("comments", "1"));
            if (RatingComments) parameters.Add(("ratingcomments", "1"));
            if (Page.HasValue) parameters.Add(("page", Page.Value.ToString()));
            if (PageSize.HasValue) parameters.Add(("pagesize", PageSize.Value.ToString()));
            return parameters;
        }
    }

    public enum ThingType
    {
        boardgame,
        boardgameexpansion,
        boardgameaccessory,
        videogame,
        rpgitem,
        rpgissue
    }
}