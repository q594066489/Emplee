using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Emploee.Authorization.Users;

namespace Emploee.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}