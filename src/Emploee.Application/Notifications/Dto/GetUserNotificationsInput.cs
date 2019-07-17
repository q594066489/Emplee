using Abp.Notifications;
using Emploee.Dto;

namespace Emploee.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}