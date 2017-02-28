using Newtonsoft.Json;

namespace BotOnBot.Backend.DataModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class RejectionResponseModel : NetworkResponseModel
    {
        public RejectionResponseModel()
        {
            ResponseStatus = ResponseStatusType.Reject.ToString();
        }

        [JsonProperty(PropertyName = "reason")]
        public string Reason;

        public override ISerializable Clone()
            => (ISerializable)MemberwiseClone();
    }
}
