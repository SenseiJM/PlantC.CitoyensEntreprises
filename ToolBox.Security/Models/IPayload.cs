using System.Collections.Generic;

namespace ToolBox.Security.Models
{
    public interface IPayload
    {
        string Identifier { get; }
        string Email { get; }
        IEnumerable<string> Roles { get; }
    }
}
