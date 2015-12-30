using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamleaderDotNet.Common
{
    public interface ITeamleaderClient
    {
        Task<string> DoCall(string endPoint, List<KeyValuePair<string, string>> fields);

        string ApiGroup { get; }
        string ApiSecret { get; }
    }
}