using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Emploee.Friendships.Dto
{
    public class CreateFriendshipRequestInput
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        public int? TenantId { get; set; }
    }
}