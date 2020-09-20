using tyr.Core.Events;

namespace tyr.Core.tests.EventTypes
{
    public class GlobalEventInfo : EventInfoBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:GlobalEventInfo" /> class.
        /// </summary>
        public GlobalEventInfo()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:GlobalEventInfo" /> class.
        /// </summary>
        /// <param name="myData">My data.</param>
        public GlobalEventInfo(object myData)
            : this()
        {
            Data = myData;
        }

        /// <summary>
        ///     Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public object Data { get; set; }
    }
}