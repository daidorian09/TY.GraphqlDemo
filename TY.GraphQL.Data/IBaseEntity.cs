using System;

namespace TY.GraphQL.Data
{
    public interface IBaseEntity
    {
        Guid Id { get; }

        DateTime? CreatedAt { get; }

        DateTime? ModifiedAt { get; }

        bool IsDeleted { get; }
    }
}
