using DocuWareEventManager.BLL.Enums;

namespace DocuWareEventManager.BLL.Models
{
    public class RegisterUserResponseDto
    {
        public int? UserId { get; set; }

        public RegisterUserResult Result { get; set; }
    }
}
