using SharprWowApi.Models.DataResources;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Battle groups information
	/// </summary>
	[DataContract]
    //[DoNotAuthenticate]
    public class BattleGroupsResponse
    {
        /// <summary>
        ///   Gets battle grops
        /// </summary>
        [DataMember(Name = "battlegroups")]
        public IList<Battlegroup> BattleGroups
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return BattleGroups.Count.ToString(CultureInfo.CurrentCulture) + " BattleGroups";
        }
    }
}